using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Parcial2
{
    public partial class frmPrincipall : Form
    {
        private Usuario user;
        public frmPrincipall(Usuario pUsuario)
        {
            InitializeComponent();
            user = pUsuario;
            cmbPermisos.DataSource = new List<String>() {"admin","user"};
        }

        private void frmPrincipall_Load(object sender, EventArgs e)
        {
            label6.Text = "Usuario: " + user.usuario;
          
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            UsuarioDAO.ActualizarPermisos(comboBox1.Text, cmbPermisos.Text);
           
            MessageBox.Show("Permisos actualizados con éxito!",
                "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length >= 1 && textBox2.Text.Length >= 1 &&
                    (textBox3.Text.Length == 1 || textBox3.Text.Length == 1))
                {
                    UsuarioDAO.CrearNuevo(textBox1.ToString(),textBox2.ToString(),textBox3.ToString(),textBox4.ToString());

                    MessageBox.Show("Usuario agregado con exito!",
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                }
                else
                {
                    MessageBox.Show("Datos invalidos",
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Datos invalidos",
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        
        }


        private void tabPage2_Click(object sender, EventArgs e)
       
      { 
                 button2.Enabled = false;
                 
            try
            {
                var dt = ConnectionDB.ExecuteQuery("SELECT * FROM BUSINESS");
                textBox1.Clear();
                textBox2.Clear();
                textBox4.Clear();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR");
            }
      }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Equals("") ||
                textBox6.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacios ");
            }
            else
            {
                try
                {
                    ConnectionDB.ExecuteNonQuery($"INSERT INTO BUSINESS( name, description) VALUES (" +
                                               $"'{textBox5.Text}'," +
                                               $"'{textBox6.Text}')");

                    MessageBox.Show("Se ha registrado la empresa");
                    
                    var dt = ConnectionDB.ExecuteQuery("SELECT * FROM PRODUCT");
                    
                    textBox5.Clear();
                    textBox6.Clear();
                   
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult deleteconfirm;
            
            if (comboBox2.Text == "")
            {
                MessageBox.Show("No se pueden dejar el campo vacio ");
            }
            else
            {
                button2.Enabled = true;
                
                deleteconfirm = MessageBox.Show("Se borrara la empresa","Confirmar",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                
                if (deleteconfirm == DialogResult.OK)
                {
                    try
                    {
                        ConnectionDB.ExecuteNonQuery("DELETE FROM public.BUSINESS WHERE name ="+
                                                   $"'{comboBox2.Text}'");
                        textBox4.Clear();
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                       
                        
                        MessageBox.Show("Empresa eliminada","Eliminar empresa", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                        throw;
                    }
                }
                else
                {
                   comboBox2.Text = "";
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacios ");
            }
            else
            {
                try
                {
                    var num = $"SELECT idBusiness FROM BUSINESS WHERE" +
                              $" name ='{comboBox3.SelectedItem.ToString()}'";
                
                    var dt = ConnectionDB.ExecuteQuery(num);
                    var dr = dt.Rows[0];
                    var myNum = int.Parse(dt.Rows[0][0].ToString());

                    ConnectionDB.ExecuteNonQuery($"INSERT INTO PRODUCT(idBusiness, name) VALUES (" +
                                               $"{myNum}, " + 
                                               $"'{textBox7.Text}')");

                    MessageBox.Show("Se ha registrado el producto");
                  
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR");
                }
            }
        }
    }
}