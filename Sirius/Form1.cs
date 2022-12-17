using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sirius
{  
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class Form1 : Form
    {
        DataBase database = new DataBase();
        int selectedRow;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateColums();
            RefreshDataGrid(dataGridView1,"");
        }
        private void CreateColums()
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("Name", "Фамилия И.О.");
            dataGridView1.Columns.Add("Status", "Статус");
            dataGridView1.Columns.Add("Deps", "Отдел");
            dataGridView1.Columns.Add("Post", "Должность");
            dataGridView1.Columns.Add("date_employ", "Дата приёма");
            dataGridView1.Columns.Add("date_uneploy", "Дата увольнения");
            dataGridView1.Columns.Add("IsNew",String.Empty);
            dataGridView1.Columns[0].Width = 20;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 60;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 80;
            dataGridView1.Columns[6].Width = 80;
            dataGridView1.Columns[7].Width = 20;
        }
        private void ReadSingleRow(DataGridView dgw,IDataRecord record)
        {
            string name = record.GetString(3)+" "+ record.GetString(1)[0]+". "+ record.GetString(2)[0]+".";//Фамилия имя отчество
            String dateUnemploy, dateEmploy;
            if (record.IsDBNull(7)) { dateEmploy = ""; } else { dateEmploy = record.GetDateTime(7).ToShortDateString(); } // Дата приёма
            if (record.IsDBNull(8)) { dateUnemploy = ""; } else { dateUnemploy = record.GetDateTime(8).ToShortDateString(); }//Дата увольнения           
            dgw.Rows.Add(record.GetInt32(0),name, record.GetString(4), record.GetString(5), record.GetString(6), dateEmploy, dateUnemploy, RowState.ModifiedNew);
        }
        private void RefreshDataGrid(DataGridView dgw,string line="")
        {
            dgw.Rows.Clear();
            string queryString;
            queryString = $"SELECT          persons.id, persons.first_name, persons.second_name, persons.last_name, status.name, deps.name, posts.name, persons.date_employ, persons.date_uneploy FROM persons INNER JOIN    posts ON persons.id_post = posts.id INNER JOIN    status ON persons.status = status.id INNER JOIN    deps ON persons.id_dep = deps.id WHERE last_name LIKE'%{line}%'";
            
            SqlCommand cmd = new SqlCommand(queryString, database.GetConnection());
            database.openConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }
        private void buttonFind_MouseClick(object sender, MouseEventArgs e)
        {
            string line = textBox1.Text;     
            RefreshDataGrid(dataGridView1, line);
        }

        private void buttonRefresh_MouseClick(object sender, MouseEventArgs e)
        {
            RefreshDataGrid(dataGridView1, "");
        }
    }
}
