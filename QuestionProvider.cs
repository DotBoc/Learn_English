using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn_English
{
    class QuestionProvider
    {
        public int question_id { get; set; }
        public string question_title { get; set; }
        public string question_a { get; set; }
        public string question_b { get; set; }
        public string question_c { get; set; }
        public string question_d { get; set; }
        public string question_correct { get; set; }
        public DateTime question_date { get; set; }
        public int question_fk_teacher { get; set; }
        public int question_fk_course { get; set; }
    }
}
