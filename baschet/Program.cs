using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using baschet.domain;
using baschet.repo;
using log4net.Config;
using log4net;


namespace baschet
{
    class Program
    {
        public static void Main()
        {
            
            XmlConfigurator.Configure(new System.IO.FileInfo("C:/Users/Esanu/RiderProjects/APP_BASCHET/APP_BASCHET/log4net.config"));
            Console.WriteLine("Configuration Settings for userDB {0}",GetConnectionStringByName("baschet.db"));
            Console.WriteLine(GetConnectionStringByName("baschet.db"));
            IDictionary<String, string> props = new SortedList<String, String>();
            //props.Add("ConnectionString", GetConnectionStringByName("baschet.db"));
            props.Add("ConnectionString", "Data Source=C://Users//Esanu//Downloads//EXAMEN-JAVAFX//CONCURS_BASCHET//identifier.sqlite");
            Console.WriteLine(props["ConnectionString"]);
            Console.WriteLine("User Repository DB ...");
            UserDBRepository userDbRepository = new UserDBRepository(props);
            MatchDBRepo matchDBRepo = new MatchDBRepo(props);
            TicketDBRepo ticketDBRepo = new TicketDBRepo(props);
            Service.Service service = new Service.Service(userDbRepository, matchDBRepo, ticketDBRepo);
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(service));
            //Application.Run(new Form2(service));
         
            
            
            // Console.WriteLine("Userii din db");
            // foreach (User u in repo.findAll())
            // {
            //     Console.WriteLine(u);
            // }
            // User user = repo.findOne(2);
            // Console.WriteLine(user);
            //
            // User addedUser = new User(9, "user9", "parola123");
            // Console.WriteLine(addedUser);
            // repo.add(addedUser);
            // repo.delete(2);
            //
            // Console.WriteLine("Userii din db dupa stergere/adaugare");
            // foreach (User u in repo.findAll())
            // {
            //     Console.WriteLine(u);
            // }

        }
        
        static string GetConnectionStringByName(string name)
        {
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings =ConfigurationManager.ConnectionStrings[name];

            // If found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }
    }
}