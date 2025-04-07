namespace wfa_liaison
{
    partial class liaisonForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            livreExplicitDataGridView = new DataGridView();
            livreLazyDataGridView = new DataGridView();
            categorieExplicitDataGridView = new DataGridView();
            categorieLazyDataGridView = new DataGridView();
            explicitButton = new Button();
            lazyButton = new Button();
            categorieEagerDataGridView = new DataGridView();
            livreEagerDataGridView = new DataGridView();
            eagerButton = new Button();
            ((System.ComponentModel.ISupportInitialize)livreExplicitDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)livreLazyDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)categorieExplicitDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)categorieLazyDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)categorieEagerDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)livreEagerDataGridView).BeginInit();
            SuspendLayout();
            // 
            // livreExplicitDataGridView
            // 
            livreExplicitDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            livreExplicitDataGridView.Location = new Point(1097, 287);
            livreExplicitDataGridView.Margin = new Padding(3, 2, 3, 2);
            livreExplicitDataGridView.Name = "livreExplicitDataGridView";
            livreExplicitDataGridView.RowHeadersWidth = 51;
            livreExplicitDataGridView.Size = new Size(538, 142);
            livreExplicitDataGridView.TabIndex = 28;
            // 
            // livreLazyDataGridView
            // 
            livreLazyDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            livreLazyDataGridView.Location = new Point(554, 287);
            livreLazyDataGridView.Margin = new Padding(3, 2, 3, 2);
            livreLazyDataGridView.Name = "livreLazyDataGridView";
            livreLazyDataGridView.RowHeadersWidth = 51;
            livreLazyDataGridView.Size = new Size(538, 142);
            livreLazyDataGridView.TabIndex = 27;
            // 
            // categorieExplicitDataGridView
            // 
            categorieExplicitDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            categorieExplicitDataGridView.Location = new Point(1097, 86);
            categorieExplicitDataGridView.Margin = new Padding(3, 2, 3, 2);
            categorieExplicitDataGridView.Name = "categorieExplicitDataGridView";
            categorieExplicitDataGridView.RowHeadersWidth = 51;
            categorieExplicitDataGridView.Size = new Size(538, 148);
            categorieExplicitDataGridView.TabIndex = 26;
            categorieExplicitDataGridView.Click += categorieExplicitDataGridView_Click;
            // 
            // categorieLazyDataGridView
            // 
            categorieLazyDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            categorieLazyDataGridView.Location = new Point(554, 86);
            categorieLazyDataGridView.Margin = new Padding(3, 2, 3, 2);
            categorieLazyDataGridView.Name = "categorieLazyDataGridView";
            categorieLazyDataGridView.RowHeadersWidth = 51;
            categorieLazyDataGridView.Size = new Size(538, 148);
            categorieLazyDataGridView.TabIndex = 25;
            categorieLazyDataGridView.Click += categorieLazyDataGridView_Click;
            // 
            // explicitButton
            // 
            explicitButton.Location = new Point(1281, 21);
            explicitButton.Margin = new Padding(3, 2, 3, 2);
            explicitButton.Name = "explicitButton";
            explicitButton.Size = new Size(126, 50);
            explicitButton.TabIndex = 24;
            explicitButton.Text = "explicit loading";
            explicitButton.UseVisualStyleBackColor = true;
            explicitButton.Click += explicitButton_Click;
            // 
            // lazyButton
            // 
            lazyButton.Location = new Point(640, 21);
            lazyButton.Margin = new Padding(3, 2, 3, 2);
            lazyButton.Name = "lazyButton";
            lazyButton.Size = new Size(126, 50);
            lazyButton.TabIndex = 23;
            lazyButton.Text = "lazy loading";
            lazyButton.UseVisualStyleBackColor = true;
            lazyButton.Click += lazyButton_Click;
            // 
            // categorieEagerDataGridView
            // 
            categorieEagerDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            categorieEagerDataGridView.Location = new Point(10, 86);
            categorieEagerDataGridView.Margin = new Padding(3, 2, 3, 2);
            categorieEagerDataGridView.Name = "categorieEagerDataGridView";
            categorieEagerDataGridView.RowHeadersWidth = 51;
            categorieEagerDataGridView.Size = new Size(538, 148);
            categorieEagerDataGridView.TabIndex = 22;
            categorieEagerDataGridView.Click += categorieEagerDataGridView_Click;
            // 
            // livreEagerDataGridView
            // 
            livreEagerDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            livreEagerDataGridView.Location = new Point(10, 287);
            livreEagerDataGridView.Margin = new Padding(3, 2, 3, 2);
            livreEagerDataGridView.Name = "livreEagerDataGridView";
            livreEagerDataGridView.RowHeadersWidth = 51;
            livreEagerDataGridView.Size = new Size(538, 142);
            livreEagerDataGridView.TabIndex = 21;
            // 
            // eagerButton
            // 
            eagerButton.Location = new Point(10, 21);
            eagerButton.Margin = new Padding(3, 2, 3, 2);
            eagerButton.Name = "eagerButton";
            eagerButton.Size = new Size(126, 50);
            eagerButton.TabIndex = 20;
            eagerButton.Text = "eager loading";
            eagerButton.UseVisualStyleBackColor = true;
            eagerButton.Click += eagerButton_Click;
            // 
            // liaisonForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1662, 479);
            Controls.Add(livreExplicitDataGridView);
            Controls.Add(livreLazyDataGridView);
            Controls.Add(categorieExplicitDataGridView);
            Controls.Add(categorieLazyDataGridView);
            Controls.Add(explicitButton);
            Controls.Add(lazyButton);
            Controls.Add(categorieEagerDataGridView);
            Controls.Add(livreEagerDataGridView);
            Controls.Add(eagerButton);
            Margin = new Padding(3, 2, 3, 2);
            Name = "liaisonForm";
            Text = "Les liaisons de données";
            ((System.ComponentModel.ISupportInitialize)livreExplicitDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)livreLazyDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)categorieExplicitDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)categorieLazyDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)categorieEagerDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)livreEagerDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView livreExplicitDataGridView;
        private DataGridView livreLazyDataGridView;
        private DataGridView categorieExplicitDataGridView;
        private DataGridView categorieLazyDataGridView;
        private Button explicitButton;
        private Button lazyButton;
        private DataGridView categorieEagerDataGridView;
        private DataGridView livreEagerDataGridView;
        private Button eagerButton;
    }
}
