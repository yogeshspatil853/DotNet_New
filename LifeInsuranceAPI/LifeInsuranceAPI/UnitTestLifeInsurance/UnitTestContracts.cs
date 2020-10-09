using LifeInsurance.Entities;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace UnitTestLifeInsurance
{
    public class UnitTestContracts
    {
        [Fact]
        public async Task Test_GetAll()
        {
            using (var client = new TestClientProvider().client)
            {
                var response = await client.GetAsync("api/Contract/GetAll?search=dev&sortCol=Id&sortDir=desc&skip=0&take=10");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }
        [Fact]
        public async Task Test_Post()
        {
            using (var client = new TestClientProvider().client)
            {
                var response = await client.PostAsync("api/Contract/Create", new StringContent(
                JsonConvert.SerializeObject(new ContractModel()
                {
                    CustomerName = "John",
                    CustomerAddress = "Test",
                    CustomerCountry = "India",
                    CustomerGender = "M",
                    DateofBirth = Convert.ToDateTime("30-6-1990"),
                    SaleDate = DateTime.Now
                }),
            Encoding.UTF8,
            "application/json"));
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }
        [Fact]
        public async Task Test_Put()
        {

            using (var client = new TestClientProvider().client)
            {
                var response = await client.PutAsync("api/Contract/Update", new StringContent(
                JsonConvert.SerializeObject(new ContractModel()
                {
                    Id = 7,
                    CustomerName = "John",
                    CustomerAddress = "Bean",
                    CustomerCountry = "USA",
                    CustomerGender = "F",
                    DateofBirth = Convert.ToDateTime("30-6-1990"),
                    SaleDate = DateTime.Now
                }),
            Encoding.UTF8,
            "application/json"));
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }
        [Fact]
        public async Task Test_Delete()
        {
            using (var client = new TestClientProvider().client)
            {
                var response = await client.GetAsync("api/Contract/Delete?id=8");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }
    }
}