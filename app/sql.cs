using System.Data.SQLite;
using System.Data;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Xml.Linq;
using System.Text.RegularExpressions;

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
            return good_line.Length > 1 ? good_line.Remove(good_line.Length - 1) : good_line;
        }
        public void DeleteGroup(string name)
        {
            string testFile = File.ReadAllText("groups.txt");
            if (testFile.IndexOf(name[0]) != -1 || testFile.IndexOf(name[0]) != 0)
                testFile = testFile.Replace(" " + name, "");
            else
                testFile = testFile.Replace(name + " ", "");
            File.WriteAllText("groups.txt", testFile);
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
        public void Refresh(string form, string name = "")
        {
            sqlite_conn = CreateConnection();
            DisplayTable(sqlite_conn, form, name);
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
        public void Update(string[] items, string id)
        {
            sqlite_conn = CreateConnection();
            UpdatePerson(sqlite_conn, items, id);
        }
        public string[] ShowInfo(string id)
        {
            string[] array = new string[8];
            string sqlExpression = $"SELECT * FROM Students WHERE ID == '{id}'";
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; "))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i <= 7; i++)
                                array[i] = reader.GetValue(i).ToString();
                        }
                    }
                }
            }
            return array;
        }
        public List<string> GetInfo(int id)
        {
            var value = id == 0 ? "Surname" : "Group_Name";
            var list_ = new List<string>();
            string sqlExpression = $"SELECT {value} FROM Students";
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; "))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                list_.Add(reader.GetValue(i).ToString());
                            }
                        }
                    }
                }
            }
            return list_;
        }
        public List<string> LoadInfo(string value)
        {
            var list_ = new List<string>();
            string sqlExpression = $"SELECT {value} FROM Students";
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; "))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                list_.Add(reader.GetValue(i).ToString());
                            }
                        }
                    }
                }
            }
            return list_;
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
            string Createsql = "create table if not exists Students(ID INTEGER PRIMARY KEY AUTOINCREMENT," +
                                                                    "'Name' VARCHAR(100)," +
                                                                    "'Surname' VARCHAR(100)," +
                                                                    "'Middle_Name' VARCHAR(100)," +
                                                                    "'Marks' VARCHAR(100)," +
                                                                    "'Group_Name' VARCHAR(100)," +
                                                                    "'Group_Num' INT," +
                                                                    "'Group_Department' VARCHAR(100))";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();
        }
        private void DisplayTable(SQLiteConnection conn, string form, string name = "")
        {
            string sql = "";
            if (form == "0")
                sql = ("SELECT * FROM Students");
            if (form == "1")
                sql = ($"SELECT * FROM Students WHERE Group_Name = '{name}'");
            if (form == "2")
                sql = ($"SELECT * FROM Students WHERE Surname = '{name}'");
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
                string sql = "INSERT INTO Students (Name, 'Surname', 'Middle_Name', 'Marks'," +
                    "'Group_Name', 'Group_Num', 'Group_Department') " +
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
        private void UpdatePerson(SQLiteConnection conn, string[] items, string id)
        {
            try
            {
                SQLiteCommand sqlite_cmd;
                string sql = $"UPDATE Students SET Name = '{items[0]}', 'Surname' = '{items[1]}', " +
                    $"'Middle_Name' = '{items[2]}', 'Marks' = '{items[3]}'," +
                    $"'Group_Name' = '{items[4]}', 'Group_Num' = '{items[5]}', 'Group_Department' = '{items[6]}' " +
                    $"WHERE ID = '{id}'";
                sqlite_cmd = conn.CreateCommand();
                sqlite_cmd.CommandText = sql;
                sqlite_cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void DeleteStudent(SQLiteConnection conn, string id)
        {
            SQLiteCommand sqlite_cmd;
            string sql = $"DELETE FROM Students WHERE ID == '{id}'";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = sql;
            sqlite_cmd.ExecuteNonQuery();
        }
    }
}
