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
    }
}
