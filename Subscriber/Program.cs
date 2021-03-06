﻿using EasyNetQ;
using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus(Config.ConnectionString))
            {
                bus.Subscribe<TextMessage>("test", HandleTextMessage);
                Console.WriteLine("Enter 'Quit/quit' to quit.");
                while (Console.ReadLine().ToLower() != "Quit".ToLower())
                {
                }
            }
        }

        static void HandleTextMessage(TextMessage textMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Got message: {0}", textMessage.Text);
            Console.ResetColor();
        }
    }
}
