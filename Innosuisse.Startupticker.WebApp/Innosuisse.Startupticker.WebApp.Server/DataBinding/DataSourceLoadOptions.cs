using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Newtonsoft.Json;

namespace Innosuisse.Startupticker.WebApp.Server.DataBinding
{
    [ModelBinder(BinderType = typeof(DataSourceLoadOptionsBinder))]
    public class DataSourceLoadOptions : DataSourceLoadOptionsBase
    {
    }

    public class DataSourceLoadOptionsBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var loadOptions = new DataSourceLoadOptions();

            // Access the HttpRequest from the HttpContext
            var request = bindingContext.HttpContext.Request;
            // Read the request body
            using (var reader = new StreamReader(request.Body, Encoding.UTF8))
            {
                var requestBody = await reader.ReadToEndAsync();
                loadOptions = JsonConvert.DeserializeObject<DataSourceLoadOptions>(requestBody);
            }
            // Set the model to the ModelBindingContext
            bindingContext.Result = ModelBindingResult.Success(loadOptions);
        }
    }
}
