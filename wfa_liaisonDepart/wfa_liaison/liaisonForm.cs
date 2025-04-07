using Microsoft.EntityFrameworkCore;
using wfa_liaison.Models;

namespace wfa_liaison
{
    public partial class liaisonForm : Form
    {
        List<Category> categories;
        LT_biblioContext context;
        public liaisonForm()
        {
            InitializeComponent();
        }

        private void DesactiverLesColonnesEntropPourCategorie(DataGridView dataGridView)
        {
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.Columns["Livres"].Visible = false;
        }

        private void DesactiverLesColonnesEntropPourLivre(DataGridView dataGridView)
        {
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.Columns["IdLivre"].Visible = false;
            dataGridView.Columns["Isbn"].Visible = false;
            dataGridView.Columns["Resume"].Visible = false;
            dataGridView.Columns["IdCategorie"].Visible = false;
            dataGridView.Columns["IdCategorieNavigation"].Visible = false;
            dataGridView.Columns["IdAuteurs"].Visible = false;
        }

        private void eagerButton_Click(object sender, EventArgs e)
        {
            using (var context = new LT_biblioContext())
            {
                categories = context.Categories.Include(l => l.Livres).ToList();
                categorieEagerDataGridView.DataSource = categories;
                DesactiverLesColonnesEntropPourCategorie(categorieEagerDataGridView);
            }
        }

        private int PrendreLaCleChoisie(DataGridView dataGridView)
        {
            return (int)dataGridView[0, dataGridView.CurrentRow.Index].Value;
        }


        private void categorieEagerDataGridView_Click(object sender, EventArgs e)
        {
            int noCategorie = PrendreLaCleChoisie(categorieEagerDataGridView);
            var categorieRecherchee = categories.FirstOrDefault(c => c.IdCategorie == noCategorie);
            livreEagerDataGridView.DataSource = categorieRecherchee.Livres;
            DesactiverLesColonnesEntropPourLivre(livreEagerDataGridView);
        }

        private void lazyButton_Click(object sender, EventArgs e)
        {
            context = new LT_biblioContext();
            categories = context.Categories.ToList();
            categorieLazyDataGridView.DataSource = categories;
            DesactiverLesColonnesEntropPourCategorie(categorieLazyDataGridView);
        }

        private void explicitButton_Click(object sender, EventArgs e)
        {
            context = new LT_biblioContext();
            categories = context.Categories.ToList();
            categorieExplicitDataGridView.DataSource = categories;
            DesactiverLesColonnesEntropPourCategorie(categorieExplicitDataGridView);

        }

        private void categorieExplicitDataGridView_Click(object sender, EventArgs e)
        {
            int noCategorie = PrendreLaCleChoisie(categorieExplicitDataGridView);
            var categorieRecherchee = categories.FirstOrDefault(c => c.IdCategorie == noCategorie);
            context.Entry(categorieRecherchee).Collection(c => c.Livres).Load();
            livreExplicitDataGridView.DataSource = categorieRecherchee.Livres;
            DesactiverLesColonnesEntropPourLivre(livreExplicitDataGridView);
        }

        private void categorieLazyDataGridView_Click(object sender, EventArgs e)
        {
            int noCategorie = PrendreLaCleChoisie(categorieLazyDataGridView);
            var categorieRecherchee = categories.FirstOrDefault(c => c.IdCategorie == noCategorie);
            livreLazyDataGridView.DataSource = categorieRecherchee.Livres;
            DesactiverLesColonnesEntropPourLivre(livreLazyDataGridView);
        }
    }
}
