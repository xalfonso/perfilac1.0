using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Perfilac.dominio;
using Perfilac.servicio;

namespace Perfilac.visual
{
    public partial class Nuevo_Cliente : Form
    {
        public Nuevo_Cliente(Service servicio)
        {
            InitializeComponent();
            this.servicio = servicio;
            this.listPersonaCliente = new List<PersonaCliente>();
        }
        private Service servicio;

        public Service Servicio
        {
            get { return servicio; }
            set { servicio = value; }
        }
        

        private Cliente nuevoCliente;

        public Cliente NuevoCliente
        {
            get { return nuevoCliente; }
            set { nuevoCliente = value; }
        }

        private List<PersonaCliente> listPersonaCliente;

        public List<PersonaCliente> ListPersonaCliente
        {
            get { return listPersonaCliente; }
            set { listPersonaCliente = value; }
        }

	

	

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;

        }

        private void limpiarDatosPersonaAutorizada()
        {
            textBox7.Clear();
            textBox8.Clear();
            textBox10.Clear();
            textBox9.Clear();
            textBox12.Clear();
            textBox11.Clear();

        }

        private void actualizarListadoPersonasAutorizadas()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(this.listPersonaCliente.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Nuevo_Cliente_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String nombre = textBox1.Text;
            String contrato = textBox2.Text;
            String codigo = textBox3.Text;
            String cuentaCUP = textBox4.Text;
            String cuentaCUC = textBox5.Text;
            String direccion = textBox6.Text;

            if (this.listPersonaCliente.Count > 0)
            {
                this.nuevoCliente = new Cliente(codigo, nombre, contrato, direccion, this.listPersonaCliente, cuentaCUP, cuentaCUC);
                foreach (PersonaCliente var in  this.listPersonaCliente)
                {
                    var.Cliente = nuevoCliente;
                }
                this.servicio.salvarCliente(nuevoCliente);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Debe adicionar al menos una persona responsable", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void limpiarDatosCliente()
        {
            textBox7.Clear();
            textBox8.Clear();
            textBox10.Clear();
            textBox9.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            String primerNombre = textBox7.Text;
            String segundoNombre = textBox8.Text;
            String primerApellido = textBox10.Text;
            String segundoApellido = textBox9.Text;
            String cargo = textBox11.Text;
            String carnet = textBox12.Text;
            String telefono = textBox13.Text;
            PersonaCliente nuevaPersonaCliente = new PersonaCliente(primerNombre, segundoNombre, primerApellido, segundoApellido, carnet, telefono,cargo);
            this.ListPersonaCliente.Add(nuevaPersonaCliente);
            actualizarListadoPersonasAutorizadas();
            limpiarDatosCliente();

            groupBox2.Visible = true;
            groupBox1.Visible = false;
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                if (MessageBox.Show("Se eliminará el elemento selecionado, ¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.ListPersonaCliente.RemoveAt(listBox1.SelectedIndex);
                    actualizarListadoPersonasAutorizadas();
                }
            }
            else
                MessageBox.Show("Debe seleccionar el elemento a eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
             
        }
    }
}