using Azure.AI.OpenAI;
using Azure;
using OpenAI.Chat;

namespace Innosuisse.Startupticker.WebApp.Server.Services
{
    public class OpenAIService
    {
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
            var apiKey = "<<apikey>>";

            AzureOpenAIClient azureClient = new(
                endpoint,
                new AzureKeyCredential(apiKey));
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
        public async Task<string> GenerateChatResponseAsync(string systemPrompt, string input)
        {

            //var systemPrompt = "Extract 3 to 5 relevant tags from this company profile.";
            //var systemPrompt = "Extract 3 to 5 relevant tags from this company. You get name of the Swiss company on market as input. Try to get the tags.";
            //var systemPrompt = "Extract industry of company based on description and categories. You get name of the Swiss company on market as input. Try to get the tags.";


            //input = "Zattoo is one of the leading TV streaming providers in Europe with several million users per month, serving both B2B and DTC markets. | Broadcasting,Internet,Media and Entertainment,TV,Video,Video Streaming";
            //input = "Scrimber CSC AG";

            var chatMessages = new List<ChatMessage>
            {
                ChatMessage.CreateSystemMessage(systemPrompt),
                ChatMessage.CreateUserMessage(input)
            };

            var endpoint = new Uri("https://swisshackstest.openai.azure.com/");
            var deploymentName = "gpt-35-turbo";
            var apiKey = "<<apikey>>";

            AzureOpenAIClient azureClient = new(
                endpoint,
                new AzureKeyCredential(apiKey));
            ChatClient chatClient = azureClient.GetChatClient(deploymentName);

            var requestOptions = new ChatCompletionOptions()
            { };

            var response = await chatClient.CompleteChatAsync(chatMessages, requestOptions);

            var chatCompletion = response.Value;
            var content = chatCompletion.Content;
            var strContent = content[0].Text;
            return strContent;

            // Split the tags by commas and clean up whitespace
            //return strContent.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        }
    } 
}
