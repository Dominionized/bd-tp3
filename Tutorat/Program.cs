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

        static void ListTutors(TutoringContext ctx)
        {
            Console.WriteLine("Tutors :");

            var tutors = ctx.Tutors;
            foreach (var tutor in tutors)
            {
                Console.WriteLine(tutor.ToString());
            }
        }

        static void ListHelpedStudents(TutoringContext ctx)
        {
            Console.WriteLine("Helped Students :");

            var helpedStudents = ctx.HelpedStudents;
            foreach (var stud in helpedStudents)
            {
                Console.WriteLine(stud.ToString());
            }
        }

        static void ListTutoringSessions(TutoringContext ctx)
        {
            Console.WriteLine("Tutoring sessions :");

            var tutoringSessions = ctx.TutoringSessions;
            foreach (var session in tutoringSessions)
            {
                Console.WriteLine(session.ToString());
            }
        }

        static void executeSectionB(TutoringContext ctx)
        {
            // Requete 1
            var tutors = ctx.Tutors.GroupJoin(ctx.TutoringSessions,
                    tut => tut.Id,
                    tutSess => tutSess.TutorId,
                    (tut, tutSess) => new
                    {
                        nom = tut.LastName,
                        prenom = tut.FirstName,
                        courriel = tut.EmailAddress,
                        nbHeures = tutSess.Count()
                    });

            // Requete 2
            var tutors = ctx.TutoringSessions
                .Where(sess => sess.DateSession > DateTime.Now())
                .Select(s => new {
                    nom = s.TutorId.LastName,
                    prenom = s.TutorId.FirstName,
                    date = s.DateSession,
                    heure = s.TimeSession,
                    duree = s.LengthSession,
                    nom_aide = s.HelpedId.LastName,
                    prenom_aide = s.HelpedId.FirstName
                })
        }

        static void executeSectionC(TutoringContext ctx)
        {
            Console.WriteLine("Requete 1");

        }
    }
}
