namespace GameClient
{
    partial class GameRoomForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            RoomPanel = new Panel();
            lstRooms = new ListBox();
            lstPlayers = new ListBox();
            label2 = new Label();
            label1 = new Label();
            panel1 = new Panel();
            label3 = new Label();
            CatBox = new ComboBox();
            CreateRoom = new Button();
            JoinRoom = new Button();
            Exit = new Button();
            PlayerNameLabel = new Label();
            PlayerLabel = new Label();
            GamePanel = new Panel();
            panel3 = new Panel();
            CategoryLabel = new Label();
            WatchersNum = new Label();
            label6 = new Label();
            label4 = new Label();
            TurnLabel = new Label();
            label8 = new Label();
            GuessedWord = new Label();
            userNameBox = new Label();
            label9 = new Label();
            label10 = new Label();
            Keyboard = new Panel();
            button1 = new Button();
            button11 = new Button();
            button12 = new Button();
            button20 = new Button();
            button10 = new Button();
            button22 = new Button();
            button9 = new Button();
            button23 = new Button();
            button8 = new Button();
            button24 = new Button();
            button7 = new Button();
            button25 = new Button();
            button6 = new Button();
            button26 = new Button();
            button5 = new Button();
            button27 = new Button();
            button4 = new Button();
            button13 = new Button();
            button3 = new Button();
            button14 = new Button();
            button2 = new Button();
            button15 = new Button();
            button19 = new Button();
            button16 = new Button();
            button18 = new Button();
            button17 = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            roomCategoryToolStripMenuItem = new ToolStripMenuItem();
            RoomCategoryStrip = new ToolStripMenuItem();
            roomOwnerToolStripMenuItem = new ToolStripMenuItem();
            RoomOwnerStrip = new ToolStripMenuItem();
            roomOpponentToolStripMenuItem = new ToolStripMenuItem();
            RoomOpponentStrip = new ToolStripMenuItem();
            DetailsTip = new ToolTip(components);
            RoomPanel.SuspendLayout();
            panel1.SuspendLayout();
            GamePanel.SuspendLayout();
            panel3.SuspendLayout();
            Keyboard.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // RoomPanel
            // 
            RoomPanel.Controls.Add(lstRooms);
            RoomPanel.Controls.Add(lstPlayers);
            RoomPanel.Controls.Add(label2);
            RoomPanel.Controls.Add(label1);
            RoomPanel.Controls.Add(panel1);
            RoomPanel.Controls.Add(JoinRoom);
            RoomPanel.Location = new Point(0, 0);
            RoomPanel.Name = "RoomPanel";
            RoomPanel.Size = new Size(1061, 633);
            RoomPanel.TabIndex = 0;
            // 
            // lstRooms
            // 
            lstRooms.FormattingEnabled = true;
            lstRooms.Location = new Point(651, 94);
            lstRooms.Name = "lstRooms";
            lstRooms.Size = new Size(355, 204);
            lstRooms.TabIndex = 7;
            lstRooms.MouseDown += lstRooms_MouseDown;
            lstRooms.MouseMove += lstRooms_MouseMove;
            // 
            // lstPlayers
            // 
            lstPlayers.FormattingEnabled = true;
            lstPlayers.Location = new Point(49, 94);
            lstPlayers.Name = "lstPlayers";
            lstPlayers.Size = new Size(355, 204);
            lstPlayers.TabIndex = 8;
            // 
            // label2
            // 
            label2.AccessibleRole = AccessibleRole.Application;
            label2.AutoSize = true;
            label2.Location = new Point(760, 61);
            label2.Name = "label2";
            label2.Size = new Size(121, 20);
            label2.TabIndex = 5;
            label2.Text = "Available Rooms";
            // 
            // label1
            // 
            label1.AccessibleRole = AccessibleRole.Application;
            label1.AutoSize = true;
            label1.Location = new Point(158, 61);
            label1.Name = "label1";
            label1.Size = new Size(130, 20);
            label1.TabIndex = 6;
            label1.Text = "Connected Players";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientInactiveCaption;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(CatBox);
            panel1.Controls.Add(CreateRoom);
            panel1.ForeColor = Color.Black;
            panel1.Location = new Point(49, 371);
            panel1.Name = "panel1";
            panel1.Size = new Size(355, 158);
            panel1.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 41);
            label3.Name = "label3";
            label3.Size = new Size(80, 20);
            label3.TabIndex = 4;
            label3.Text = "Categories";
            // 
            // CatBox
            // 
            CatBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CatBox.FormattingEnabled = true;
            CatBox.Items.AddRange(new object[] { "Animals", "Countries", "Fruits" });
            CatBox.Location = new Point(19, 64);
            CatBox.Name = "CatBox";
            CatBox.Size = new Size(151, 28);
            CatBox.TabIndex = 3;
            // 
            // CreateRoom
            // 
            CreateRoom.Location = new Point(218, 103);
            CreateRoom.Name = "CreateRoom";
            CreateRoom.Size = new Size(120, 39);
            CreateRoom.TabIndex = 2;
            CreateRoom.Text = "Create Room";
            CreateRoom.UseVisualStyleBackColor = true;
            CreateRoom.Click += CreateRoom_Click;
            // 
            // JoinRoom
            // 
            JoinRoom.Location = new Point(760, 341);
            JoinRoom.Name = "JoinRoom";
            JoinRoom.Size = new Size(134, 50);
            JoinRoom.TabIndex = 9;
            JoinRoom.Text = "Join Room";
            JoinRoom.UseVisualStyleBackColor = true;
            JoinRoom.Click += JoinRoom_Click;
            // 
            // Exit
            // 
            Exit.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Exit.Location = new Point(386, 345);
            Exit.Name = "Exit";
            Exit.Size = new Size(178, 51);
            Exit.TabIndex = 25;
            Exit.Text = "Exit Watching";
            Exit.UseVisualStyleBackColor = true;
            Exit.Click += Exit_Click;
            // 
            // PlayerNameLabel
            // 
            PlayerNameLabel.AutoSize = true;
            PlayerNameLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PlayerNameLabel.Location = new Point(75, 34);
            PlayerNameLabel.Name = "PlayerNameLabel";
            PlayerNameLabel.Size = new Size(0, 37);
            PlayerNameLabel.TabIndex = 26;
            // 
            // PlayerLabel
            // 
            PlayerLabel.AutoSize = true;
            PlayerLabel.Location = new Point(23, 45);
            PlayerLabel.Name = "PlayerLabel";
            PlayerLabel.Size = new Size(52, 20);
            PlayerLabel.TabIndex = 24;
            PlayerLabel.Text = "Player:";
            // 
            // GamePanel
            // 
            GamePanel.Controls.Add(RoomPanel);
            GamePanel.Controls.Add(Exit);
            GamePanel.Controls.Add(panel3);
            GamePanel.Controls.Add(GuessedWord);
            GamePanel.Controls.Add(userNameBox);
            GamePanel.Controls.Add(label9);
            GamePanel.Controls.Add(label10);
            GamePanel.Controls.Add(Keyboard);
            GamePanel.Controls.Add(PlayerLabel);
            GamePanel.Controls.Add(PlayerNameLabel);
            GamePanel.Location = new Point(0, 0);
            GamePanel.Name = "GamePanel";
            GamePanel.Size = new Size(1061, 633);
            GamePanel.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.GradientInactiveCaption;
            panel3.Controls.Add(CategoryLabel);
            panel3.Controls.Add(WatchersNum);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(TurnLabel);
            panel3.Controls.Add(label8);
            panel3.Location = new Point(705, 25);
            panel3.Name = "panel3";
            panel3.Size = new Size(305, 147);
            panel3.TabIndex = 17;
            // 
            // CategoryLabel
            // 
            CategoryLabel.AutoSize = true;
            CategoryLabel.Location = new Point(144, 66);
            CategoryLabel.Name = "CategoryLabel";
            CategoryLabel.Size = new Size(0, 20);
            CategoryLabel.TabIndex = 13;
            // 
            // WatchersNum
            // 
            WatchersNum.AutoSize = true;
            WatchersNum.Location = new Point(135, 107);
            WatchersNum.Name = "WatchersNum";
            WatchersNum.Size = new Size(17, 20);
            WatchersNum.TabIndex = 1;
            WatchersNum.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 66);
            label6.Name = "label6";
            label6.Size = new Size(116, 20);
            label6.TabIndex = 12;
            label6.Text = "Room Category:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 107);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 0;
            label4.Text = "Watchers:";
            // 
            // TurnLabel
            // 
            TurnLabel.AutoSize = true;
            TurnLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TurnLabel.Location = new Point(119, 17);
            TurnLabel.Name = "TurnLabel";
            TurnLabel.Size = new Size(0, 23);
            TurnLabel.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 17);
            label8.Name = "label8";
            label8.Size = new Size(93, 20);
            label8.TabIndex = 8;
            label8.Text = "Current Turn:";
            // 
            // GuessedWord
            // 
            GuessedWord.AutoSize = true;
            GuessedWord.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GuessedWord.Location = new Point(287, 199);
            GuessedWord.Name = "GuessedWord";
            GuessedWord.Size = new Size(0, 41);
            GuessedWord.TabIndex = 16;
            // 
            // userNameBox
            // 
            userNameBox.AutoSize = true;
            userNameBox.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            userNameBox.Location = new Point(-37, 51);
            userNameBox.Name = "userNameBox";
            userNameBox.Size = new Size(0, 37);
            userNameBox.TabIndex = 15;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(-95, 61);
            label9.Name = "label9";
            label9.Size = new Size(52, 20);
            label9.TabIndex = 14;
            label9.Text = "Player:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(181, 198);
            label10.Name = "label10";
            label10.Size = new Size(98, 41);
            label10.TabIndex = 13;
            label10.Text = "Word:";
            // 
            // Keyboard
            // 
            Keyboard.BackColor = SystemColors.InactiveCaption;
            Keyboard.Controls.Add(button1);
            Keyboard.Controls.Add(button11);
            Keyboard.Controls.Add(button12);
            Keyboard.Controls.Add(button20);
            Keyboard.Controls.Add(button10);
            Keyboard.Controls.Add(button22);
            Keyboard.Controls.Add(button9);
            Keyboard.Controls.Add(button23);
            Keyboard.Controls.Add(button8);
            Keyboard.Controls.Add(button24);
            Keyboard.Controls.Add(button7);
            Keyboard.Controls.Add(button25);
            Keyboard.Controls.Add(button6);
            Keyboard.Controls.Add(button26);
            Keyboard.Controls.Add(button5);
            Keyboard.Controls.Add(button27);
            Keyboard.Controls.Add(button4);
            Keyboard.Controls.Add(button13);
            Keyboard.Controls.Add(button3);
            Keyboard.Controls.Add(button14);
            Keyboard.Controls.Add(button2);
            Keyboard.Controls.Add(button15);
            Keyboard.Controls.Add(button19);
            Keyboard.Controls.Add(button16);
            Keyboard.Controls.Add(button18);
            Keyboard.Controls.Add(button17);
            Keyboard.Location = new Point(64, 301);
            Keyboard.Name = "Keyboard";
            Keyboard.Size = new Size(859, 265);
            Keyboard.TabIndex = 12;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(14, 23);
            button1.Name = "button1";
            button1.Size = new Size(65, 58);
            button1.TabIndex = 0;
            button1.Tag = "letter";
            button1.Text = "Q";
            button1.UseVisualStyleBackColor = true;
            button1.Click += LetterButtonClick;
            // 
            // button11
            // 
            button11.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button11.Location = new Point(32, 100);
            button11.Name = "button11";
            button11.Size = new Size(65, 58);
            button11.TabIndex = 0;
            button11.Tag = "letter";
            button11.Text = "A";
            button11.UseVisualStyleBackColor = true;
            button11.Click += LetterButtonClick;
            // 
            // button12
            // 
            button12.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button12.Location = new Point(117, 100);
            button12.Name = "button12";
            button12.Size = new Size(65, 58);
            button12.TabIndex = 0;
            button12.Tag = "letter";
            button12.Text = "S";
            button12.UseVisualStyleBackColor = true;
            button12.Click += LetterButtonClick;
            // 
            // button20
            // 
            button20.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button20.Location = new Point(75, 180);
            button20.Name = "button20";
            button20.Size = new Size(65, 58);
            button20.TabIndex = 0;
            button20.Tag = "letter";
            button20.Text = "Z";
            button20.UseVisualStyleBackColor = true;
            button20.Click += LetterButtonClick;
            // 
            // button10
            // 
            button10.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button10.Location = new Point(785, 23);
            button10.Name = "button10";
            button10.Size = new Size(65, 58);
            button10.TabIndex = 0;
            button10.Tag = "letter";
            button10.Text = "P";
            button10.UseVisualStyleBackColor = true;
            button10.Click += LetterButtonClick;
            // 
            // button22
            // 
            button22.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button22.Location = new Point(164, 180);
            button22.Name = "button22";
            button22.Size = new Size(65, 58);
            button22.TabIndex = 0;
            button22.Tag = "letter";
            button22.Text = "X";
            button22.UseVisualStyleBackColor = true;
            button22.Click += LetterButtonClick;
            // 
            // button9
            // 
            button9.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button9.Location = new Point(696, 23);
            button9.Name = "button9";
            button9.Size = new Size(65, 58);
            button9.TabIndex = 0;
            button9.Tag = "letter";
            button9.Text = "O";
            button9.UseVisualStyleBackColor = true;
            button9.Click += LetterButtonClick;
            // 
            // button23
            // 
            button23.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button23.Location = new Point(250, 180);
            button23.Name = "button23";
            button23.Size = new Size(65, 58);
            button23.TabIndex = 0;
            button23.Tag = "letter";
            button23.Text = "C";
            button23.UseVisualStyleBackColor = true;
            button23.Click += LetterButtonClick;
            // 
            // button8
            // 
            button8.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button8.Location = new Point(604, 23);
            button8.Name = "button8";
            button8.Size = new Size(65, 58);
            button8.TabIndex = 0;
            button8.Tag = "letter";
            button8.Text = "I";
            button8.UseVisualStyleBackColor = true;
            button8.Click += LetterButtonClick;
            // 
            // button24
            // 
            button24.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button24.Location = new Point(336, 180);
            button24.Name = "button24";
            button24.Size = new Size(65, 58);
            button24.TabIndex = 0;
            button24.Tag = "letter";
            button24.Text = "V";
            button24.UseVisualStyleBackColor = true;
            button24.Click += LetterButtonClick;
            // 
            // button7
            // 
            button7.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button7.Location = new Point(518, 23);
            button7.Name = "button7";
            button7.Size = new Size(65, 58);
            button7.TabIndex = 0;
            button7.Tag = "letter";
            button7.Text = "U";
            button7.UseVisualStyleBackColor = true;
            button7.Click += LetterButtonClick;
            // 
            // button25
            // 
            button25.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button25.Location = new Point(422, 180);
            button25.Name = "button25";
            button25.Size = new Size(65, 58);
            button25.TabIndex = 0;
            button25.Tag = "letter";
            button25.Text = "B";
            button25.UseVisualStyleBackColor = true;
            button25.Click += LetterButtonClick;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Location = new Point(435, 23);
            button6.Name = "button6";
            button6.Size = new Size(65, 58);
            button6.TabIndex = 0;
            button6.Tag = "letter";
            button6.Text = "Y";
            button6.UseVisualStyleBackColor = true;
            button6.Click += LetterButtonClick;
            // 
            // button26
            // 
            button26.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button26.Location = new Point(507, 180);
            button26.Name = "button26";
            button26.Size = new Size(65, 58);
            button26.TabIndex = 0;
            button26.Tag = "letter";
            button26.Text = "N";
            button26.UseVisualStyleBackColor = true;
            button26.Click += LetterButtonClick;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Location = new Point(347, 23);
            button5.Name = "button5";
            button5.Size = new Size(65, 58);
            button5.TabIndex = 0;
            button5.Tag = "letter";
            button5.Text = "T";
            button5.UseVisualStyleBackColor = true;
            button5.Click += LetterButtonClick;
            // 
            // button27
            // 
            button27.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button27.Location = new Point(594, 180);
            button27.Name = "button27";
            button27.Size = new Size(65, 58);
            button27.TabIndex = 0;
            button27.Tag = "letter";
            button27.Text = "M";
            button27.UseVisualStyleBackColor = true;
            button27.Click += LetterButtonClick;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(264, 23);
            button4.Name = "button4";
            button4.Size = new Size(65, 58);
            button4.TabIndex = 0;
            button4.Tag = "letter";
            button4.Text = "R";
            button4.UseVisualStyleBackColor = true;
            button4.Click += LetterButtonClick;
            // 
            // button13
            // 
            button13.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button13.Location = new Point(208, 100);
            button13.Name = "button13";
            button13.Size = new Size(65, 58);
            button13.TabIndex = 0;
            button13.Tag = "letter";
            button13.Text = "D";
            button13.UseVisualStyleBackColor = true;
            button13.Click += LetterButtonClick;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(180, 23);
            button3.Name = "button3";
            button3.Size = new Size(65, 58);
            button3.TabIndex = 0;
            button3.Tag = "letter";
            button3.Text = "E";
            button3.UseVisualStyleBackColor = true;
            button3.Click += LetterButtonClick;
            // 
            // button14
            // 
            button14.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button14.Location = new Point(296, 100);
            button14.Name = "button14";
            button14.Size = new Size(65, 58);
            button14.TabIndex = 0;
            button14.Tag = "letter";
            button14.Text = "F";
            button14.UseVisualStyleBackColor = true;
            button14.Click += LetterButtonClick;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(98, 23);
            button2.Name = "button2";
            button2.Size = new Size(65, 58);
            button2.TabIndex = 0;
            button2.Tag = "letter";
            button2.Text = "W";
            button2.UseVisualStyleBackColor = true;
            button2.Click += LetterButtonClick;
            // 
            // button15
            // 
            button15.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button15.Location = new Point(379, 100);
            button15.Name = "button15";
            button15.Size = new Size(65, 58);
            button15.TabIndex = 0;
            button15.Tag = "letter";
            button15.Text = "G";
            button15.UseVisualStyleBackColor = true;
            button15.Click += LetterButtonClick;
            // 
            // button19
            // 
            button19.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button19.Location = new Point(728, 100);
            button19.Name = "button19";
            button19.Size = new Size(65, 58);
            button19.TabIndex = 0;
            button19.Tag = "letter";
            button19.Text = "L";
            button19.UseVisualStyleBackColor = true;
            button19.Click += LetterButtonClick;
            // 
            // button16
            // 
            button16.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button16.Location = new Point(470, 100);
            button16.Name = "button16";
            button16.Size = new Size(65, 58);
            button16.TabIndex = 0;
            button16.Tag = "letter";
            button16.Text = "H";
            button16.UseVisualStyleBackColor = true;
            button16.Click += LetterButtonClick;
            // 
            // button18
            // 
            button18.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button18.Location = new Point(641, 100);
            button18.Name = "button18";
            button18.Size = new Size(65, 58);
            button18.TabIndex = 0;
            button18.Tag = "letter";
            button18.Text = "K";
            button18.UseVisualStyleBackColor = true;
            button18.Click += LetterButtonClick;
            // 
            // button17
            // 
            button17.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button17.Location = new Point(560, 100);
            button17.Name = "button17";
            button17.Size = new Size(65, 58);
            button17.TabIndex = 0;
            button17.Tag = "letter";
            button17.Text = "J";
            button17.UseVisualStyleBackColor = true;
            button17.Click += LetterButtonClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { roomCategoryToolStripMenuItem, roomOwnerToolStripMenuItem, roomOpponentToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(190, 76);
            // 
            // roomCategoryToolStripMenuItem
            // 
            roomCategoryToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { RoomCategoryStrip });
            roomCategoryToolStripMenuItem.Name = "roomCategoryToolStripMenuItem";
            roomCategoryToolStripMenuItem.Size = new Size(189, 24);
            roomCategoryToolStripMenuItem.Text = "Room Category";
            // 
            // RoomCategoryStrip
            // 
            RoomCategoryStrip.Enabled = false;
            RoomCategoryStrip.Name = "RoomCategoryStrip";
            RoomCategoryStrip.Size = new Size(224, 26);
            RoomCategoryStrip.Text = ".";
            // 
            // roomOwnerToolStripMenuItem
            // 
            roomOwnerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { RoomOwnerStrip });
            roomOwnerToolStripMenuItem.Name = "roomOwnerToolStripMenuItem";
            roomOwnerToolStripMenuItem.Size = new Size(189, 24);
            roomOwnerToolStripMenuItem.Text = "Room Owner";
            // 
            // RoomOwnerStrip
            // 
            RoomOwnerStrip.Enabled = false;
            RoomOwnerStrip.Name = "RoomOwnerStrip";
            RoomOwnerStrip.Size = new Size(224, 26);
            RoomOwnerStrip.Text = ".";
            // 
            // roomOpponentToolStripMenuItem
            // 
            roomOpponentToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { RoomOpponentStrip });
            roomOpponentToolStripMenuItem.Name = "roomOpponentToolStripMenuItem";
            roomOpponentToolStripMenuItem.Size = new Size(189, 24);
            roomOpponentToolStripMenuItem.Text = "Room Opponent";
            // 
            // RoomOpponentStrip
            // 
            RoomOpponentStrip.Enabled = false;
            RoomOpponentStrip.Name = "RoomOpponentStrip";
            RoomOpponentStrip.Size = new Size(224, 26);
            RoomOpponentStrip.Text = ".";
            // 
            // DetailsTip
            // 
            DetailsTip.ToolTipIcon = ToolTipIcon.Info;
            // 
            // GameRoomForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1063, 634);
            Controls.Add(GamePanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "GameRoomForm";
            Text = "Guess The Word";
            RoomPanel.ResumeLayout(false);
            RoomPanel.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            GamePanel.ResumeLayout(false);
            GamePanel.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            Keyboard.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel RoomPanel;
        private ListBox lstRooms;
        private ListBox lstPlayers;
        private Label label2;
        private Label label1;
        private Panel panel1;
        private Label label3;
        private ComboBox CatBox;
        private Button CreateRoom;
        private Button JoinRoom;
        private Panel GamePanel;
        private Panel panel3;
        private Label CategoryLabel;
        private Label WatchersNum;
        private Label label6;
        private Label label4;
        private Label TurnLabel;
        private Label label8;
        private Label GuessedWord;
        private Label userNameBox;
        private Label label9;
        private Label label10;
        private Panel Keyboard;
        private Button button1;
        private Button button11;
        private Button button12;
        private Button button20;
        private Button button10;
        private Button button22;
        private Button button9;
        private Button button23;
        private Button button8;
        private Button button24;
        private Button button7;
        private Button button25;
        private Button button6;
        private Button button26;
        private Button button5;
        private Button button27;
        private Button button4;
        private Button button13;
        private Button button3;
        private Button button14;
        private Button button2;
        private Button button15;
        private Button button19;
        private Button button16;
        private Button button18;
        private Button button17;
        private Label PlayerNameLabel;
        private Button Exit;
        private Label PlayerLabel;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem roomOwnerToolStripMenuItem;
        private ToolStripMenuItem RoomOwnerStrip;
        private ToolStripMenuItem roomOpponentToolStripMenuItem;
        private ToolStripMenuItem RoomOpponentStrip;
        private ToolStripMenuItem roomCategoryToolStripMenuItem;
        private ToolStripMenuItem RoomCategoryStrip;
        private ToolTip DetailsTip;
    }
}