namespace WindowsFormsApplication1
{
    partial class forget_pass
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
            this.que = new System.Windows.Forms.ComboBox();
            this.btn_forget = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ans = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.forgt = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pic_log = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_log)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // que
            // 
            this.que.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.que.Font = new System.Drawing.Font("Elephant", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.que.FormattingEnabled = true;
            this.que.Items.AddRange(new object[] {
            "what is your favourite team?",
            "what is the name of your pet?",
            "whats is the name of your fav.teacher?",
            "where have you born?",
            "what is your uncle\'s name?",
            "what is your favourite color?"});
            this.que.Location = new System.Drawing.Point(615, 221);
            this.que.Name = "que";
            this.que.Size = new System.Drawing.Size(204, 24);
            this.que.TabIndex = 102;
            // 
            // btn_forget
            // 
            this.btn_forget.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_forget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_forget.Font = new System.Drawing.Font("Century Gothic", 26F, System.Drawing.FontStyle.Bold);
            this.btn_forget.ForeColor = System.Drawing.Color.Chocolate;
            this.btn_forget.Location = new System.Drawing.Point(473, 391);
            this.btn_forget.Name = "btn_forget";
            this.btn_forget.Size = new System.Drawing.Size(346, 53);
            this.btn_forget.TabIndex = 101;
            this.btn_forget.Text = "Login";
            this.btn_forget.UseVisualStyleBackColor = false;
            this.btn_forget.Click += new System.EventHandler(this.btn_forget_Click);
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.name.Location = new System.Drawing.Point(615, 145);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(204, 24);
            this.name.TabIndex = 100;
            this.name.TextChanged += new System.EventHandler(this.name_TextChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Chocolate;
            this.label2.Location = new System.Drawing.Point(426, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 42);
            this.label2.TabIndex = 99;
            this.label2.Text = "User name :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.textBox1.Location = new System.Drawing.Point(615, 312);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(204, 24);
            this.textBox1.TabIndex = 98;
            // 
            // ans
            // 
            this.ans.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.ans.ForeColor = System.Drawing.Color.Chocolate;
            this.ans.Location = new System.Drawing.Point(426, 292);
            this.ans.Name = "ans";
            this.ans.Size = new System.Drawing.Size(141, 46);
            this.ans.TabIndex = 97;
            this.ans.Text = "Answer :";
            this.ans.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Chocolate;
            this.label1.Location = new System.Drawing.Point(420, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 38);
            this.label1.TabIndex = 96;
            this.label1.Text = "S.Question:";
            // 
            // forgt
            // 
            this.forgt.AutoSize = true;
            this.forgt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.forgt.Font = new System.Drawing.Font("Elephant", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forgt.ForeColor = System.Drawing.Color.DimGray;
            this.forgt.Location = new System.Drawing.Point(585, 41);
            this.forgt.Name = "forgt";
            this.forgt.Size = new System.Drawing.Size(260, 35);
            this.forgt.TabIndex = 95;
            this.forgt.Text = "Forgot Password";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.bunifuImageButton1);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 25);
            this.panel1.TabIndex = 105;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton1.Image = global::WindowsFormsApplication1.Properties.Resources.back_button_gif_4;
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(0, 3);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(46, 25);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bunifuImageButton1.TabIndex = 89;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::WindowsFormsApplication1.Properties.Resources.icons8_minimize_window_32;
            this.pictureBox5.Location = new System.Drawing.Point(887, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 25);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 32;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::WindowsFormsApplication1.Properties.Resources.icons8_cancel_32;
            this.pictureBox4.Location = new System.Drawing.Point(925, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 25);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 31;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pic_log
            // 
            this.pic_log.BackColor = System.Drawing.Color.DimGray;
            this.pic_log.ErrorImage = null;
            this.pic_log.Image = global::WindowsFormsApplication1.Properties.Resources.bad_food_choices;
            this.pic_log.Location = new System.Drawing.Point(0, 14);
            this.pic_log.Name = "pic_log";
            this.pic_log.Size = new System.Drawing.Size(397, 517);
            this.pic_log.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_log.TabIndex = 104;
            this.pic_log.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApplication1.Properties.Resources.icons8_key_50;
            this.pictureBox1.Location = new System.Drawing.Point(529, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 48);
            this.pictureBox1.TabIndex = 103;
            this.pictureBox1.TabStop = false;
            // 
            // forget_pass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pic_log);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.que);
            this.Controls.Add(this.btn_forget);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ans);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.forgt);
            this.Name = "forget_pass";
            this.Size = new System.Drawing.Size(960, 531);
            this.Load += new System.EventHandler(this.forget_pass_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_log)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox que;
        private System.Windows.Forms.Button btn_forget;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label ans;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label forgt;
        public System.Windows.Forms.PictureBox pic_log;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
    }
}
