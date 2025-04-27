using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClient
{
    public partial class GameRoomForm : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private string playerName;
        private StreamWriter writer;
        private StreamReader reader;
        private Thread receiveThread;
        private int selectedIndex = -1;

        public GameRoomForm(TcpClient client, string usrname, StreamReader reader)
        {
            InitializeComponent();

            this.client = client;
            this.playerName = usrname;
            stream = client.GetStream();
            this.reader = reader;
            writer = new StreamWriter(stream) { AutoFlush = true };
            receiveThread = new Thread(ListenForMessages);
            receiveThread.IsBackground = true;
            receiveThread.Start();
            Exit.Hide();
        }
        public void SendMessage(string message)
        {
            writer.WriteLine(message);
        }

        private void ListenForMessages()
        {
            while (true)
            {
                string message = reader.ReadLine();
                if (message == null) break;
                ProcessMessage(message);
            }
        }

        private void ProcessMessage(string message)
        {
            if (message.StartsWith("PLAYERS_LIST"))
            {
                string[] players = message.Substring(13).Split('|');

                if (lstPlayers.InvokeRequired)
                {
                    lstPlayers.BeginInvoke(new Action(() =>
                    {
                        lstPlayers.Items.Clear();
                        foreach (var player in players)
                        {
                            if (!string.IsNullOrWhiteSpace(player))
                            {
                                lstPlayers.Items.Add(player);
                            }
                        }
                    }));
                }
                else
                {
                    lstPlayers.Items.Clear();
                    foreach (var player in players)
                    {
                        if (!string.IsNullOrWhiteSpace(player))
                        {
                            lstPlayers.Items.Add(player);
                        }
                    }
                }

            }
            else if (message.StartsWith("ROOM_LIST"))
            {
                string[] rooms = message.Substring(10).Split('|');
                if (lstRooms.InvokeRequired)
                {
                    lstRooms.BeginInvoke(new Action(() =>
                    {
                        lstRooms.Items.Clear();
                        foreach (var room in rooms)
                        {
                            if (!string.IsNullOrWhiteSpace(room))
                            {
                                lstRooms.Items.Add(room);
                            }
                        }
                    }));
                }
                else
                {
                    lstRooms.Items.Clear();
                    foreach (var room in rooms)
                    {
                        if (!string.IsNullOrWhiteSpace(room))
                        {
                            lstRooms.Items.Add(room);
                        }
                    }
                }
            }
            else if (message.StartsWith("JoinRequest"))
            {
                string opponent = message.Split(':')[1];
                string roomId = message.Split(':')[2];

                DialogResult result = MessageBox.Show($"{opponent} wants to play with you", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    SendMessage($"AcceptToJoin:{opponent}:{roomId}");
                }
            }

            else if (message.StartsWith("ROOM_JOINED"))
            {
                string roomId = message.Split(':')[1];
                MessageBox.Show($"You Have Joined Room {roomId}.");
            }

            else if (message == "Alone")
            {
                MessageBox.Show($"Wait for an opponent first");
            }

            else if (message == "ROOM_NOT_FOUND")
            {
                MessageBox.Show($"Room not Found");
            }

            else if (message.StartsWith("STARTGAME"))
            {
                string word = message.Split(":")[1];
                string Room_Categorey = message.Split(":")[2];
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new Action(() =>
                     {
                         GuessedWord.Text = word;
                         PlayerNameLabel.Text = playerName;
                         RoomPanel.Hide();
                         CategoryLabel.Text = Room_Categorey;
                     }));

                }
                else
                {
                    GuessedWord.Text = word;
                    PlayerNameLabel.Text = playerName;
                    RoomPanel.Hide();
                    CategoryLabel.Text = Room_Categorey;
                }
            }
            else if (message.StartsWith("ROOM_FULL"))
            {
                string roomId = message.Split(":")[1];

                DialogResult result = MessageBox.Show($"Room: {roomId} is Full, Do you want to Join For Watching??", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    SendMessage($"WantsToWatch:{playerName}:{roomId}");
                }
            }
            else if (message.StartsWith("AcceptWatch"))
            {
                string word = message.Split(':')[2];
                string ownerName = message.Split(":")[3];
                string opponentName = message.Split(":")[4];
                string Room_Categorey = message.Split(":")[5];
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        GuessedWord.Text = word;
                        PlayerNameLabel.Text = playerName;
                        RoomPanel.Hide();
                        TurnLabel.Text = $"{ownerName} vs {opponentName}";
                        label8.Text = "Players:";
                        label4.Text = "";
                        WatchersNum.Text = "";
                        CategoryLabel.Text = Room_Categorey;
                        Exit.Show();
                        Keyboard.Hide();
                    }));

                }
                else
                {
                    GuessedWord.Text = word;
                    PlayerNameLabel.Text = playerName;
                    RoomPanel.Hide();
                    Exit.Show();
                    TurnLabel.Text = $"{ownerName} vs {opponentName}";
                    label8.Text = "Players:";
                    label4.Text = "";
                    WatchersNum.Text = "";
                    CategoryLabel.Text = Room_Categorey;
                    Keyboard.Hide();
                }
            }

            else if (message.StartsWith("WORD:"))
            {
                SoundPlayer player = new SoundPlayer("../../../Sound Effects/correct.wav");
                player.Play();
                if (GuessedWord.InvokeRequired)
                {
                    GuessedWord.BeginInvoke(new Action(() =>
                    {
                        GuessedWord.Text = message.Substring(5);
                        ExceptCorrectGuesses(GuessedWord.Text);
                    }));
                }
                else
                {
                    GuessedWord.Text = message.Substring(5);
                }
            }

            else if (message == "WRONG")
            {
                SoundPlayer player = new SoundPlayer("../../../Sound Effects/wrong.wav");
                player.Play();
            }

            else if (message == "YOUR_TURN")
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        TurnLabel.Text = "YOUR_TURN";
                    }));
                }
                else
                {
                    TurnLabel.Text = "YOUR_TURN";
                }

                EnableLetterButtons();
                ExceptCorrectGuesses(GuessedWord.Text);
            }
            else if (message == "OPPONENT_TURN")
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        TurnLabel.Text = "OPPONENT_TURN";
                    }));
                }
                else
                {
                    TurnLabel.Text = "OPPONENT_TURN";
                }

                DisableLetterButtons();
            }
            else if (message.StartsWith("WATCHERS"))
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        WatchersNum.Text = message.Split(':')[1];
                    }));
                }
                else
                {
                    WatchersNum.Text = message.Split(':')[1];
                }
            }
            else if (message.StartsWith("GAME_OVER"))
            {
                string status = message.Split(':')[1];
                if (status == "WON")
                {
                    DialogResult result = MessageBox.Show($"Congrats {playerName}, You Have Won.\n Would You Like To Play Again?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                    if (result == DialogResult.OK)
                    {
                        SendMessage($"PLAY_AGAIN?");
                    }
                    else
                    {
                        if (this.InvokeRequired)
                        {
                            this.BeginInvoke(new Action(() =>
                            {
                                SendMessage("KICK");
                                RoomPanel.Show();
                            }));
                        }
                    }
                }

                else
                {
                    DialogResult result = MessageBox.Show($"Sorry {playerName}, You Have Lost.\n Would You Like To Play Again?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    if (result == DialogResult.OK)
                    {
                        SendMessage($"PLAY_AGAIN?");
                    }
                    else
                    {
                        if (this.InvokeRequired)
                        {
                            this.BeginInvoke(new Action(() =>
                            {
                                SendMessage("KICK");
                                RoomPanel.Show();
                            }));
                        }
                    }
                }

            }
            else if (message.StartsWith("RESTARTGAME"))
            {
                if (GuessedWord.InvokeRequired)
                {
                    GuessedWord.BeginInvoke(new Action(() =>
                    {
                        GuessedWord.Text = message.Split(':')[1];
                    }));
                }

                else
                {
                    GuessedWord.Text = message.Split(':')[1];
                }
                EnableLetterButtons();
            }
            else if (message.StartsWith("KICKED"))
            {
                MessageBox.Show("You Have Been Kicked by the Room Owner");
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        RoomPanel.Show();
                    }));
                }

            }
            else if (message.StartsWith("OPPONENT_LEFT"))
            {
                MessageBox.Show("Your Opponent Has Left The Room");
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        RoomPanel.Show();
                    }));
                }

            }
            else if (message.StartsWith("KICK_WATCHERS"))
            {
                MessageBox.Show("The Game Was Terminated");
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        RoomPanel.Show();
                        Keyboard.Show();
                        Exit.Hide();
                        label4.Text = "Watchers:";
                        WatchersNum.Text = "0";
                    }));
                }
                else
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        RoomPanel.Show();
                        Keyboard.Show();
                        Exit.Hide();
                        label4.Text = "Watchers:";
                        WatchersNum.Text = "0";
                    }));
                }
            }
            else if (message.StartsWith("ROOM_DETAILS"))
            {
                RoomOpponentStrip.Text = message.Split(':')[1];
                RoomCategoryStrip.Text = message.Split(':')[2];
            }

        }

        private void CreateRoom_Click(object sender, EventArgs e)
        {
            if (CatBox.SelectedItem == null)
                MessageBox.Show("Please Choose A Category");
            else
            {
                string category = CatBox.SelectedItem.ToString();
                SendMessage($"CREATE_ROOM:{category}");
                CatBox.SelectedItem = null;
            }
        }

        private void JoinRoom_Click(object sender, EventArgs e)
        {
            if (lstRooms.SelectedItem == null)
            {
                MessageBox.Show("Please select a room to join.");
                return;
            }

            string selectedRoom = lstRooms.SelectedItem.ToString();
            string roomId = selectedRoom;

            SendMessage($"JOIN_ROOM:{roomId}");
        }

        private void LetterButtonClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string letter = btn.Text;
            SendMessage($"GUESS:{letter}");
        }
        private void ExceptCorrectGuesses(string word)
        {
            char removable = '-';
            string result = "";
            if (!string.IsNullOrEmpty(word))
            {
                StringBuilder sb = new StringBuilder();
                foreach (char c in word)
                {
                    if (c != removable)
                        sb.Append(c);
                }

                result = sb.ToString();
            }
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() =>
                {
                    foreach (Button btn in Keyboard.Controls)
                    {
                        foreach (char let in result)
                        {
                            if (btn.Text == let.ToString())
                            {
                                btn.Enabled = false;
                            }
                        }
                    }
                }));
            }
            else
            {
                foreach (Button btn in Keyboard.Controls)
                {
                    foreach (char let in result)
                    {
                        if (btn.Text == let.ToString())
                        {
                            btn.Enabled = false;
                        }
                    }
                }

            }
        }
        public void DisableLetterButtons()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() =>
                {
                    foreach (Control control in Keyboard.Controls)
                    {
                        if (control is Button btn && btn.Tag?.ToString() == "letter")
                        {
                            btn.Enabled = false;
                        }
                    }
                }));
            }
            else
            {
                foreach (Control control in Keyboard.Controls)
                {
                    if (control is Button btn && btn.Tag?.ToString() == "letter")
                    {
                        btn.Enabled = false;
                    }
                }
            }
        }

        private void EnableLetterButtons()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() =>
                {
                    foreach (Control control in Keyboard.Controls)
                    {
                        if (control is Button btn && btn.Tag?.ToString() == "letter")
                        {
                            btn.Enabled = true;
                        }
                    }
                }));
            }
            else
            {
                foreach (Control control in Keyboard.Controls)
                {
                    if (control is Button btn && btn.Tag?.ToString() == "letter")
                    {
                        btn.Enabled = true;
                    }
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            SendMessage("EXITWATCHING");
            RoomPanel.Show();
            Keyboard.Show();
            Exit.Hide();
            label4.Text = "Watchers:";
            WatchersNum.Text = "0";
        }

        private void lstRooms_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = lstRooms.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    selectedIndex = index;
                    string RoomOwner = lstRooms.Items[selectedIndex].ToString().Split('-')[0];

                    RoomOwnerStrip.Text = RoomOwner;

                    SendMessage($"GET_ROOM_DETAILS:{lstRooms.Items[selectedIndex].ToString()}");
                    contextMenuStrip1.Show(lstRooms, e.Location);
                }
            }

        }

        private void lstRooms_MouseMove(object sender, MouseEventArgs e)
        {
            int index = lstRooms.IndexFromPoint(e.Location);
            if (index >= 0 && index < lstRooms.Items.Count)
            {
                string itemText = "Right Click to View Room Details!";
                if (DetailsTip.GetToolTip(lstRooms) != itemText) // Avoid flickering
                {
                    DetailsTip.SetToolTip(lstRooms, itemText);
                }
            }
            else
            {
                DetailsTip.SetToolTip(lstRooms, "");
            }
        }
    }
}
