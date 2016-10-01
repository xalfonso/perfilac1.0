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
    public partial class PagoCliente : Form
    {
        private Ingreso pagoCliente;

        public Ingreso TipoPagoCliente
        {
            get { return pagoCliente; }
            set { pagoCliente = value; }
        }

            
	
        
        public PagoCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            try 
	        {	        
	         double importe = double.Parse(textBox1.Text);
             String cheque = textBox2.Text;
             TipoMoneda moneda = new TipoMoneda();
             moneda = (TipoMoneda)Enum.Parse(typeof(TipoMoneda), comboBox1.Text);
             this.pagoCliente = new Ingreso(importe,cheque,moneda);
             this.DialogResult = DialogResult.OK;

	        }
	        catch (Exception)
	        {
                label2.Visible = true;
                MessageBox.Show("Existen campos que estan incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
	        }
            
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            this.DialogResult = DialogResult.Cancel;
        }
    }
}