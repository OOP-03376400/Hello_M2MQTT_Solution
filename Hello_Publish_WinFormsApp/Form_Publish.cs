using System;
using System.Net;
using System.Text;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;

namespace Hello_Publish_WinFormsApp
{
    public partial class Terminal
    {
        public int Id { get; set; }
        public string message { get; set; }
        public string datetime { get; set; }
        public string topic { get; set; }
    }

    public partial class Form_Publish : Form
    {
        MqttClient client;

        public Form_Publish()
        {
            InitializeComponent();

            // create client instance
            client = new MqttClient(IPAddress.Parse("172.104.35.200"));

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // client.Publish("/hello", Encoding.UTF8.GetBytes(strValue)  /*, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE */ );
            client.Publish("esp32/output", Encoding.UTF8.GetBytes("on"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // client.Publish("/hello", Encoding.UTF8.GetBytes(strValue)  /*, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE */ );
            client.Publish("esp32/output", Encoding.UTF8.GetBytes("off"));
        }


        private void Form_Publish_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.Disconnect();
        }
    }
}
