using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorat.Repository;
using Tutorat.Model;

namespace Tutorat
{
    class Program
    {
        static void Main(string[] args)
        {
            TutoringContext ctx = new TutoringContext();
            TutoringInitializer init = new TutoringInitializer();


            Database.SetInitializer<TutoringContext>(init);

            init.InitializeDatabase(ctx);

            ListTutors(ctx);
            ListHelpedStudents(ctx);
            ListTutoringSessions(ctx);

            Console.ReadLine();
        }
    }
}
