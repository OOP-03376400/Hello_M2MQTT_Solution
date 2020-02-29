using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Hello_Publish_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Merhaba MQTT");

            // create client instance
            MqttClient client = new MqttClient(IPAddress.Parse("172.104.35.200"));

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);

            //string strValue = Convert.ToString(value);
            string strValue = "off";

            // publish a message on "/home/temperature" topic with QoS 2
            client.Publish("esp32/output", Encoding.UTF8.GetBytes(strValue)  /*, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE */ );

        }
    }
}
