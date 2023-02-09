using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.Net_QuestRoom_App.Data.Context;
using ASP.Net_QuestRoom_App.Data.Entities;
using ASP.Net_QuestRoom_App.Models.ViewModel;

namespace ASP.Net_QuestRoom_App.Controllers
{
    public class QuestRoomsController : Controller
    {
        private readonly QuestRoomContext _context;

        public QuestRoomsController(QuestRoomContext context)
        {
            _context = context;
        }

        // GET: QuestRooms
        //public async Task<IActionResult> Index(string? search, FiltersParams filterParam, FiltersProperty filterProp)
        //{
        //    IQueryable<QuestRoom> questRooms = _context.QuestRooms;
        //    if (filterParam == FiltersParams.SmallestToLargest)
        //    {
        //        switch (filterProp)
        //        {
        //            case FiltersProperty.Rating:
        //                {
        //                    questRooms.OrderBy(t => t.Rating);
        //                }
        //                break;
        //            case FiltersProperty.DefficultyLevel:
        //                {
        //                    questRooms.OrderBy(t => t.DefficultyLevel);
        //                }
        //                break;
        //            case FiltersProperty.LevelOfFear:
        //                {
        //                    questRooms.OrderBy(t => t.LevelOfFear);
        //                }
        //                break;
        //            case FiltersProperty.MaxPlayers:
        //                {
        //                    questRooms.OrderBy(t => t.MaxPlayers);
        //                }
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        switch (filterProp)
        //        {
        //            case FiltersProperty.Rating:
        //                {
        //                    questRooms.OrderByDescending(t => t.Rating);
        //                }
        //                break;
        //            case FiltersProperty.DefficultyLevel:
        //                {
        //                    questRooms.OrderByDescending(t => t.DefficultyLevel);
        //                }
        //                break;
        //            case FiltersProperty.LevelOfFear:
        //                {
        //                    questRooms.OrderByDescending(t => t.LevelOfFear);
        //                }
        //                break;
        //            case FiltersProperty.MaxPlayers:
        //                {
        //                    questRooms.OrderByDescending(t => t.MaxPlayers);
        //                }
        //                break;
        //        }
        //    }
        //    if (search is not null)
        //    {
        //        questRooms.Where(t => t.Name.Contains(search));
        //    }
        //    var fp = from FiltersParams d in Enum.GetValues(typeof(FiltersParams))
        //             select new { Id = (int)d, Name = d.ToString() };
        //    var fProp = from FiltersProperty d in Enum.GetValues(typeof(FiltersProperty))
        //                select new { Id = (int)d, Name = d.ToString() };
        //    SelectList filtersParameters = new SelectList(fp,
        //        dataValueField: "Id",
        //        dataTextField: "Name",
        //        0);
        //    SelectList filtersProperty = new SelectList(fProp,
        //        dataValueField: "Id",
        //        dataTextField: "Name",
        //        0);
        //    var tmpQuestRooms = await questRooms.ToListAsync();
        //    FiltrationViewModel viewModel = new FiltrationViewModel()
        //    {
        //        questRooms = tmpQuestRooms,
        //        FilterProp = filterProp,
        //        FilterParam = filterParam,
        //        FilterParameters = filtersParameters,
        //        FilterPropertys = filtersProperty,
        //        Search = search
        //    };
        //    return View(viewModel);
        //}

        // GET: QuestRooms/Details/5
        public async Task<IActionResult> Index(string? search, int filterParam, int filterProp)
        {
            IQueryable<QuestRoom> questRooms = _context.QuestRooms.AsQueryable();
            if (filterParam == 1)
            {
                switch (filterProp)
                {
                    case 1:
                        {
                            questRooms= questRooms.OrderBy(t => t.Rating);
                        }
                        break;
                    case 2:
                        {
                            questRooms=questRooms.OrderBy(t => t.DefficultyLevel);
                        }
                        break;
                    case 3:
                        {
                            questRooms=questRooms.OrderBy(t => t.LevelOfFear);
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
                            questRooms=questRooms.OrderByDescending(t => t.Rating);
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


    }
}
