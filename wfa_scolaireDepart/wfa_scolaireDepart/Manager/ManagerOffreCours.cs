using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wfa_scolaireDepart.Models;

namespace wfa_scolaireDepart.Manager
{
    public class ManagerOffreCours
    {
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

    }
}
