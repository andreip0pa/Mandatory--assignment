using System;
using System.Collections.Generic;
using System.Net.Sockets;
using BookClassLib;
namespace TCPBookServer
{
    class Program
    {
        
        static void Main(string[] args)
        {
            

            Server c = new Server();
            c.Start();
            

            Console.WriteLine("Hello World!");
        }
    }
}
