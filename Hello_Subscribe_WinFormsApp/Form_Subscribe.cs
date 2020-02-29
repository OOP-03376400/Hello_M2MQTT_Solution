﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Hello_Subscribe_WinFormsApp
{
    public partial class Form_Subscribe : Form
    {
        MqttClient client;

        public Form_Subscribe()
        {
            InitializeComponent();

            client = new MqttClient(IPAddress.Parse("172.104.35.200"));

            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);

            // subscribe to the topic "/home/temperature" with QoS 2
            client.Subscribe
                (new string[] { "esp32/temperature" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        }

        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            // access data bytes throug e.Message
            byte[] buffer = e.Message;
            string s = System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length);

            Console.WriteLine(s);
            this.Invoke(new MethodInvoker(()=> { textBox1.Text += s.ToString() + "\r\n";  } ));

            
        }

        private void Form_Subscribe_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.Disconnect();
        }
    }
}
