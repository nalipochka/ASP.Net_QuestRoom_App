using ASP.Net_QuestRoom_App.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP.Net_QuestRoom_App.Models.ViewModel
{
    public class FiltrationViewModel
    {
        public IEnumerable<QuestRoom> questRooms { get; set; } = default!;
        public SelectList FilterPropertys { get; set; } = default!;
        public SelectList FilterParameters { get; set; } = default!;
        public int FilterProp { get; set; }
        public int FilterParam { get; set; }
        public string? Search { get; set; }
    }
    public enum FiltersProperty
    {
        Rating = 1,
        DefficultyLevel,
        LevelOfFear,
        MaxPlayers
    }
    public enum FiltersParams
    {
        SmallestToLargest = 1,
        LargestToSmallest
    }
}
