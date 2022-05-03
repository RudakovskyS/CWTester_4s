using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWTester.Models
{
    public class QuestionResult
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public int BottomMark { get; set; }
        public int TopMark { get; set; }
        public Questions Questions { get; set; }
    }
}
