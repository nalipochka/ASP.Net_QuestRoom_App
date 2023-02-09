using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.Net_QuestRoom_App.Data.Entities
{
    public class QuestRoom
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string About { get; set; } = null!;
        public double TravelTime { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int MinAgePlayers { get; set; }
        public string Address { get; set; } = null!;
        [NotMapped]
        public string[] Phones
        {
            get
            {
                var tab = this.PnonesDb.Split(',');
                return tab.ToArray();
            }
            set
            {
                this.PnonesDb = string.Join(",", value);
            }
        }
        public string PnonesDb { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Company { get; set; } = null!;
        [Range(0, 10)]
        public int Rating { get; set; }
        [Range(0, 5)]
        public int LevelOfFear { get; set; }
        [Range(0, 5)]
        public int DefficultyLevel { get; set; }
        public byte[]? Logo { get; set; } = null!;

    }
}
