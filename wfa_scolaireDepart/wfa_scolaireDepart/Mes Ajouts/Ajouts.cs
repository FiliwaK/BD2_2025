using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace wfa_scolaireDepart.Models
{
        public partial class k2fl_bdContext : DbContext
        {
            partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<VueListerResultat>(entity =>
                {
                    entity.HasKey(i => new { i.NoDa, i.NoOffreCours });
                    entity.UpdateUsingStoredProcedure("ModifierNoteEtudiant", sp =>
                    {
                        sp.HasOriginalValueParameter(i => i.NoDa);
                        sp.HasOriginalValueParameter(i => i.NoOffreCours);
                        sp.HasParameter(i => i.Note);
                        sp.HasParameter(i => i.Nom);
                        sp.HasParameter(i => i.Prenom);
                    });
                    entity.ToTable("TblInscription", i => i.ExcludeFromMigrations());
                });
            }
        }
}
