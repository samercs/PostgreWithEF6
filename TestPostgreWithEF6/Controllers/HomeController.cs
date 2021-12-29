using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using TestPostgreWithEF6.Data;
using TestPostgreWithEF6.Models;

namespace TestPostgreWithEF6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly CcsstageContext _ccsstageContext;

        public HomeController(ILogger<HomeController> logger, CcsstageContext ccsstageContext)
        {
            _logger = logger;
            _ccsstageContext = ccsstageContext;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<JsonResult> Json(DataTablesOptionsVm model)
        {
            model.BindValuesFromRequest(Request.Query);

            var query = _ccsstageContext.Memos
                .AsNoTracking()
                .AsQueryable();

            

            var count = await query.CountAsync();
            if (!string.IsNullOrEmpty(model.SearchValue))
            {
                var searchJson = "{\"Title\": \""+model.SearchValue+"\"}";
                query = query
                    .Where(i => EF.Functions.Like(i.Subject, $" %{model.SearchValue}%") ||
                                EF.Functions.Like(i.Message.Body, $"%{model.SearchValue}%") ||
                                EF.Functions.Like(i.Replaydata.Body, $"%{model.SearchValue}%") ||
                                EF.Functions.Like(i.Details.fullnamear, $"%{model.SearchValue}%") ||
                                EF.Functions.Like(i.Details.destname, $"%{model.SearchValue}%") ||
                                EF.Functions.Like(i.Details.sourcename, $"%{model.SearchValue}%") ||
                                EFFunctions.Any(i.Actions, "Title", model.SearchValue, false)
                                //EF.Functions.Like(EFFunctions.ToString(i.Actions), $"%{model.SearchValue}%")
                                );

            }

            
            if (!string.IsNullOrEmpty(model.SortColumn))
            {
                switch (model.SortColumn)
                {
                    case "id":
                        query = model.SortColumnDirection.Equals("desc") ? query.OrderByDescending(i => i.Id) : query.OrderBy(i => i.Id);
                        break;
                    case "letterid":
                        query = model.SortColumnDirection.Equals("desc") ? query.OrderByDescending(i => i.Letterid) : query.OrderBy(i => i.Letterid);
                        break;
                    case "destinationid":
                        query = model.SortColumnDirection.Equals("desc") ? query.OrderByDescending(i => i.Destinationid) : query.OrderBy(i => i.Destinationid);
                        break;
                    case "subject":
                        query = model.SortColumnDirection.Equals("desc") ? query.OrderByDescending(i => i.Subject) : query.OrderBy(i => i.Subject);
                        break;
                }
            }
            var filter = await query.CountAsync();
            var data = await query.Skip(model.Skip).Take(model.PageSize).ToListAsync();

            return Json(new
            {
                recordsTotal = count,
                recordsFiltered =  filter,
                data= data.Select(i=> new
                {
                    i.Id,
                    i.Letterid,
                    i.Subject,
                    i.Destinationid
                })
            });
            
        }

        [Route("{id:long}/details")]
        public async Task<IActionResult> Details(long id)
        {
            var memo = await _ccsstageContext.Memos.FirstOrDefaultAsync(i=>i.Id == id);
            if (memo == null)
            {
                return NotFound();
            }

            return View(memo);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}