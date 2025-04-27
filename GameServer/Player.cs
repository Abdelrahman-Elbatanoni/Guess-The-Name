using System;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading;

namespace GameServer
{
    class Player
    {
        public string PlayerName { get; set; }
        public TcpClient client { get; private set; }
        public NetworkStream stream { get; private set; }
        private Server server;
        private StreamReader reader;
        private StreamWriter writer;
        private readonly object streamLock = new object();  // Lock object for stream access
        public bool PlayAgain = false;
        public int score=0;

        public Player(TcpClient client, Server server)
        {
            this.client = client;
            this.server = server;
            stream = client.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream) {AutoFlush = true};
        }

        public void HandleClient()
        {
            try
            {
                while (true)
                {
                    string message = reader.ReadLine();
                    if (message == null) break;
                    Console.WriteLine($"Received: {message}");
                    ProcessMessage(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
        }

        private void ProcessMessage(string message)  //process recieved messages from client side
        {
            if (message.StartsWith("LOGIN:"))
            {
                server.HandleLogin(this, message);
            }
            else if (message.StartsWith("CREATE_ROOM"))
            {
                string category = message.Split(':')[1];
                server.CreateRoom(this,category);
                Console.WriteLine($"{PlayerName} created a room.");
            }
            else if (message.StartsWith("JOIN_ROOM:"))
            {
                string roomId = message.Split(':')[1];
                Console.WriteLine($"{PlayerName} wants to join room {roomId}");
                server.HandleJoinRequest(this, roomId);
            }
            else if (message.StartsWith("AcceptToJoin"))
            {
                Console.WriteLine($"{PlayerName} accepted a join request");
                server.HandleJoinRoom(message);
            }
            else if (message.StartsWith("WantsToWatch"))
            {
                Console.WriteLine($"{PlayerName} Wants to watch room {message.Split(':')[2]}");
                server.HandleJoinRoom(message);
            }
            else if (message.StartsWith("GUESS:"))
            {
                char letter = message.Substring(6)[0];
                GameRoom room = server.GetRoomForPlayer(this);
                room?.GuessLetter(this, letter);
            }
            else if (message == "PLAY_AGAIN?")
            {
                Console.WriteLine($"{PlayerName} wants to play again");
                server.HandlePlayAgain(this);
            }
            else if (message == "KICK")
            {
                Console.WriteLine($"{PlayerName} wants to leave the room");
                server.HandleLeavingRoom(this);
            }
            else if (message == "EXITWATCHING")
            {
                Console.WriteLine($"{PlayerName} Ends his watching mode");
                closeWatcher();
            }
            else if (message.StartsWith("GET_ROOM_DETAILS"))
            {
               string roomID = message.Split(':')[1];
                GameRoom room = server.gameRooms.Find(r => r.RoomId == roomID);
                if (room != null)
                {
                    if (room.Opponent != null)
                    {
                        SendMessage($"ROOM_DETAILS:{room.Opponent.PlayerName}:{room.RoomCategory}");
                    }
                    else
                    {
                        SendMessage($"ROOM_DETAILS:.:{room.RoomCategory}");
                    }
                }
            }
        }

        public void SendMessage(string message)
        {
            lock (streamLock)
            {
                writer.WriteLine(message);  // Send message safely using lock
            }
        }
       
        public void closeWatcher()
        {
            GameRoom Watchedroom = server.gameRooms.Find(room => room.Spectators.Contains(this));
            if (Watchedroom != null)
            {
                Watchedroom.Spectators.Remove(this);
                string watchers = $"WATCHERS:{Watchedroom.Spectators.Count.ToString()}";
                Watchedroom.Owner.SendMessage(watchers);
                Watchedroom.Opponent.SendMessage(watchers);
               
            }
        }
        public void CloseConnection()
        {
            closeWatcher();

            List<GameRoom> rooms = server.gameRooms.FindAll(room => room.Owner  == this);
            Console.WriteLine($"{PlayerName} disconnected.");
            lock(streamLock)
            { 
                server.connectedPlayers.Remove(this);
                server.BroadcastPlayersList();
                if(rooms!=null)
                {
                    for(int i=0;i< rooms.Count;i++)
                    {
                        server.gameRooms.Remove(rooms[i]);
                        Console.WriteLine($"room {rooms[i].RoomId} was Removed");
                    }
                    server.BroadcastRoomList();
                }  
            }
            try
            {
                this.stream.Close();
                this.client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error closing watcher: " + ex.Message);
            }

        }
    }

}
