using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.IO;
using BookClassLib;
using Newtonsoft.Json;
namespace TCPBookServer
{
    class Server
    {
        List<Book> bookList = new List<Book>();
        public void Start()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            TcpListener tcpListener = new TcpListener(System.Net.IPAddress.Loopback, 4646);
            tcpListener.Start();
            Console.WriteLine("Server started");
            bookList.Add(new Book("Moby Dick", "Herman Melville", 234, "12-34-32-12-3"));
            bookList.Add(new Book("abc", "def",111, "1234123412341"));
            


            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            while (true)
            {
                if (tcpListener.Pending())
                {
                    tcpClient = tcpListener.AcceptTcpClient();
                }

                //  Console.Clear();
                //  Console.WriteLine("Connected");



                try
                {

                    //  Console.Write("Receiving...:");
                    System.Threading.Tasks.Task.Run(() => { TcpClient tsock = tcpClient; DoClient(tsock); });

                    //  System.Threading.Thread.Sleep(5000);
                    //  DoClient(tcpClient);
                }


                catch
                {

                }



            }



        }

        void DoClient(TcpClient tcpClient)
        {
            var stream = tcpClient.GetStream();
            StreamReader sr = new StreamReader(stream);
            StreamWriter sw = new StreamWriter(stream);
            sw.AutoFlush = true;
            string line = sr.ReadLine();
            Console.WriteLine(line);


            if (line=="GetAll")
            {
                foreach (var item in bookList) 
                {
                    sw.WriteLine(JsonConvert.SerializeObject(item));

                }
            }


            if (line.Contains("Get"))
            {
                foreach (var item in line.Split(" "))
                {
                    if (item == "Get")
                    {

                    }
                    else
                    {
                        try
                        {
                            sw.WriteLine(JsonConvert.SerializeObject(bookList.Find(x => (x.Isbn13 == item))));
                        }
                        catch
                        {
                            sw.WriteLine("Couldn't find book!");
                        }
                    }
                }
            }

            if (line.Contains("Save"))
            {
                foreach (var item in line.Split(" "))
                {
                    if (item == "Save")
                    {

                    }
                    else
                    {
                        try
                        {
                            Book book1 = JsonConvert.DeserializeObject<Book>(item);
                            bookList.Add(book1);
                        }
                        catch
                        {
                            sw.WriteLine("Couldn't save book");
                        }
                    }
                }
            }



            else
            {
                sw.WriteLine("Message Received!");
            }



        }
    }
}
