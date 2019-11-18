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
   public class Delete
    {
       public async void ydal(object sender, EventArgs e, SqlConnection sqlConnection1, Form1 form)
        {
            string connectionSTR = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\WindowsFormsApp2\Database1.mdf;Integrated Security=True";
            SqlConnection SqlConnection = new SqlConnection(connectionSTR);
            await SqlConnection.OpenAsync();
            if (!string.IsNullOrEmpty(form.textBox7.Text) && !string.IsNullOrWhiteSpace(form.textBox7.Text))
            {
                string x = form.comboBox1.Text;
                SqlCommand sqlCommand = new SqlCommand("DELETE FROM [" + x + "] WHERE [Id]=@Id", SqlConnection);
                sqlCommand.Parameters.AddWithValue("Id", form.textBox7.Text);
                await sqlCommand.ExecuteNonQueryAsync();
                form.обновитьToolStripMenuItem_Click(sender, e);
                form.textBox7.Clear();
                MessageBox.Show("Информация успешно удалена");

            }
            else
            {
                MessageBox.Show("Ошибка.Укажите индификатор.");
            }
        }
    }
}
