namespace wfa_scolaireDepart.Manager
{
    partial class viewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            coursComboBox = new ComboBox();
            sessionComboBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            etudiantDataGridView = new DataGridView();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)etudiantDataGridView).BeginInit();
            SuspendLayout();
            // 
            // coursComboBox
            // 
            coursComboBox.FormattingEnabled = true;
            coursComboBox.Location = new Point(271, 33);
            coursComboBox.Name = "coursComboBox";
            coursComboBox.Size = new Size(283, 23);
            coursComboBox.TabIndex = 0;
            coursComboBox.SelectionChangeCommitted += coursComboBox_SelectionChangeCommitted;
            // 
            // sessionComboBox
            // 
            sessionComboBox.FormattingEnabled = true;
            sessionComboBox.Location = new Point(271, 97);
            sessionComboBox.Name = "sessionComboBox";
            sessionComboBox.Size = new Size(283, 23);
            sessionComboBox.TabIndex = 1;
            sessionComboBox.SelectionChangeCommitted += sessionComboBox_SelectionChangeCommitted;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(176, 36);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 2;
            label1.Text = "Cours";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(176, 100);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 3;
            label2.Text = "Session";
            // 
            // etudiantDataGridView
            // 
            etudiantDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            etudiantDataGridView.Location = new Point(100, 171);
            etudiantDataGridView.Name = "etudiantDataGridView";
            etudiantDataGridView.Size = new Size(577, 246);
            etudiantDataGridView.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(100, 153);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 5;
            label3.Text = "Etudiants";
            // 
            // viewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(etudiantDataGridView);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(sessionComboBox);
            Controls.Add(coursComboBox);
            Name = "viewForm";
            Text = "viewForm";
            Load += viewForm_Load;
            ((System.ComponentModel.ISupportInitialize)etudiantDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox coursComboBox;
        private ComboBox sessionComboBox;
        private Label label1;
        private Label label2;
        private DataGridView etudiantDataGridView;
        private Label label3;
    }
}