using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baschet
{
    public partial class Form2 : Form
    {
        private Service.Service myService;
        public Form2(Service.Service service)
        {
            InitializeComponent();
            setService(service);
            initializeDataGridView();
        }
        
        public void setService(Service.Service service)
        {
            this.myService = service;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //get the selected match from the datagridview
            int matchId = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            Console.WriteLine("Aceste este meciul : ____________________ " + matchId);
            Match match = myService.findOneMatch(matchId);
            //open form3
            Form3 form3 = new Form3(myService, match);
            form3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        
        private void only_availableBtn_Click(object sender, EventArgs e)
        {
            emptyTable();
            foreach (Match match in myService.getAllMatches())
            {
                // call myService.CheckAvailableSeats() to check if seats are available
                bool seatsAvailable = myService.CheckAvailableSeats(match, 0);
                if (seatsAvailable)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dataGridView1);
                    row.Cells[0].Value = match.GetId();
                    row.Cells[1].Value = match.TeamA;
                    row.Cells[2].Value = match.TeamB;
                    row.Cells[3].Value = match.TicketPrice;
                    row.Cells[4].Value = match.SoldSeats;
                    row.Cells[5].Value = "Available";
                    row.Cells[5].Style.ForeColor = Color.Green;
                    dataGridView1.Rows.Add(row);
                }
            }
        }

        private void refreshBtnClick(object sender, EventArgs e)
        {
            emptyTable();
            initializeDataGridView();
        }

        private void Inapoi_Click(object sender, EventArgs e)
        {
            emptyTable();
            initializeDataGridView();
        }
        
        //method to initialize the datagridview with the matches
        private void initializeDataGridView()
        {
            foreach (Match match in myService.getAllMatches())
            {
                // call myService.CheckAvailableSeats() to check if seats are available
                bool seatsAvailable = myService.CheckAvailableSeats(match, 0);

                // add a row to the DataGridView
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[0].Value = match.GetId();
                row.Cells[1].Value = match.TeamA;
                row.Cells[2].Value = match.TeamB;
                row.Cells[3].Value = match.TicketPrice;
                row.Cells[4].Value = match.SoldSeats;

                // add "Available" or "Sold out" column based on seats availability
                if (seatsAvailable)
                {
                    row.Cells[5].Value = "Available";
                    row.Cells[5].Style.ForeColor = Color.Green;
                }
                else
                {
                    row.Cells[5].Value = "Sold out";
                    row.Cells[5].Style.ForeColor = Color.Red;
                }

                // add the row to the DataGridView
                dataGridView1.Rows.Add(row);


            }
        }
        
        private void emptyTable()
        {
            dataGridView1.Rows.Clear();
        }
        
        

    }
}
