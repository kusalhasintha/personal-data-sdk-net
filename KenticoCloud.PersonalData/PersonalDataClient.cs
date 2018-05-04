using KenticoCloud.PersonalData.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace KenticoCloud.PersonalData
{
    /// <summary>
    /// Class for querying Kentico Cloud Personal Data API.
    /// </summary>
    public class PersonalDataClient
    {
        private readonly HttpClient _httpClient;

        private readonly string _personalDataRoutePrefix;

        /// <summary>
        /// Client constructor for production API.
        /// </summary>
        /// <param name="accessToken">Your personalization API key. It can be found on Kentico Cloud Developer page.</param>
        /// <param name="projectId">Your project identifier.</param>
        public PersonalDataClient(string accessToken, Guid projectId)
            : this("https://personal-data-api.kenticocloud.com", accessToken, projectId)
        {
        }


        /// <summary>
        /// Client constructor.
        /// </summary>
        /// <param name="endpointUri">Root url of API endpoint.</param>
        /// <param name="accessToken">Your personalization API key. It can be found on Kentico Cloud Developer page.</param>
        /// <param name="projectId">Your project identifier.</param>
        public PersonalDataClient(string endpointUri, string accessToken, Guid projectId)
        {
            _personalDataRoutePrefix = $"v1/visitor/{projectId}";

            _httpClient = new HttpClient { BaseAddress = new Uri(endpointUri) };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
        }


        /// <summary>
        /// Gets all information about the visitor (specified by <paramref name="uid"/>) stored in Kentico Cloud.
        /// </summary>
        /// <param name="uid">User ID.</param>
        public async Task<ContactDataResponse> GetVisitorDataByUidAsync(string uid)
        {
            if (string.IsNullOrEmpty(uid))
            {
                throw new ArgumentException("Uid must be set.", nameof(uid));
            }
            using (var response = await _httpClient.GetAsync($"{_personalDataRoutePrefix}/uid/{uid}"))
            {
                return await DeserializeContent<ContactDataResponse>(response);
            }
        }


        /// <summary>
        ///Gets all information about the visitor (specified by <paramref name="email"/>) stored in Kentico Cloud.
        /// </summary>
        /// <param name="email">User email.</param>
        public async Task<ContactDataResponse> GetVisitorDataByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Email must be set.", nameof(email));
            }
            using (var response = await _httpClient.GetAsync($"{_personalDataRoutePrefix}/email/{email}"))
            {
                return await DeserializeContent<ContactDataResponse>(response);
            }
        }


        private async Task<T> DeserializeContent<T>(HttpResponseMessage response)
        {
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(responseBody);
            }

            throw new PersonalDataException(response.StatusCode, responseBody);
        }
    }
}
