using EasyNetQ;
using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus(Config.ConnectionString))
            {
                var input = "";
                Console.WriteLine("Enter a message. 'Quit/quit' to quit.");
                while ((input = Console.ReadLine()).ToLower() != "Quit".ToLower())
                {
                    bus.Publish(new TextMessage
                    {
                        Text = input
                    });
                }
            }
        }
    }
}
