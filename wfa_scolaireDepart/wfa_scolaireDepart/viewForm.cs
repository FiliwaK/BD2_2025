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
        List<TblCour> listerCours;

        public viewForm()
        {
            InitializeComponent();
        }

        private void RemplirComboBoxNomCours()
        {
            ManagerCours managerCours = new ManagerCours();
            listerCours = managerCours.Listercours();
            coursComboBox.DataSource = listerCours;
            coursComboBox.ValueMember = "NoCours";
            coursComboBox.DisplayMember = "NomCours";
        }

        private void viewForm_Load(object sender, EventArgs e)
        {
            RemplirComboBoxNomCours();
        }
    }
}
