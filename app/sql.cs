using System.Data.SQLite;
using System.Data;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

namespace SQlite
{
    public partial class Extensions
    {
        private string path;
        public void RenamePath(string name)
        {
            path = name;
        }
        async public void CreateFile(string filename)
        {
            if (!(File.Exists(path)))
                using (FileStream fstream = new FileStream(path + filename, FileMode.OpenOrCreate))
                {
                    byte[] buffer = Encoding.Default.GetBytes("");
                    await fstream.WriteAsync(buffer, 0, buffer.Length);
                }
        }
        public void AddTextToFile(string filename, string text)
        {
            var legitcheck = CheckRepeat(filename, text);
            if (legitcheck.Length > 0)
            File.AppendAllText(path + filename, " " + legitcheck);
        }
        private string CheckRepeat(string filename, string text)
        {
            var error_line = "";
            var good_line = "";
            var textfile = LoadFile(filename).Split(' ');
            foreach (var item in text.Split(' '))
            {
                if (textfile.Contains(item))
                    error_line += item + " ";
                else
                    good_line += item + " ";
            }
            if (error_line.Length > 0)
                MessageBox.Show($"Couldn't add in {filename}: {error_line}");
            return good_line;
        }
        public string LoadFile(string filename)
        {
            return File.ReadAllText(path+ filename);
        }
    }
    public partial class DataBase
    {
        public static DataGridView dgv = new DataGridView();
        private static SQLiteDataAdapter da = new SQLiteDataAdapter();
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        private SQLiteConnection sqlite_conn = new SQLiteConnection();
        public void Start()
        {
            sqlite_conn = CreateConnection();
            CreateTable(sqlite_conn);
            DisplayTable(sqlite_conn, "0");
        }
        public void Refresh(string form)
        {
            sqlite_conn = CreateConnection();
            DisplayTable(sqlite_conn, form);
        }
        public void Create(string[] items)
        {
            sqlite_conn = CreateConnection();
            Add(sqlite_conn, items);
        }
        public void Delete(string id)
        {
            sqlite_conn = CreateConnection();
            DeleteStudent(sqlite_conn, id);
        }
        static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception)
            {

            }
            return sqlite_conn;
        }

        private void CreateTable(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            string Createsql = "create table if not exists Students('Name' VARCHAR(100)," +
                                                                    "'Last Name' VARCHAR(100)," +
                                                                    "'Middle Name' VARCHAR(100) UNIQUE," +
                                                                    "'Date of Birth' VARCHAR(100)," +
                                                                    "'Group Name' VARCHAR(100)," +
                                                                    "'Group Num' INT," +
                                                                    "'Group Department' VARCHAR(100))";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();
        }
        private void DisplayTable(SQLiteConnection conn, string form)
        {
            string sql = "";
            if (form == "0")
                sql = ("SELECT * FROM Students");
            if (form == "1")
                sql = ("SELECT * FROM Students");
            da = new SQLiteDataAdapter(sql, conn);
            ds.Reset(); da.Fill(ds);
            dt = ds.Tables[0];
            dgv.DataSource = dt;
        }
        private void Add(SQLiteConnection conn, string[] items)
        {
            try
            {
                SQLiteCommand sqlite_cmd;
                string sql = "INSERT INTO Students (Name, 'Last Name', 'Middle Name', 'Date of Birth'," +
                    "'Group Name', 'Group Num', 'Group Department') " +
                    $"VALUES ('{items[0]}','{items[1]}','{items[2]}','{items[3]}'," +
                    $"'{items[4]}','{items[5]}','{items[6]}')";
                sqlite_cmd = conn.CreateCommand();
                sqlite_cmd.CommandText = sql;
                sqlite_cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void DeleteStudent(SQLiteConnection conn, string name)
        {
            SQLiteCommand sqlite_cmd;
            string sql = $"DELETE FROM Students WHERE Name ='{name}'";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = sql;
            sqlite_cmd.ExecuteNonQuery();
        }
    }
}
