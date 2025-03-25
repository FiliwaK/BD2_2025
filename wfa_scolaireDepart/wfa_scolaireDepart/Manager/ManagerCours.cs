using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wfa_scolaireDepart.Models;

namespace wfa_scolaireDepart.Manager
{
    public class ManagerCours
    {
        public int AjouterCours(TblCour cours)
        {
            int nombreDeLigneAffectees = 0;

            using(var context = new k2fl_bdContext())
            {
                //MessageBox.Show(context.Entry(cours).State.ToString());
                context.TblCours.Add(cours);
                //MessageBox.Show(context.Entry(cours).State.ToString());
                nombreDeLigneAffectees = context.SaveChanges();
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
