using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Perfilac.visual;

namespace Perfilac
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            this.Opacity += 0.02;
           

            if (this.Opacity == 1)
            {
                timer1.Stop();
                Principal ddk = new Principal(this);

                ddk.Show();
                this.Visible = false;

            }

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}