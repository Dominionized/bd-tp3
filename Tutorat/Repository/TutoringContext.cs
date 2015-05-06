using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Tutorat.Model;

namespace Tutorat.Repository
{
    public class TutoringContext : DbContext
    {
        public DbSet<Tutor> Tutors { get; set; }

        public DbSet<HelpedStudent> HelpedStudents { get; set; }

        public DbSet<TutoringSession> TutoringSessions { get; set; }
    }

    public class TutoringInitializer : DropCreateDatabaseIfModelChanges<TutoringContext>
    {
        protected override void Seed(TutoringContext context)
        {
            base.Seed(context);

            Tutor gary = new Tutor() { LastName = "Bilodeau", FirstName = "Gary", EmailAddress = "bgary2@hotmail.com"};
            context.Tutors.Add(gary);
            Tutor sam_gagnon = new Tutor() { LastName = "Gagnon", FirstName = "Samuel", EmailAddress = "samPP92@hotmail.com"};
            context.Tutors.Add(sam_gagnon);
            Tutor simon_gingras = new Tutor() { LastName = "Gingras", FirstName = "Simon", EmailAddress = "ptitguy22@bell.net"};
            context.Tutors.Add(simon_gingras);
            Tutor eroy = new Tutor() { LastName = "Roy", FirstName = "Éric", EmailAddress = "eroy231@videotron.ca"};
            context.Tutors.Add(eroy);
            Tutor caro_veilleux = new Tutor() { LastName = "Veilleux", FirstName = "Caroline", EmailAddress = "caro.koko@hotmail.com"};
            context.Tutors.Add(caro_veilleux);
            Tutor kar_tremb = new Tutor() { LastName = "Tremblay", FirstName = "Karine", EmailAddress = "kar.tremblay@gmail.com"};
            context.Tutors.Add(kar_tremb);
            Tutor louis_vez = new Tutor() { LastName = "Vézina", FirstName = "Louis", EmailAddress = "vl410Bd@gmail.com"};
            context.Tutors.Add(louis_vez);

            HelpedStudent marc_ars = new HelpedStudent() { LastName = "Arsenault", FirstName = "Marc", EmailAddress = "marco.arso@hotmail.com" };
            context.HelpedStudents.Add(marc_ars);
            HelpedStudent eric_boilard = new HelpedStudent() { LastName = "Boilard", FirstName = "Éric", EmailAddress = "eric.r.boilard2@coop.com" };
            context.HelpedStudents.Add(eric_boilard);
            HelpedStudent jc_cout = new HelpedStudent() { LastName = "Couture", FirstName = "Jean-Christophe", EmailAddress = "jc.couture.wilde@hotmail.com" };
            context.HelpedStudents.Add(jc_cout);
            HelpedStudent jul_des = new HelpedStudent() { LastName = "Desrosiers", FirstName = "Julianne", EmailAddress = "galypo13@hotmail.com" };
            context.HelpedStudents.Add(jul_des);
            HelpedStudent leo_ga = new HelpedStudent() { LastName = "Grégoire-Allen", FirstName = "Léo", EmailAddress = "leoga@hotmail.com" };
            context.HelpedStudents.Add(leo_ga);
            HelpedStudent fran_ham = new HelpedStudent() { LastName = "Hamel", FirstName = "François", EmailAddress = "" };
            context.HelpedStudents.Add(fran_ham);
            HelpedStudent jer_lep = new HelpedStudent() { LastName = "Lepage", FirstName = "Jérémy", EmailAddress = "" };
            context.HelpedStudents.Add(jer_lep);
            HelpedStudent nic_poit = new HelpedStudent() { LastName = "Poitras", FirstName = "Nicolas", EmailAddress = "" };
            context.HelpedStudents.Add(nic_poit);
            HelpedStudent sam_rg = new HelpedStudent() { LastName = "Roy-Gagnon", FirstName = "Samuel", EmailAddress = "" };
            context.HelpedStudents.Add(sam_rg);
            HelpedStudent ben_sim = new HelpedStudent() { LastName = "Simard", FirstName = "Benjamin", EmailAddress = "" };
            context.HelpedStudents.Add(ben_sim);
            HelpedStudent sam_vach = new HelpedStudent() { LastName = "Vachon", FirstName = "Samuel", EmailAddress = "" };
            context.HelpedStudents.Add(sam_vach);

            context.TutoringSessions.Add(new TutoringSession() { DateSession = new DateTime(2015,03,16), TimeSession = new TimeSpan(13, 0, 0), LengthSession = new TimeSpan(2, 0, 0), HelpedId = leo_ga, TutorId = caro_veilleux});
            context.TutoringSessions.Add(new TutoringSession() { DateSession = new DateTime(2015,03,24), TimeSession = new TimeSpan(10, 0, 0), LengthSession = new TimeSpan(1, 0, 0), HelpedId = leo_ga, TutorId = gary});
            context.TutoringSessions.Add(new TutoringSession() { DateSession = new DateTime(2015,03,25), TimeSession = new TimeSpan(13, 0, 0), LengthSession = new TimeSpan(1, 0, 0), HelpedId = eric_boilard, TutorId = eroy});
            context.TutoringSessions.Add(new TutoringSession() { DateSession = new DateTime(2015,04,01), TimeSession = new TimeSpan(12, 0, 0), LengthSession = new TimeSpan(2, 0, 0), HelpedId = marc_ars, TutorId = caro_veilleux});
            context.TutoringSessions.Add(new TutoringSession() { DateSession = new DateTime(2015,04,01), TimeSession = new TimeSpan(13, 0, 0), LengthSession = new TimeSpan(1, 0, 0), HelpedId = eric_boilard, TutorId = simon_gingras});
            context.TutoringSessions.Add(new TutoringSession() { DateSession = new DateTime(2015,04,06), TimeSession = new TimeSpan(16, 0, 0), LengthSession = new TimeSpan(1, 0, 0), HelpedId = marc_ars, TutorId = eroy});
            context.TutoringSessions.Add(new TutoringSession() { DateSession = new DateTime(2015,04,08), TimeSession = new TimeSpan(10, 0, 0), LengthSession = new TimeSpan(1, 0, 0), HelpedId = fran_ham, TutorId = eroy});
            context.TutoringSessions.Add(new TutoringSession() { DateSession = new DateTime(2015,04,10), TimeSession = new TimeSpan(10, 0, 0), LengthSession = new TimeSpan(2, 0, 0), HelpedId = marc_ars, TutorId = eroy});
            context.TutoringSessions.Add(new TutoringSession() { DateSession = new DateTime(2015,04,29), TimeSession = new TimeSpan(12, 0, 0), LengthSession = new TimeSpan(1, 0, 0), HelpedId = sam_rg, TutorId = caro_veilleux});
            context.TutoringSessions.Add(new TutoringSession() { DateSession = new DateTime(2015,05,25), TimeSession = new TimeSpan(13, 0, 0), LengthSession = new TimeSpan(1, 0, 0), HelpedId = ben_sim, TutorId = louis_vez});
            context.TutoringSessions.Add(new TutoringSession() { DateSession = new DateTime(2015,05,27), TimeSession = new TimeSpan(12, 0, 0), LengthSession = new TimeSpan(2, 0, 0), HelpedId = ben_sim, TutorId = caro_veilleux});
            context.TutoringSessions.Add(new TutoringSession() { DateSession = new DateTime(2015,05,27), TimeSession = new TimeSpan(13, 0, 0), LengthSession = new TimeSpan(1, 0, 0), HelpedId = eric_boilard, TutorId = simon_gingras});
            context.TutoringSessions.Add(new TutoringSession() { DateSession = new DateTime(2015,06,01), TimeSession = new TimeSpan(09, 0, 0), LengthSession = new TimeSpan(1, 0, 0), HelpedId = jer_lep, TutorId = louis_vez});
            context.TutoringSessions.Add(new TutoringSession() { DateSession = new DateTime(2015,06,02), TimeSession = new TimeSpan(09, 0, 0), LengthSession = new TimeSpan(1, 0, 0), HelpedId = sam_vach, TutorId = louis_vez});
            context.TutoringSessions.Add(new TutoringSession() { DateSession = new DateTime(2015,06,02), TimeSession = new TimeSpan(11, 0, 0), LengthSession = new TimeSpan(1, 0, 0), HelpedId = eric_boilard, TutorId = louis_vez});
            context.TutoringSessions.Add(new TutoringSession() { DateSession = new DateTime(2015,06,02), TimeSession = new TimeSpan(13, 0, 0), LengthSession = new TimeSpan(1, 0, 0), HelpedId = leo_ga, TutorId = gary});
            context.TutoringSessions.Add(new TutoringSession() { DateSession = new DateTime(2015,06,02), TimeSession = new TimeSpan(15, 0, 0), LengthSession = new TimeSpan(1, 0, 0), HelpedId = sam_rg, TutorId = eroy});
            context.TutoringSessions.Add(new TutoringSession() { DateSession = new DateTime(2015,06,03), TimeSession = new TimeSpan(13, 0, 0), LengthSession = new TimeSpan(2, 0, 0), HelpedId = jer_lep, TutorId = simon_gingras });
        }
    }
}
