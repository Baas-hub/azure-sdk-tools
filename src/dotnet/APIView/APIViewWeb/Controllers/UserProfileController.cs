﻿using Microsoft.AspNetCore.Mvc;
using APIViewWeb.Models;
using System.Threading.Tasks;

namespace APIViewWeb.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly UserProfileManager _userProfileManager;

        public UserProfileController(UserProfileManager userProfileManager)
        {
            _userProfileManager = userProfileManager;
        }

        [HttpPost]
        public async Task<ActionResult> Update(string email)
        {
            UserProfileModel profile = await _userProfileManager.tryGetUserProfileAsync(User);

            if(profile.UserName == null)
            {
                await _userProfileManager.createUserProfileAsync(User, email);
            } else
            {
                await _userProfileManager.updateEmailAsync(User, email);
            }
            return Ok();
        }
    }
}
