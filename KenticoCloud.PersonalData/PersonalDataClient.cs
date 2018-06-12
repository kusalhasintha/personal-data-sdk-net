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

        private string GetUidRoute(string uid) => $"{_personalDataRoutePrefix}/uid/{uid}";
        private string GetEmailRoute(string email) => $"{_personalDataRoutePrefix}/email/{email}";


        /// <summary>
        /// Client constructor for the production API.
        /// </summary>
        /// <param name="accessToken">Your Personal Data API key. It can be found on Kentico Cloud API Keys page.</param>
        /// <param name="projectId">Your project identifier.</param>
        public PersonalDataClient(string accessToken, Guid projectId)
            : this("https://personal-data-api.kenticocloud.com", accessToken, projectId)
        {
        }


        /// <summary>
        /// Client constructor.
        /// </summary>
        /// <param name="endpointUri">Root url of API endpoint.</param>
        /// <param name="accessToken">Your Personal Data API key. It can be found on Kentico Cloud API Keys page.</param>
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
        /// Gets all information about a visitor (specified by <paramref name="uid"/>) stored in Kentico Cloud.
        /// </summary>
        /// <param name="uid">User ID.</param>
        /// <throws><see cref="ArgumentException"/>If <paramref name="uid"/> is <c>null</c></throws>
        public async Task<Response<string>> GetByUidAsync(string uid)
        {
            if (string.IsNullOrEmpty(uid))
            {
                throw new ArgumentException("Uid must be set.", nameof(uid));
            }
            using (var response = await _httpClient.GetAsync(GetUidRoute(uid)))
            {
                return await GetResponse(response);
            }
        }


        /// <summary>
        /// Gets all information about a visitor (specified by <paramref name="email"/>) stored in Kentico Cloud.
        /// </summary>
        /// <param name="email">User email.</param>
        /// <throws><see cref="ArgumentException"/>If <paramref name="email"/> is <c>null</c></throws>
        public async Task<Response<string>> GetByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Email must be set.", nameof(email));
            }
            using (var response = await _httpClient.GetAsync(GetEmailRoute(email)))
            {
                return await GetResponse(response);
            }
        }


        /// <summary>
        /// Deletes all personal data stored in Kentico Cloud belonging to a visitor with the specified <paramref name="uid"/>.
        /// </summary>
        /// <param name="uid">User ID.</param>
        /// <throws><see cref="ArgumentException"/>If <paramref name="uid"/> is <c>null</c></throws>
        public async Task<Response> DeleteByUidAsync(string uid)
        {
            if (string.IsNullOrEmpty(uid))
            {
                throw new ArgumentException("Uid must be set.", nameof(uid));
            }
            using (var response = await _httpClient.DeleteAsync(GetUidRoute(uid)))
            {
                return await GetResponse(response);
            }
        }


        /// <summary>
        /// Deletes all personal data stored in Kentico Cloud belonging to a visitor with the specified <paramref name="email"/>.
        /// </summary>
        /// <param name="email">User email.</param>
        /// <throws><see cref="ArgumentException"/>If <paramref name="email"/> is <c>null</c></throws>
        public async Task<Response> DeleteByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Email must be set.", nameof(email));
            }
            using (var response = await _httpClient.DeleteAsync(GetEmailRoute(email)))
            {
                return await GetResponseWithoutContent(response);
            }
        }

        private static async Task<Response> GetResponseWithoutContent(HttpResponseMessage response)
        {
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return new Response()
                {
                    StatusCode = response.StatusCode,
                    Error = new PersonalDataError(responseBody),
                };
            }

            return new Response()
            {
                StatusCode = response.StatusCode,
            };
        }

        private static async Task<Response<string>> GetResponse(HttpResponseMessage response)
        {
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return new Response<string>()
                {
                    StatusCode = response.StatusCode,
                    Error = new PersonalDataError(responseBody),
                };
            }

            return new Response<string>()
            {
                StatusCode = response.StatusCode,
                Content = responseBody,
            };
        }
    }
}