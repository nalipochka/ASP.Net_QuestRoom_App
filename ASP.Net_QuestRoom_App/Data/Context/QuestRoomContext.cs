using ASP.Net_QuestRoom_App.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net_QuestRoom_App.Data.Context
{
    public class QuestRoomContext : DbContext
    {
        public QuestRoomContext(DbContextOptions<QuestRoomContext> options):base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<QuestRoom> QuestRooms { get; set; } = null!;
    }

}
