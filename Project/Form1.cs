using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
     public partial class Form1 : Form
    {
        static SqlConnection SqlConnection;
        public Dobavit dobavit;
        public Izmenit izmenit;
        public Delete delete;
        static Form1 form;
        private static string x = "";
        

        public static void GetFirstObject(Form1 f)
        {
            form = f;
        }
        public Form1()
        {
            form = this;
            dobavit = new Dobavit();
            izmenit = new Izmenit();
            delete = new Delete();
            InitializeComponent();
        }

       public static async void Form1_Load(object sender, EventArgs e)
        {
            
            string connectionSTR = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\WindowsFormsApp2\Database1.mdf;Integrated Security=True";
            SqlConnection SqlConnection = new SqlConnection(connectionSTR);
            await SqlConnection.OpenAsync();
        }

        private void выходToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            form.BackgroundImage = new Bitmap(@"C:\Users\User\source\repos\WindowsFormsApp2\tank.jpg");
            comboBox1.Text = "";
            dataGridView1.Rows.Clear();
            dataGridView1.Visible = false;
            dataGridView1.Enabled = false;
            tabControl1.Visible = false;
            tabControl1.Enabled = false;
            label1.Visible = true;
            comboBox1.Visible = true;
            button1.Visible = true;
            button1.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox1.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox1.Text = "";
            textBox2.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox10.Clear();
            
        }

        private async void Выбрать_Click(object sender, EventArgs e)
        {
            x = comboBox1.Text;
            if (x=="")
            {
                MessageBox.Show("Ошибка.Выберите подразделение");
                выходToolStripMenuItem_Click_1( sender,  e);
                return;
            }
        
            form.BackgroundImage = new Bitmap(@"C:\Users\User\source\repos\WindowsFormsApp2\Безымянный.png");


            if (!String.IsNullOrEmpty(comboBox1.Text) && !String.IsNullOrWhiteSpace(comboBox1.Text))
            {
               
                if (x == "Офицеры")
                {

                    comboBox4.Visible = true;
                    comboBox4.Enabled = true;
                    comboBox6.Visible = true;
                    comboBox6.Enabled = true;
                    comboBox5.Visible = false;
                    comboBox5.Enabled = false;
                    comboBox7.Visible = false;
                    comboBox7.Enabled = false;
                    comboBox3.Visible = false;
                    comboBox3.Enabled = false;
                    comboBox2.Visible = false;
                    comboBox2.Enabled = false;
                }
              

                 if (x == "Прапорщики")
                {
                    comboBox5.Visible = true;
                    comboBox5.Enabled = true;
                    comboBox7.Visible = true;
                    comboBox7.Enabled = true;
                    comboBox3.Visible = false;
                    comboBox3.Enabled = false;
                    comboBox2.Visible = false;
                    comboBox2.Enabled = false;
                    comboBox4.Visible = false;
                    comboBox4.Enabled = false;
                    comboBox6.Visible = false;
                    comboBox6.Enabled = false;

                }
                if (x != "Офицеры" && x != "Прапорщики")
                {
                    comboBox3.Visible = true;
                    comboBox3.Enabled = true;
                    comboBox2.Visible = true;
                    comboBox2.Enabled = true;
                    comboBox5.Visible = false;
                    comboBox5.Enabled = false;
                    comboBox7.Visible = false;
                    comboBox7.Enabled = false;
                    comboBox4.Visible = false;
                    comboBox4.Enabled = false;
                    comboBox6.Visible = false;
                    comboBox6.Enabled = false;

                }

            }
            else
            {
                MessageBox.Show("Выберите подразделение");
                
            }
            label1.Visible = false;
            comboBox1.Visible = false;
            button1.Visible = false;
            tabControl1.Visible = true;
            tabControl1.Enabled = true;
            dataGridView1.Visible = true;
            dataGridView1.Enabled = true;
            button1.Enabled = false;
            comboBox1.Enabled = false;
           
            SqlDataReader sqlDataReader = null;

            string connectionSTR = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\WindowsFormsApp2\Database1.mdf;Integrated Security=True";
            SqlConnection SqlConnection = new SqlConnection(connectionSTR);
            await SqlConnection.OpenAsync();
            SqlCommand command = new SqlCommand("SELECT * FROM [" + x + "]", SqlConnection);
                List<string[]> data = new List<string[]>();
                try
                {
                    sqlDataReader = await command.ExecuteReaderAsync();
                    while (await sqlDataReader.ReadAsync())
                    {
                        data.Add(new string[37]);
                        int b = 33;

                        bool i = true;
                        for (i = true; i != false;)
                        {
                            for (int c = 0; c <= b; i = false)
                            {
                                data[data.Count - 1][c] = sqlDataReader[c].ToString();
                                c++;
                            }
                        }
                    }
                    foreach (string[] s in data)

                        dataGridView1.Rows.Add(s);
                }

                finally
                {
                    if (sqlDataReader != null)
                        sqlDataReader.Close();
                }
            
        }

       
        public async void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionSTR = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\WindowsFormsApp2\Database1.mdf;Integrated Security=True";
            SqlConnection SqlConnection = new SqlConnection(connectionSTR);
            await SqlConnection.OpenAsync();
            dataGridView1.Rows.Clear();
            SqlDataReader sqlDataReader = null;
            string x = comboBox1.Text;
            SqlCommand Command = new SqlCommand("SELECT * FROM ["+x+"]", SqlConnection);
            try
            {
                sqlDataReader = await Command.ExecuteReaderAsync();                List<string[]> data = new List<string[]>();

                while (await sqlDataReader.ReadAsync())
                {
                    data.Add(new string[37]);
                    int b = 33;

                    bool i = true;
                    for (i = true; i != false;)
                    {
                        for (int c = 0; c <= b; i = false)
                        {
                            data[data.Count - 1][c] = sqlDataReader[c].ToString();
                            c++;

                        }
                    }
                }
                foreach (string[] s in data)
                    dataGridView1.Rows.Add(s);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (sqlDataReader != null)
                    sqlDataReader.Close();
            }
        }
    

        public async void Изменить_Click(object sender, EventArgs e)            
        {
            Form1_Load(sender, e);
           izmenit.izmen(sender, e, SqlConnection, form);
        }

        private async void Удалить_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
            delete.ydal(sender, e, SqlConnection, form);
        }

        private async void button5_Click(object sender, EventArgs e)
        {
          
            if (!string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text)
                 )
            {
                
                numericUpDown1.Maximum = 31;
                numericUpDown1.Minimum = 1;
                decimal i;

                if (numericUpDown1.Minimum <= numericUpDown1.Value && numericUpDown1.Value <= numericUpDown1.Maximum)
                {
                    i = numericUpDown1.Value;

                    string connectionSTR = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\WindowsFormsApp2\Database1.mdf;Integrated Security=True";
                    SqlConnection SqlConnection = new SqlConnection(connectionSTR);
                    await SqlConnection.OpenAsync();
                    i = i + 1;
                    string b = i.ToString();
                    string x = comboBox1.Text;
                    SqlCommand sqlCommand = new SqlCommand("UPDATE [" + x + "] SET [" + b + "]=@" + b + " WHERE [Id]=@Id", SqlConnection);
                    sqlCommand.Parameters.AddWithValue("Id", textBox8.Text);
                    sqlCommand.Parameters.AddWithValue(b, "Н");
                    await sqlCommand.ExecuteNonQueryAsync();
                    обновитьToolStripMenuItem_Click(sender, e);
                    textBox8.Clear();
                    numericUpDown1.Value = 1;
                    MessageBox.Show("Наряд успешно добавлен");
                }
                else
                {
                    MessageBox.Show("Ошибка.Выберите число месяца");
                }

                

            }

        }

        

        private async void Добавить_Click_(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
            dobavit.Dobavit1(sender, e, SqlConnection, form);
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Приложение «График нарядов 1.0.»" +
"Только для служебного пользования." +
"                                                                                                                                                                                                                                                                                                                                                                                              "+
"Приложение осуществляет визуализацию информации о состоянии нарядов в подразделении на текущий месяц.Приложение дает пользователю возможность редактировать данную таблицу, а именно:      " +
"                                                                                                                                                                                                                                                    " +
"1.Добавлять информацию о каком - либо военнослужащем.Для этого после выбора подразделения перейдите во вкладку «Добавить информацию о военнослужащем», заполните необходимую информацию и нажмите кнопку «Добавить».       " +
"                                                                                                                                                                                                                                                                                                                                                                                              " +
"2.Редактировать информацию о каком - либо военнослужащем.Для этого после выбора подразделения перейдите во вкладку «Изменить». Для этого заполните необходимую информацию в полях на вкладке(ID - личный номер для каждого военнослужащего.ID можно найти в крайней слева колонке в таблице) и нажмите кнопку «Изменить».      " +
"                                                                                                                                                                                                                                                                                                                                                                                              " +
"3.Удалять информацию о конкретном военнослужащем и его нарядах на текущий месяц.Для этого перейдите во вкладку «Удалить» и укажите ID военнослужащего в одноименном поле.После этого нажмите кнопу «Удалить».      " +
"                                                                                                                                                                                                                                                                                                                                                                                              " +
"4.Удаление и добавление нарядов «вне очереди» для отдельных военнослужащих в текущем месяце.Для этого перейдите во вкладку «Добавить / удалить наряд». Заполните поле с ID военнослужащего и укажите на какое число в месяце необходимо добавить либо удалить наряд.После этого нажмите кнопку «Добавить» либо «Удалить».      " +
"                                                                                                                                                                                                                                                                                                                                                                                                                  " +
"При возникновении каких - либо вопросов по использованию данного приложения, а также при возникновении предложений по улучшению данного продукта пишите на следующий почтовый адрес: lehagrekov2@gmail.com.А также следите за обновлениями для данного приложения по следующему адресу: https://github.com/leha2976/Project.       ");
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox10.Text)
                )
            {

                numericUpDown2.Maximum = 31;
                numericUpDown2.Minimum = 1;
                decimal i;
                if (numericUpDown2.Minimum <= numericUpDown2.Value && numericUpDown2.Value <= numericUpDown2.Maximum)
                {
                    string connectionSTR = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\WindowsFormsApp2\Database1.mdf;Integrated Security=True";
                    SqlConnection SqlConnection = new SqlConnection(connectionSTR);
                    await SqlConnection.OpenAsync();
                    i = numericUpDown2.Value;
                    string x = comboBox1.Text;
                    i = i + 1;
                    string b = i.ToString();
                    SqlCommand sqlCommand = new SqlCommand("UPDATE [" + x + "] SET [" + b + "]=@" + b + " WHERE [Id]=@Id", SqlConnection);
                    sqlCommand.Parameters.AddWithValue("Id", textBox10.Text);
                    sqlCommand.Parameters.AddWithValue(b, DBNull.Value);
                    await sqlCommand.ExecuteNonQueryAsync();
                    обновитьToolStripMenuItem_Click(sender, e);
                    textBox10.Clear();
                    numericUpDown2.Value = 01;
                    MessageBox.Show("Наряд успешно удален");
                }
                else
                {
                    MessageBox.Show("Ошибка.Выберите число месяца");
                }

            }
        }

        
    }
}



    

    
    

