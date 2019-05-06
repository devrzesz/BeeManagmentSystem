using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeeManagmentSystem
{
    public partial class Form1 : Form
    {
        Queen queen;

        public Form1()
        {
            InitializeComponent();
            workerBeeJob.SelectedIndex = 0;

            Worker[] workers = new Worker[4];

            workers[0] = new Worker(new string[] { "Zbieranie nektaru", "Wytwarzanie miodu" });
            workers[1] = new Worker(new string[] { "Pielęgnacja jaj", "Nauczanie pszczółek" });
            workers[2] = new Worker(new string[] { "Utrzymanie ula", "Patrol z żądłami" });
            workers[3] = new Worker(new string[] { "Zbieranie nektaru", "Wytwarzanie miodu", "Pielęgnacja jaj", "Nauczanie pszczółek", "Utrzymanie ula", "Patrol z żądłami" });
            

            queen = new Queen(workers);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (queen.AssignWork(workerBeeJob.Text, (int)shifts.Value) == false)
                MessageBox.Show("Nie ma dostepnych robotnic do wykonania zadania '" + workerBeeJob.Text + "'", "Krolowa pszczol mowi...");
            else
                MessageBox.Show("Zadanie '" + workerBeeJob.Text + "' bedzie ukonczone za " + shifts.Value + " zmiany", "Krolowa pszczol mowi...");
        }

        private void NextShift_Click(object sender, EventArgs e)
        {
            report.Text = queen.WorkTheNextShift();
        }
    }
}
