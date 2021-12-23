using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyProduct.HttpClientExtensions
{
    public static class HttpResponseMessageExtensions
    {

        public static async Task<HttpClientResponse<TDataModel>> Map<TDataModel>(this HttpResponseMessage response)
        {

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new HttpClientResponse<TDataModel>()
                {
                    Response = default,
                    StatusCode = response.StatusCode
                };
            }

            var content = await response?.Content?.ReadAsStreamAsync();

            using var streamReader = new StreamReader(content);
            using var jsonTextReader = new JsonTextReader(streamReader);
            var dataModel = new JsonSerializer().Deserialize<TDataModel>(jsonTextReader);

            return new HttpClientResponse<TDataModel>()
            {
                Response = dataModel,
                StatusCode = response.StatusCode
            };

        }
    }
}
