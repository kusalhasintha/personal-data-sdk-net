using System;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using KenticoCloud.PersonalData.Models;

namespace KenticoCloud.PersonalData.Tests
{
    [TestFixture]
    public class PersonalDataClientTests
    {
        private readonly string PROJECT_ID_ENV_VAR = "PROJECT_ID";
        private readonly string PERSONAL_DATA_API_KEY_ENV_VAR = "PERSONAL_DATA_API_KEY";
        
        private readonly string EXISTING_EMAIL = "80b98683-b57f-44d4-b1cb-38b19a3cb577@email.test";
        private readonly string EXISTING_UID = "uvleinsupxsz8h7o";

        private readonly string NONEXISTING_EMAIL = "non@existing.test";
        private readonly string NONEXISTING_UID = "aa123451234eaaaa";

        private readonly PersonalDataClient _client;

        public PersonalDataClientTests()
        {
            var projectIdString = Environment.GetEnvironmentVariable(PROJECT_ID_ENV_VAR);
            var projectId = new Guid(projectIdString);
            var apiKey = Environment.GetEnvironmentVariable(PERSONAL_DATA_API_KEY_ENV_VAR);

            _client = new PersonalDataClient(apiKey, projectId);
        }


        [Test]
        public async Task GetByEmailAsync()
        {
            var response = await _client.GetByEmailAsync(EXISTING_EMAIL);
            AssertContactDataResponse(response);
        }


        [Test]
        public async Task GetByUidAsync()
        {
            var response = await _client.GetByUidAsync(EXISTING_UID);
            AssertContactDataResponse(response);
        }


        [Test]
        public void DeleteByUidAsync()
        {
            // Responses about the user creation might get to Engage after a delete signal. That's why we consider such request valid.
            Assert.DoesNotThrowAsync(() => _client.DeleteByUidAsync(NONEXISTING_UID));
        }


        [Test]
        public void DeleteByEmailAsync()
        {
            // Email does not exists so we can't determine what users we should delete.
            var exception = Assert.ThrowsAsync<PersonalDataException>(async () => await _client.DeleteByEmailAsync(NONEXISTING_EMAIL));

            Assert.AreEqual(HttpStatusCode.NotFound, exception.StatusCode);
            Assert.AreEqual("Requested email was not found", exception.Description);
        }


        private void AssertContactDataResponse(ContactDataResponse contactDataResponse)
        {
            Assert.NotNull(contactDataResponse);

            Assert.NotNull(contactDataResponse.ContactData);
            Assert.IsNotEmpty(contactDataResponse.ContactData);
            Assert.AreEqual(EXISTING_EMAIL, contactDataResponse.ContactData[0].Email);
            Assert.NotNull(contactDataResponse.ContactData[0].SessionRecords);
            Assert.IsNotEmpty(contactDataResponse.ContactData[0].SessionRecords);

            Assert.NotNull(contactDataResponse.TrackedIds);
            Assert.IsNotEmpty(contactDataResponse.TrackedIds);
            Assert.AreEqual(EXISTING_UID, contactDataResponse.TrackedIds[0]);
        }
    }
}
