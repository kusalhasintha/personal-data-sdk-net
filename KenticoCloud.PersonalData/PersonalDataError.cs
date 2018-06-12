using System;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KenticoCloud.PersonalData
{
    /// <summary>
    /// Represents an error response from the API.
    /// </summary>
    public class PersonalDataError
    {
        /// <summary>
        /// Detailed message from the API.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Description of error from the API.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Error Code.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Id of the error from the API.
        /// </summary>
        public string ErrorId { get; }

        /// <summary>
        /// Initializes exception.
        /// </summary>
        /// <param name="statusCode">Status code of response.</param>
        /// <param name="message">Exception message.</param>
        public PersonalDataError(string message)
        {
            try
            {
                var errorMessage = JObject.Parse(message);
                Message = errorMessage["message"]?.ToString() ?? message;
                Description = errorMessage["description"]?.ToString();
                Code = errorMessage["code"]?.ToString();
                ErrorId = errorMessage["error_id"]?.ToString();
            }
            catch (JsonReaderException)
            {
                Message = message;
            }
        }
    }
}