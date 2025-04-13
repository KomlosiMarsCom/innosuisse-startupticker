using Azure.AI.OpenAI;
using Azure;
using OpenAI.Chat;

namespace Innosuisse.Startupticker.WebApp.Server.Services
{
    public class OpenAIService
    {
        private const string _apikey = "<<apikey>>";
        private static readonly Dictionary<string, List<ChatMessage>> _conversationHistory = new();

        public OpenAIService(IConfiguration config)
        { }

        /// <summary>
        /// Generates an embedding vector for the given input text using Azure OpenAI.
        /// </summary>
        /// <param name="input">The input text to generate embeddings for.</param>
        /// <returns>A list of floats representing the embedding vector.</returns>
        public async Task<float[]> GetEmbeddingAsync(string input)
        {
            var endpoint = new Uri("https://swisshackstest.openai.azure.com/");
            var deploymentName = "text-embedding-ada-002";

            AzureOpenAIClient azureClient = new(
                endpoint,
                new AzureKeyCredential(_apikey));
            var embeddingClient = azureClient.GetEmbeddingClient(deploymentName);

            var messages = new List<string> { input };
            var response = await embeddingClient.GenerateEmbeddingsAsync(messages);
            var embedding = response.Value.ToList()[0];
            return embedding.ToFloats().ToArray();
        }

        /// <summary>
        /// Extracts relevant tags from the given input text using Azure OpenAI's chat capabilities.
        /// </summary>
        /// <param name="input">The input text to extract tags from.</param>
        /// <returns>An array of strings representing the extracted tags.</returns>
        public async Task<string> GenerateChatResponseAsync(string sessionId, string systemPrompt, string input, bool useHistory)
        {
            var chatHistory = new List<ChatMessage>();
            if (useHistory) 
            {
                if (!_conversationHistory.TryGetValue(sessionId, out chatHistory))
                {
                    chatHistory = new List<ChatMessage>();
                }
            }

            var chatMessages = new List<ChatMessage>();
            var systemMsg = ChatMessage.CreateSystemMessage(systemPrompt);
            var userMsg = ChatMessage.CreateUserMessage(input);
            chatMessages.Add(systemMsg);
            chatMessages.AddRange(chatHistory);
            chatMessages.Add(userMsg);

            var endpoint = new Uri("https://swisshackstest.openai.azure.com/");
            var deploymentName = "gpt-35-turbo";

            AzureOpenAIClient azureClient = new(
                endpoint,
                new AzureKeyCredential(_apikey));
            ChatClient chatClient = azureClient.GetChatClient(deploymentName);

            var requestOptions = new ChatCompletionOptions()
            { };

            var response = await chatClient.CompleteChatAsync(chatMessages, requestOptions);

            var chatCompletion = response.Value;
            var content = chatCompletion.Content;
            var strContent = content[0].Text;
            
            if (useHistory) 
            {
                chatMessages.Add(ChatMessage.CreateAssistantMessage(strContent));
                _conversationHistory[sessionId] = chatMessages.Skip(1).ToList();
            }

            return strContent;
        }
    } 
}
