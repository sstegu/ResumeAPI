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
    public class CandidatesControllerTest : ControllerTest
    {


        [TestMethod]
        public async Task TestGetCandidateData()
        {
            var response = await _client.GetAsync("/api/Candidates/1");

            Assert.IsTrue(response.IsSuccessStatusCode, "response success");

            var data = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"data returned: {data}");

            var candidate = JsonConvert.DeserializeObject<Candidate>(data);

            Assert.IsNotNull(candidate);

            Assert.IsTrue(candidate.WorkHistory[0].Projects.Count == 5, "candidate has 5 projects");
        }
    }
}
