﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tutorat.Model
{
    public class Tutor : Entity
    {
        [Required]
        [MaxLength(30), MinLength(1)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(30), MinLength(1)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(60), MinLength(1)]
        public string EmailAddress { get; set; }

        public virtual ICollection<TutoringSession> TutoringSessions { get; set; }
    }
}
