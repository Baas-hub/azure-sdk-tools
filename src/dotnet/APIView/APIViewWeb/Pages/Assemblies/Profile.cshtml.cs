using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using APIViewWeb.Models;
using APIViewWeb.Repositories;
using System.Threading.Tasks;

namespace APIViewWeb.Pages.Assemblies
{
    public class ProfileModel : PageModel
    {
        private readonly UserProfileManager _manager;
        public readonly UserPreferenceCache _preferenceCache;

        public UserProfileModel userProfile;
        public ProfileModel(UserProfileManager manager, UserPreferenceCache preferenceCache)
        {
            _manager = manager;
            _preferenceCache = preferenceCache;
        }

        public async Task<IActionResult> OnGetAsync(string UserName)
        {
            UserProfileModel profile;
            if (User.GetGitHubLogin().Equals(UserName))
            {
                profile = await this._manager.tryGetUserProfileAsync(User);
            }
            else
            {
                profile = await this._manager.tryGetUserProfileByNameAsync(UserName);
            }
            

            userProfile = profile;
            return Page();
        }
    }
}
