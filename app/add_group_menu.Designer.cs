namespace app
{
    partial class add_group_menu
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groups_text = new System.Windows.Forms.TextBox();
            this.departments_text = new System.Windows.Forms.TextBox();
            this.group_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(488, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter group or department information separated by a space in order or leave a bl" +
    "ank space";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(9, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Groups";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(9, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Departments";
            // 
            // groups_text
            // 
            this.groups_text.Location = new System.Drawing.Point(146, 81);
            this.groups_text.Name = "groups_text";
            this.groups_text.Size = new System.Drawing.Size(351, 23);
            this.groups_text.TabIndex = 3;
            // 
            // departments_text
            // 
            this.departments_text.Location = new System.Drawing.Point(146, 125);
            this.departments_text.Name = "departments_text";
            this.departments_text.Size = new System.Drawing.Size(351, 23);
            this.departments_text.TabIndex = 4;
            // 
            // group_exit
            // 
            this.group_exit.Location = new System.Drawing.Point(191, 164);
            this.group_exit.Name = "group_exit";
            this.group_exit.Size = new System.Drawing.Size(110, 35);
            this.group_exit.TabIndex = 5;
            this.group_exit.Text = "Add Information";
            this.group_exit.UseVisualStyleBackColor = true;
            this.group_exit.Click += new System.EventHandler(this.group_exit_Click);
            // 
            // add_group_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 211);
            this.Controls.Add(this.group_exit);
            this.Controls.Add(this.departments_text);
            this.Controls.Add(this.groups_text);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "add_group_menu";
            this.Text = "Information about Groups and Departments";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox groups_text;
        private TextBox departments_text;
        private Button group_exit;
    }
}