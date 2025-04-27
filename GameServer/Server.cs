using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace GameServer
{
    class Server
    {
        private TcpListener listener;
        public List<Player> connectedPlayers;
        public List<GameRoom> gameRooms;
        private object lockObj = new object();

        Thread clientThread;

        public Server(IPAddress ip, int port)
        {
            listener = new TcpListener(ip, port);
            connectedPlayers = new List<Player>();
            gameRooms = new List<GameRoom>();
        }

        public void Start_Server()
        {
            listener.Start();
            Console.WriteLine("Server started... Waiting for players.");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Player player = new Player(client, this);

                 clientThread = new Thread(player.HandleClient);
                 clientThread.Start();
            }
        }    
        public void BroadcastPlayersList()
        {
            StringBuilder playerList = new StringBuilder("PLAYERS_LIST:");

            lock (lockObj)
            {
                foreach (var player in connectedPlayers)
                {
                    playerList.Append($"{player.PlayerName}|");
                }
            }
                string message = playerList.ToString().TrimEnd('|');

            lock (lockObj)
            {
                foreach (var player in connectedPlayers)
                {
                    player.SendMessage(message);
                }
                Console.WriteLine($"Broadcasted_Players:{message}");
            }
        }

        public bool isPlaying(GameRoom r)
        {
            bool flag=false;
            foreach(var room in gameRooms)
            {
                if (r.Owner == room.Opponent)
                    flag = true;
            }
            return flag;
        }
        public bool isWatching(GameRoom r)
        {
            bool flag = false;
            foreach (var room in gameRooms)
            {
               for(int i=0; i<room.Spectators.Count;i++)
                {
                    if(r.Owner == room.Spectators[i])
                        flag = true;
                }
            }
            return flag;
        }
        public void BroadcastRoomList()
        {
            StringBuilder roomList = new StringBuilder("ROOM_LIST:");

            lock (lockObj)
            {
                foreach (var room in gameRooms)
                {
                    if(!isPlaying(room) && !isWatching(room))
                        roomList.Append($"{room.RoomId}|");
                }
            }

            string message = roomList.ToString().TrimEnd('|');

            lock (lockObj)
            {
                foreach (var player in connectedPlayers)
                {
                    player.SendMessage(message);
                }
            }
            Console.WriteLine($"Broadcasted_Rooms:{message}");
        }

        public void HandleLogin(Player player ,string message)
        {
            player.PlayerName = message.Split(':')[1];
            bool flag = false;

            foreach (var plr in connectedPlayers)
            {
                if (plr.PlayerName == player.PlayerName)
                    flag = true;
            }

            if (flag)
            {
                player.SendMessage("FAIL");
                Console.WriteLine("Login failed, Username was Already Used");
            }
            else
            {
                lock (lockObj)
                {
                    connectedPlayers.Add(player);
                }
                player.SendMessage("SUCCESS");
                Console.WriteLine($"{player.PlayerName} connected.");
                BroadcastPlayersList();
                BroadcastRoomList();
            }
        }

        public void CreateRoom(Player player, string category)
        {
            lock (lockObj)
            {
                GameRoom newRoom = new GameRoom(player, category);
                gameRooms.Add(newRoom);
                player.SendMessage($"ROOM_CREATED:{newRoom.RoomId}");
                BroadcastRoomList();
            }
        }

        public void HandleJoinRequest(Player player, string roomId)
        {
            lock (lockObj)
            {
                GameRoom room = gameRooms.Find(r => r.RoomId == roomId);
                
                if (room != null)
                {
                    if (room.Owner == player)
                    {
                        Console.WriteLine("Alone will be sent");
                        player.SendMessage("Alone");
                    }
                    else if (room.Opponent == null)
                    {
                        Console.WriteLine($"{player.PlayerName} wants to join {room.Owner.PlayerName}'s Room");
                        room.Owner.SendMessage($"JoinRequest:{player.PlayerName}:{roomId}");
                    }
                    else //possible watcher
                    {
                        Console.WriteLine($"{player.PlayerName} wants to watch {room.Owner.PlayerName}'s Room");
                        player.SendMessage($"ROOM_FULL:{roomId}"); //might be a watcher
                    }
                }
                else
                {
                    player.SendMessage("ROOM_NOT_FOUND");
                }

            }
        }
        public void HandleJoinRoom(string AcceptMessage)
        {
            lock (lockObj)
            {
                string playerName = AcceptMessage.Split(':')[1];
                string roomId = AcceptMessage.Split(':')[2];
                Player player = connectedPlayers.Find(p => p.PlayerName == playerName);
                GameRoom room = gameRooms.Find(r => r.RoomId == roomId);
                if (room != null)
                {
                    int joined = room.JoinRoom(player);  //checks if he will be an opponent(1) or will be a watcher (2)
                    if (joined == 1)
                    {
                        player.SendMessage($"ROOM_JOINED:{roomId}");
                        if (room.IsReadyToStart())
                        {
                            room.StartGame();
                            BroadcastRoomList();
                        }
                    }
                    else if (joined == 2)
                    {
                        Console.WriteLine($"{room.Owner.PlayerName} accepted a watch request from {player.PlayerName}");
                        player.SendMessage($"AcceptWatch:{room.RoomId}:{new string(room.guessedWord)}:{room.Owner.PlayerName}:{room.Opponent.PlayerName}:{room.RoomCategory}"); //watcher
                        BroadcastRoomList();
                    }
                }
                else
                {
                    player.SendMessage("ROOM_NOT_FOUND");
                }
            }
        }

        public GameRoom GetRoomForPlayer(Player player)
        {
            lock (lockObj)
            {
                return gameRooms.Find(room => room.Owner == player || room.Opponent == player);
            }
        }

        public void HandlePlayAgain(Player player)
        {
            GameRoom room = GetRoomForPlayer(player);
            if(room !=null)
            {
                if(room.Opponent != null)
                {
                    if (room.Owner == player)
                    {
                        player.PlayAgain = true;
                        Console.WriteLine($"{room.Owner.PlayerName} sends to {room.Opponent.PlayerName} that he wants to play again");
                    }
                    else
                    {
                        player.PlayAgain = true;
                        Console.WriteLine($"{room.Opponent.PlayerName} sends to {room.Owner.PlayerName} that he wants to play again");
                    }

                    if (room.Owner.PlayAgain && room.Opponent.PlayAgain)
                    {
                        room.RestartGame();
                        room.Owner.PlayAgain = false;
                        room.Opponent.PlayAgain = false;
                    }
                }
                else
                {
                    room.Owner.SendMessage("OPPONENT_LEFT");
                }
            }
            else
            {
                player.SendMessage("KICKED");

            }
        }

        public void HandleLeavingRoom(Player player)
        {
            GameRoom room = GetRoomForPlayer(player);

            if (room != null)
            {
                if(room.Spectators.Count>=1)
                {
                    lock (lockObj)
                    {
                        for (int i=0;i<room.Spectators.Count;i++)
                        {
                            room.Spectators[i].SendMessage("KICK_WATCHERS");
                            room.Spectators.Remove(room.Spectators[i]);
                        }
                        string watchers = $"WATCHERS:{room.Spectators.Count.ToString()}";
                        room.Owner.SendMessage(watchers);
                    }
                }

               if(player == room.Owner)
                {
                    if (room.Opponent != null)
                    {
                        room.Opponent.SendMessage("KICKED");
                        Console.WriteLine($"{room.Opponent.PlayerName} was kicked from room {room.RoomId}");
                        room.Opponent = null;
                    }
                    
                }
               else
                {
                    room.Opponent = null;
                    room.Owner.SendMessage("OPPONENT_LEFT");
                }
            }
        }
        public static void SaveGameResult(string winner, int score1, string looser,int score2)
        {
            string result = $"{winner}: {score1}, {looser}: {score2}";
            System.IO.File.AppendAllText("..\\..\\..\\Results\\GameResults.txt", result + Environment.NewLine);
            Console.WriteLine($"Game_Over: {winner} wins!");
        }

        public void ShutdownServer()
        {
           
            // Close all client connections
            foreach (Player player in connectedPlayers)
            {
                player.CloseConnection();
            }

            clientThread.Abort();

            // Stop the listener
            if (listener != null)
            {
                listener.Stop();
                listener = null;
            }
        }
  
    } 
}