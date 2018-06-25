using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn_English
{
    class TopicProvider
    {
        public int topic_id { get; set; }
        public string topic_title { get; set; }
        public string topic_text { get; set; }
        public DateTime topic_date { get; set; }
        public int topic_fk_teacher { get; set; }
        public int topic_fk_course { get; set; }
    }
}
