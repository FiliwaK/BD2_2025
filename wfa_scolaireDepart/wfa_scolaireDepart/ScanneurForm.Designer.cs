namespace wfa_scolaireDepart
{
    partial class ScanneurForm
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
            listerButton = new Button();
            noDaTextBox = new TextBox();
            resultatDataGridView = new DataGridView();
            label1 = new Label();
            spButton = new Button();
            spOutputButton = new Button();
            label2 = new Label();
            sessionTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)resultatDataGridView).BeginInit();
            SuspendLayout();
            // 
            // listerButton
            // 
            listerButton.Location = new Point(619, 67);
            listerButton.Name = "listerButton";
            listerButton.Size = new Size(138, 23);
            listerButton.TabIndex = 0;
            listerButton.Text = "Lister Resultats";
            listerButton.UseVisualStyleBackColor = true;
            listerButton.Click += listerButton_Click;
            // 
            // noDaTextBox
            // 
            noDaTextBox.Location = new Point(202, 64);
            noDaTextBox.Name = "noDaTextBox";
            noDaTextBox.Size = new Size(382, 23);
            noDaTextBox.TabIndex = 1;
            // 
            // resultatDataGridView
            // 
            resultatDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resultatDataGridView.Location = new Point(93, 139);
            resultatDataGridView.Name = "resultatDataGridView";
            resultatDataGridView.Size = new Size(627, 258);
            resultatDataGridView.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(120, 67);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 3;
            label1.Text = "No DA";
            // 
            // spButton
            // 
            spButton.Location = new Point(158, 12);
            spButton.Name = "spButton";
            spButton.Size = new Size(234, 23);
            spButton.TabIndex = 4;
            spButton.Text = "nombre de cours par session";
            spButton.UseVisualStyleBackColor = true;
            spButton.Click += spButton_Click;
            // 
            // spOutputButton
            // 
            spOutputButton.Location = new Point(421, 12);
            spOutputButton.Name = "spOutputButton";
            spOutputButton.Size = new Size(213, 23);
            spOutputButton.TabIndex = 5;
            spOutputButton.Text = "nombre de par session output";
            spOutputButton.UseVisualStyleBackColor = true;
            spOutputButton.Click += spOutputButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(120, 113);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 7;
            label2.Text = "Session";
            // 
            // sessionTextBox
            // 
            sessionTextBox.Location = new Point(202, 110);
            sessionTextBox.Name = "sessionTextBox";
            sessionTextBox.Size = new Size(151, 23);
            sessionTextBox.TabIndex = 6;
            // 
            // ScanneurForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(sessionTextBox);
            Controls.Add(spOutputButton);
            Controls.Add(spButton);
            Controls.Add(label1);
            Controls.Add(resultatDataGridView);
            Controls.Add(noDaTextBox);
            Controls.Add(listerButton);
            Name = "ScanneurForm";
            Text = "ScanneurForm";
            ((System.ComponentModel.ISupportInitialize)resultatDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button listerButton;
        private TextBox noDaTextBox;
        private DataGridView resultatDataGridView;
        private Label label1;
        private Button spButton;
        private Button spOutputButton;
        private Label label2;
        private TextBox sessionTextBox;
    }
}