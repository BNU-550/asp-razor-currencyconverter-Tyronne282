using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CurrencyConverter.Pages
{
    public class CurrencyConverterModel : PageModel
    {
        public const Double GBP_PHP_RATE = 69.17;

        [BindProperty]
        public Double InputAmount { get; set; }
        
        [BindProperty]
        public Double OutputAmount { get; set; }

        private readonly ILogger<CurrencyConverterModel> _logger;

        public CurrencyConverterModel(ILogger<CurrencyConverterModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            if (Double.IsNaN(InputAmount))
            {
                ViewData["Message"] = "Invalid type. " +
                    "Please enter an amount.";
            }
            else if (Double.IsNegative(InputAmount))
            {
                ViewData["Message"] = "Invalid input. " +
                    "Please enter a positive amount.";
            }
            else if (InputAmount > 0)
            {
                OutputAmount = InputAmount * GBP_PHP_RATE;
                ViewData["Message"] = "Amount converted at ratio £1 : ₱69.17.";
            }
        }
    }
}
