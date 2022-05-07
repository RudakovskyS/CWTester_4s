using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWTester.Models
{
    public class PassedTests
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public DateTime TestDate { get; set; }
        public Tests Tests { get; set; }
    }
}
