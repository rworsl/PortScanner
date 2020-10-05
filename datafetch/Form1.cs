using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace datafetch
{
    public partial class Form1 : Form
    {
        string address { get; set; }
        decimal endPort { get; set; }
        decimal startPort { get; set; }
        List<int> ports = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            address = textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

       public void scan(string address, List<int> ports)
        {
            foreach (int s in ports)
            {
                using (TcpClient Scan = new TcpClient())
                {
                    try
                    {
                        Scan.Connect(address, s);
                        textBox1.AppendText($"[{s}] | OPEN");
                        textBox1.AppendText(Environment.NewLine);
                    }
                    catch
                    {
                        textBox1.AppendText($"[{s}] | CLOSED");
                        textBox1.AppendText(Environment.NewLine);
                    }
                }
            }
        }

        private void button1_MouseClick(object sender, EventArgs e)
        {
            for(int i = (int)startPort; i <= (int)endPort; i++)
            {
                ports.Add(i);
            }
            scan(address, ports);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            endPort = numericUpDown2.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            startPort = numericUpDown1.Value;
        }
    }
}


