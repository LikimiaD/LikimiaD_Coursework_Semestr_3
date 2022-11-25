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
        private int status = 0;

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        public main()
        {
            Load();
            InitializeComponent();
            SQlite.DataBase.dgv = datagrid;
            datagrid.ReadOnly = true;
            db.Start();
            combobox_main.Visible = false;
            apply_filter.Visible = false;
            combobox_delete.Visible = false;
            delete_group_button.Visible = false;
        }
        private void Load()
        {
            ext.RenamePath(AppDomain.CurrentDomain.BaseDirectory);
            ext.CreateFile("groups.txt");
            ext.CreateFile("departments.txt");
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
                foreach (var item in db.GetInfo(-1).Distinct().ToList())
                    combobox_main.Items.Add(item);
            }
            else
            {
                combobox_main.SelectedIndex = -1;
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
                foreach (var item in db.GetInfo(0).Distinct().ToList())
                    combobox_main.Items.Add(item);
            }
            else
            {
                combobox_main.SelectedIndex = -1;
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

        private void delete_group_button_Click(object sender, EventArgs e)
        {
            var checker = db.GetInfo(-1);
            if (checker.Contains(combobox_delete.GetItemText(combobox_delete.SelectedItem)))
            {
                MessageBox.Show("I cann't do this because this information is contained in the DataBase");
            }
            else
            {
                ext.DeleteGroup(combobox_delete.GetItemText(combobox_delete.SelectedItem));
                ClearItems();
                Console.WriteLine(status);
            }
        }
        private void ClearItems()
        {
            combobox_delete.SelectedIndex = -1;
            delete_group.Checked = false;
            combobox_delete.Visible = false;
            delete_group_button.Visible = false;
            combobox_delete.Items.Clear();
        }

        private void delete_group_CheckedChanged(object sender, EventArgs e)
        {
            if (delete_group.Checked)
            {
                combobox_delete.Visible = true;
                delete_group_button.Visible = true;
                foreach (var item in ext.LoadFile("groups.txt").Split(' '))
                    combobox_delete.Items.Add(item);
            }
            else
            {
                combobox_delete.Items.Clear();
                combobox_delete.Visible = false;
                delete_group_button.Visible = false;
                db.Refresh("0");
            }
        }

        private void load_data_Click(object sender, EventArgs e)
        {
            ext.AddTextToFile("groups.txt", "����-18 ����-19 ����-20 ����-21 ���-19 ���-20 ���-21 ���-19 ���-20 ���-21 ���-19 ���-20 ���-21 ���-19 ���-20 ���-21");
            ext.AddTextToFile("departments.txt", "���� ���� ����� ������ �� ��� ����� ����");

            string[] values = { "������� ��������� ���������� 5-5-4-5 ����-18 1 ����",
                                "��������� ���� ������������� 5-3-5-5 ����-19 2 ����",
                                "������ ����� �������� 2-3-4-5 ����-19 3 ����",
                                "������� ������ ���������� 4-3-4-3 ����-20 3 ����",

                                "������� ����� ���������� 2-2-3-2 ���-18 1 ����",
                                "��������� ����� ������������� 5-5-4-5 ���-19 2 ����",
                                "������ ��������� �������� 4-4-4-4 ���-19 3 ����",
                                "������� ������ ���������� 2-2-4-5 ���-20 3 ����",

                               "������� ����� ���������� 5-5-4-5 ����-18 1 ����",
                                "��������� ������ ������������� 5-3-4-5 ����-19 2 ����",
                                "������ ����� �������� 3-3-4-3 ����-19 3 ����",
                                "������� ���� ���������� 5-5-5-5 ����-20 3 ����",

                               "������� ������ ���������� 2-2-3-2 ���-18 1 ������",
                                "��������� ������ ������������� 5-3-4-5 ���-19 2 ������",
                                "������ ����� �������� 3-3-4-3 ���-19 3 ������",
                                "������� ����� ���������� 5-5-5-5 ���-20 3 ������"};

            foreach (var item in values)
            {
                db.Create(item.Split(' '));
            }
            db.Refresh("0");
        }
    }
}