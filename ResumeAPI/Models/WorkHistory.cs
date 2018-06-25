using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeAPI.Models
{
    public class WorkHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string Description { get; set; }
        //public int ProjectFK { get; set; }
        //[ForeignKey("ProjectFK")]
        public List<Project> Projects { get; set; }
    }
}
