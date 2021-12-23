using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyProduct.HttpClientExtensions
{
    /// <summary>
    /// A data model to hold a collection of request parameters.
    /// </summary>
    public sealed class HttpRequestParameterCollection
    {
        /// <summary>
        /// Model to hold a request parameters in key value pairs.
        /// </summary>
        public HttpRequestParameterCollection()
        {
            Items = new List<HttpRequestParameter>();
        }

        /// <summary>
        /// Gets list of request parameters.
        /// </summary>
        public IList<HttpRequestParameter> Items { get; }

        /// <summary>
        /// Adds an item to the parameter list.
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        public void Add(string key, string value)
        {
            Items.Add(new HttpRequestParameter()
            {
                Key = key,
                Value = value
            });
        }
    }

    /// <summary>
    /// Model to hold a request parameter in key value pair.
    /// </summary>
    public sealed class HttpRequestParameter
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
