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

            var cvContent = JsonConvert.DeserializeObject<List<CVContent>>(data);

            Assert.IsTrue(cvContent.Count == 2, "has two cv records");

            foreach (var cv in cvContent)
            {
                Assert.IsNotNull(cv.Company, $"Company populated for ID {cv.ID}");

                Assert.IsTrue(cv.Company.Guid == "efbc5b84-004b-4ac2-b53d-40aedf128274", "Only company XYZ records");

                Assert.IsNotNull(cv.Company.Address, $"Address populated for company {cv.Company.Name}");
            }


        }
    }
}
