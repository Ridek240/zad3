using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using zad3.Model;
using zad3.Data;

namespace zad3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly BuzzFizzContext _cont;

        [BindProperty, Range(1, 1000, ErrorMessage = "Liczby of 1 do 1000")]
        public int BuzzFizzNum { get; set; }

        public IndexModel(ILogger<IndexModel> logger, BuzzFizzContext cont)
        {
            _logger = logger;
            _cont = cont;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                AddFizz();
                BuzzFizz fizzbuzz = new BuzzFizz(BuzzFizzNum);
                
                HttpContext.Session.SetString("BuzzFizz", fizzbuzz.ToString());
                HttpContext.Session.SetString("Data", fizzbuzz.date.ToString());
                
                return RedirectToPage("./Sesdb");
            }
            return Page();
        }
        public void AddFizz()
        {
            var FizzBuzzQuerry = (from BuzzFizz in _cont.BuzzFizz where BuzzFizz.historical == false orderby BuzzFizz.date descending select BuzzFizz).Take(10);
            int liczba = FizzBuzzQuerry.Count();
            if (liczba >= 10)
            {
                var FizzBuzzLast = FizzBuzzQuerry.LastOrDefault();

                if (FizzBuzzLast != null)
                    FizzBuzzLast.historical = true;
            }
                BuzzFizz fizzbuzz = new BuzzFizz(BuzzFizzNum);
               
                _cont.BuzzFizz.Add(fizzbuzz);
                _cont.SaveChanges();
            
        }
    }
}
