using Microsoft.AspNetCore.Mvc;
using APIViewWeb.Models;
using APIViewWeb.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APIViewWeb.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly UserProfileManager _userProfileManager;
        private readonly UserPreferenceCache _userPreferenceCache;

        public UserProfileController(UserProfileManager userProfileManager, UserPreferenceCache userPreferenceCache)
        {
            _userProfileManager = userProfileManager;
            _userPreferenceCache = userPreferenceCache;
        }

        [HttpPost]
        public async Task<ActionResult> Update(string email, string[] languages, string theme="light-theme")
        {
            UserProfileModel profile = await _userProfileManager.tryGetUserProfileAsync(User);
            UserPreferenceModel preference = await _userPreferenceCache.GetUserPreferences(User.GetGitHubLogin());

            preference.Theme = theme;

            HashSet<string> Languages = new HashSet<string>(languages);
            if(profile.UserName == null)
            {
                await _userProfileManager.createUserProfileAsync(User, email, Languages, preference);
            } else
            {
                await _userProfileManager.updateUserProfile(User, email, Languages, preference);
            }

            return RedirectToPage("/Assemblies/Index");
        }
    }
}