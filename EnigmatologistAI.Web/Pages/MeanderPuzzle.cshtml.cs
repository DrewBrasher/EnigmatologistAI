using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using EnigmatologistAI.Meander;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnigmatologistAI.Web.Pages
{
    public class MeanderPuzzleModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int NumberOfPoints { get; set; }

        public MeanderPuzzle Puzzle { get; set; }

        public void OnGet()
        {
            if(NumberOfPoints < 2 || NumberOfPoints > 6)
            {
                NumberOfPoints = 4;
            }
            Puzzle = new MeanderPuzzle(NumberOfPoints);
        }
    }
}