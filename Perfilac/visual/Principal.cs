using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Perfilac.dominio;
using Perfilac.servicio;
using Perfilac.dao;
using Perfilac.reportes;
using System.Globalization;

namespace Perfilac.visual
{
    public partial class Principal : Form
    {
        private Service servicio;

        public Service Servicio
        {
            get { return servicio; }
            set { servicio = value; }
        }

        private Form1 formPrincipal;

        private List<Producto> listProductoFactura;

        public List<Producto> ListProductoFactura
        {
            get { return listProductoFactura; }
            set { listProductoFactura = value; }
        }

        private List<ProductoVenta> listProductosVenta;

        public List<ProductoVenta> ListProductoV
        {
            get { return listProductosVenta; }
            set { listProductosVenta = value; }
        }


        private Boolean clienteSelecionado;

        public Boolean ClienteSelecionado
        {
            get { return clienteSelecionado; }
            set { clienteSelecionado = value; }
        }

        private TipoVenta tipoVenta;

        public TipoVenta TipoVent
        {
            get { return tipoVenta; }
            set { tipoVenta = value; }
        }


        public Principal(Form1 formPrincipal)
        {
            InitializeComponent();
            servicio = new Service();
            this.formPrincipal = formPrincipal;

        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label17.Visible = false;
            label16.Visible = false;
            label15.Visible = false;
            int numeroFicha = 0;
            double precioCUC = 0.0;
            double precioCUP = 0.0;
            Boolean error = false;
            try
            {
                numeroFicha = int.Parse(textBox2.Text);
            }
            catch (Exception)
            {
                label17.Visible = true;
                error = true;
            }

            try
            {
                precioCUC = double.Parse(textBox3.Text);
            }
            catch (Exception)
            {
                label15.Visible = true;
                error = true;
            }

            try
            {
                precioCUP = double.Parse(textBox4.Text);
            }
            catch (Exception)
            {
                label16.Visible = true;
                error = true;
            }

            if (!error)
            {
                TipoProducto tipo = (TipoProducto)comboBox1.SelectedItem;
                TipoEnchape enchape = (TipoEnchape)comboBox2.SelectedItem;
                String codigo = textBox1.Text;
                String color = textBox5.Text;
                String suministrador = textBox6.Text;
                String descripcion = textBox7.Text;
                Producto nuevoProducto = new Producto(codigo, descripcion, numeroFicha, precioCUC, precioCUP, suministrador, color, enchape, tipo);
                this.servicio.salvarProducto(nuevoProducto);
                limpiarVisualProducto();
                MessageBox.Show("Se ha insertado satisfactoriamente la ficha con código: " + precioCUC + " y " + precioCUP, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Existen campos que estan incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void insertarFichaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(servicio.obtenerTiposProducto().ToArray());
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(servicio.obtenerTiposEnchape().ToArray());
            comboBox2.SelectedIndex = 0;

        }

        private void limpiarVisualProducto()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            label17.Visible = false;
            label16.Visible = false;
            label15.Visible = false;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Si continua se perderan los datos.¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                limpiarVisualProducto();
            }
        }

        private void verFichaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (groupBox1.Visible || groupBox3.Visible)
            {
                if (MessageBox.Show("¿Desea conservar los datos que no haya guardado de la vista actual?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    limpiarVisualProducto();
                }
            }

            groupBox3.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            label14.Visible = false;

            comboBox3.Items.Clear();
            TipoProducto tipoVacio = new TipoProducto("Todos");
            tipoVacio.Id = -1;
            comboBox3.Items.Add(tipoVacio);
            comboBox3.Items.AddRange(servicio.obtenerTiposProducto().ToArray());
            comboBox3.SelectedIndex = 0;

            comboBox4.Items.Clear();
            TipoEnchape enchapoVacio = new TipoEnchape("Todos");
            enchapoVacio.Id = -1;
            comboBox4.Items.Add(enchapoVacio);
            comboBox4.Items.AddRange(servicio.obtenerTiposEnchape().ToArray());
            comboBox4.SelectedIndex = 0;

            //List<Producto> listProducto = this.servicio.consultarProducto();
            //dataGridView1.RowCount = listProducto.Count+1;

            //for (int i = 0; i < listProducto.Count; i++)
            //{
            //    dataGridView1[0, i].Value = listProducto[i].Codigo;
            //    dataGridView1[1, i].Value = listProducto[i].NoFicha;
            //    dataGridView1[2, i].Value = listProducto[i].Descripcion;
            //    dataGridView1[3, i].Value = listProducto[i].Tipo.ToString();
            //    dataGridView1[4, i].Value = listProducto[i].Enchape.ToString();
            //    dataGridView1[5, i].Value = listProducto[i].PrecioCUP;
            //    dataGridView1[6, i].Value = listProducto[i].PrecioCUC;  
            //}           

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está a punto de cerrar la aplicación. ¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                formPrincipal.Close();
            }

        }

        private void prefacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (groupBox1.Visible)
            {
                if (MessageBox.Show("¿Desea conservar los datos que no haya guardado de la vista actual?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    limpiarVisualProducto();
                }
            }

            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = true;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Value = DateTime.Now;

            label46.Visible = false;

            comboBox6.Items.Clear();
            TipoProducto tipoVacio = new TipoProducto("Todos");
            tipoVacio.Id = -1;
            comboBox6.Items.Add(tipoVacio);
            comboBox6.Items.AddRange(servicio.obtenerTiposProducto().ToArray());
            comboBox6.SelectedIndex = 0;

            comboBox5.Items.Clear();
            TipoEnchape enchapoVacio = new TipoEnchape("Todos");
            enchapoVacio.Id = -1;
            comboBox5.Items.Add(enchapoVacio);
            comboBox5.Items.AddRange(servicio.obtenerTiposEnchape().ToArray());
            comboBox5.SelectedIndex = 0;
            this.listProductosVenta = new List<ProductoVenta>();
            this.TipoVent = TipoVenta.prefactura;

            actualizarListadoClientes();




        }

        private void button6_Click(object sender, EventArgs e)
        {
            Boolean error = false;

            if (!clienteSelecionado)
            {
                MessageBox.Show("Debe seleccionar permanentemente la persona cliente de la factura", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = true;
            }
            if (this.listProductosVenta.Count == 0)
            {
                MessageBox.Show("Debe seleccionar las fichas de la factura", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = true;
            }


            if (!error)
            {
                PersonaCliente personaSelecionada = (PersonaCliente)listBox2.Items[listBox2.SelectedIndex];
                Cliente clienteSeleccionado = (Cliente)listBox1.Items[listBox1.SelectedIndex];
                List<ProductoVenta> produstosVender = new List<ProductoVenta>();
                DateTime fecha = dateTimePicker1.Value;
                Perfilac.dominio.Venta vet = new Perfilac.dominio.Venta(clienteSeleccionado, personaSelecionada, fecha, produstosVender, TipoVent);

                List<Ingreso> listPagos = new List<Ingreso>();
                foreach (Object var in listBox3.Items)
                {
                    Ingreso nuevo = (Ingreso)var;
                    nuevo.Client = clienteSeleccionado;
                    nuevo.Venta = vet;
                    listPagos.Add(nuevo);

                }
                vet.ImportePagado = listPagos;


                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        Producto nuevo = new Producto();
                        nuevo.Id = int.Parse(row.Cells[14].Value.ToString());
                        ProductoVenta nuevoProductoVenta = new ProductoVenta();
                        nuevoProductoVenta.Prod = nuevo;
                        nuevoProductoVenta.Ancho = double.Parse(row.Cells[7].Value.ToString());
                        nuevoProductoVenta.Alto = double.Parse(row.Cells[8].Value.ToString());
                        nuevoProductoVenta.Cant = int.Parse(row.Cells[9].Value.ToString());
                        nuevoProductoVenta.Vent = vet;
                        produstosVender.Add(nuevoProductoVenta);

                    }
                }


                try
                {
                    int id = servicio.salvarVenta(vet);
                    MessageBox.Show("La Factura se ha insertado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    imprimirVenta(id);
                    limpiarDatosFactura();

                }
                catch (Exception exep)
                {

                    MessageBox.Show(exep.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void actualizarListadoClientes()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(this.servicio.obtenerClientes().ToArray());
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nuevo_Cliente formNuevoCliente = new Nuevo_Cliente(this.servicio);
            if (formNuevoCliente.ShowDialog() == DialogResult.OK)
            {
                if (groupBox3.Visible)
                    actualizarListadoClientes();

            }
        }

        private void operacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Cliente clienteSeleccionado = (Cliente)listBox1.Items[listBox1.SelectedIndex];
                label26.Text = clienteSeleccionado.Nombre;
                label31.Text = clienteSeleccionado.Codigo;
                textBox13.Text = clienteSeleccionado.Direccion;
                label33.Text = clienteSeleccionado.Contrato;
                label42.Text = clienteSeleccionado.CuentaCUP;
                label43.Text = clienteSeleccionado.CuentaCUC;
                listBox2.Items.Clear();
                listBox2.Items.AddRange(clienteSeleccionado.Comerciales.ToArray());
            }

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            PersonaCliente personaSelecionada = (PersonaCliente)listBox2.Items[listBox2.SelectedIndex];
            label30.Text = personaSelecionada.nombreCompleto();
            label34.Text = personaSelecionada.Cargo;
            label36.Text = personaSelecionada.CI;
            label38.Text = personaSelecionada.Telefono;
        }

        private void limpiarDatosFactura()
        {
            //fecha
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Value = DateTime.Now;


            //Cliente
            abilitarSeleccionarCliente();
            abilitarSeleccionarPersonaCliente();


            //Pagos
            listBox3.Items.Clear();


            //Producto
            comboBox6.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            textBox10.Clear();
            textBox11.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            this.listProductosVenta = new List<ProductoVenta>();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Boolean error = false;

            if (!clienteSelecionado)
            {
                MessageBox.Show("Debe seleccionar permanentemente la persona cliente de la factura", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = true;
            }
            if (this.listProductosVenta.Count == 0)
            {
                MessageBox.Show("Debe seleccionar las fichas de la factura", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = true;
            }


            if (!error)
            {
                PersonaCliente personaSelecionada = (PersonaCliente)listBox2.Items[listBox2.SelectedIndex];
                Cliente clienteSeleccionado = (Cliente)listBox1.Items[listBox1.SelectedIndex];
                List<ProductoVenta> produstosVender = new List<ProductoVenta>();
                DateTime fecha = dateTimePicker1.Value;
                Perfilac.dominio.Venta vet = new Perfilac.dominio.Venta(clienteSeleccionado, personaSelecionada, fecha, produstosVender, TipoVent);

                List<Ingreso> listPagos = new List<Ingreso>();
                foreach (Object var in listBox3.Items)
                {
                    Ingreso nuevo = (Ingreso)var;
                    nuevo.Client = clienteSeleccionado;
                    nuevo.Venta = vet;
                    listPagos.Add(nuevo);

                }
                vet.ImportePagado = listPagos;


                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        Producto nuevo = new Producto();
                        nuevo.Id = int.Parse(row.Cells[14].Value.ToString());
                        ProductoVenta nuevoProductoVenta = new ProductoVenta();
                        nuevoProductoVenta.Prod = nuevo;
                        nuevoProductoVenta.Ancho = double.Parse(row.Cells[7].Value.ToString());
                        nuevoProductoVenta.Alto = double.Parse(row.Cells[8].Value.ToString());
                        nuevoProductoVenta.Cant = int.Parse(row.Cells[9].Value.ToString());
                        nuevoProductoVenta.Vent = vet;
                        produstosVender.Add(nuevoProductoVenta);

                    }
                }


                try
                {
                    servicio.salvarVenta(vet);
                    MessageBox.Show("La Factura se ha insertado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarDatosFactura();

                }
                catch (Exception exep)
                {

                    MessageBox.Show(exep.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }



        private void button7_Click_1(object sender, EventArgs e)
        {
            if (button10.Visible)
            {
                PagoCliente formPago = new PagoCliente();
                if (formPago.ShowDialog() == DialogResult.OK)
                {
                    listBox3.Items.Add(formPago.TipoPagoCliente);


                }
            }
            else
                MessageBox.Show("Debe seleccionar permanentemente la persona que efectúa el pago", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        private void button5_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void pruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox4.Visible = false;
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(servicio.obtenerTiposProducto().ToArray());
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(servicio.obtenerTiposEnchape().ToArray());
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Debe seleccionar un valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Handled = true;
            return;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Debe seleccionar un valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Handled = true;
            return;

        }

        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Debe seleccionar un valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Handled = true;
            return;

        }

        private void comboBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Debe seleccionar un valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Handled = true;
            return;
        }

        private void comboBox3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Boolean error = false;
            label14.Visible = false;
            int noFicha = 0;
            if (textBox9.Text.Length != 0)
            {
                try
                {

                    noFicha = int.Parse(textBox9.Text);
                }
                catch (Exception)
                {
                    error = true;
                    label14.Visible = true;
                    MessageBox.Show("Existen campos que estan incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                noFicha = -1;

            if (!error)
            {
                String codigo = textBox8.Text;

                TipoEnchape enchape = (TipoEnchape)comboBox4.SelectedItem;
                if (enchape.Id == -1)
                    enchape = null;
                TipoProducto tipo = (TipoProducto)comboBox3.SelectedItem;
                if (tipo.Id == -1)
                    tipo = null;

                List<Producto> listProducto = servicio.consultarProductosPorParametros(codigo, noFicha, tipo, enchape);
                dataGridView1.RowCount = listProducto.Count + 1;

                for (int i = 0; i < listProducto.Count; i++)
                {
                    dataGridView1[0, i].Value = listProducto[i].Codigo;
                    dataGridView1[1, i].Value = listProducto[i].NoFicha;
                    dataGridView1[2, i].Value = listProducto[i].Descripcion;
                    dataGridView1[3, i].Value = listProducto[i].Suministrador;
                    dataGridView1[4, i].Value = listProducto[i].Color;
                    dataGridView1[5, i].Value = listProducto[i].Tipo.ToString();
                    dataGridView1[6, i].Value = listProducto[i].Enchape.ToString();
                    dataGridView1[7, i].Value = listProducto[i].PrecioCUP;
                    dataGridView1[8, i].Value = listProducto[i].PrecioCUC;
                }



            }
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Boolean error = false;
            label46.Visible = false;
            int noFicha = 0;
            if (textBox10.Text.Length != 0)
            {
                try
                {

                    noFicha = int.Parse(textBox10.Text);
                }
                catch (Exception)
                {
                    error = true;
                    label46.Visible = true;
                    MessageBox.Show("Existen campos que estan incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                noFicha = -1;

            if (!error)
            {
                String codigo = textBox11.Text;

                TipoEnchape enchape = (TipoEnchape)comboBox5.SelectedItem;
                if (enchape.Id == -1)
                    enchape = null;
                TipoProducto tipo = (TipoProducto)comboBox6.SelectedItem;
                if (tipo.Id == -1)
                    tipo = null;

                listProductoFactura = servicio.consultarProductosPorParametros(codigo, noFicha, tipo, enchape);
                dataGridView2.RowCount = listProductoFactura.Count + 1;


                for (int i = 0; i < listProductoFactura.Count; i++)
                {
                    dataGridView2[0, i].Value = listProductoFactura[i].Codigo;
                    dataGridView2[1, i].Value = listProductoFactura[i].NoFicha;
                    dataGridView2[2, i].Value = listProductoFactura[i].Descripcion;
                    dataGridView2[3, i].Value = listProductoFactura[i].Suministrador;
                    dataGridView2[4, i].Value = listProductoFactura[i].Color;
                    dataGridView2[5, i].Value = listProductoFactura[i].Tipo.ToString();
                    dataGridView2[6, i].Value = listProductoFactura[i].Enchape.ToString();
                    dataGridView2[7, i].Value = listProductoFactura[i].PrecioCUP;
                    dataGridView2[8, i].Value = listProductoFactura[i].PrecioCUC;
                    dataGridView2[9, i].Value = listProductoFactura[i].Id;
                }



            }
        }

        private void dataGridView2_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Boolean existe = false;
            if (dataGridView3.Rows.Count > 1)
            {
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().Equals(dataGridView2.SelectedRows[0].Cells[0].Value))
                    {
                        existe = true;
                        break;
                    }
                }
            }

            if (!existe)
            {
                AgregarProductoVenta formAgregarProductoVenta = new AgregarProductoVenta();

                formAgregarProductoVenta.mostrarCampos(dataGridView2.SelectedRows[0].Cells[0].Value.ToString(), dataGridView2.SelectedRows[0].Cells[1].Value.ToString(), dataGridView2.SelectedRows[0].Cells[2].Value.ToString(), dataGridView2.SelectedRows[0].Cells[3].Value.ToString(), dataGridView2.SelectedRows[0].Cells[4].Value.ToString(), dataGridView2.SelectedRows[0].Cells[5].Value.ToString(), dataGridView2.SelectedRows[0].Cells[6].Value.ToString(), dataGridView2.SelectedRows[0].Cells[7].Value.ToString(), dataGridView2.SelectedRows[0].Cells[8].Value.ToString(), dataGridView2.SelectedRows[0].Cells[9].Value.ToString());
                if (formAgregarProductoVenta.ShowDialog() == DialogResult.OK)
                {
                    ProductoVenta productoVentaEscogido = formAgregarProductoVenta.ProductoVender;
                    dataGridView3.RowCount++;
                    dataGridView3[0, dataGridView3.RowCount - 2].Value = productoVentaEscogido.Prod.Codigo;
                    dataGridView3[1, dataGridView3.RowCount - 2].Value = productoVentaEscogido.Prod.NoFicha;
                    dataGridView3[2, dataGridView3.RowCount - 2].Value = productoVentaEscogido.Prod.Descripcion;
                    dataGridView3[3, dataGridView3.RowCount - 2].Value = productoVentaEscogido.Prod.Suministrador;
                    dataGridView3[4, dataGridView3.RowCount - 2].Value = productoVentaEscogido.Prod.Color;
                    dataGridView3[5, dataGridView3.RowCount - 2].Value = productoVentaEscogido.Prod.Tipo.Nombre;
                    dataGridView3[6, dataGridView3.RowCount - 2].Value = productoVentaEscogido.Prod.Enchape.Nombre;
                    dataGridView3[7, dataGridView3.RowCount - 2].Value = productoVentaEscogido.Ancho;
                    dataGridView3[8, dataGridView3.RowCount - 2].Value = productoVentaEscogido.Alto;
                    dataGridView3[9, dataGridView3.RowCount - 2].Value = productoVentaEscogido.Cant;
                    dataGridView3[10, dataGridView3.RowCount - 2].Value = productoVentaEscogido.precioCUC();
                    dataGridView3[11, dataGridView3.RowCount - 2].Value = productoVentaEscogido.ImporteCUC();
                    dataGridView3[12, dataGridView3.RowCount - 2].Value = productoVentaEscogido.precioCUP();
                    dataGridView3[13, dataGridView3.RowCount - 2].Value = productoVentaEscogido.ImporteCUP();
                    dataGridView3[14, dataGridView3.RowCount - 2].Value = productoVentaEscogido.Prod.Id;


                    this.listProductosVenta.Add(productoVentaEscogido);

                }
            }
            else
                MessageBox.Show("Ya existe una ficha con este número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void dataGridView3_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (MessageBox.Show("Se eliminará el producto de la factura o prefactura actual.¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                this.listProductosVenta.RemoveAt(dataGridView3.SelectedRows[0].Index);
                dataGridView3.Rows.Remove(dataGridView3.SelectedRows[0]);

            }


        }

        private void desabilitarSeleccionarCliente()
        {
            listBox1.Enabled = false;
            button9.Visible = true;
        }
        private void abilitarSeleccionarCliente()
        {
            listBox1.Enabled = true;
            button9.Visible = false;
        }

        private void listBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyValue == 13)
                desabilitarSeleccionarCliente();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (listBox3.Items.Count > 0)
            {
                if (MessageBox.Show("Si continua se perderán los datos de pago realizado por la persona, ¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    abilitarSeleccionarCliente();
                    abilitarSeleccionarPersonaCliente();
                    listBox3.Items.Clear();
                }
            }
            else
            {
                abilitarSeleccionarCliente();
                abilitarSeleccionarPersonaCliente();
            }


        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
                desabilitarSeleccionarCliente();
        }
        private void desabilitarSeleccionarPersonaCliente()
        {
            listBox2.Enabled = false;
            button10.Visible = true;
            clienteSelecionado = true;
        }
        private void abilitarSeleccionarPersonaCliente()
        {
            listBox2.Enabled = true;
            button10.Visible = false;
            clienteSelecionado = false;
        }
        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                desabilitarSeleccionarPersonaCliente();
                desabilitarSeleccionarCliente();

            }

        }

        private void listBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                desabilitarSeleccionarPersonaCliente();
                desabilitarSeleccionarCliente();

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (listBox3.Items.Count > 0)
            {
                if (MessageBox.Show("Si continua se perderán los datos de pago realizado por la persona, ¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    abilitarSeleccionarPersonaCliente();
                    listBox3.Items.Clear();
                }
            }
            else
                abilitarSeleccionarPersonaCliente();

        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void datosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nuevo_Cliente formNuevoCliente = new Nuevo_Cliente(this.servicio);
            if (formNuevoCliente.ShowDialog() == DialogResult.OK)
            {
                if (groupBox3.Visible)
                    actualizarListadoClientes();

            }
        }

        private void reporteClienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteClientes infor = new ReporteClientes();
            String selection = "{TCliente.id} <> -1";
            VisorDeInforme visor = new VisorDeInforme(infor, selection);
            visor.ShowDialog(this);
        }

        private void consultarFichasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (groupBox1.Visible || groupBox3.Visible)
            {
                if (MessageBox.Show("¿Desea conservar los datos que no haya guardado de la vista actual?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    limpiarVisualProducto();
                }
            }

            groupBox3.Visible = false;
            groupBox1.Visible = false;
            groupBox4.Visible = false;
            groupBox2.Visible = true;
            label14.Visible = false;

            comboBox3.Items.Clear();
            TipoProducto tipoVacio = new TipoProducto("Todos");
            tipoVacio.Id = -1;
            comboBox3.Items.Add(tipoVacio);
            comboBox3.Items.AddRange(servicio.obtenerTiposProducto().ToArray());
            comboBox3.SelectedIndex = 0;

            comboBox4.Items.Clear();
            TipoEnchape enchapoVacio = new TipoEnchape("Todos");
            enchapoVacio.Id = -1;
            comboBox4.Items.Add(enchapoVacio);
            comboBox4.Items.AddRange(servicio.obtenerTiposEnchape().ToArray());
            comboBox4.SelectedIndex = 0;

            //List<Producto> listProducto = this.servicio.consultarProducto();
            //dataGridView1.RowCount = listProducto.Count+1;

            //for (int i = 0; i < listProducto.Count; i++)
            //{
            //    dataGridView1[0, i].Value = listProducto[i].Codigo;
            //    dataGridView1[1, i].Value = listProducto[i].NoFicha;
            //    dataGridView1[2, i].Value = listProducto[i].Descripcion;
            //    dataGridView1[3, i].Value = listProducto[i].Tipo.ToString();
            //    dataGridView1[4, i].Value = listProducto[i].Enchape.ToString();
            //    dataGridView1[5, i].Value = listProducto[i].PrecioCUP;
            //    dataGridView1[6, i].Value = listProducto[i].PrecioCUC;  
            //} 
        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (groupBox1.Visible)
            {
                if (MessageBox.Show("¿Desea conservar los datos que no haya guardado de la vista actual?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    limpiarVisualProducto();
                }
            }

            groupBox3.Text = "Nueva Prefactura";
            groupBox4.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = true;


            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Value = DateTime.Now;

            label46.Visible = false;

            comboBox6.Items.Clear();
            TipoProducto tipoVacio = new TipoProducto("Todos");
            tipoVacio.Id = -1;
            comboBox6.Items.Add(tipoVacio);
            comboBox6.Items.AddRange(servicio.obtenerTiposProducto().ToArray());
            comboBox6.SelectedIndex = 0;

            comboBox5.Items.Clear();
            TipoEnchape enchapoVacio = new TipoEnchape("Todos");
            enchapoVacio.Id = -1;
            comboBox5.Items.Add(enchapoVacio);
            comboBox5.Items.AddRange(servicio.obtenerTiposEnchape().ToArray());
            comboBox5.SelectedIndex = 0;
            this.listProductosVenta = new List<ProductoVenta>();
            this.TipoVent = TipoVenta.prefactura;

            actualizarListadoClientes();




        }

        private void facturaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
        }

        private void consultarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (groupBox1.Visible)
            {
                if (MessageBox.Show("¿Desea conservar los datos que no haya guardado de la vista actual?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    limpiarVisualProducto();
                }
            }

            groupBox3.Text = "Nueva Factura";
            groupBox4.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = true;


            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Value = DateTime.Now;

            label46.Visible = false;

            comboBox6.Items.Clear();
            TipoProducto tipoVacio = new TipoProducto("Todos");
            tipoVacio.Id = -1;
            comboBox6.Items.Add(tipoVacio);
            comboBox6.Items.AddRange(servicio.obtenerTiposProducto().ToArray());
            comboBox6.SelectedIndex = 0;

            comboBox5.Items.Clear();
            TipoEnchape enchapoVacio = new TipoEnchape("Todos");
            enchapoVacio.Id = -1;
            comboBox5.Items.Add(enchapoVacio);
            comboBox5.Items.AddRange(servicio.obtenerTiposEnchape().ToArray());
            comboBox5.SelectedIndex = 0;
            this.listProductosVenta = new List<ProductoVenta>();
            this.TipoVent = TipoVenta.factura;

            actualizarListadoClientes();
        }

        private void reportesFichasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteClientes infor = new ReporteClientes();
            String selection = "";
            VisorDeInforme visor = new VisorDeInforme(infor, selection);
            visor.ShowDialog(this);
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteVenta infor = new ReporteVenta();
            String selection = "{TVenta.Id} = 22 and {TCliente.Id}={TVenta.cliente} and {TPersonaCliente.id} = {TVenta.comercial} and {TProductoVenta.venta} = {TVenta.id} and {TProducto.id} = {TProductoVenta.producto}";
            VisorDeInforme visor = new VisorDeInforme(infor, selection);
            visor.ShowDialog(this);
        }

        private void imprimirVenta(int id)
        {
            ReporteVenta infor = new ReporteVenta();
            String selection = "{TVenta.Id} = " + id + " and {TCliente.Id}={TVenta.cliente} and {TPersonaCliente.id} = {TVenta.comercial} and {TProductoVenta.venta} = {TVenta.id} and {TProducto.id} = {TProductoVenta.producto}";
            VisorDeInforme visor = new VisorDeInforme(infor, selection);
            visor.ShowDialog(this);
        }

        private void insertarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Administrar_Usuarios form = new Administrar_Usuarios(this.servicio);
            form.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {

            //DateTimeFormatInfo dfi = new DateTimeFormatInfo();
            ////dfi.MonthDayPattern = "MM-MMMM, ddd-dddd";

            //dfi.ShortDatePattern = "dd/MM/yyyy";
            //string fechas = dateTimePicker2.Value.ToString(dfi);

            //dfi.ShortDatePattern = "dd - MM - yyyy";
            //fechas += "\n\n" + dateTimePicker2.Value.ToString(dfi);

            //dfi.ShortDatePattern = "MM/dd/yyyy HH:mm";
            //fechas += "\n\n" + dateTimePicker2.Value.ToString(dfi);


            //MessageBox.Show(fechas);



            List<Venta> result = servicio.consultarVentas(0, dateTimePicker2.Value, dateTimePicker3.Value);



            dataGridView4.RowCount = result.Count + 1;
            for (int i = 0; i < result.Count; i++)
            {
                dataGridView4[0, i].Value = i+1;
                dataGridView4[1, i].Value = result[i].Fecha;
                dataGridView4[2, i].Value = result[i].Cliente.Nombre;
                dataGridView4[3, i].Value = result[i].Comercial.nombreCompleto();
                dataGridView4[4, i].Value = result[i].ImporteCUCTotal();
                dataGridView4[5, i].Value = result[i].ImporteCUPTotal();

            }
             

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            formPrincipal.Close();
        }

    }
}