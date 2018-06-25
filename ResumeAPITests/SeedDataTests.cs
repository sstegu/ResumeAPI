using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ResumeAPI.ExtensionMethods;
using ResumeAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ResumeAPITests
{
    [TestClass]
    public class SeedDataTests
    {
        [TestMethod]
        public async Task TestSeedData()
        {


            var builder = new Mock<IApplicationBuilder>();
            var fileProvider = new Mock<IFileProvider>();
            //var stream = new Mock<Stream>();

            var options = new DbContextOptionsBuilder<DataContext>()
               .UseInMemoryDatabase(databaseName: "cvdb_unit")
               .Options;

            //using this queue to mock multiple calls for a file stream
            var queue = new Queue<Func<Stream>>(new Func<Stream>[]
            {
                GetJSON,
                GetContent,
                GetContent,
                GetContent,
                GetContent
            });

            queue.Enqueue(GetContent);

            fileProvider.Setup(call => call.GetFileInfo(It.IsAny<string>()).CreateReadStream()).Returns(() => queue.Dequeue().Invoke());

            using (var dc = new DataContext(options))
            {
                StartupExtensions.SeedData(builder.Object, fileProvider.Object, dc);

                var taskList = new List<Task<int>>
                {
                    dc.Address.CountAsync(),
                    dc.Company.CountAsync(),
                    dc.CVContent.CountAsync()
                };


                Task.WaitAll(taskList.ToArray());

                foreach (var item in taskList)
                {
                    Assert.IsTrue(item.IsCompletedSuccessfully, "async call completed successfully");
                }

                Assert.IsTrue(taskList[1].Result == 2, "company record count is 2");
                Assert.IsTrue(taskList[0].Result == 2, "address record count is 2");
                Assert.IsTrue(taskList[2].Result == 4, "content record count is 2");

                var contentRetrieved = await dc.CVContent.FirstOrDefaultAsync();

                Assert.IsTrue(contentRetrieved.Content.Length > 0, "a record has content");

                Console.WriteLine(contentRetrieved.Content);
            }


        }

        private Stream GetContent()
        {
            return StringAsStream("THIS IS CONTENT!!!!!");
        }

        private Stream GetJSON()
        {
            return File.Open("JSON/cv_data.json", System.IO.FileMode.Open, FileAccess.Read);
        }

        private Stream StringAsStream(string input)
        {
            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(ms);
            sw.Write(input);
            sw.Flush();
            ms.Position = 0;
            return ms;
        }
    }
}
