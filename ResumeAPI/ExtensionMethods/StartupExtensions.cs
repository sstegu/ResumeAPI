using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using ResumeAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeAPI.ExtensionMethods
{
    public static class StartupExtensions
    {
        public static void SeedData(this IApplicationBuilder app, IFileProvider fileProvider, DataContext dc)
        {


            IEnumerable<SeedData> seedData = null;
            using (var stream = fileProvider.GetFileInfo("JSON/cv_data.json").CreateReadStream())
            {
                using (var sr = new StreamReader(stream))
                {
                    var data = sr.ReadToEnd();

                    seedData = JsonConvert.DeserializeObject<IEnumerable<SeedData>>(data);
                }
            }

            foreach (var item in seedData)
            {

                dc.Add(item.Company);

                foreach (var cv in item.CVContent)
                {
                    cv.Company = item.Company;

                    using (var contentStream = fileProvider.GetFileInfo($"Content/{cv.FileName}").CreateReadStream())
                    {
                        using (var contentReader = new StreamReader(contentStream))
                        {
                            var content = contentReader.ReadToEnd();
                            cv.Content = content;
                        }
                    }

                    dc.Add(cv);
                }
            }

            dc.SaveChanges();
        }
    }

}

