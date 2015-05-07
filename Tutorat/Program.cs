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

            var tutoringSessions = ctx.TutoringSessions;
            foreach (var session in tutoringSessions)
            {
                Console.WriteLine(session.ToString());
            }

            var helpedStudents = ctx.HelpedStudents;
            foreach (var stud in helpedStudents)
            {
                Console.WriteLine(stud.ToString());
            }

            var tutors = ctx.Tutors;
            foreach (var tutor in tutors)
            {
                Console.WriteLine(tutor.ToString());
            }
            Console.ReadLine();
        }
    }
}
