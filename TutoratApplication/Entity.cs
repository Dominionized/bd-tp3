using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoratApplication
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
