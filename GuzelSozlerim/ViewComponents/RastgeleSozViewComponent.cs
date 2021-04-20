using GuzelSozlerim.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuzelSozlerim.ViewComponents
{
    // https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-components?view=aspnetcore-5.0#walkthrough-creating-a-simple-view-component

    public class RastgeleSozViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;

        public RastgeleSozViewComponent(ApplicationDbContext context)
        {
            _db = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(bool enYeniyiGoster = false)
        {
            if (enYeniyiGoster)
            {
                return View(await _db.GuzelSozler.OrderBy(x => x.Id).LastOrDefaultAsync());
            }
            int adet = _db.GuzelSozler.Count();
            int indeks = new Random().Next(adet);
            GuzelSoz soz = await _db.GuzelSozler.Skip(indeks).FirstAsync();
            return View(soz);
        }
    }
}
