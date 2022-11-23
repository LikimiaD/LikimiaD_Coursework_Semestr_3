using SQlite;
using System.Data;
using System.Runtime.InteropServices;

namespace app
{
    public partial class main : Form
    {
        private add_menu FormPerson = new add_menu();
        private add_group_menu FormGroup = new add_group_menu();
        private edit_person FormEdit = new edit_person();
        private SQlite.DataBase db = new DataBase();
        private SQlite.Extensions ext = new Extensions();
        private int filter_status = 0;

        public main()
        {
            ext.RenamePath(System.AppDomain.CurrentDomain.BaseDirectory);
            ext.CreateFile("groups.txt");
            ext.CreateFile("departments.txt");
            InitializeComponent();
            SQlite.DataBase.dgv = datagrid;
            datagrid.ReadOnly = true;
            db.Start();
            combobox_main.Visible = false;
            apply_filter.Visible = false;
        }

        private void add_person_Click(object sender, EventArgs e)
        {
            FormPerson.LoadGroupsInfo();
            FormPerson.ShowDialog();
        }

        private void group_info_Click(object sender, EventArgs e)
        {
            FormGroup.ShowDialog();
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            try
            {
                int rowindex = datagrid.CurrentCell.RowIndex;
                db.Delete(datagrid.Rows[rowindex].Cells[0].Value.ToString());
                db.Refresh("0");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private void group_filter_CheckedChanged(object sender, EventArgs e)
        {
            if (filter_status == 0)
            {
                combobox_main.Visible = true;
                apply_filter.Visible = true;
                surname_filter.Enabled = false;
                filter_status = 1;
                foreach (var item in db.Surnames(-1))
                    combobox_main.Items.Add(item);
            }
            else
            {
                combobox_main.Items.Clear();
                combobox_main.Visible = false;
                apply_filter.Visible = false;
                filter_status = 0;
                surname_filter.Enabled = true;
                db.Refresh("0");
            }
        }

        private void surname_filter_CheckedChanged(object sender, EventArgs e)
        {
            if (filter_status == 0)
            {
                combobox_main.Visible = true;
                apply_filter.Visible = true;
                group_filter.Enabled = false;
                filter_status = 2;
                foreach (var item in db.Surnames(0))
                    combobox_main.Items.Add(item);
            }
            else
            {
                combobox_main.Items.Clear();
                combobox_main.Visible = false;
                apply_filter.Visible = false;
                group_filter.Enabled = true;
                filter_status = 0;
                db.Refresh("0");
            }
        }

        private void apply_filter_Click(object sender, EventArgs e)
        {
            if(filter_status == 1)
            {
                db.Refresh("1", combobox_main.GetItemText(combobox_main.SelectedItem));
            }
            if (filter_status == 2)
            {
                db.Refresh("2", combobox_main.GetItemText(combobox_main.SelectedItem));
            }
        }

        private void edit_person_Click(object sender, EventArgs e)
        {
            int rowindex = datagrid.CurrentCell.RowIndex;
            FormEdit.ShowInfo(datagrid.Rows[rowindex].Cells[0].Value.ToString());
            FormEdit.ShowDialog();
        }
    }
}