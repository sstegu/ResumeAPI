using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ResumeAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeAPI
{
    public class DataSeeder
    {
        ILogger<DataSeeder> _logger;
        IFileProvider _fileProvider;
        DataContext _context;

        public DataSeeder(ILogger<DataSeeder> logger, IFileProvider fileProvider, DataContext context)
        {
            _logger = logger;
            _fileProvider = fileProvider;
            _context = context;
        }

        public void SeedData()
        {
            using (var stream = _fileProvider.GetFileInfo("JSON/candidate_data.json").CreateReadStream())
            {
                using (var sr = new StreamReader(stream))
                {
                    var data = sr.ReadToEnd();

                    var obj = JsonConvert.DeserializeObject<Candidate>(data);

                    _context.Add(obj);
                }
            }

            IEnumerable<SeedData> seedData = null;
            using (var stream = _fileProvider.GetFileInfo("JSON/cv_data.json").CreateReadStream())
            {
                using (var sr = new StreamReader(stream))
                {
                    var data = sr.ReadToEnd();

                    seedData = JsonConvert.DeserializeObject<IEnumerable<SeedData>>(data);
                }
            }

            foreach (var item in seedData)
            {

                _context.Add(item.Company);

                foreach (var cv in item.CVContent)
                {
                    cv.Company = item.Company;

                    using (var contentStream = _fileProvider.GetFileInfo($"Content/{cv.FileName}").CreateReadStream())
                    {
                        using (var contentReader = new StreamReader(contentStream))
                        {
                            var content = contentReader.ReadToEnd();
                            cv.Content = content;
                        }
                    }

                    _context.Add(cv);
                }
            }

            _context.SaveChanges();
        }
    }
}

