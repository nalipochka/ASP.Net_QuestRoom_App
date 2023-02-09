using ASP.Net_QuestRoom_App.Data.Context;
using ASP.Net_QuestRoom_App.Data.Entities;
using ASP.Net_QuestRoom_App.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net_QuestRoom_App.Controllers
{
    public class AdminController : Controller
    {
        private readonly QuestRoomContext _context;

        public AdminController(QuestRoomContext context)
        {
            this._context = context;
        }

        // GET: AdminController
        public async Task<IActionResult> Panel(string? search, int filterParam, int filterProp)
        {
            IQueryable<QuestRoom> questRooms = _context.QuestRooms.AsQueryable();
            if (filterParam == 1)
            {
                switch (filterProp)
                {
                    case 1:
                        {
                            questRooms = questRooms.OrderBy(t => t.Rating);
                        }
                        break;
                    case 2:
                        {
                            questRooms = questRooms.OrderBy(t => t.DefficultyLevel);
                        }
                        break;
                    case 3:
                        {
                            questRooms = questRooms.OrderBy(t => t.LevelOfFear);
                        }
                        break;
                    case 4:
                        {
                            questRooms = questRooms.OrderBy(t => t.MaxPlayers);
                        }
                        break;
                }
            }
            else
            {
                switch (filterProp)
                {
                    case 1:
                        {
                            questRooms = questRooms.OrderByDescending(t => t.Rating);
                        }
                        break;
                    case 2:
                        {
                            questRooms = questRooms.OrderByDescending(t => t.DefficultyLevel);
                        }
                        break;
                    case 3:
                        {
                            questRooms = questRooms.OrderByDescending(t => t.LevelOfFear);
                        }
                        break;
                    case 4:
                        {
                            questRooms = questRooms.OrderByDescending(t => t.MaxPlayers);
                        }
                        break;
                }
            }
            if (search is not null)
            {
                questRooms = questRooms.Where(t => t.Name.Contains(search));
            }
            var fp = from FiltersParams d in Enum.GetValues(typeof(FiltersParams))
                     select new { Id = (int)d, Name = d.ToString() };
            var fProp = from FiltersProperty d in Enum.GetValues(typeof(FiltersProperty))
                        select new { Id = (int)d, Name = d.ToString() };
            SelectList filtersParameters = new SelectList(fp,
                dataValueField: "Id",
                dataTextField: "Name",
                0);
            SelectList filtersProperty = new SelectList(fProp,
                dataValueField: "Id",
                dataTextField: "Name",
                0);
            var tmpQuestRooms = await questRooms.ToListAsync();
            FiltrationViewModel viewModel = new FiltrationViewModel()
            {
                questRooms = tmpQuestRooms,
                FilterProp = filterProp,
                FilterParam = filterParam,
                FilterParameters = filtersParameters,
                FilterPropertys = filtersProperty,
                Search = search
            };
            return View(viewModel);
        }

        // GET: AdminController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.QuestRooms == null)
            {
                return NotFound();
            }

            var questRoom = await _context.QuestRooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questRoom == null)
            {
                return NotFound();
            }

            return View(questRoom);
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,About,TravelTime,MinPlayers,MaxPlayers,MinAgePlayers,Address,PnonesDb,Email,Company,Rating,LevelOfFear,DefficultyLevel,Logo")] QuestRoom questRoom, IFormFile logo)
        {
            if (ModelState.IsValid)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    logo.CopyTo(ms);
                    questRoom.Logo = ms.ToArray();
                }
                _context.Add(questRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Panel));
            }
            return View(questRoom);
        }

        // GET: AdminController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.QuestRooms == null)
            {
                return NotFound();
            }

            var questRoom = await _context.QuestRooms.FindAsync(id);
            if (questRoom == null)
            {
                return NotFound();
            }
            return View(questRoom);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,About,TravelTime,MinPlayers,MaxPlayers,MinAgePlayers,Address,PnonesDb,Email,Company,Rating,LevelOfFear,DefficultyLevel,Logo")] QuestRoom questRoom, IFormFile logo)
        {
            if (id != questRoom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        logo.CopyTo(ms);
                        questRoom.Logo= ms.ToArray();
                    }
                    _context.Update(questRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestRoomExists(questRoom.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Panel));
            }
            return View(questRoom);
        }

        // GET: AdminController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.QuestRooms == null)
            {
                return NotFound();
            }

            var questRoom = await _context.QuestRooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questRoom == null)
            {
                return NotFound();
            }

            return View(questRoom);
        }

        // POST: AdminController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.QuestRooms == null)
            {
                return Problem("Entity set 'QuestRoomContext.QuestRooms'  is null.");
            }
            var questRoom = await _context.QuestRooms.FindAsync(id);
            if (questRoom != null)
            {
                _context.QuestRooms.Remove(questRoom);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Panel));
        }
        private bool QuestRoomExists(int id)
        {
            return _context.QuestRooms.Any(e => e.Id == id);
        }
    }
}
