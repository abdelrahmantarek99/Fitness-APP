namespace WindowsFormsApplication1
{
    partial class Rate_feedback
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.bunifuRating1 = new Bunifu.Framework.UI.BunifuRating();
            this.feedback = new System.Windows.Forms.TextBox();
            this.submitFeedback = new System.Windows.Forms.Button();
            this.submitRate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SeaGreen;
            this.panel1.Location = new System.Drawing.Point(84, 79);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 36);
            this.panel1.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(96, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 36);
            this.label1.TabIndex = 37;
            this.label1.Text = "Rate Us";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SeaGreen;
            this.panel2.Location = new System.Drawing.Point(84, 239);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 36);
            this.panel2.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(96, 239);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(604, 36);
            this.label4.TabIndex = 35;
            this.label4.Text = "Do you have any addtional feedback for us ?";
            // 
            // bunifuRating1
            // 
            this.bunifuRating1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuRating1.ForeColor = System.Drawing.Color.SeaGreen;
            this.bunifuRating1.Location = new System.Drawing.Point(267, 143);
            this.bunifuRating1.Name = "bunifuRating1";
            this.bunifuRating1.Size = new System.Drawing.Size(237, 39);
            this.bunifuRating1.TabIndex = 31;
            this.bunifuRating1.Value = 0;
            this.bunifuRating1.onValueChanged += new System.EventHandler(this.bunifuRating1_onValueChanged);
            // 
            // feedback
            // 
            this.feedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feedback.ForeColor = System.Drawing.Color.Gray;
            this.feedback.Location = new System.Drawing.Point(96, 279);
            this.feedback.Margin = new System.Windows.Forms.Padding(2);
            this.feedback.Multiline = true;
            this.feedback.Name = "feedback";
            this.feedback.Size = new System.Drawing.Size(604, 135);
            this.feedback.TabIndex = 34;
            // 
            // submitFeedback
            // 
            this.submitFeedback.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.submitFeedback.Cursor = System.Windows.Forms.Cursors.Hand;
            this.submitFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitFeedback.Location = new System.Drawing.Point(267, 417);
            this.submitFeedback.Name = "submitFeedback";
            this.submitFeedback.Size = new System.Drawing.Size(237, 35);
            this.submitFeedback.TabIndex = 32;
            this.submitFeedback.Text = "Submit";
            this.submitFeedback.UseVisualStyleBackColor = false;
            this.submitFeedback.Click += new System.EventHandler(this.submitFeedback_Click);
            // 
            // submitRate
            // 
            this.submitRate.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.submitRate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.submitRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitRate.Location = new System.Drawing.Point(267, 201);
            this.submitRate.Name = "submitRate";
            this.submitRate.Size = new System.Drawing.Size(237, 35);
            this.submitRate.TabIndex = 33;
            this.submitRate.Text = "Submit";
            this.submitRate.UseVisualStyleBackColor = false;
            this.submitRate.Click += new System.EventHandler(this.submitRate_Click);
            // 
            // Rate_feedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bunifuRating1);
            this.Controls.Add(this.feedback);
            this.Controls.Add(this.submitFeedback);
            this.Controls.Add(this.submitRate);
            this.Name = "Rate_feedback";
            this.Size = new System.Drawing.Size(785, 531);
            this.Load += new System.EventHandler(this.Rate_feedback_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuRating bunifuRating1;
        private System.Windows.Forms.TextBox feedback;
        private System.Windows.Forms.Button submitFeedback;
        private System.Windows.Forms.Button submitRate;
    }
}
