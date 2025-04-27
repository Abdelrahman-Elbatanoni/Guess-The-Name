using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GameClient
{

    public partial class LoginForm : Form
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        private StreamWriter writer;
        private StreamReader reader;
        private Thread receiveThread;
        private bool isReading = true;
        public LoginForm(string serverAddress, int port)
        {
            InitializeComponent();
            tcpClient = new TcpClient(serverAddress, port);
            stream = tcpClient.GetStream();
            writer = new StreamWriter(stream) { AutoFlush = true };
            reader = new StreamReader(stream);
            receiveThread = new Thread(ListenForMessages);
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }
        private void ListenForMessages()
        {
            while (isReading)
            {
                string message = reader.ReadLine();
                if (message == null) break;
                ProcessMessage(message);
            }
        }

        private void ProcessMessage(string message)
        {
            if(message.StartsWith("FAIL"))
            {
                MessageBox.Show("UserName Already Exists.\nPlease try Again.");
                txtUsername.Text = "";   
            }
            else
            {
                isReading = false;
                this.BeginInvoke(new Action(() =>
                {
                    string username = txtUsername.Text;
                    this.Hide();
                    GameRoomForm gameRoomForm = new GameRoomForm(tcpClient, username, reader);
                    gameRoomForm.ShowDialog();
                    this.Close();
                }));      
            }
        }
        public void SendMessage(string message)
        {
            writer.WriteLine(message);
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string message = $"LOGIN:{username}";
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username.", "Error");
                return;
            }
            try
            {
                SendMessage(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect: " + ex.Message, "Error");
            }
        }
    }

}
