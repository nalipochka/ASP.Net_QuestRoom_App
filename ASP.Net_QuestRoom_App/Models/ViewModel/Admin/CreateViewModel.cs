using ASP.Net_QuestRoom_App.Data.Entities.DTO;

namespace ASP.Net_QuestRoom_App.Models.ViewModel.Admin
{
    public class CreateViewModel
    {
        public QuestRoomDTO QuestRoom { get; set; } = default!;
        public IFormFile Logo { get; set; } = default!;
    }
}
