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

namespace proasenseIO
{
    public partial class proasense : Form
    {
        private NetworkStream serverStream;
        private TcpClient tcpCl;
        public NetworkStream ServerStream
        {
            get
            {
                return this.serverStream;
            }
            set 
            {
                this.serverStream = value;
            }
        }
        public TcpClient TCPCl
        {
            get
            {
                return this.tcpCl ;
            }
            set
            {
                this.tcpCl = value;
            }
        }
        public proasense()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = "{\"totalUnits\":\""+textBox1.Text+"\",\"scrapRate\":\""+textBox2.Text+"\",\"oee\":\""+textBox3.Text+"\",\"kpi\":\""+textBox4.Text+"\"}";
            byte[] outStream = Encoding.ASCII.GetBytes(msg);
            this.ServerStream.Write(outStream, 0, outStream.Length);
            this.ServerStream.Flush();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.TCPCl = new TcpClient();
                this.TCPCl.Connect(textBox5.Text, Convert.ToInt16(textBox6.Text));
                this.ServerStream = this.TCPCl.GetStream();
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true; 
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = true;
            }
            catch(Exception ex)
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.TCPCl.Close();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = false;

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

    }
}
