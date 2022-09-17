﻿namespace LoadingScreen
{
    partial class LoginScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginScreen));
            this.usertxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.passtxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.signup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usertxt
            // 
            this.usertxt.Location = new System.Drawing.Point(406, 99);
            this.usertxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usertxt.Name = "usertxt";
            this.usertxt.Size = new System.Drawing.Size(152, 23);
            this.usertxt.TabIndex = 0;
            this.usertxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usertxt_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(267, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email ID :";
            // 
            // passtxt
            // 
            this.passtxt.Location = new System.Drawing.Point(406, 161);
            this.passtxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.passtxt.Name = "passtxt";
            this.passtxt.PasswordChar = '*';
            this.passtxt.Size = new System.Drawing.Size(152, 23);
            this.passtxt.TabIndex = 1;
            this.passtxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passtxt_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(260, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password :";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MidnightBlue;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.LimeGreen;
            this.button2.Location = new System.Drawing.Point(249, 219);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 35);
            this.button2.TabIndex = 6;
            this.button2.Text = "Login";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.LimeGreen;
            this.label4.Location = new System.Drawing.Point(294, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 29);
            this.label4.TabIndex = 9;
            this.label4.Text = "STUDENT LOGIN";
            // 
            // signup
            // 
            this.signup.BackColor = System.Drawing.Color.MidnightBlue;
            this.signup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.signup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signup.FlatAppearance.BorderSize = 0;
            this.signup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signup.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.signup.ForeColor = System.Drawing.Color.LimeGreen;
            this.signup.Location = new System.Drawing.Point(438, 219);
            this.signup.Name = "signup";
            this.signup.Size = new System.Drawing.Size(133, 35);
            this.signup.TabIndex = 10;
            this.signup.Text = "Sign Up";
            this.signup.UseVisualStyleBackColor = false;
            this.signup.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(595, 285);
            this.Controls.Add(this.signup);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passtxt);
            this.Controls.Add(this.usertxt);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginScreen_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginScreen_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox usertxt;
        private Label label1;
        private TextBox passtxt;
        private Label label3;
        private Button button2;
        private Label label4;
        private Button signup;
    }
}