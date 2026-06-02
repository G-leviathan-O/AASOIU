namespace Homework3
{
    partial class MainForm
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
            buttonCountries = new Button();
            buttonCities = new Button();
            buttonReports = new Button();
            buttonResetDatabase = new Button();
            SuspendLayout();
            // 
            // buttonCountries
            // 
            buttonCountries.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonCountries.Location = new Point(700, 200);
            buttonCountries.Name = "buttonCountries";
            buttonCountries.Size = new Size(400, 75);
            buttonCountries.TabIndex = 0;
            buttonCountries.Text = "Countries";
            buttonCountries.UseVisualStyleBackColor = true;
            buttonCountries.Click += buttonCountries_Click;
            // 
            // buttonCities
            // 
            buttonCities.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonCities.Location = new Point(700, 300);
            buttonCities.Name = "buttonCities";
            buttonCities.Size = new Size(400, 75);
            buttonCities.TabIndex = 1;
            buttonCities.Text = "Cities";
            buttonCities.UseVisualStyleBackColor = true;
            buttonCities.Click += buttonCities_Click;
            // 
            // buttonReports
            // 
            buttonReports.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonReports.Location = new Point(700, 400);
            buttonReports.Name = "buttonReports";
            buttonReports.Size = new Size(400, 75);
            buttonReports.TabIndex = 2;
            buttonReports.Text = "Reports";
            buttonReports.UseVisualStyleBackColor = true;
            buttonReports.Click += buttonReports_Click;
            // 
            // buttonResetDatabase
            // 
            buttonResetDatabase.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonResetDatabase.Location = new Point(700, 500);
            buttonResetDatabase.Name = "buttonResetDatabase";
            buttonResetDatabase.Size = new Size(400, 75);
            buttonResetDatabase.TabIndex = 3;
            buttonResetDatabase.Text = "Reset Database";
            buttonResetDatabase.UseVisualStyleBackColor = true;
            buttonResetDatabase.Click += buttonResetDatabase_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(1774, 1129);
            Controls.Add(buttonResetDatabase);
            Controls.Add(buttonReports);
            Controls.Add(buttonCities);
            Controls.Add(buttonCountries);
            Name = "MainForm";
            Text = "Main";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button buttonCountries;
        private Button buttonCities;
        private Button buttonReports;
        private Button buttonResetDatabase;
    }
}
