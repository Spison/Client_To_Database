namespace Sirius
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.listBox_Status = new System.Windows.Forms.ListBox();
            this.statusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.siriusDataSet = new Sirius.SiriusDataSet();
            this.listBox_EmployOrUnemploy = new System.Windows.Forms.ListBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.button_StatisticOfEmploy = new System.Windows.Forms.Button();
            this.statusTableAdapter = new Sirius.SiriusDataSetTableAdapters.statusTableAdapter();
            this.labelStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.siriusDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(37, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(687, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackgroundImage = global::Sirius.Properties.Resources.refresh_update_icon_142975;
            this.buttonRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonRefresh.Location = new System.Drawing.Point(684, 24);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(40, 40);
            this.buttonRefresh.TabIndex = 1;
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonRefresh_MouseClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(37, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(588, 20);
            this.textBox1.TabIndex = 2;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackgroundImage = global::Sirius.Properties.Resources.search_icon;
            this.buttonSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonSearch.Location = new System.Drawing.Point(638, 24);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(40, 40);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonFind_MouseClick);
            // 
            // listBox_Status
            // 
            this.listBox_Status.DataSource = this.statusBindingSource;
            this.listBox_Status.DisplayMember = "name";
            this.listBox_Status.FormattingEnabled = true;
            this.listBox_Status.Location = new System.Drawing.Point(37, 256);
            this.listBox_Status.Name = "listBox_Status";
            this.listBox_Status.Size = new System.Drawing.Size(120, 30);
            this.listBox_Status.TabIndex = 4;
            this.listBox_Status.ValueMember = "name";
            this.listBox_Status.SelectedIndexChanged += new System.EventHandler(this.ListBox_Status_SelectedIndexChanged);
            // 
            // statusBindingSource
            // 
            this.statusBindingSource.DataMember = "status";
            this.statusBindingSource.DataSource = this.siriusDataSet;
            // 
            // siriusDataSet
            // 
            this.siriusDataSet.DataSetName = "SiriusDataSet";
            this.siriusDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // listBox_EmployOrUnemploy
            // 
            this.listBox_EmployOrUnemploy.FormattingEnabled = true;
            this.listBox_EmployOrUnemploy.Items.AddRange(new object[] {
            "(нет)",
            "Принятые",
            "Уволенные"});
            this.listBox_EmployOrUnemploy.Location = new System.Drawing.Point(37, 292);
            this.listBox_EmployOrUnemploy.Name = "listBox_EmployOrUnemploy";
            this.listBox_EmployOrUnemploy.Size = new System.Drawing.Size(120, 43);
            this.listBox_EmployOrUnemploy.TabIndex = 5;
            this.listBox_EmployOrUnemploy.SelectedIndexChanged += new System.EventHandler(this.ListBox_EmployOrUnemploy_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(183, 289);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(425, 289);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 7;
            // 
            // button_StatisticOfEmploy
            // 
            this.button_StatisticOfEmploy.Location = new System.Drawing.Point(342, 315);
            this.button_StatisticOfEmploy.Name = "button_StatisticOfEmploy";
            this.button_StatisticOfEmploy.Size = new System.Drawing.Size(127, 23);
            this.button_StatisticOfEmploy.TabIndex = 8;
            this.button_StatisticOfEmploy.Text = "Получить статистику";
            this.button_StatisticOfEmploy.UseVisualStyleBackColor = true;
            this.button_StatisticOfEmploy.Click += new System.EventHandler(this.Button_StatisticOfEmploy_Click);
            // 
            // statusTableAdapter
            // 
            this.statusTableAdapter.ClearBeforeFill = true;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(183, 256);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(35, 13);
            this.labelStatus.TabIndex = 9;
            this.labelStatus.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.button_StatisticOfEmploy);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.listBox_EmployOrUnemploy);
            this.Controls.Add(this.listBox_Status);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.siriusDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ListBox listBox_Status;
        private System.Windows.Forms.ListBox listBox_EmployOrUnemploy;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button button_StatisticOfEmploy;
        private SiriusDataSet siriusDataSet;
        private System.Windows.Forms.BindingSource statusBindingSource;
        private SiriusDataSetTableAdapters.statusTableAdapter statusTableAdapter;
        private System.Windows.Forms.Label labelStatus;
    }
}

