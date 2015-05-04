using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorat.Model
{
    class TutoringSession
    {
        public TutoringSession(){}
        [Key]
        public int Id { get; set; }
        public DateTime DateSession { get; set; }
        public TimeSpan TimeSession { get; set; }
        public TimeSpan LengthSession { get; set; }

        public Tutor TutorId { get; set; }
        public HelpedStudent HelpedId { get; set; }
    }
}
