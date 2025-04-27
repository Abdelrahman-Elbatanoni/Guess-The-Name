using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer
{
    class GameRoom
    {
        public string RoomId { get; private set; }
        public Player Owner { get; private set; }
        public Player Opponent { get; set; }
        public List<Player> Spectators { get; private set; }
        public bool IsGameActive { get; private set; }
        private string selectedWord;
        public char[] guessedWord;
        private Player currentTurn;

        private object lockObj = new object();
        public string RoomCategory;

        public GameRoom(Player owner, string cat)
        {
            RoomCategory = cat;
            RoomId = owner.PlayerName + '-' + Guid.NewGuid().ToString().Substring(0, 8);
            Owner = owner;
            Spectators = new List<Player>();
            IsGameActive = false;
            //selectedWord = WordManager.GetRandomWord(RoomCategory);     
        }

        public int JoinRoom(Player player)
        {
            if (this.Opponent == null)
            {
                this.Opponent = player;
                return 1;
            }
            else
            {
                lock (lockObj)
                {
                    Spectators.Add(player);
                    string watchers = $"WATCHERS:{Spectators.Count.ToString()}";
                    Owner.SendMessage(watchers);
                    Opponent.SendMessage(watchers);
                    Console.WriteLine($"{player.PlayerName} was added to the Spectators of Room: {this.RoomId}");
                    return 2;
                }
            }
        }

        public bool IsReadyToStart()
        {
            return Owner != null && Opponent != null && !IsGameActive;
        }

        public void WhoseTurn()
        {
            // Notify players about whose turn it is
            string ownerMessage = (currentTurn == Owner ? "YOUR_TURN" : "OPPONENT_TURN");
            string opponentMessage = (currentTurn == Opponent ? "YOUR_TURN" : "OPPONENT_TURN");

            Console.WriteLine($"Sending to Owner ({Owner.PlayerName}): {ownerMessage}");
            Console.WriteLine($"Sending to Opponent ({Opponent.PlayerName}): {opponentMessage}");

            Owner.SendMessage(ownerMessage);
            Opponent.SendMessage(opponentMessage);

            Console.WriteLine($"Current Turn On: {currentTurn.PlayerName}");
        }
        public void StartGame()
        {
            selectedWord = WordManager.GetRandomWord(RoomCategory);
            guessedWord = new string('-', selectedWord.Length).ToCharArray();
            IsGameActive = true;
            currentTurn = Owner; // Owner starts first
            Console.WriteLine($"Game started with word: {selectedWord}");
            Broadcast($"STARTGAME:{new string(guessedWord)}:{RoomCategory}");
            WhoseTurn();
        }
        public void RestartGame() //if they both accept to play again
        {
            selectedWord = WordManager.GetRandomWord(RoomCategory);
            guessedWord = new string('-', selectedWord.Length).ToCharArray();
            IsGameActive = true;
            currentTurn = Owner; // Owner starts first
            Console.WriteLine($"Game Restarted with word: {selectedWord}");
            Broadcast($"RESTARTGAME:{new string(guessedWord)}");

            WhoseTurn();
            UpdateClients();
        }

        public void GuessLetter(Player player, char letter)
        {
            if (player != currentTurn || !IsGameActive) return;

            bool correctGuess = false;
            for (int i = 0; i < selectedWord.Length; i++)
            {
                if (selectedWord[i] == letter)
                {
                    guessedWord[i] = letter;
                    correctGuess = true;
                    Console.WriteLine($"player {player.PlayerName} guessed correct");
                }
            }

            if (!correctGuess)
            {
                currentTurn.SendMessage("WRONG");
                currentTurn = (currentTurn == Owner) ? Opponent : Owner;
                Console.WriteLine($"Current Turn On: {currentTurn.PlayerName}");
            }

            if(correctGuess)
                UpdateClients();

            if (new string(guessedWord) == selectedWord)
            {
                EndGame(currentTurn);
            }

            if(IsGameActive)
                WhoseTurn();
        }

        private void UpdateClients()
        {
            string wordState = $"WORD:{new string(guessedWord)}";
            Broadcast(wordState);
        }


        public void Broadcast(string message)
        {
            Owner.SendMessage(message);
            Opponent.SendMessage(message);
            Console.WriteLine($"broadcasted:{message} to {Owner.PlayerName} and {Opponent.PlayerName}");
            lock (lockObj)
            {
                foreach (var spectator in Spectators)
                {
                    spectator.SendMessage(message);
                }
            }
        }

        private void EndGame(Player winner)
        {
            winner.score+=1;
            IsGameActive = false;
            winner.SendMessage("GAME_OVER:WON");
            Player looser = (winner == Owner) ? Opponent : Owner;
            looser.SendMessage("GAME_OVER:LOST");
            Server.SaveGameResult(Owner.PlayerName, Owner.score, Opponent.PlayerName, Opponent.score);
        }
    }
}