using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpUsage
{
    class Program
    {
        const string address = "127.0.0.1";
        const int port = 13000;
        const string message = "Hello from the Client!";

        static void Main(string[] args)
        {
            StartListener();
            StartClient();

            Console.ReadKey();
        }

        private static void StartListener()
        {
            Task.Run(() =>
            {
                try
                {
                    // Set the TcpListener on port 13000.
                    IPAddress localAddr = IPAddress.Parse(address);

                    // TcpListener server = new TcpListener(port);
                    TcpListener server = new TcpListener(localAddr, port);

                    // Start listening for client requests.
                    server.Start();

                    // Buffer for reading data
                    Byte[] bytes = new Byte[256];
                    String data = null;

                    // Enter the listening loop.
                    while (true)
                    {
                        Console.WriteLine("SERVER: Waiting for a connection... ");

                        // Perform a blocking call to accept requests.
                        // You could also user server.AcceptSocket() here.
                        TcpClient client = server.AcceptTcpClient();
                        Console.WriteLine("SERVER: Client Connected!");

                        data = null;

                        // Get a stream object for reading and writing
                        NetworkStream stream = client.GetStream();

                        int i;

                        // Loop to receive all the data sent by the client.
                        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            // Translate data bytes to a ASCII string.
                            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                            Console.WriteLine(String.Format("SERVER: Received: {0}", data));

                            // Process the data sent by the client.
                            data = data.ToUpper();

                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                            // Send back a response.
                            stream.Write(msg, 0, msg.Length);
                            Console.WriteLine(String.Format("SERVER: Sent: {0}", data));
                        }

                        // Shutdown and end connection
                        client.Close();
                    }
                }
                catch (SocketException e)
                {
                    Console.WriteLine("SERVER: SocketException: {0}", e);
                }
            });
        }

        private static void StartClient()
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.
                Int32 port = 13000;
                TcpClient client = new TcpClient(address, port);

                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);

                Console.WriteLine("CLIENT: Sent: {0}", message);

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                data = new Byte[256];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("CLIENT: Received: {0}", responseData);

                // Close everything.
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("CLIENT: ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("CLIENT: SocketException: {0}", e);
            }
        }
    }
}
