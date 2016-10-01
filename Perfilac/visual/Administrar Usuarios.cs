using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Perfilac.servicio;
using Perfilac.dominio;
namespace Perfilac.visual
{
    public partial class Administrar_Usuarios : Form
    {
        public Administrar_Usuarios(Service servicio)
        {
            InitializeComponent();
            this.servicio = servicio;
            actualizarListadoUsuario();
        }

        private Boolean agregarUser;

        public Boolean AgregarUser
        {
            get { return agregarUser; }
            set { agregarUser = value; }
        }

        private Boolean modificarUser;

        public Boolean ModificarUser
        {
            get { return modificarUser; }
            set { modificarUser = value; }
        }

	
        private Service servicio;

        public Service Servicio
        {
            get { return servicio; }
            set { servicio = value; }
        }
        private void actualizarListadoUsuario()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(servicio.listarUsuarios().ToArray());
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Administrar_Usuarios_Load(object sender, EventArgs e)
        {

        }

         private void  seleccionarUsuario()
        {
            if (listBox1.SelectedIndex != -1)
            {
              Usuario user = (Usuario)listBox1.SelectedItem;
              textBox1.Text = user.PrimerNombre;
              textBox2.Text = user.SegundoNombre;
              textBox3.Text = user.PrimerApellido;
              textBox4.Text = user.SegundoApellido;
              textBox5.Text = user.User;
              textBox6.Text = user.Pass;
              textBox7.Text = user.Pass;
              textBox8.Text = user.Id.ToString();


            }
        }
        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            seleccionarUsuario();            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox7.Visible = false;
            label8.Visible = false;
            textBox7.Clear();
            button3.Text = "Modificar";
            listBox1.SelectedIndex = -1;
            modificarUser = false;
            if (agregarUser)
            {

             
               Boolean validacion = false;
               String mensaje = "";
               if (textBox1.Text.Length < 1  || textBox3.Text.Length < 1 || textBox4.Text.Length < 1 || textBox5.Text.Length < 1 || textBox6.Text.Length<1)
               {
                   validacion = true;
                   mensaje = ", No debe haber campos vacios exceptuado el Segundo Nombre";
               }
               if (textBox5.Text.Length < 4 || textBox6.Text.Length < 7)
               {
                   validacion = true;
                   mensaje += ", el usuario debe tener más de 3 caracteres y las contraseña más de 6.";
               }


               if (!validacion)
               {
                   Usuario nuevoUser = new Usuario(textBox5.Text, textBox6.Text, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                   servicio.salvarUsuario(nuevoUser);
                   actualizarListadoUsuario();
                   textBox1.Clear();
                   textBox2.Clear();
                   textBox3.Clear();
                   textBox4.Clear();
                   textBox5.Clear();
                   textBox6.Clear();
                   //-----------------------
                   textBox1.ReadOnly = true;
                   textBox2.ReadOnly = true;
                   textBox3.ReadOnly = true;
                   textBox4.ReadOnly = true;
                   textBox5.ReadOnly = true;
                   textBox6.ReadOnly = true;

                   button2.Text = "Agregar";
                   agregarUser = false;
               }
               else
               {
                   MessageBox.Show("Verifique los datos"+mensaje+"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
               
             }
            else
            {
                
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                //----------------------------
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;
                textBox6.ReadOnly = false;
                agregarUser = true;

                button2.Text = "Agregar!";
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            button2.Text = "Agregar";
            agregarUser = false;
           
            if (listBox1.SelectedIndex != -1)
            {

                if (modificarUser)
                {


                    Boolean validacion = false;
                    String mensaje = "";
                    if (textBox1.Text.Length < 1 || textBox3.Text.Length < 1 || textBox4.Text.Length < 1 || textBox5.Text.Length < 1 || textBox6.Text.Length < 1)
                    {
                        validacion = true;
                        mensaje = ", No debe haber campos vacios exceptuado el Segundo Nombre";
                    }
                    if (textBox5.Text.Length < 4 || textBox6.Text.Length < 7)
                    {
                        validacion = true;
                        mensaje += ", el usuario debe tener más de 3 caracteres y las contraseña más de 6";
                    }
                    if (textBox6.Text != textBox7.Text)
                    {
                        validacion = true;
                        mensaje += "; las contraseñas deben coincidir.";
                    }


                    if (!validacion)
                    {
                        Usuario nuevoUser = new Usuario(textBox5.Text, textBox6.Text, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                        nuevoUser.Id = int.Parse(textBox8.Text);
                        servicio.modificarUsuario(nuevoUser);
                        actualizarListadoUsuario();
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox7.Clear();
                        //-----------------------
                        textBox1.ReadOnly = true;
                        textBox2.ReadOnly = true;
                        textBox3.ReadOnly = true;
                        textBox4.ReadOnly = true;
                        textBox5.ReadOnly = true;
                        textBox6.ReadOnly = true;
                        textBox7.Visible = false;
                        label8.Visible = false;

                        button3.Text = "Modificar";
                        modificarUser = false;
                    }
                    else
                    {
                        MessageBox.Show("Verifique los datos" + mensaje + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                else
                {

                    //textBox1.Clear();
                    //textBox2.Clear();
                    //textBox3.Clear();
                    //textBox4.Clear();
                    //textBox5.Clear();
                    //textBox6.Clear();
                    //----------------------------
                    textBox1.ReadOnly = false;
                    textBox2.ReadOnly = false;
                    textBox3.ReadOnly = false;
                    textBox4.ReadOnly = false;
                    textBox5.ReadOnly = false;
                    textBox6.ReadOnly = false;
                    textBox7.Visible = true;
                    label8.Visible = true;
                    modificarUser = true;

                    button3.Text = "Modificar!";

                }
            }
            else
            MessageBox.Show("Debe seleccionar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                if (MessageBox.Show("Se eliminará el usuario seleccionado, ¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    this.servicio.eliminarUsuario(int.Parse(textBox8.Text));
                    actualizarListadoUsuario();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                }
            }
            else
                MessageBox.Show("Debe seleccionar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            button2.Text = "Agregar";
            agregarUser = false;

            if (listBox1.SelectedIndex != -1)
            {

                if (modificarUser)
                {


                    Boolean validacion = false;
                    String mensaje = "";
                    if (textBox1.Text.Length < 1 || textBox3.Text.Length < 1 || textBox4.Text.Length < 1 || textBox5.Text.Length < 1 || textBox6.Text.Length < 1)
                    {
                        validacion = true;
                        mensaje = ", No debe haber campos vacios exceptuado el Segundo Nombre";
                    }
                    if (textBox5.Text.Length < 4 || textBox6.Text.Length < 7)
                    {
                        validacion = true;
                        mensaje += ", el usuario debe tener más de 3 caracteres y las contraseña más de 6";
                    }
                    if (textBox6.Text != textBox7.Text)
                    {
                        validacion = true;
                        mensaje += "; las contraseñas deben coincidir.";
                    }


                    if (!validacion)
                    {
                        Usuario nuevoUser = new Usuario(textBox5.Text, textBox6.Text, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                        nuevoUser.Id = int.Parse(textBox8.Text);
                        servicio.modificarUsuario(nuevoUser);
                        actualizarListadoUsuario();
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox7.Clear();
                        //-----------------------
                        textBox1.ReadOnly = true;
                        textBox2.ReadOnly = true;
                        textBox3.ReadOnly = true;
                        textBox4.ReadOnly = true;
                        textBox5.ReadOnly = true;
                        textBox6.ReadOnly = true;
                        textBox7.Visible = false;
                        label8.Visible = false;

                        button3.Text = "Modificar";
                        modificarUser = false;
                    }
                    else
                    {
                        MessageBox.Show("Verifique los datos" + mensaje + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                else
                {

                    //textBox1.Clear();
                    //textBox2.Clear();
                    //textBox3.Clear();
                    //textBox4.Clear();
                    //textBox5.Clear();
                    //textBox6.Clear();
                    //----------------------------
                    textBox1.ReadOnly = false;
                    textBox2.ReadOnly = false;
                    textBox3.ReadOnly = false;
                    textBox4.ReadOnly = false;
                    textBox5.ReadOnly = false;
                    textBox6.ReadOnly = false;
                    textBox7.Visible = true;
                    label8.Visible = true;
                    modificarUser = true;

                    button3.Text = "Modificar!";

                }
            }
            else
                MessageBox.Show("Debe seleccionar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}