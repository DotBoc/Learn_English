using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn_English
{
    class ScoreProvider
    {
        public int student_course_fk_student_uid { get; set; }
        public int student_course_fk_course_id { get; set; }
        public decimal student_course_grade { get; set; }       
    }
}
