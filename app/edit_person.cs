using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQlite;

namespace app
{
    public partial class edit_person : Form
    {
        private SQlite.DataBase db = new DataBase();
        private SQlite.Extensions addons = new Extensions();
        private string id = "";
        public edit_person()
        {
            InitializeComponent();
            LoadInfo();
        }
        private void LoadInfo()
        {
            group_num.Items.AddRange(Enumerable.Range(0, 11).Cast<object>().ToArray());
            foreach (var item in addons.LoadFile("groups.txt").Split(' '))
                group_name.Items.Add(item);
            foreach (var item in addons.LoadFile("departments.txt").Split(' '))
                group_department.Items.Add(item);
        }
        public void ShowInfo(string name)
        {
            var array = db.ShowInfo(name);
            id = array[0];
            student_name.Text = array[1];
            student_surname.Text = array[2];
            student_middle.Text = array[3];
            student_birth.Text = array[4];
            group_name.Text = array[5];
            group_num.Text = array[6];
            group_department.Text = array[7];
        }

        private void edit_person_info_Click(object sender, EventArgs e)
        {
            var items = AddItems();
            db.Update(items, id);
            ClearText();
            db.Refresh("0");
            this.Close();

        }
        private string[] AddItems()
        {
            var items = new string[7];
            items[0] = student_name.Text;
            items[1] = student_surname.Text;
            items[2] = student_middle.Text;
            items[3] = student_birth.Text;
            items[4] = group_name.GetItemText(group_name.SelectedItem);
            items[5] = group_num.GetItemText(group_num.SelectedItem);
            items[6] = group_department.GetItemText(group_department.SelectedItem);
            return items;
        }
        private void ClearText()
        {
            id = "";
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
