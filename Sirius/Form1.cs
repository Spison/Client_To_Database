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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "siriusDataSet.status". При необходимости она может быть перемещена или удалена.
            this.statusTableAdapter.Fill(this.siriusDataSet.status);
            listBox_EmployOrUnemploy.SelectedIndex = 0;
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
            database.closeConnection();
        }
        private void ButtonFind_MouseClick(object sender, MouseEventArgs e)
        {
            string line = textBox1.Text;     
            RefreshDataGrid(dataGridView1, line);
        }

        private void ButtonRefresh_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            RefreshDataGrid(dataGridView1, "");
        }

        private void ListBox_EmployOrUnemploy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_EmployOrUnemploy.SelectedIndex != 0) { dateTimePicker1.Visible = true; dateTimePicker2.Visible = true; button_StatisticOfEmploy.Enabled = true; button_StatisticOfEmploy.Visible = true; }
            if (listBox_EmployOrUnemploy.SelectedIndex == 0) { dateTimePicker1.Visible = false; dateTimePicker2.Visible = false; button_StatisticOfEmploy.Enabled = false; button_StatisticOfEmploy.Visible = false; }
        }

        private void ListBox_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            var line = listBox_Status.SelectedValue;
            
            labelStatus.Visible = true;

            string queryString;
            queryString = $"SELECT  COUNT(*) FROM status INNER JOIN persons ON status.id = status WHERE status.name = '{line}'";

            SqlCommand cmd = new SqlCommand(queryString, database.GetConnection());
            database.openConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            labelStatus.Text = "Число работников со статусом "+line+": "+reader.GetInt32(0);
            
            database.closeConnection();
        }

        private void Button_StatisticOfEmploy_Click(object sender, EventArgs e)
        {
            var dateStart = dateTimePicker1.Value;
            var dateEnd = dateTimePicker2.Value;
            if(dateStart > dateEnd) 
            {
                MessageBox.Show("Были выбраны неверные даты");
                return;
            }
            string queryString="";
            if (listBox_EmployOrUnemploy.SelectedIndex == 1) { queryString = $"SELECT last_name, first_name, second_name, date_employ FROM persons WHERE date_employ >= '{dateStart}' AND date_employ<= '{dateEnd}'"; }
            else if (listBox_EmployOrUnemploy.SelectedIndex == 2) { queryString = $"SELECT last_name, first_name, second_name, date_uneploy FROM persons WHERE date_uneploy >= '{dateStart}' AND date_uneploy<= '{dateEnd}'"; }
            else return;

            SqlCommand cmd = new SqlCommand(queryString, database.GetConnection());
            database.openConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            string res="";
            string name;
            while (reader.Read())
            {
                name = reader.GetString(0) + " " + reader.GetString(1)[0] + ". " + reader.GetString(2)[0] + ".";//Фамилия имя отчество
                res = res+reader.GetDateTime(3).ToShortDateString()+" " + name + '\n';
            }
            if(res == "") { res = "В указанном диапазоне записи не были обнаружены"; }
            MessageBox.Show(res,listBox_EmployOrUnemploy.Text);

            

            database.closeConnection();

        }
    }
}
