using ASP.Net_QuestRoom_App.Data.Entities.DTO;

namespace ASP.Net_QuestRoom_App.Models.ViewModel.Admin
{
    public class EditViewModel
    {
        public QuestRoomDTO QuestRoom { get; set; } = default!;
        public IFormFile? Logotype { get; set; } = default!;
    }
}
