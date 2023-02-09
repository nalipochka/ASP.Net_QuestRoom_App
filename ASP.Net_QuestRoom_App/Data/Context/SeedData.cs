using ASP.Net_QuestRoom_App.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net_QuestRoom_App.Data.Context
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider,
            IWebHostEnvironment hostEnvironment)
        {
            DbContextOptions<QuestRoomContext> options = serviceProvider.GetRequiredService<DbContextOptions<QuestRoomContext>>();
            using(QuestRoomContext context= new QuestRoomContext(options))
            {
                context.Database.EnsureCreated();
                if (context.QuestRooms.Any())
                    return;
                byte[] image1 = File.ReadAllBytes($"{hostEnvironment.WebRootPath}\\images\\логово_маньяка.jpg");
                byte[] image2 = File.ReadAllBytes($"{hostEnvironment.WebRootPath}\\images\\ограбления_банка.jpg");
                byte[] image3 = File.ReadAllBytes($"{hostEnvironment.WebRootPath}\\images\\побег.jpg");
                byte[] image4 = File.ReadAllBytes($"{hostEnvironment.WebRootPath}\\images\\тайны_алхимика.jpg");
                byte[] image5 = File.ReadAllBytes($"{hostEnvironment.WebRootPath}\\images\\хранитель_души.jpg");

                QuestRoom room1 = new()
                {
                    Name = "Логово маньяка",
                    About = "Все думают что это шутка! Дурацкая старинная легенда! " +
                    "Дом, в котором всё исчезает! Но когда ты внутри — все ухмылки уходят прочь, уже не до шуток! " +
                    "Одному Богу известно с каким ужасом приходиться столкнуться! " +
                    "Говорят, Души тех, кто не выбрался так и скитаются среди опустевших стен в поисках плоти!" +
                    " А тот, кто выбрался, навсегда оставил свой здравый смысл по ту сторону дверей!" +
                    " Вам Придется узнать что же на самом деле происходит в этом жутком месте." +
                    " Квест-комната в стиле хоррор с перфомансом (живой актер) ждет Вас.",
                    TravelTime = 60,
                    MinPlayers = 1,
                    MaxPlayers = 6,
                    MinAgePlayers = 14,
                    Address = "Украина, вулиця Олександра Поля, 6, Кривий Ріг, Дніпропетровська область, 50001",
                    Phones = new string[2] { "+38-098-103-53-23", "+38-095-298-14-14" },
                    Email = "info@questlife.com.ua",
                    Company = "Quest Life",
                    Rating = 8,
                    LevelOfFear = 4,
                    DefficultyLevel = 4,
                    Logo = image1
                };
                QuestRoom room2 = new()
                {
                    Name = "Ограбление банка",
                    About = "Всегда мечтали ощутить себя рисковыми профессиональными грабителями, которые отправляются «на дело» всей своей жизни? И не удивительно! " +
                    "Ведь на кону небывалый куш! Надеваем маски, вступаем в зговор с сотрудником банка и сюжетно-ролевая квест-игра началась! " +
                    "Реальная система безопасности банка: датчики движения, лазерная сетка, потайные сейфы, депозитарные ячейки, кодовые замки … " +
                    "Все это Вы взломаете благодаря вашей логике, сообразительности, наблюдательности, командному духу и глупому охраннику банка, который оставил для Вас подсказки! " +
                    "Ваша задача — за 60 мин обойти систему безопасности, расшифровать все закодированные подсказки и отыскать все скрытые механизмы, с каждым шагом все ближе приближаясь к заветному банковскому хранилищу! " +
                    "Но всегда следует быть осторожным: ведь, когда в деле замешаны серьезные деньги — даже самые близкие и надежные люди могут оказаться предателями и сдать вас «с потрохами»…",
                    TravelTime = 60,
                    MinPlayers = 1,
                    MaxPlayers = 5,
                    MinAgePlayers = 6,
                    Address = "Украина, вулиця Олександра Поля, 6, Кривий Ріг, Дніпропетровська область, 50001",
                    Phones = new string[2] { "+38-098-103-53-23", "+38-095-298-14-14" },
                    Email = "info@questlife.com.ua",
                    Company = "Quest Life",
                    Rating = 6,
                    LevelOfFear = 1,
                    DefficultyLevel = 5,
                    Logo = image2
                };
                QuestRoom room3 = new()
                {
                    Name = "Побег",
                    About = "Как совершить побег, найти выход из тюрьмы?" +
                    " Огромное помещение, огромное количество игровых зон. " +
                    "Вы в запертой тюремной камере, в коридорах, карцерах и других помещениях квест-тюрьмы." +
                    " Интересная, наполненная техническими загадками комната. " +
                    "Вы преднамеренно совершаете преступление и попадаете в тюрьму для побега со своим братом." +
                    " Только действуя сообща, вы сможете выбраться на волю. " +
                    "Самая огромная квест-комната Кривого Рога (150м.кв) может приютить одновременно до 8 чел." +
                    " И ты сможешь выбраться за 1 час?",
                    TravelTime = 90,
                    MinPlayers = 1,
                    MaxPlayers = 8,
                    MinAgePlayers = 10,
                    Address = "Украина, вулиця Олександра Поля, 6, Кривий Ріг, Дніпропетровська область, 50001",
                    Phones = new string[2] { "+38-098-103-53-23", "+38-095-298-14-14" },
                    Email = "info@questlife.com.ua",
                    Company = "Quest Life",
                    Rating = 7,
                    LevelOfFear = 3,
                    DefficultyLevel = 5,
                    Logo = image3
                };
                QuestRoom room4 = new()
                {
                    Name = "Тайны алхимика",
                    About = "В небольшой городок приехал странный богатый старик. " +
                    "Он поселился в заброшенном замке на окраине, и с тех пор, в городе стали происходить мистические вещи. " +
                    "Люди стали поговаривать, что это дело рук Алхимика, а вся его сила и могущество, скрыты в философском камне. " +
                    "Ваша цель, украсть у деда философский камень, и спасти город от темных сил.",
                    TravelTime = 60,
                    MinPlayers = 1,
                    MaxPlayers = 5,
                    MinAgePlayers = 6,
                    Address = "Украина, вулиця Олександра Поля, 6, Кривий Ріг, Дніпропетровська область, 50001",
                    Phones = new string[2] { "+38-098-103-53-23", "+38-095-298-14-14" },
                    Email = "info@questlife.com.ua",
                    Company = "Quest Life",
                    Rating = 6,
                    LevelOfFear = 0,
                    DefficultyLevel = 4,
                    Logo = image4
                };
                QuestRoom room5 = new()
                {
                    Name = "Хранитель души",
                    About = "ОН и ОНА очень любили друг друга." +
                    " Но ОНА умирает, а ОН сходит с ума от горя…ЕМУ кажется, что если написать портрет любимой — ОНА опять будет рядом! " +
                    "Добавляя в свои краски кровь, портрет практически готов, но не получается написать глаза." +
                    " И тут на пороге появляется та, которая так похожа " +
                    "на НЕЕ — та же улыбка, тот же взгляд… а чем закончилась эта мистическая история Вы узнаете в нашей квест-локации!",
                    TravelTime = 60,
                    MinPlayers = 1,
                    MaxPlayers = 5,
                    MinAgePlayers = 14,
                    Address = "Украина, вулиця Олександра Поля, 6, Кривий Ріг, Дніпропетровська область, 50001",
                    Phones = new string[2] { "+38-098-103-53-23", "+38-095-298-14-14" },
                    Email = "info@questlife.com.ua",
                    Company = "Quest Life",
                    Rating = 9,
                    LevelOfFear = 5,
                    DefficultyLevel = 5,
                    Logo = image5
                };
                await context.QuestRooms.AddRangeAsync(room1, room2, room3, room4, room5);
                await context.SaveChangesAsync();
            }
        }
    }
}
