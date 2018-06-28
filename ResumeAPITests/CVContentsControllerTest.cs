using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ResumeAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ResumeAPITests
{
    [TestClass]
    public class CVContentsControllerTest : ControllerTest
    {

        [TestMethod]
        public async Task TestGetCVData()
        {
            var response = await _client.GetAsync("/api/CVContents/efbc5b84-004b-4ac2-b53d-40aedf128274");

            Assert.IsTrue(response.IsSuccessStatusCode, "response success");

            var data = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"data returned: {data}");

            var cvContent = JsonConvert.DeserializeObject<CVContent>(data);


            Assert.IsNotNull(cvContent.Company, $"Company populated for ID {cvContent.ID}");

            Assert.IsTrue(cvContent.Company.Guid == "efbc5b84-004b-4ac2-b53d-40aedf128274", "Only company XYZ records");

            Assert.IsNotNull(cvContent.Company.Address, $"Address populated for company {cvContent.Company.Name}");



        }
    }
}
