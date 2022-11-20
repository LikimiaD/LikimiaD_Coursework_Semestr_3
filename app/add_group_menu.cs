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
    public partial class add_group_menu : Form
    {
        private SQlite.DataBase db = new DataBase();
        private SQlite.Extensions ext = new Extensions();
        public add_group_menu()
        {
            InitializeComponent();
        }

        private void group_exit_Click(object sender, EventArgs e)
        {
            if (groups_text.Text.Length > 0)
                ext.AddTextToFile("groups.txt", groups_text.Text);
            if (departments_text.Text.Length > 0)
                ext.AddTextToFile("departments.txt", departments_text.Text);
            ClearText();
            this.Close();
        }
        private void ClearText()
        {
            groups_text.Clear();
            departments_text.Clear();
        }
    }
}
