using System.Net;

namespace GameServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int port = 5000;
            byte[] bt = { 127, 0, 0, 1 };
            IPAddress ladd = new IPAddress(bt);
            Server server = new Server(ladd,port);
            server.Start_Server();

            Console.CancelKeyPress += (sender, e) => {
                server.ShutdownServer();
            };
        }
    }
}
