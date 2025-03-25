using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wfa_scolaireDepart.Models;

namespace wfa_scolaireDepart.Manager
{
    public class ManagerEtudiant
    {
        public async Task<List<ListerResultatEtudiantResult>> ListerCoursEtudiant(string noDa)
        {
            using (var context = new k2fl_bdContext())
            {
                return await context.Procedures.ListerResultatEtudiantAsync(noDa);
            }
        }

    }
}
