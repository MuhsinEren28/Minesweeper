using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MayınTarlası
{
    public class Skorboard
    {
        private List<PlayerScore> playerScores;
        private readonly string filePath = "scores.txt"; // Skorları kaydetmek için dosya yolu

        public Skorboard()
        {
            playerScores = new List<PlayerScore>();
            LoadScores(); // Uygulama başlatıldığında skorları yükleyin
        }

        // Skorları ekler
        public void AddScore(string playerName, int score)
        {
            if (string.IsNullOrWhiteSpace(playerName) || score < 0)
                return;

            playerScores.Add(new PlayerScore { PlayerName = playerName, Score = score });
            SortScores();
            SaveScores(); // Yeni skor eklendiğinde dosyaya kaydedin
        }

        // Skorları sıralar (azalan sırayla)
        private void SortScores()
        {
            playerScores = playerScores.OrderByDescending(ps => ps.Score).Take(10).ToList();
        }

        // En iyi 10 oyuncuyu alır
        public List<PlayerScore> GetTopScores()
        {
            return playerScores;
        }

        // Skorları dosyaya kaydeder
        private void SaveScores()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var score in playerScores)
                    {
                        writer.WriteLine($"{score.PlayerName},{score.Score}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Skorlar kaydedilirken bir hata oluştu: " + ex.Message);
            }
        }

        // Skorları dosyadan yükler
        private void LoadScores()
        {
            if (!File.Exists(filePath)) return;

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split(',');
                        if (parts.Length == 2 && int.TryParse(parts[1], out int score))
                        {
                            playerScores.Add(new PlayerScore { PlayerName = parts[0], Score = score });
                        }
                    }
                }
                SortScores();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Skorlar yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        // Skor listesini sıfırlar
        public void ResetScores()
        {
            playerScores.Clear();
            SaveScores(); // Sıfırladıktan sonra dosyayı güncelle
        }       
    }

    // Oyuncu ve skor bilgilerini tutan sınıf
    public class PlayerScore
    {
        public string PlayerName { get; set; }
        public int Score { get; set; }
    }
}
