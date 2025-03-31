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
            button1 = new Button();
            button2 = new Button();
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
            // button1
            // 
            button1.Location = new Point(295, 12);
            button1.Name = "button1";
            button1.Size = new Size(138, 23);
            button1.TabIndex = 4;
            button1.Text = "Lister Resultats";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(467, 12);
            button2.Name = "button2";
            button2.Size = new Size(138, 23);
            button2.TabIndex = 5;
            button2.Text = "Lister Resultats";
            button2.UseVisualStyleBackColor = true;
            // 
            // ScanneurForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
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
        private Button button1;
        private Button button2;
    }
}