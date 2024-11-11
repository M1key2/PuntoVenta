using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoVenta
{
    public partial class Form1 : Form
    {
        String[,] productos = new string[5, 2] { { "coca", "20" }, { "sabritas", "15" }, { "atun", "15" }, { "mapa", "50" }, { "agua", "10" } };
        String[] recibo;
        double sub, iva, total;
        public Form1()
        {
            InitializeComponent();
            iniciarproductos();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void iniciarproductos()
        {
            for (int i = 0; i < 5; i++)
            {
                lbProductos.Items.Add(productos[i,0]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbrecibo.Items.Add(productos[lbProductos.SelectedIndex,0]);
            sub += Convert.ToDouble(productos[lbProductos.SelectedIndex, 1]);
            iva = sub * .16;
            lblIva.Text = "$"+iva.ToString();
            lblSub.Text = "$"+sub.ToString();
            total = sub + iva;
            lblTotal.Text = "$" + total.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lbrecibo.SelectedIndex != -1)
            {
                switch (lbrecibo.SelectedItem)
                {
                    case "coca":
                        sub = sub - 20;
                        break;
                    case "sabritas":
                        sub = sub - 15;
                        break;
                    case "atun":
                        sub = sub - 15;
                        break;
                    case "mota":
                        sub = sub - 50;
                        break;
                    case "agua":
                        sub = sub - 10;
                        break;
                }
                lbrecibo.Items.RemoveAt(lbrecibo.SelectedIndex);

                iva = sub * .16;
                lblIva.Text = iva.ToString();
                lblSub.Text = "$" + sub.ToString();
                total = sub + iva;
                lblTotal.Text = "$" + total.ToString();
            }
            else
            {
                MessageBox.Show("Please select an item to remove.");
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("desea confirmar la compra?","factura",MessageBoxButtons.YesNo)==DialogResult.No)
            {

            }
            else
            {
               
                lblSub.Text = "$0.00";
                lblIva.Text = "$0.00";
                lblTotal.Text = "$0.00";
            }

            
            
        }
    }
}
