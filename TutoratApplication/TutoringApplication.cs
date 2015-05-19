using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoratApplication
{
    class TutoringApplication
    {
        public TutoratRepository<HelpedStudents> helpedStudents { get; set; }
        public TutoratRepository<Tutor> tutors { get; set; }
        public TutoratRepository<TutoringSession> tutoringSessions { get; set; }

        public TutoringApplication(TutoringContext ctx)
        {

        }

        static void ListTutors(TutoringContext ctx)
        {
            Console.WriteLine("Tutors :");

            var tutors = tutors.GetAll();
            foreach (var tutor in tutors)
            {
                Console.WriteLine(tutor.ToString());
            }
        }

        static void ListHelpedStudents(TutoringContext ctx)
        {
            Console.WriteLine("Helped Students :");

            var helpedStudents = helpedStudents.GetAll();
            foreach (var stud in helpedStudents)
            {
                Console.WriteLine(stud.ToString());
            }
        }

        static void ListTutoringSessions(TutoringContext ctx)
        {
            Console.WriteLine("Tutoring sessions :");

            var tutoringSessions = tutoringSessions.GetAll();
            foreach (var session in tutoringSessions)
            {
                Console.WriteLine(session.ToString());
            }
        }

        static void executeSectionB(TutoringContext ctx)
        {
            // Requete 1
            var tutors = tutors.GetAll().GroupJoin(tutoringSessions.GetAll(),
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
            var tutors = tutoringSessions.GetAll()
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

            // Requete 3
            var tutors = helpedStudents.GetAll().GroupJoin(tutoringSessions.GetAll(),
                    helpStud => helpStud.Id,
                    tutSess => tutSess.HelpedId,
                    (helpStud, tutSess) => new
                    {
                        nom = helpStud.LastName,
                        prenom = helpStud.FirstName,
                        courriel = helpStud.EmailAddress
                    })
                    .Where(s => s.Count() = 0);

            // Requete 4
            var tutors = tutors.GetAll().Join(tutoringSessions.GetAll(),
                tut => tut.Id,
                tutSess => tutSess.TutorId,
                (tut, tutSess) => new
                {
                    nom = tut.FirstName + " " + tut.LastName,
                    dateSession = tutSess.DateSession
                })
                .Where(s => s.dateSession != DateTime(2015, 06, 02))
                .GroupBy(s => s.nom);
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

        public void Seed()
        {
            Tutor gary = new Tutor() { LastName = "Bilodeau", FirstName = "Gary", EmailAddress = "bgary2@hotmail.com" };
            tutors.Insert(gary);
            Tutor sam_gagnon = new Tutor() { LastName = "Gagnon", FirstName = "Samuel", EmailAddress = "samPP92@hotmail.com" };
            tutors.Insert(sam_gagnon);
            Tutor simon_gingras = new Tutor() { LastName = "Gingras", FirstName = "Simon", EmailAddress = "ptitguy22@bell.net" };
            tutors.Insert(simon_gingras);
            Tutor eroy = new Tutor() { LastName = "Roy", FirstName = "Éric", EmailAddress = "eroy231@videotron.ca" };
            tutors.Insert(eroy);
            Tutor caro_veilleux = new Tutor() { LastName = "Veilleux", FirstName = "Caroline", EmailAddress = "caro.koko@hotmail.com" };
            tutors.Insert(caro_veilleux);
            Tutor kar_tremb = new Tutor() { LastName = "Tremblay", FirstName = "Karine", EmailAddress = "kar.tremblay@gmail.com" };
            tutors.Insert(kar_tremb);
            Tutor louis_vez = new Tutor() { LastName = "Vézina", FirstName = "Louis", EmailAddress = "vl410Bd@gmail.com" };
            tutors.Insert(louis_vez);

            HelpedStudent marc_ars = new HelpedStudent() { LastName = "Arsenault", FirstName = "Marc", EmailAddress = "marco.arso@hotmail.com" };
            helpedStudents.Insert(marc_ars);
            HelpedStudent eric_boilard = new HelpedStudent() { LastName = "Boilard", FirstName = "Éric", EmailAddress = "eric.r.boilard2@coop.com" };
            helpedStudents.Insert(eric_boilard);
            HelpedStudent jc_cout = new HelpedStudent() { LastName = "Couture", FirstName = "Jean-Christophe", EmailAddress = "jc.couture.wilde@hotmail.com" };
            helpedStudents.Insert(jc_cout);
            HelpedStudent jul_des = new HelpedStudent() { LastName = "Desrosiers", FirstName = "Julianne", EmailAddress = "galypo13@hotmail.com" };
            helpedStudents.Insert(jul_des);
            HelpedStudent leo_ga = new HelpedStudent() { LastName = "Grégoire-Allen", FirstName = "Léo", EmailAddress = "leoga@hotmail.com" };
            helpedStudents.Insert(leo_ga);
            HelpedStudent fran_ham = new HelpedStudent() { LastName = "Hamel", FirstName = "François", EmailAddress = "" };
            helpedStudents.Insert(fran_ham);
            HelpedStudent jer_lep = new HelpedStudent() { LastName = "Lepage", FirstName = "Jérémy", EmailAddress = "" };
            helpedStudents.Insert(jer_lep);
            HelpedStudent nic_poit = new HelpedStudent() { LastName = "Poitras", FirstName = "Nicolas", EmailAddress = "" };
            helpedStudents.Insert(nic_poit);
            HelpedStudent sam_rg = new HelpedStudent() { LastName = "Roy-Gagnon", FirstName = "Samuel", EmailAddress = "" };
            helpedStudents.Insert(sam_rg);
            HelpedStudent ben_sim = new HelpedStudent() { LastName = "Simard", FirstName = "Benjamin", EmailAddress = "" };
            helpedStudents.Insert(ben_sim);
            HelpedStudent sam_vach = new HelpedStudent() { LastName = "Vachon", FirstName = "Samuel", EmailAddress = "" };
            helpedStudents.Insert(sam_vach);

            tutoringSessions.Insert(new TutoringSession() { DateSession = new DateTime(2015, 03, 16), TimeSession = new TimeSpan(13, 0, 0), LengthSession = new TimeSpan(2, 0, 0), HelpedId = leo_ga, TutorId = caro_veilleux });
            tutoringSessions.Insert(new TutoringSession() { DateSession = new DateTime(2015, 03, 24), TimeSession = new TimeSpan(10, 0, 0), LengthSession = new TimeSpan(1, 0, 0), HelpedId = leo_ga, TutorId = gary });
            tutoringSessions.Insert(new TutoringSession() { DateSession = new DateTime(2015, 03, 25), TimeSession = new TimeSpan(13, 0, 0), LengthSession = new TimeSpan(1, 0, 0), HelpedId = eric_boilard, TutorId = eroy });
            tutoringSessions.Insert(new TutoringSession() { DateSession = new DateTime(2015, 04, 01), TimeSession = new TimeSpan(12, 0, 0), LengthSession = new TimeSpan(2, 0, 0), HelpedId = marc_ars, TutorId = caro_veilleux });
            tutoringSessions.Insert(new TutoringSession() { DateSession = new DateTime(2015, 04, 01), TimeSession = new TimeSpan(13, 0, 0), LengthSession = new TimeSpan(1, 0, 0), HelpedId = eric_boilard, TutorId = simon_gingras });
            tutoringSessions.Insert(new TutoringSession() { DateSession = new DateTime(2015, 04, 06), TimeSession = new TimeSpan(16, 0, 0), LengthSession = new TimeSpan(1, 0, 0), HelpedId = marc_ars, TutorId = eroy });
            tutoringSessions.Insert(new TutoringSession() { DateSession = new DateTime(2015, 04, 08), TimeSession = new TimeSpan(10, 0, 0), LengthSession = new TimeSpan(1, 0, 0), HelpedId = fran_ham, TutorId = eroy });
            tutoringSessions.Insert(new TutoringSession() { DateSession = new DateTime(2015, 04, 10), TimeSession = new TimeSpan(10, 0, 0), LengthSession = new TimeSpan(2, 0, 0), HelpedId = marc_ars, TutorId = eroy });
            tutoringSessions.Insert(new TutoringSession() { DateSession = new DateTime(2015, 04, 29), TimeSession = new TimeSpan(12, 0, 0), LengthSession = new TimeSpan(1, 0, 0), HelpedId = sam_rg, TutorId = caro_veilleux });
            tutoringSessions.Insert(new TutoringSession() { DateSession = new DateTime(2015, 05, 25), TimeSession = new TimeSpan(13, 0, 0), LengthSession = new TimeSpan(1, 0, 0), HelpedId = ben_sim, TutorId = louis_vez });
            tutoringSessions.Insert(new TutoringSession() { DateSession = new DateTime(2015, 05, 27), TimeSession = new TimeSpan(12, 0, 0), LengthSession = new TimeSpan(2, 0, 0), HelpedId = ben_sim, TutorId = caro_veilleux });
            tutoringSessions.Insert(new TutoringSession() { DateSession = new DateTime(2015, 05, 27), TimeSession = new TimeSpan(13, 0, 0), LengthSession = new TimeSpan(1, 0, 0), HelpedId = eric_boilard, TutorId = simon_gingras });
            tutoringSessions.Insert(new TutoringSession() { DateSession = new DateTime(2015, 06, 01), TimeSession = new TimeSpan(09, 0, 0), LengthSession = new TimeSpan(1, 0, 0), HelpedId = jer_lep, TutorId = louis_vez });
            tutoringSessions.Insert(new TutoringSession() { DateSession = new DateTime(2015, 06, 02), TimeSession = new TimeSpan(09, 0, 0), LengthSession = new TimeSpan(1, 0, 0), HelpedId = sam_vach, TutorId = louis_vez });
            tutoringSessions.Insert(new TutoringSession() { DateSession = new DateTime(2015, 06, 02), TimeSession = new TimeSpan(11, 0, 0), LengthSession = new TimeSpan(1, 0, 0), HelpedId = eric_boilard, TutorId = louis_vez });
            tutoringSessions.Insert(new TutoringSession() { DateSession = new DateTime(2015, 06, 02), TimeSession = new TimeSpan(13, 0, 0), LengthSession = new TimeSpan(1, 0, 0), HelpedId = leo_ga, TutorId = gary });
            tutoringSessions.Insert(new TutoringSession() { DateSession = new DateTime(2015, 06, 02), TimeSession = new TimeSpan(15, 0, 0), LengthSession = new TimeSpan(1, 0, 0), HelpedId = sam_rg, TutorId = eroy });
            tutoringSessions.Insert(new TutoringSession() { DateSession = new DateTime(2015, 06, 03), TimeSession = new TimeSpan(13, 0, 0), LengthSession = new TimeSpan(2, 0, 0), HelpedId = jer_lep, TutorId = simon_gingras });
        }
    }
}
