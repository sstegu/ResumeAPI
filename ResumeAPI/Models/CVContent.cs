using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeAPI.Models
{
    public enum CVContentType { CoverLetter, Resume }

    public class CVContent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public CVContentType CVType { get; set; }
        public Company Company { get; set; }
        public string Content { get; set; }
        [NotMapped]
        public string FileName { get; set; }
    }
}
