using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tutorat.Model
{
    public class TutoringSession : Entity
    {
        [Required]
        public DateTime DateSession { get; set; }
        [Required]
        public TimeSpan TimeSession { get; set; }
        [Required]
        public TimeSpan LengthSession { get; set; }

        [Required]
        public virtual Tutor TutorId { get; set; }

        [Required]
        public virtual HelpedStudent HelpedId { get; set; }
    }
}
