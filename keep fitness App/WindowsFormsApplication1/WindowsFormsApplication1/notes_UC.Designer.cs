namespace WindowsFormsApplication1
{
    partial class notes_UC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(notes_UC));
            this.NotesList = new System.Windows.Forms.ListBox();
            this.DeleteNotesBtn = new System.Windows.Forms.Button();
            this.AddNotesBtn = new System.Windows.Forms.Button();
            this.EditeNotesBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NotesList
            // 
            this.NotesList.BackColor = System.Drawing.SystemColors.Window;
            this.NotesList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NotesList.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotesList.ForeColor = System.Drawing.Color.Black;
            this.NotesList.FormattingEnabled = true;
            this.NotesList.ItemHeight = 24;
            this.NotesList.Location = new System.Drawing.Point(36, 74);
            this.NotesList.Name = "NotesList";
            this.NotesList.Size = new System.Drawing.Size(676, 360);
            this.NotesList.TabIndex = 102;
            this.NotesList.SelectedIndexChanged += new System.EventHandler(this.NotesList_SelectedIndexChanged);
            // 
            // DeleteNotesBtn
            // 
            this.DeleteNotesBtn.BackColor = System.Drawing.Color.Transparent;
            this.DeleteNotesBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeleteNotesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteNotesBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DeleteNotesBtn.Image = ((System.Drawing.Image)(resources.GetObject("DeleteNotesBtn.Image")));
            this.DeleteNotesBtn.Location = new System.Drawing.Point(675, 5);
            this.DeleteNotesBtn.Name = "DeleteNotesBtn";
            this.DeleteNotesBtn.Size = new System.Drawing.Size(37, 48);
            this.DeleteNotesBtn.TabIndex = 103;
            this.DeleteNotesBtn.UseVisualStyleBackColor = false;
            this.DeleteNotesBtn.Click += new System.EventHandler(this.DeleteNotesBtn_Click);
            // 
            // AddNotesBtn
            // 
            this.AddNotesBtn.BackColor = System.Drawing.Color.Transparent;
            this.AddNotesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddNotesBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AddNotesBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddNotesBtn.Image")));
            this.AddNotesBtn.Location = new System.Drawing.Point(589, 5);
            this.AddNotesBtn.Name = "AddNotesBtn";
            this.AddNotesBtn.Size = new System.Drawing.Size(37, 48);
            this.AddNotesBtn.TabIndex = 104;
            this.AddNotesBtn.UseVisualStyleBackColor = false;
            this.AddNotesBtn.Click += new System.EventHandler(this.AddNotesBtn_Click);
            // 
            // EditeNotesBtn
            // 
            this.EditeNotesBtn.BackColor = System.Drawing.Color.Transparent;
            this.EditeNotesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditeNotesBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EditeNotesBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditeNotesBtn.Image")));
            this.EditeNotesBtn.Location = new System.Drawing.Point(632, 5);
            this.EditeNotesBtn.Name = "EditeNotesBtn";
            this.EditeNotesBtn.Size = new System.Drawing.Size(37, 48);
            this.EditeNotesBtn.TabIndex = 105;
            this.EditeNotesBtn.UseVisualStyleBackColor = false;
            this.EditeNotesBtn.Click += new System.EventHandler(this.EditeNotesBtn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(543, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 48);
            this.button1.TabIndex = 106;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // notes_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DeleteNotesBtn);
            this.Controls.Add(this.AddNotesBtn);
            this.Controls.Add(this.NotesList);
            this.Controls.Add(this.EditeNotesBtn);
            this.Controls.Add(this.button1);
            this.Name = "notes_UC";
            this.Size = new System.Drawing.Size(785, 531);
            this.Load += new System.EventHandler(this.notes_UC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button DeleteNotesBtn;
        public System.Windows.Forms.Button AddNotesBtn;
        public System.Windows.Forms.ListBox NotesList;
        public System.Windows.Forms.Button EditeNotesBtn;
        public System.Windows.Forms.Button button1;
    }
}
