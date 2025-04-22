using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfa_scolaireDepart.Models;

namespace wfa_scolaireDepart.Manager
{
    public partial class viewForm : Form
    {
        List<TblCour> listerCours;// car on est eagle loading
        TblCour coursRecherche;

        public viewForm()
        {
            InitializeComponent();
        }

        private void RemplirComboBoxNomCours()
        {
            ManagerCours managerCours = new ManagerCours();
            listerCours = managerCours.ListerCoursEagerLoading();
            coursComboBox.DataSource = listerCours;
            coursComboBox.ValueMember = "NoCours";
            coursComboBox.DisplayMember = "NomCours";
        }

        private void viewForm_Load(object sender, EventArgs e)
        {
            RemplirComboBoxNomCours();
        }

        private void coursComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            coursRecherche = listerCours.FirstOrDefault(l => l.NoCours == coursComboBox.SelectedValue);
            sessionComboBox.DataSource = coursRecherche.TblOffreCours.ToList();
            sessionComboBox.ValueMember = "NoSession";
            sessionComboBox.DisplayMember = "NoSession";
        }

        private void sessionComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string sessionChoisi = sessionComboBox.SelectedValue.ToString();
            string noCoursChoisi = coursComboBox.SelectedValue.ToString();
            int noOffreCours = coursRecherche.TblOffreCours.Where(o => o.NoCours == noCoursChoisi && o.NoSession == sessionChoisi).FirstOrDefault().NoOffreCours;

            var managerOffreCours = new ManagerOffreCours();
            etudiantDataGridView.DataSource = managerOffreCours.listerResultat(noOffreCours);

        }
    }
}
