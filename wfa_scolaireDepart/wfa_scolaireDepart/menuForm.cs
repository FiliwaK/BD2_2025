﻿using System;
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
    public partial class menuForm : Form
    {
        public menuForm()
        {
            InitializeComponent();
        }

        private void ajouterUnCoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var maForme = new ajouterCoursForm();
            maForme.ShowDialog();
        }

        private void modifierdétruireUnCoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var maForme = new modifierDetruireCoursForm();
            maForme.ShowDialog();
        }

        private void resultatDunEtudiantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var maForme = new ScanneurForm();
            maForme.ShowDialog();
        }

        private void viewEtudiantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var maForme = new viewForm();
            maForme.ShowDialog();
        }
    }
}
