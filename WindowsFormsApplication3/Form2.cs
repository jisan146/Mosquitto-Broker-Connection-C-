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
    public partial class Form2 : Form
    {
        string s;

        public Form2()
        {
            InitializeComponent();
            var client = new MqttClient(IPAddress.Parse("192.168.0.101"));

            // register to message received
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            var clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);

            // subscribe to the topic "/home/temperature" with QoS 2
            client.Subscribe(
                new string[] { "test" },
                new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
           
        }
        void client_MqttMsgPublishReceived(
      object sender, MqttMsgPublishEventArgs e)
        {
            // handle message received  e.Message.ToString()
            s = Encoding.UTF8.GetString(e.Message);
          

           // MessageBox.Show(s);
            //Console.WriteLine("message=" + Encoding.UTF8.GetString(e.Message));
           
        
           
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
          

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = s;
        }
    }
}
