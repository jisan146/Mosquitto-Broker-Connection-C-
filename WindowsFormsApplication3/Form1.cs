using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using System.Threading.Tasks;
using System.Windows;


namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        MqttClient client;
        string clientId;
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            client = new MqttClient(IPAddress.Parse(host.Text));
            clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);
            client.Publish(topic.Text,Encoding.UTF8.GetBytes(message.Text));
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                // these last two lines will stop the beep sound
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                topic.Focus();
                // these last two lines will stop the beep sound
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                message.Focus();
                // these last two lines will stop the beep sound
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

       
  

     
    }
}
