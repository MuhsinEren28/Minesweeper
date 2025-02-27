using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MayınTarlası
{
    public class Oyun
    {
        public string PlayerName { get; private set; }
        public int GridSize { get; private set; }
        public int MineCount { get; private set; }
        public int Score { get; private set; }
        public Button[,] Buttons { get; private set; }
        public bool[,] Mines { get; private set; }
        public bool[,] Revealed { get; private set; }
        public bool GameOver { get; private set; }
        private Skorboard skorboard;
        private Stopwatch timer;
        private int correctFlags;

        public Oyun(string playerName, int gridSize, int mineCount, Skorboard skorboard)
        {
            PlayerName = playerName;
            GridSize = gridSize;
            MineCount = mineCount;
            Score = 0;
            GameOver = false;
            this.skorboard = skorboard;
            InitializeGame();
            correctFlags = 0;
            timer = new Stopwatch();
            timer.Start();
        }

        private void InitializeGame()
        {
            Buttons = new Button[GridSize, GridSize];
            Mines = new bool[GridSize, GridSize];
            Revealed = new bool[GridSize, GridSize];
            PlaceMines();
        }

        public double GetElapsedTime()
        {
            return timer.Elapsed.TotalSeconds;
        }

        private void PlaceMines()
        {
            Random rand = new Random();
            int placedMines = 0;
            while (placedMines < MineCount)
            {
                int x = rand.Next(GridSize);
                int y = rand.Next(GridSize);
                if (!Mines[x, y])
                {
                    Mines[x, y] = true;
                    placedMines++;
                }
            }
        }

        public int CountAdjacentMines(int x, int y)
        {
            int count = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int nx = x + i;
                    int ny = y + j;
                    if (nx >= 0 && ny >= 0 && nx < GridSize && ny < GridSize && Mines[nx, ny])
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public void RevealCell(int x, int y)
        {
            if (x < 0 || y < 0 || x >= GridSize || y >= GridSize || Revealed[x, y])
                return;

            int adjacentMines = CountAdjacentMines(x, y);
            Revealed[x, y] = true;
            UpdateButtonDisplay(x, y);

            // Eğer hücrede "0" varsa, etrafındaki komşu hücreleri otomatik aç
            if (adjacentMines == 0)
            {
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (i == 0 && j == 0) continue;
                        RevealCell(x + i, y + j);
                    }
                }
            }

            // Kazanma koşulunu kontrol et
            if (CheckWinCondition())
            {
                EndGame(true); // Oyun kazanıldıysa bitir
            }
        }

        public bool CheckWinCondition()
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    // Eğer bir mayınsız hücre açılmadıysa, kazanma koşulu sağlanmadı
                    if (!Mines[i, j] && !Revealed[i, j])
                    {
                        return false;
                    }
                }
            }
            return true; // Tüm mayınsız hücreler açıldıysa oyunu kazanır
        }

        private void UpdateButtonDisplay(int x, int y)
        {
            Button button = Buttons[x, y];
            int adjacentMines = CountAdjacentMines(x, y);
            button.Text = adjacentMines == 0 ? "" : adjacentMines.ToString();
            button.BackColor = Color.White;
        }

        public void DecrementCorrectFlagCount()
        {
            if (correctFlags > 0)
            {
                correctFlags--;
            }
        }

        public void IncrementCorrectFlagCount(bool isAddingFlag, int x, int y)
        {
            if (isAddingFlag)
            {
                correctFlags++;
            }
            else if (correctFlags > 0)
            {
                correctFlags--;
            }
        }

        public void RevealAllNonMinedCells()
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    if (!Mines[i, j] && !Revealed[i, j])
                    {
                        RevealCell(i, j);
                    }
                }
            }
        }

        public void EndGame(bool kazandiMi)
        {
            GameOver = true;
            timer.Stop();

            if (kazandiMi)
            {
                MessageBox.Show("Tebrikler, oyunu kazandınız!");
               
            }
            else
            {
                MessageBox.Show("Oyun Bitti! Mayına bastınız.");
               
            }
            RevealAllMines(); // Oyunu kazandığında tüm mayınları göster


            double elapsedTime = timer.Elapsed.TotalSeconds;
            // Skoru, doğru bayrak sayısı ve geçen süre ile hesapla
            Score = (int)(1000 * correctFlags / elapsedTime);
            

            MessageBox.Show($"Oyuncu: {PlayerName}\nPuanınız: {Score}");

            skorboard.AddScore(PlayerName, Score);

        }

        public void RevealAllMines()
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    if (Mines[i, j])
                    {
                        Buttons[i, j].BackColor = Color.Red; // Mayın hücresini kırmızı renkte göster
                        Buttons[i, j].Text = "💣"; // Mayın hücresini 'M' ile işaretle
                    }
                }
            }
        }
    }
}
    