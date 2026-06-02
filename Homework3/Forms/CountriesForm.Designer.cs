namespace Homework3.Forms
{
    partial class CountriesForm
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
            buttonAdd = new Button();
            buttonDelete = new Button();
            textBoxName = new TextBox();
            textBoxId = new TextBox();
            buttonEdit = new Button();
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
            dataGridView1.TabIndex = 0;
            // 
            // buttonAdd
            // 
            buttonAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonAdd.Location = new Point(1150, 850);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(150, 75);
            buttonAdd.TabIndex = 2;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonDelete.Location = new Point(1550, 850);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(150, 75);
            buttonDelete.TabIndex = 4;
            buttonDelete.Text = "Del";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // textBoxName
            // 
            textBoxName.Font = new Font("Segoe UI", 19F, FontStyle.Italic);
            textBoxName.Location = new Point(600, 850);
            textBoxName.Name = "textBoxName";
            textBoxName.PlaceholderText = "Name";
            textBoxName.Size = new Size(500, 75);
            textBoxName.TabIndex = 5;
            // 
            // textBoxId
            // 
            textBoxId.Font = new Font("Segoe UI", 19F, FontStyle.Italic);
            textBoxId.Location = new Point(400, 850);
            textBoxId.Name = "textBoxId";
            textBoxId.PlaceholderText = "Id";
            textBoxId.Size = new Size(150, 75);
            textBoxId.TabIndex = 12;
            // 
            // buttonEdit
            // 
            buttonEdit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonEdit.Location = new Point(1350, 850);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(150, 75);
            buttonEdit.TabIndex = 13;
            buttonEdit.Text = "Edit";
            buttonEdit.UseVisualStyleBackColor = true;
            // 
            // CountriesForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(1774, 1129);
            Controls.Add(buttonEdit);
            Controls.Add(textBoxId);
            Controls.Add(textBoxName);
            Controls.Add(buttonDelete);
            Controls.Add(buttonAdd);
            Controls.Add(dataGridView1);
            Name = "CountriesForm";
            Text = "Countries";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button buttonAdd;
        private Button buttonDelete;
        private TextBox textBoxName;
        private TextBox textBoxId;
        private Button buttonEdit;
    }
}