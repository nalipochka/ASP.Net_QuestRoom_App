using ASP.Net_QuestRoom_App.Data.Entities;
using ASP.Net_QuestRoom_App.Data.Entities.DTO;
using AutoMapper;

namespace ASP.Net_QuestRoom_App.AutoMapperProfiles
{
    public class QuestRoomProfiles : Profile
    {
        public QuestRoomProfiles() 
        {
            CreateMap<QuestRoom, QuestRoomDTO>().ReverseMap();
        }
    }
}
