using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfa_scolaireDepart.Manager;

namespace wfa_scolaireDepart
{
    public partial class ScanneurForm : Form
    {
        public ScanneurForm()
        {
            InitializeComponent();
        }

        private async void listerButton_Click(object sender, EventArgs e)//toujours mettre async et await partout ou on utilise une procedure stockée 
        {
            var managerEtudiant = new ManagerEtudiant();
            var listeCours = await managerEtudiant.ListerCoursEtudiant(noDaTextBox.Text); //toujours mettre await lorsqu'on met le lien avec la bd 
            resultatDataGridView.DataSource = listeCours;
        }

        private async void spButton_Click(object sender, EventArgs e)
        {
            var managerOffreCours = new ManagerOffreCours();
            var nombreDeCoursSession = await managerOffreCours.nombreCoursSessionAsync(sessionTextBox.Text);
            MessageBox.Show("nombre de cours : " + nombreDeCoursSession);
        }

        private async void spOutputButton_Click(object sender, EventArgs e)
        {
            var managerOffreCours = new ManagerOffreCours();
            var nombreDeCoursSessionOutput = await managerOffreCours.nombreCoursSessionOutputAsync(sessionTextBox.Text);
            MessageBox.Show("nombre de cours output : " + nombreDeCoursSessionOutput);
        }
    }
}
