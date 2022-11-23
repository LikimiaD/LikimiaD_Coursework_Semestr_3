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
            this.label1 = new System.Windows.Forms.Label();
            this.group_filter = new System.Windows.Forms.CheckBox();
            this.surname_filter = new System.Windows.Forms.CheckBox();
            this.combobox_main = new System.Windows.Forms.ComboBox();
            this.apply_filter = new System.Windows.Forms.Button();
            this.edit_person = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // add_person
            // 
            this.add_person.Location = new System.Drawing.Point(886, 12);
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
            this.datagrid.Size = new System.Drawing.Size(876, 438);
            this.datagrid.TabIndex = 1;
            // 
            // group_info
            // 
            this.group_info.Location = new System.Drawing.Point(886, 57);
            this.group_info.Name = "group_info";
            this.group_info.Size = new System.Drawing.Size(95, 39);
            this.group_info.TabIndex = 2;
            this.group_info.Text = "Add Group Info";
            this.group_info.UseVisualStyleBackColor = true;
            this.group_info.Click += new System.EventHandler(this.group_info_Click);
            // 
            // delete_button
            // 
            this.delete_button.Location = new System.Drawing.Point(886, 392);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(95, 39);
            this.delete_button.TabIndex = 3;
            this.delete_button.Text = "Delete Person";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(882, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filter";
            // 
            // group_filter
            // 
            this.group_filter.AutoSize = true;
            this.group_filter.Location = new System.Drawing.Point(886, 131);
            this.group_filter.Name = "group_filter";
            this.group_filter.Size = new System.Drawing.Size(74, 19);
            this.group_filter.TabIndex = 5;
            this.group_filter.Text = "By group\n";
            this.group_filter.UseVisualStyleBackColor = true;
            this.group_filter.CheckedChanged += new System.EventHandler(this.group_filter_CheckedChanged);
            // 
            // surname_filter
            // 
            this.surname_filter.AutoSize = true;
            this.surname_filter.Location = new System.Drawing.Point(886, 156);
            this.surname_filter.Name = "surname_filter";
            this.surname_filter.Size = new System.Drawing.Size(88, 19);
            this.surname_filter.TabIndex = 6;
            this.surname_filter.Text = "By surname";
            this.surname_filter.UseVisualStyleBackColor = true;
            this.surname_filter.CheckedChanged += new System.EventHandler(this.surname_filter_CheckedChanged);
            // 
            // combobox_main
            // 
            this.combobox_main.FormattingEnabled = true;
            this.combobox_main.Location = new System.Drawing.Point(882, 181);
            this.combobox_main.Name = "combobox_main";
            this.combobox_main.Size = new System.Drawing.Size(99, 23);
            this.combobox_main.TabIndex = 7;
            // 
            // apply_filter
            // 
            this.apply_filter.Location = new System.Drawing.Point(886, 210);
            this.apply_filter.Name = "apply_filter";
            this.apply_filter.Size = new System.Drawing.Size(88, 23);
            this.apply_filter.TabIndex = 8;
            this.apply_filter.Text = "Apply filter";
            this.apply_filter.UseVisualStyleBackColor = true;
            this.apply_filter.Click += new System.EventHandler(this.apply_filter_Click);
            // 
            // edit_person
            // 
            this.edit_person.Location = new System.Drawing.Point(886, 347);
            this.edit_person.Name = "edit_person";
            this.edit_person.Size = new System.Drawing.Size(95, 39);
            this.edit_person.TabIndex = 9;
            this.edit_person.Text = "Edit Person";
            this.edit_person.UseVisualStyleBackColor = true;
            this.edit_person.Click += new System.EventHandler(this.edit_person_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 443);
            this.Controls.Add(this.edit_person);
            this.Controls.Add(this.apply_filter);
            this.Controls.Add(this.combobox_main);
            this.Controls.Add(this.surname_filter);
            this.Controls.Add(this.group_filter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.group_info);
            this.Controls.Add(this.datagrid);
            this.Controls.Add(this.add_person);
            this.Name = "main";
            this.Text = "Main DB";
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button add_person;
        private DataGridView datagrid;
        private Button group_info;
        private Button delete_button;
        private Label label1;
        private CheckBox group_filter;
        private CheckBox surname_filter;
        private ComboBox combobox_main;
        private Button apply_filter;
        private Button edit_person;
    }
}