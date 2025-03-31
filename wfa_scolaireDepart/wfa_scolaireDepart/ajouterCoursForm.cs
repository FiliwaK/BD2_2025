using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Tokens;
using wfa_scolaireDepart.Manager;
using wfa_scolaireDepart.Models;

namespace wfa_scolaireDepart
{
    public partial class ajouterCoursForm : Form
    {
        public ajouterCoursForm()
        {
            InitializeComponent();
        }

        private void ajouterCoursForm_Load(object sender, EventArgs e)
        {
            //noCoursTextBox.MaxLength = 8;
            //ponderationTextBox.MaxLength = 5;
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

        private void ViderChamps()
        {
            noCoursTextBox.Clear();
            nomCoursTextBox.Clear(); 
            ponderationTextBox.Clear();
        }

        private Boolean EstUnFormatDeCoursValid(TblCour cours)
        {
            var validationContext = new ValidationContext(cours);
            var validationResults = new List<ValidationResult>();
            bool estValide = Validator.TryValidateObject(cours, validationContext, validationResults, true);
            if (!estValide)
            {
                string messageErreur = string.Join("\n", validationResults.Select(r => r.ErrorMessage));
                MessageBox.Show(messageErreur, "Erreur de validation");
            }
            return estValide;
        }

        private void ajouterButton_Click(object sender, EventArgs e)
        {
            TblCour cours = new TblCour();
            ManagerCours managerCours = new ManagerCours();
            int nombreDeLigneAffectees = 0;

            try
            {
                if (ChampsRemplits())
                {
                    cours = RemplirInformation();
                    if (EstUnFormatDeCoursValid(cours))
                    {
                        nombreDeLigneAffectees = managerCours.AjouterCours(cours);
                        if (nombreDeLigneAffectees > 0)
                        {
                            MessageBox.Show("nombre de ligne affectées est : " + nombreDeLigneAffectees + " lignes");
                            ViderChamps();
                        }
                        else
                        {
                            MessageBox.Show("Respecter les contraintes de la base de donnée");
                        }
                    }
                    

                }
                else 
                {
                    MessageBox.Show("Remplir tous les champs");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
