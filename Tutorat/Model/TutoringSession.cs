using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tutorat.Model
{
    class TutoringSession
    {
        public TutoringSession(){}
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateSession { get; set; }
        [Required]
        public TimeSpan TimeSession { get; set; }
        [Required]
        public TimeSpan LengthSession { get; set; }

        [Required]
        public Tutor TutorId { get; set; }

        [Required]
        public HelpedStudent HelpedId { get; set; }
    }
}
