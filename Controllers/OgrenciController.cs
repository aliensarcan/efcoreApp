using Microsoft.AspNetCore.Mvc;
using efcoreApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;

namespace efcoreApp.Controllers
{ 
    // Öğrenci verilerini işlemek için kullanılan denetleyici
    public class OgrenciController : Controller
    {
        private readonly DataContext _context;

        // Constructor metodu, DataContext bağımlılığını alır
        public OgrenciController(DataContext context)
        {
            _context = context;
        }

        // Öğrenci listesi sayfasını gösteren metot
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ogrenciler.ToListAsync());
        }

        // Yeni öğrenci ekleme sayfasını gösteren metot
        public IActionResult Create()
        {
            return View();
        }

        // Yeni öğrenci ekleme işlemini gerçekleştiren metot
        [HttpPost]
        public async Task<IActionResult> Create(Ogrenci model)
        {
            _context.Ogrenciler.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // Öğrenci düzenleme sayfasını gösteren metot
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogr = await _context.Ogrenciler.FindAsync(id);

            if (ogr == null)
            {
                return NotFound();
            }

            return View(ogr);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id , Ogrenci model)
        {
            if(id !=model.OgrenciId)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(_context.Ogrenciler.Any(o => o.OgrenciId ==model.OgrenciId))
                    {
                        return NotFound();

                    }
                    else
                    {
                        throw;
                    }
                }
                    return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete (int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var ogrenci = await _context.Ogrenciler.FindAsync(id);
            if(ogrenci ==null) 
            {
                return NotFound();
            }
            return View(ogrenci);
        }

        [HttpPost]
        public async Task<IActionResult> Delete ([FromForm]int id)
        {
            var ogrenci =await _context.Ogrenciler.FindAsync(id);
            if(ogrenci == null)
            {
                return NotFound();

            }
            _context.Ogrenciler.Remove(ogrenci);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }

}
