using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1

{
     public class Dobavit
    {
        
       public async void Dobavit1(object sender, EventArgs e,SqlConnection sqlConnection, Form1 form)
        {
            string connectionSTR = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\WindowsFormsApp2\Database1.mdf;Integrated Security=True";
            SqlConnection SqlConnection = new SqlConnection(connectionSTR);
            await SqlConnection.OpenAsync();
            if (!string.IsNullOrEmpty(form.textBox2.Text) && !string.IsNullOrWhiteSpace(form.textBox2.Text) )
            {
                
                string x = form.comboBox1.Text;
        SqlCommand sqlCommand = new SqlCommand("INSERT INTO [" + x + "] (VZ,FIO) VALUES (@VZ,@FIO)", SqlConnection);
                if (x == "Офицеры" && form.comboBox4.Text != ""  )
                {
                    sqlCommand.Parameters.AddWithValue("VZ", form.comboBox4.Text);
                    
                }
                if (x == "Прапорщики" && form.comboBox5.Text!="" )
                {
                    sqlCommand.Parameters.AddWithValue("VZ", form.comboBox5.Text);
                    
                }      
                if (x != "Офицеры" && x != "Прапорщики" && form.comboBox3.Text!="" )
                {
                    sqlCommand.Parameters.AddWithValue("VZ", form.comboBox3.Text);
                    
                }
                
                sqlCommand.Parameters.AddWithValue("FIO", form.textBox2.Text);
                await sqlCommand.ExecuteNonQueryAsync();
                form.обновитьToolStripMenuItem_Click(sender,e);
                MessageBox.Show("Информация успешно добавлена");
                form.comboBox3.Text = "";
                form.comboBox4.Text = "";
                form.comboBox5.Text = "";
                form.textBox2.Clear();                   
                }
                

            
            else
            {
                MessageBox.Show("Ошибка.Поля для ввода должны быть заполнены");
            }
    }}
}
