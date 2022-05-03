using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWTester.Models
{
    public class Questions
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public string Text { get; set; }
        public int MediaId { get; set; }
        public Tests Tests { get; set; }
        public Media Media { get; set; }
    }
}
