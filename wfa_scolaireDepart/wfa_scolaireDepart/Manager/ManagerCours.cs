using System;
using System.Collections.Generic;
//using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using wfa_scolaireDepart.Models;

namespace wfa_scolaireDepart.Manager
{
    public class ManagerCours
    {
        public List<TblCour> ListerCoursEagerLoading()
        {
            try
            {
                using (var context = new k2fl_bdContext())
                {
                    return context.TblCours.Include(c => c.TblOffreCours).OrderBy(c=> c.NomCours).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AjouterCours(TblCour cours)
        {
            int nombreDeLigneAffectees = 0;

            try
            {


                using(var context = new k2fl_bdContext())
                {
                //MessageBox.Show(context.Entry(cours).State.ToString());
                context.TblCours.Add(cours);
                //MessageBox.Show(context.Entry(cours).State.ToString());
                nombreDeLigneAffectees = context.SaveChanges();
                }

            }
            catch (DbUpdateException ExDbUpdate)
            {
                var errorMessage = "Erreur, corrigez puis réessayer. \n\r";
                if (ExDbUpdate.InnerException is SqlException sqlException)
                {
                    if (sqlException.Number == 2628 && sqlException.Message.Contains("pond"))
                    {
                        errorMessage += $"la ponderation est trop longue. \n\r";
                    }
                    else 
                    {
                        errorMessage += $" Error Number: {sqlException.Number}\n\r Message: {sqlException.Message}\n\r";
                    }


                }
                throw new Exception(errorMessage);
            }
            catch (Exception)
            {
                throw;
            }

            return nombreDeLigneAffectees;

        }

        public List<TblCour> Listercours()
        {
            using(var context = new k2fl_bdContext())
            {
                return context.TblCours.OrderBy(c => c.NomCours).ToList(); // pour retourner toute la liste des cours dans la bd en ordre
            }   
        }

        public int ModifierCours(TblCour cour)
        {
            int nombreDeLigneAffectees = 0;

            using (var context = new k2fl_bdContext())
            {
                var courAModifie = context.TblCours.Find(cour.NoCours);
                //MessageBox.Show(context.Entry(courAModifie).State.ToString());
                courAModifie.NoCours = cour.NoCours;
                courAModifie.NomCours = cour.NomCours;
                courAModifie.Pond = cour.Pond;
                //MessageBox.Show(context.Entry(courAModifie).State.ToString());
                nombreDeLigneAffectees = context.SaveChanges();
            }
            return nombreDeLigneAffectees ;
        }

        public int ModifierCoursAttach(TblCour courModif, TblCour coursNonModif)
        {
            int nombreDeLigneAffectees = 0;

            using (var context = new k2fl_bdContext())
            {
                //MessageBox.Show(context.Entry(coursNonModif).State.ToString());
                context.TblCours.Attach(coursNonModif); // coursNonModif c'est un objet trouver a partir d'un combo box , un objet existant 
                //MessageBox.Show(context.Entry(coursNonModif).State.ToString());
                coursNonModif.NoCours = courModif.NoCours;
                coursNonModif.NomCours = courModif.NomCours;
                coursNonModif.Pond = courModif.Pond;
                //MessageBox.Show(context.Entry(coursNonModif).State.ToString());
                nombreDeLigneAffectees = context.SaveChanges();
            }
            return nombreDeLigneAffectees;
        }

        public int DetruireCours(TblCour cour)
        {
            int nombreDeLigneAffectees = 0;

            using (var context = new k2fl_bdContext())
            {
                var courASupprimer = context.TblCours.Find(cour.NoCours);
                //MessageBox.Show(context.Entry(courAModifie).State.ToString());
                context.TblCours.Remove(courASupprimer);
                //MessageBox.Show(context.Entry(courAModifie).State.ToString());
                nombreDeLigneAffectees = context.SaveChanges();
            }
            return nombreDeLigneAffectees;
        }


    }
}
