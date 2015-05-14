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
                .Select(s => new
                {
                    nom = s.TutorId.LastName,
                    prenom = s.TutorId.FirstName,
                    date = s.DateSession,
                    heure = s.TimeSession,
                    duree = s.LengthSession,
                    nom_aide = s.HelpedId.LastName,
                    prenom_aide = s.HelpedId.FirstName
                });

            var tutors = ctx.HelpedStudents
                .Where(s => )
        }

        static void executeSectionC(TutoringContext ctx)
        {
            protected static void SectionC(ProjetContext appContext)
            {
                Tutor tutorUP = new Tutor();
                tutorUP = appContext.Tutor.Where(s => s.FirstName == "Gary" && s.LastName == "Bilodeau").FirstOrDefault<Tutor>();
                if (tutorUP != null)
                {
                    tutorUP.EmailAddress = "gbilodeau@invalidemail.com";
                }
                HelpedStudent hsUP;
                hsUP = appContext.HelpedStudent.Where(hs => hs.FirstName == "Marc" && hs.LastName == "Arsenault").FirstOrDefault<HelpedStudent>();
                TutoringSession TutoringSessionHsUp = appContext.TutoringSession.Where(s => s.Id == hsUP.Id).FirstOrDefault();
                appContext.TutoringSession.Remove(TutoringSessionHsUp);
                appContext.HelpedStudent.Remove(hsUP);
                appContext.SaveChanges();
                HelpedStudent hsUP2;
                hsUP2 = appContext.HelpedStudent.Where(hs => hs.FirstName == "Marc" && hs.LastName == "Arsenault").FirstOrDefault<HelpedStudent>();
                TutoringSession TutoringSessionUP = new TutoringSession();
                TutoringSessionUP = appContext.TutoringSession.Where(ts => ts.Helped.Id == hsUP2.Id).FirstOrDefault<TutoringSession>();
                if (tutorUP != null)
                {
                    TutoringSessionUP.DateSession = new DateTime(2015, 04, 09, 11, 0, 0);
                    TutoringSessionUP.TimeSession = TimeSpan.FromHours(2);
                }
                appContext.SaveChanges();
                HelpedStudent HsJoin = new HelpedStudent();
                HsJoin = appContext.HelpedStudent.Where(hs => hs.FirstName == "Samuel" && hs.LastName == "Vachon").FirstOrDefault<HelpedStudent>();
                Tutor TutorJoin = new Tutor();
                TutorJoin = appContext.Tutor.Where(hs => hs.FirstName == "Louis" && hs.LastName == "Vézina").FirstOrDefault<Tutor>();

                TutoringSession newTutoringSession = new TutoringSession();
                newTutoringSession.DateSession = new DateTime(2015, 06, 04, 10, 0, 0);
                newTutoringSession.TimeSession = TimeSpan.FromHours(10);
                newTutoringSession.LengthSession = TimeSpan.FromHours(2);
                newTutoringSession.HelpedId = HsJoin;
                newTutoringSession.TutorId = TutorJoin;

                appContext.TutoringSession.Add(newTutoringSession);
                appContext.SaveChanges();
            }
        }
    }
}
