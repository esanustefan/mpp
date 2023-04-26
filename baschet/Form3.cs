using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APP_BASCHET.domain;

namespace baschet
{
    public partial class Form3 : Form
    {
        
        private Service.Service myService;
        private Match myMatch;
        public Form3(Service.Service service, Match match)
        {
            InitializeComponent();
            setService(service);
            setMatch(match);
        }
        
        public void setService(Service.Service service)
        {
            this.myService = service;
        }
        
        public void setMatch(Match match)
        {
            this.myMatch = match;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            var tickets = textBox2.Text;
            //convert tickets to int
            if (name == "" || tickets == "")
            {
                label1.Text = "Purchase failed!";
                return;
            }
            else
            {
                int NrOfTicketsInt = Int32.Parse(tickets);
                if (NrOfTicketsInt <= 0)
                {
                    
                    label1.Text = "Purchase failed!";
                    return;
                }
                else
                {
                    if(myService.CheckAvailableSeats(myMatch, NrOfTicketsInt))
                    {
                        //update the match
                        int NewTicketsNb = myMatch.SoldSeats -  NrOfTicketsInt;
                        myService.updateMatch(myMatch.GetId(), myMatch.TeamA, myMatch.TeamB, myMatch.TicketPrice, NewTicketsNb);
                        label1.Text = "Purchase successful!";
                        
                        Random rnd = new Random();
                        int ticketId = rnd.Next(1, 1000);
                        Console.WriteLine("Ticket id: " + ticketId);
                        myService.addTicket(ticketId, name, NrOfTicketsInt);
                        return;
                    }
                    else
                    {
                        label1.Text = "Purchase failed!";
                        return;
                    }
                }
            }
            
        }
        
        
    }
}
