using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn_English
{
    class AnswerProvider
    {
        public int student_results_fk_student { get; set; }
        public int student_results_fk_question { get; set; }
        public string student_results_selected_answer { get; set; }
        public DateTime student_results_date { get; set; }
        
    }
}
