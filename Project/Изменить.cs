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
    public class Izmenit
    {

       public  async void izmen(object sender, EventArgs e, SqlConnection sqlConnection, Form1 form)
        {
            string connectionSTR = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\WindowsFormsApp2\Database1.mdf;Integrated Security=True";
            SqlConnection SqlConnection = new SqlConnection(connectionSTR);
            await SqlConnection.OpenAsync();
            string x = form.comboBox1.Text;
            if (x == "Офицеры")
            {
                form.comboBox4.Visible = true;
                form.comboBox4.Enabled = true;
               
            }

            if (x == "Прапорщики")
            {
                
                form.comboBox5.Visible = true;
                form.comboBox5.Enabled = true;
            }
            if (x != "Офицеры" && x != "Прапорщики")
            {
                
                form.comboBox6.Visible = true;
                form.comboBox6.Enabled = true;
            }
           
            if (!String.IsNullOrEmpty(form.textBox6.Text) && !String.IsNullOrWhiteSpace(form.textBox6.Text) &&
                   !String.IsNullOrEmpty(form.textBox5.Text) && !String.IsNullOrWhiteSpace(form.textBox5.Text))
            {
               
                
                SqlCommand sqlCommand = new SqlCommand("UPDATE [" + x + "] SET  [FIO]=@FIO, [VZ]=@VZ WHERE [Id]=@Id", SqlConnection);
                if (x == "Офицеры" && form.comboBox6.Text != "")
                {
                    sqlCommand.Parameters.AddWithValue("VZ", form.comboBox6.Text);

                }
                if (x == "Прапорщики" && form.comboBox7.Text != "")
                {
                    sqlCommand.Parameters.AddWithValue("VZ", form.comboBox7.Text);

                }
                if (x != "Офицеры" && x != "Прапорщики" && form.comboBox2.Text != "")
                {
                    sqlCommand.Parameters.AddWithValue("VZ", form.comboBox2.Text);

                }
                sqlCommand.Parameters.AddWithValue("ID", form.textBox6.Text);
                sqlCommand.Parameters.AddWithValue("FIO", form.textBox5.Text);
                
                await sqlCommand.ExecuteNonQueryAsync();
                form.обновитьToolStripMenuItem_Click(sender, e);
                form.textBox5.Clear();
                form.textBox6.Clear();
                form.comboBox2.Text = "";
                MessageBox.Show("Информация успешно изменена");
            }
           
            else
            {
                if (!String.IsNullOrWhiteSpace(form.textBox6.Text) && !String.IsNullOrEmpty(form.textBox6.Text))
                {

                    MessageBox.Show("Ошибка. Укажите индификатор");
                }
            }
        }
    }
}
