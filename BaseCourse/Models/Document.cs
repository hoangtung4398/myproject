using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCourse.Models
{
    public class Document : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string NameAzure { get; set; }
        public int CreatedBy { get; set; }
        
    }
}
