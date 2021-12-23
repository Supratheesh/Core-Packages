using System.Net;

namespace MyProduct.HttpClientExtensions
{
    /// <summary>
    /// Generic Response model for all the HttpClient requests.
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public class HttpClientResponse<TResponse>
    {
        /// <summary>
        /// Response object for the request.
        /// </summary>
        public TResponse Response { get; set; }


        /// <summary>
        /// Code indicating the request status.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
    }
}