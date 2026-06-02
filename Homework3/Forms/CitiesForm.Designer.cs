namespace Homework3.Forms
{
    partial class CitiesForm
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
            dataGridView1 = new DataGridView();
            buttonDelete = new Button();
            buttonEdit = new Button();
            buttonAdd = new Button();
            comboBoxCountry = new ComboBox();
            textBoxName = new TextBox();
            textBoxPopulation = new TextBox();
            textBoxId = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(100, 100);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(1600, 700);
            dataGridView1.TabIndex = 3;
            // 
            // buttonDelete
            // 
            buttonDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonDelete.Location = new Point(1550, 850);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(150, 75);
            buttonDelete.TabIndex = 7;
            buttonDelete.Text = "Del";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonEdit.Location = new Point(1350, 850);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(150, 75);
            buttonEdit.TabIndex = 6;
            buttonEdit.Text = "Edit";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonAdd.Location = new Point(1150, 850);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(150, 75);
            buttonAdd.TabIndex = 5;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // comboBoxCountry
            // 
            comboBoxCountry.Font = new Font("Segoe UI", 19F, FontStyle.Bold | FontStyle.Italic);
            comboBoxCountry.FormattingEnabled = true;
            comboBoxCountry.Location = new Point(850, 850);
            comboBoxCountry.Name = "comboBoxCountry";
            comboBoxCountry.Size = new Size(250, 76);
            comboBoxCountry.TabIndex = 8;
            // 
            // textBoxName
            // 
            textBoxName.Font = new Font("Segoe UI", 19F, FontStyle.Italic);
            textBoxName.Location = new Point(300, 850);
            textBoxName.Name = "textBoxName";
            textBoxName.PlaceholderText = "Name";
            textBoxName.Size = new Size(250, 75);
            textBoxName.TabIndex = 9;
            // 
            // textBoxPopulation
            // 
            textBoxPopulation.Font = new Font("Segoe UI", 19F, FontStyle.Italic);
            textBoxPopulation.Location = new Point(600, 850);
            textBoxPopulation.Name = "textBoxPopulation";
            textBoxPopulation.PlaceholderText = "Popul.";
            textBoxPopulation.Size = new Size(200, 75);
            textBoxPopulation.TabIndex = 10;
            // 
            // textBoxId
            // 
            textBoxId.Font = new Font("Segoe UI", 19F, FontStyle.Italic);
            textBoxId.Location = new Point(100, 850);
            textBoxId.Name = "textBoxId";
            textBoxId.PlaceholderText = "Id";
            textBoxId.Size = new Size(150, 75);
            textBoxId.TabIndex = 11;
            // 
            // CitiesForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(1774, 1129);
            Controls.Add(textBoxId);
            Controls.Add(textBoxPopulation);
            Controls.Add(textBoxName);
            Controls.Add(comboBoxCountry);
            Controls.Add(buttonDelete);
            Controls.Add(buttonEdit);
            Controls.Add(buttonAdd);
            Controls.Add(dataGridView1);
            Name = "CitiesForm";
            Text = "Cities";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private Button buttonDelete;
        private Button buttonEdit;
        private Button buttonAdd;
        private ComboBox comboBoxCountry;
        private TextBox textBoxName;
        private TextBox textBoxPopulation;
        private TextBox textBoxId;
    }
}