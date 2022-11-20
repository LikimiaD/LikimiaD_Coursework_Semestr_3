namespace app
{
    partial class main
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
            this.add_person = new System.Windows.Forms.Button();
            this.datagrid = new System.Windows.Forms.DataGridView();
            this.group_info = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // add_person
            // 
            this.add_person.Location = new System.Drawing.Point(759, 12);
            this.add_person.Name = "add_person";
            this.add_person.Size = new System.Drawing.Size(95, 39);
            this.add_person.TabIndex = 0;
            this.add_person.Text = "Add Person";
            this.add_person.UseVisualStyleBackColor = true;
            this.add_person.Click += new System.EventHandler(this.add_person_Click);
            // 
            // datagrid
            // 
            this.datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid.Location = new System.Drawing.Point(0, 0);
            this.datagrid.Name = "datagrid";
            this.datagrid.RowTemplate.Height = 25;
            this.datagrid.Size = new System.Drawing.Size(749, 438);
            this.datagrid.TabIndex = 1;
            // 
            // group_info
            // 
            this.group_info.Location = new System.Drawing.Point(759, 57);
            this.group_info.Name = "group_info";
            this.group_info.Size = new System.Drawing.Size(95, 39);
            this.group_info.TabIndex = 2;
            this.group_info.Text = "Add Group Info";
            this.group_info.UseVisualStyleBackColor = true;
            this.group_info.Click += new System.EventHandler(this.group_info_Click);
            // 
            // delete_button
            // 
            this.delete_button.Location = new System.Drawing.Point(759, 392);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(95, 39);
            this.delete_button.TabIndex = 3;
            this.delete_button.Text = "Delete Person";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 443);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.group_info);
            this.Controls.Add(this.datagrid);
            this.Controls.Add(this.add_person);
            this.Name = "main";
            this.Text = "Main DB";
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button add_person;
        private DataGridView datagrid;
        private Button group_info;
        private Button delete_button;
    }
}