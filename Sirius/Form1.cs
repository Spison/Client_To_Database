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
            dataGridView1.Width = 580;
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
            dataGridView1.Columns[0].Width = 20;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 60;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 80;
            dataGridView1.Columns[6].Width = 80;
        }
        private void ReadSingleRow(DataGridView dgw,IDataRecord record)
        {
            string name = record.GetString(3)+" "+ record.GetString(1)[0]+". "+ record.GetString(2)[0]+".";//Фамилия имя отчество
            String dateUnemploy, dateEmploy;
            if (record.IsDBNull(7)) { dateEmploy = ""; } else { dateEmploy = record.GetDateTime(7).ToShortDateString(); } // Дата приёма
            if (record.IsDBNull(8)) { dateUnemploy = ""; } else { dateUnemploy = record.GetDateTime(8).ToShortDateString(); }//Дата увольнения           
            dgw.Rows.Add(record.GetInt32(0),name, record.GetString(4), record.GetString(5), record.GetString(6), dateEmploy, dateUnemploy);
        }
        private void RefreshDataGrid(DataGridView dgw,string line="")
        {
            dgw.Rows.Clear();
            database.openConnection();
            string sqlExpression = "dbo.MainQuery";
            SqlCommand command = new SqlCommand(sqlExpression, database.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter surname = new SqlParameter
            {
                ParameterName = "@surname",
                Value = line,
            };
            command.Parameters.Add(surname);
            SqlDataReader reader = command.ExecuteReader();
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
            database.openConnection();
            var line = listBox_Status.SelectedValue;
            if (line != null)
            {
                string check = line.ToString();
                labelStatus.Visible = true;
                string sqlExpression = "dbo.CountPeopleStatus";//название процедуры
                SqlCommand command = new SqlCommand(sqlExpression, database.GetConnection());
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter status = new SqlParameter
                {
                    ParameterName = "@stat",
                    Value = check,
                };
                command.Parameters.Add(status);
                SqlDataReader reader = command.ExecuteReader();
                int count = 0;
                if (reader.Read()) { count = reader.GetInt32(0); }
                labelStatus.Text = "Число работников со статусом " + line + ": " + count;               
            }    
            database.closeConnection();    
        }

        private void Button_StatisticOfEmploy_Click(object sender, EventArgs e)
        {
            var dateStart = dateTimePicker1.Value;
            var dateEnd = dateTimePicker2.Value;
            if (dateStart > dateEnd)
            {
                MessageBox.Show("Были выбраны неверные даты");
                return;
            }
            string sqlExpression = "";
            if (listBox_EmployOrUnemploy.SelectedIndex == 1) { sqlExpression = "dbo.peoplesEmployed"; }
            else if (listBox_EmployOrUnemploy.SelectedIndex == 2) { sqlExpression = "dbo.peoplesUnemployed"; }
            else return;

            database.openConnection();
            SqlCommand command = new SqlCommand(sqlExpression, database.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter dateStartParam = new SqlParameter
            {
                ParameterName = "@dateStart",
                Value = dateStart,
            };
            SqlParameter dateEndParam = new SqlParameter
            {
                ParameterName = "@dateEnd",
                Value = dateEnd,
            };
            command.Parameters.Add(dateStartParam);
            command.Parameters.Add(dateEndParam);
            string result = "";
            string name = "";
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    name = reader.GetString(0) + " " + reader.GetString(1)[0] + ". " + reader.GetString(2)[0] + ".";//Фамилия имя отчество
                    result = result + reader.GetDateTime(3).ToShortDateString() + " " + name + '\n';
                }
            }
            database.closeConnection();

            if(result == "") { result = "В указанном диапазоне записи не были обнаружены"; }
            MessageBox.Show(result,listBox_EmployOrUnemploy.Text);

            

            //database.closeConnection();

        }
    }
}
