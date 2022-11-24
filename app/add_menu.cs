using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using SQlite;
using static System.Net.Mime.MediaTypeNames;

namespace app
{
    public partial class add_menu : Form
    {
        SQlite.DataBase db = new DataBase();
        SQlite.Extensions addons = new SQlite.Extensions();
        public add_menu()
        {
            InitializeComponent();
        }
        public void LoadGroupsInfo()
        {
            group_name.Items.Clear();
            group_num.Items.Clear();
            group_department.Items.Clear();
            group_num.Items.AddRange(Enumerable.Range(1, 11).Cast<object>().ToArray());
            foreach (var item in addons.LoadFile("groups.txt").Split(' '))
                group_name.Items.Add(item);
            foreach (var item in addons.LoadFile("departments.txt").Split(' '))
                group_department.Items.Add(item);
        }

        private void add_person_Click(object sender, EventArgs e)
        {
            if ((student_name.Text.Length != 0) && (student_surname.Text.Length != 0) && (student_middle.Text.Length != 0) &&
                (student_birth.Text.Length != 0 || (int.TryParse(student_birth.Text, out int numericValue))))
            {
                string[] items = {student_name.Text, student_surname.Text, student_middle.Text, student_birth.Text, group_name.GetItemText(group_name.SelectedItem),
                          group_num.GetItemText(group_num.SelectedItem), group_department.GetItemText(group_department.SelectedItem)};
                db.Create(items);
                db.Refresh("0");
                ClearText();
                this.Close();
            }
            else
            {
                MessageBox.Show("Одно из полей студента не правильно заполнено");
            }
        }
        private void ClearText()
        {
            group_department.SelectedIndex = group_name.SelectedIndex = group_num.SelectedIndex = -1;
            student_name.Clear();
            student_surname.Clear();
            student_middle.Clear();
            student_birth.Clear();
            group_name.Items.Clear();
            group_num.Items.Clear();
            group_department.Items.Clear();
        }
    }
}
