using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeAPI.Models
{
    public class Candidate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        //public int EducationFK { get; set; }
        //[ForeignKey("EducationFK")]
        public List<Education> Education { get; set; }
        public string Skills { get; set; }
        //public int WorkHistoryFK { get; set; }
        //[ForeignKey("WorkHistoryFK")]
        public List<WorkHistory> WorkHistory { get; set; }
    }
}
