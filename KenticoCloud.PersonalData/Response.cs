using System.Net;

namespace KenticoCloud.PersonalData
{
    /// <summary>
    /// Represents response from the API.
    /// </summary>
    /// <typeparam name="T">Type of content.</typeparam>
    public class Response<T> : Response
    {
        /// <summary>
        /// Data returned from the API.
        /// Contains null in case of error.
        /// </summary>
        public T Content { get; set; }
    }

    /// <summary>
    /// Represents response from the API.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Http status code of response.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Details about current error.
        /// Contains null when there is no error.
        /// </summary>
        public PersonalDataError Error { get; set; }
    }
}