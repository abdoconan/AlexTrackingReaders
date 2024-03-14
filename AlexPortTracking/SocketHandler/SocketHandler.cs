using System.Net.Sockets;
using System.Net;
using System.Text;

namespace SocketHandler
{
    public class SocketHandler
    {
        private readonly uint port;
        public Func<string, SocketHandler, Task<bool>> Action { get; set; }

        public SocketHandler(uint port, Func<string, SocketHandler, Task<bool>> Action)
        {
            this.port = port;
            this.Action = Action;
        }

        public async Task Connect()
        {


            // Start listening for incoming connection requests


            new Thread( async() => 
            {
                IPAddress ipAddress = IPAddress.Any;

                // Create a TCP listener
                TcpListener listener = new TcpListener(ipAddress, (int)port);

                listener.Start();
                Console.WriteLine($"Server is listening on {ipAddress}:{port}");
                try
                {
                    while (true)
                    {

                        // Accept the pending client connection
                        TcpClient client = await listener.AcceptTcpClientAsync();

                        Console.WriteLine($"Client connected on port {this.port}");

                        // Handle client communication asynchronously
                        _ = HandleClientAsync(client);

                        Thread.Sleep(10);

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
                finally
                {
                    // Stop listening for new clients
                    listener.Stop();
                }
            } ).Start();

          


        }


        async Task HandleClientAsync(TcpClient client)
        {
            try
            {
                // Get a stream object for reading and writing
                NetworkStream stream = client.GetStream();

                // Buffer for storing received data
                byte[] buffer = new byte[1024];

                while (true)
                {
                    buffer = new byte[1024]; 
                    // Read data from the client
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

                    //// If no data was read, the client has disconnected
                    //if (bytesRead == 0)
                    //{
                    //    Console.WriteLine("Client disconnected.");
                    //    break;
                    //}

                    // Convert the received data to a string
                    string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    await this.Action(dataReceived.Trim(), this);


                    // Optionally, you can send a response back to the client
                    //string responseMessage = "Message received!";
                    //byte[] responseData = Encoding.UTF8.GetBytes(responseMessage);
                    //await stream.WriteAsync(responseData, 0, responseData.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred with a client: {ex.Message}");
            }
            finally
            {
                // Close the client connection
                client.Close();
            }
        }
    }
}
