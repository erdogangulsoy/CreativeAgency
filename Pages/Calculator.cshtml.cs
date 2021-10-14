using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CreativeAgency.Pages
{
    public class CalculatorModel : PageModel
    {
        [BindProperty]
        public int? Num1 { get; set; }

        [BindProperty]
        public int? Num2 { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!Num1.HasValue)
            {
                throw new ArgumentNullException("Bolunecek sayi icin bir deger giriniz");
            }
            else if (!Num2.HasValue)
            {
                throw new ArgumentNullException("Kac ile bolunmesi gerekiyor icin bir deger giriniz");
            }
            else if (Num2.Value==0)
            {
                throw new ArgumentException("Bolunecek sayi icin 0 (sifir) değeri girilemez");
            }
            else
            {
                decimal res = (decimal)Num1.Value / (decimal)Num2.Value;

                return Content($"Sonuc: {res}");
            }
        }

    }
}
