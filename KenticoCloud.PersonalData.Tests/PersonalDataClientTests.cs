using System;
using System.Threading.Tasks;
using KenticoCloud.PersonalData.Models;
using NUnit.Framework;

namespace KenticoCloud.PersonalData.Tests
{
    [TestFixture]
    public class PersonalDataClientTests
    {
        private readonly string EXISTING_EMAIL = "kroberts2y@godaddy.com";
        private readonly string EXISTING_UID = "aad50bb1223e4199";

        private readonly PersonalDataClient _client;

        public PersonalDataClientTests()
        {
            var projectId = new Guid("e151a1b5-d69c-0086-cdbd-f453989c537a");
            var apiKey = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiI3MDE1MmMyZTE3NGU0NmQ3YTc3ZTk1ODNkN2I0MDgwYiIsImlhdCI6IjE1MjU5NTM4MzciLCJleHAiOiIxODcxNTUzODM3IiwicHJvamVjdF9pZCI6ImUxNTFhMWI1ZDY5YzAwODZjZGJkZjQ1Mzk4OWM1MzdhIiwidmVyIjoiMS4wLjAiLCJhdWQiOiJwZXJzb25hbC1kYXRhLWFwaS5rZW50aWNvY2xvdWQuY29tIn0.C56WXShLrlF--dZMzJeCFZvA8xOdta6DMYot2ikDMF4";
            _client = new PersonalDataClient("https://engage-personal-data-api-develop.azurewebsites.net/", apiKey, projectId);
        }

        [Test]
        public async Task GetByEmailAsync()
        {
            var contactDataResponse = await _client.GetByEmailAsync(EXISTING_EMAIL);
            AssertData(contactDataResponse);
        }

        [Test]
        public async Task GetByUidAsync()
        {
            var contactDataResponse = await _client.GetByUidAsync(EXISTING_UID);
            AssertData(contactDataResponse);
        }

        private void AssertData(ContactDataResponse contactDataResponse)
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
