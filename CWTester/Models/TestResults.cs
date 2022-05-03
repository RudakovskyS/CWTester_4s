using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWTester.Models
{
    public class TestResults
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PlannedTesId { get; set; }
        public int Result { get; set; }
        public User User { get; set; }
        public PlannedTests PlannedTests { get; set; }
    }
}
