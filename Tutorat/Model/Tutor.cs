using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorat.Model
{
    class Tutor
    {
        public Tutor() { }
        [Key]
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string EmailAddress { get; set; }

        public ICollection<TutoringSession> TutoringSessions { get; set; }
    }
}
