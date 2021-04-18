namespace WindowsFormsApplication1
{
    partial class Notes2_UC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SaveNoteeBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NotesTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SaveNoteeBtn
            // 
            this.SaveNoteeBtn.BackColor = System.Drawing.Color.SeaShell;
            this.SaveNoteeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveNoteeBtn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveNoteeBtn.ForeColor = System.Drawing.Color.Teal;
            this.SaveNoteeBtn.Location = new System.Drawing.Point(593, 418);
            this.SaveNoteeBtn.Name = "SaveNoteeBtn";
            this.SaveNoteeBtn.Size = new System.Drawing.Size(110, 34);
            this.SaveNoteeBtn.TabIndex = 70;
            this.SaveNoteeBtn.Text = "Save";
            this.SaveNoteeBtn.UseVisualStyleBackColor = false;
            this.SaveNoteeBtn.Click += new System.EventHandler(this.SaveNoteeBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(19, 8);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(208, 25);
            this.label1.TabIndex = 69;
            this.label1.Text = "Write your Notes .... ";
            // 
            // NotesTextbox
            // 
            this.NotesTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotesTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.NotesTextbox.Location = new System.Drawing.Point(24, 36);
            this.NotesTextbox.Multiline = true;
            this.NotesTextbox.Name = "NotesTextbox";
            this.NotesTextbox.Size = new System.Drawing.Size(679, 376);
            this.NotesTextbox.TabIndex = 68;
            // 
            // Notes2_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SaveNoteeBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NotesTextbox);
            this.Name = "Notes2_UC";
            this.Size = new System.Drawing.Size(785, 531);
            this.Load += new System.EventHandler(this.Notes2_UC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button SaveNoteeBtn;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox NotesTextbox;
    }
}
