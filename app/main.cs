using SQlite;
namespace app
{
    public partial class main : Form
    {
        private add_menu FormPerson = new add_menu();
        private add_group_menu FormGroup = new add_group_menu();
        private SQlite.DataBase db = new DataBase();
        private SQlite.Extensions ext = new Extensions();
        public main()
        {
            ext.RenamePath(System.AppDomain.CurrentDomain.BaseDirectory);
            ext.CreateFile("groups.txt");
            ext.CreateFile("departments.txt");
            InitializeComponent();
            SQlite.DataBase.dgv = datagrid;
            datagrid.ReadOnly = true;
            db.Start();
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
    }
}