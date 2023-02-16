using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASP.Net_QuestRoom_App.Data.Entities.DTO
{
    public class QuestRoomDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string About { get; set; } = default!;
        public double TravelTime { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int MinAgePlayers { get; set; }
        public string Address { get; set; } = default!;
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
        public string PnonesDb { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Company { get; set; } = default!;
        [Range(0, 10)]
        public int Rating { get; set; }
        [Range(0, 5)]
        public int LevelOfFear { get; set; }
        [Range(0, 5)]
        public int DefficultyLevel { get; set; }
        public byte[]? Logo { get; set; } = default!;

    }
}
