using System;

namespace OSOS_Website.Models
{
    public class RankingEntry
    {
        public string Username { get; set; } = "";
        public int Score { get; set; }
        public int MaxCombo { get; set; }
        public string LastSong { get; set; } = "";
        public DateTime LastPlayed { get; set; }
    }
}