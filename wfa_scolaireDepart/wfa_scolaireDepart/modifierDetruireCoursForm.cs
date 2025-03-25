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
using wfa_scolaireDepart.Models;

namespace wfa_scolaireDepart
{
    public partial class modifierDetruireCoursForm : Form
    {
        public modifierDetruireCoursForm()
        {
            InitializeComponent();
        }

        private void modifierDetruireCoursForm_Load(object sender, EventArgs e)
        {
            RemplirComboBoxDeCours();
            noCoursTextBox.Enabled = false;
        }

        private void RemplirComboBoxDeCours()
        {
            try
            {
                var managerCours = new ManagerCours();
                nomCoursComboBox.DataSource = managerCours.Listercours();
                nomCoursComboBox.DisplayMember = "NomCours";//nom de colonne dans la classe ; pas dans la base de donnée
                nomCoursComboBox.ValueMember = "NoCours"; // la clé dans la classe
                nomCoursComboBox.DropDownStyle = ComboBoxStyle.DropDownList;//empeche d'ecrire dans le combobox juste selectionner 
                nomCoursComboBox.SelectedValue = ""; // pour qu'il n y ait pas de selection au debut
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void nomCoursComboBox_SelectionChangeCommitted(object sender, EventArgs e)//afin de remplir les textbox a partir du combobox 
        {
            TblCour cours = nomCoursComboBox.SelectedItem as TblCour;
            noCoursTextBox.Text = cours.NoCours.ToString();
            nomCoursTextBox.Text = cours.NomCours.ToString();
            //ponderationTextBox.Text = cours.Pond.ToString();
            ponderationTextBox.Text = cours.Pond ?? ""; // si c'est null ca met vide 
        }

        private void modifierButton_Click(object sender, EventArgs e)
        {
            TblCour cours;
            int nombreDeLigneAffectees = 0;

            try
            {
                ManagerCours managerCours = new ManagerCours();
                if (ChampsRemplits())
                {
                    cours = RemplirInformation();
                    nombreDeLigneAffectees = managerCours.ModifierCours(cours);
                    if (nombreDeLigneAffectees > 0)
                    {
                        MessageBox.Show("Modification reussie");
                        ViderChamps();
                        RemplirComboBoxDeCours();
                    }
                }
                else
                {
                    MessageBox.Show("entrez toutes les valeurs");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViderChamps()
        {
            noCoursTextBox.Clear();
            nomCoursTextBox.Clear();
            ponderationTextBox.Clear();
        }

        private Boolean ChampsRemplits()
        {
            return (!string.IsNullOrEmpty(noCoursTextBox.Text)
                && !string.IsNullOrEmpty(nomCoursTextBox.Text)
                && !string.IsNullOrEmpty(ponderationTextBox.Text));
        }

        private TblCour RemplirInformation()
        {
            TblCour cours = new TblCour();

            cours.NoCours = noCoursTextBox.Text;
            cours.NomCours = nomCoursTextBox.Text;
            cours.Pond = ponderationTextBox.Text;

            return cours;
        }

        private void modifAttachButton_Click(object sender, EventArgs e)
        {
            TblCour courModif;
            int nombreDeLigneAffectees = 0;

            try
            {
                ManagerCours managerCours = new ManagerCours();
                if (ChampsRemplits())
                {
                    TblCour courNonModif = nomCoursComboBox.SelectedItem as TblCour;
                    courModif = RemplirInformation();
                    nombreDeLigneAffectees = managerCours.ModifierCoursAttach(courModif, courNonModif);
                    if (nombreDeLigneAffectees > 0)
                    {
                        MessageBox.Show("Modification reussie");
                        ViderChamps();
                        RemplirComboBoxDeCours();
                    }
                }
                else
                {
                    MessageBox.Show("entrez toutes les valeurs");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void detruireButton_Click(object sender, EventArgs e)
        {
            TblCour cours;
            int nombreDeLigneAffectees = 0;

            try
            {
                ManagerCours managerCours = new ManagerCours();
                if (ChampsRemplits())
                {
                    cours = RemplirInformation();
                    nombreDeLigneAffectees = managerCours.DetruireCours(cours);
                    if (nombreDeLigneAffectees > 0)
                    {
                        MessageBox.Show("Suppression reussie");
                        ViderChamps();
                        RemplirComboBoxDeCours();
                    }
                }
                else
                {
                    MessageBox.Show("n'existe pas");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void detruireAttachButton_Click(object sender, EventArgs e)
        {

        }
    }

}
