using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wfa_scolaireDepart.Models;

namespace wfa_scolaireDepart.Manager
{
    public class ManagerOffreCours
    {
        k2fl_bdContext Context;// apres ce qu'on faire des modications dans les vues, pour ne pas fermer le context

        public async Task<int?> nombreCoursSessionAsync(string session) //pour afficher dans un messagebox, procedure qui retourne un scalaire 
        {
            List<nombreCoursSessionResult> nombreDeCours;
            using (var context = new k2fl_bdContext())
            {
              nombreDeCours = await context.Procedures.nombreCoursSessionAsync(session);
            }
            return nombreDeCours.FirstOrDefault().nombredecours;
        }

        public async Task<int> nombreCoursSessionOutputAsync(string session)
        {
            var note = new OutputParameter<int?>();
            using (var context = new k2fl_bdContext())
            {
                await context.Procedures.nombreCoursSessionOutputAsync(session, note);
            }
            return (int)note.Value;
        }

        public List<VueListerResultat> listerResultat(int noOfrreCours)
        {

            Context = new k2fl_bdContext();// apres ce qu'on faire des modications dans les vues, pour ne pas fermer le context

            return Context.VueListerResultats.Where(v => v.NoOffreCours == noOfrreCours).OrderBy(v => v.Note).ToList();        

        }

        public int EnregistrerChangementNote()
        {
            int nombreLigne = 0;
            try
            {
                nombreLigne = Context.SaveChanges();

            }
            catch(Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                //if (ex.InnerException is SqlException sqlException)
                {
                    if (ex.InnerException.Message.Contains("CHECK") && ex.InnerException.Message.Contains("note"))
                    {
                        MessageBox.Show("La note doit etre entre 0 et 100");
                        var ligneErreur = ex.Entries.Single();
                        ligneErreur.Property("Note").CurrentValue = ligneErreur.Property("Note").OriginalValue;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return nombreLigne;
        }
    }
}
