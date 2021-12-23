using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyProduct.HttpClientExtensions
{
    /// <summary>
    /// Extension class for HttpClient.
    /// </summary>
    public static class HttpClientExtensions
    {
        #region Fields

        const string mediaType = "application/json";

        #endregion Fields

        #region Extension Methods

        /// <summary>
        /// Triggers a Http Get call with query parameters and maps the response to client data model.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="httpClient"></param>
        /// <param name="url"></param>
        /// <param name="requestParameters"></param>
        /// <returns></returns>
        public static async Task<HttpClientResponse<TResponse>> GetAsync<TResponse>
            (this HttpClient httpClient,
            string url,
            HttpRequestParameterCollection requestParameters)
        {
            var queryString = BuildQueryString(requestParameters);
            var response = await httpClient.GetAsync($"{url}?{queryString}").ConfigureAwait(false);
            return await response.Map<TResponse>();
        }

        /// <summary>
        /// Posts request and maps the response into the client data model.
        /// </summary>
        /// <typeparam name="TRequestData"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <returns></returns>
        public static async Task<HttpClientResponse<TResponse>> PostAsync<TRequestData, TResponse>
        (this HttpClient httpClient,
        string url,
        TRequestData requestData,
        JsonSerializerSettings serializerSettings = null) where TRequestData : class, new()
        {
            var postData = JsonConvert.SerializeObject(requestData, serializerSettings);
            var stringContent = new StringContent(postData, Encoding.UTF8, mediaType);
            var httpResponse = await httpClient.PostAsync(url, stringContent).ConfigureAwait(false);
            return await httpResponse.Map<TResponse>();
        }


        #endregion Extension Methods

        #region Private Methods

        private static string BuildQueryString(HttpRequestParameterCollection requestParameters)
        {
            var queryStringBuilder = new StringBuilder();
            foreach (var parameter in requestParameters.Items)
            {
                if (queryStringBuilder.Length > 0)
                {
                    queryStringBuilder.Append("&");
                }
                queryStringBuilder.Append($"{parameter.Key}={parameter.Value}");
            }
            return queryStringBuilder.ToString();
        }

        #endregion Private Methods
    }
}
