using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using zad3.Data;
using zad3.Model;
namespace zad3.Pages
{
    public class ListaSzukModel : PageModel
    {
        public IList<BuzzFizz> BF { get; set; }
        private readonly BuzzFizzContext _cont;
        public int a { get; set; }

        public ListaSzukModel(BuzzFizzContext cont)
        {
            _cont = cont;
        }
        public void OnGet()
        {
            var FizzBuzzQuerry = (from BuzzFizz in _cont.BuzzFizz orderby BuzzFizz.date descending select BuzzFizz).Take(10);
            BF = FizzBuzzQuerry.ToList();

        }
    }
}
