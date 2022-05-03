using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWTester.Models
{
    public class Answers
    {
        public int Id { get; set; }
        public int QuesionId { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public Questions Questions { get; set; }
    }
}
