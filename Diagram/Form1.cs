using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Net.Mime.MediaTypeNames;

namespace Diagram
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadTXT(1, "Group_Department");
            LoadTXT(2, "Surname");
            chart2.Titles.Add("Статистика повторений имен");
            Chart1.Titles.Add("Диаграмма факультетов");

        }
        async private void LoadTXT(int id, string value)
        {
            string path = id == 1 ? @"c:\Data\Group_Department.txt" : @"c:\Data\Surname.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string text = await reader.ReadToEndAsync();
                string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var result = words.GroupBy(x => x)
                                  .Where(x => x.Count() > 1)
                                  .Select(x => new { Word = x.Key, Frequency = x.Count() });
                foreach (var item in result)
                {
                    if (id == 1)
                    {
                        Chart1.Series["s1"].Points.AddXY(item.Word, item.Frequency);
                    }
                    else
                    {
                        chart2.Series["s1"].Points.AddXY(item.Word, item.Frequency);
                    }
                }
            }
        }
    }
}
