using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Perfilac.dominio;

namespace Perfilac.visual
{
    public partial class AgregarProductoVenta : Form
    {
        public AgregarProductoVenta()
        {
            InitializeComponent();
            this.productoVender = new ProductoVenta();
        }

        private ProductoVenta productoVender;

        public ProductoVenta ProductoVender
        {
            get { return productoVender; }
            set { productoVender = value; }
        }

        
	

        public void mostrarCampos(String codigo,String noFicha,String descripcion,String suministrador,String color,String precioCUP,String precioCUC,String tipo,String enchape,String id)
        {
            textBox1.Text = codigo;
            textBox2.Text = noFicha;
            textBox7.Text = descripcion;
            textBox12.Text = suministrador;
            textBox13.Text = color;
            textBoxTipo.Text = precioCUP;
            textBoxEnchape.Text = precioCUC;
            textBoxCUP.Text = tipo;
            textBoxCUC.Text = enchape;            
            textBox11.Text = id;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double ancho = 0;
            double alto = 0;
            int cant = 0;
            Boolean error = false;
            try
            {
                ancho = double.Parse(textBox6.Text);
            }
            catch (Exception)
            {

                label11.Visible = true;
                error = true;
                

            }
            try
            {
                alto = double.Parse(textBox5.Text);
            }
            catch (Exception)
            {

                label12.Visible = true;
                error = true;
                

            }
            try
            {
                cant = int.Parse(textBox8.Text);
            }
            catch (Exception)
            {

                label13.Visible = true;
                error = true;
                

            }
            if (!error)
            {
                productoVender = new ProductoVenta();
                productoVender.Ancho = ancho;
                productoVender.Alto = alto;
                productoVender.Cant = cant;
                productoVender.Id = -1;
                productoVender.Prod = new Producto(textBox1.Text, textBox7.Text, int.Parse(textBox2.Text),double.Parse(textBoxCUC.Text), double.Parse(textBoxCUP.Text), textBox12.Text, textBox13.Text, new TipoEnchape(textBoxEnchape.Text), new TipoProducto(textBoxTipo.Text));
                productoVender.Prod.Id = int.Parse(textBox11.Text);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Existen campos que estan incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}