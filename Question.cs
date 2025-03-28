using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Question(string question, string answer)
    {
        public string QuestionText { get; set; } = question;
        public string Answer { get; set; } = answer;
    }
}
