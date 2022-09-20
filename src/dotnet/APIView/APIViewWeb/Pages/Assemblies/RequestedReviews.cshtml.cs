using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiView;
using APIViewWeb.Models;
using APIViewWeb.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace APIViewWeb.Pages.Assemblies
{
    public class RequestedReviews: PageModel
    {
        private readonly ReviewManager _manager;
        public readonly UserPreferenceCache _preferenceCache;
        public List<ReviewModel> Reviews { get; set; } = new List<ReviewModel>();

        public RequestedReviews(ReviewManager manager, UserPreferenceCache cache)
        {
            _manager = manager;
            _preferenceCache = cache;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }
    }
}
