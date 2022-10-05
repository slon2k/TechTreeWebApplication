using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechTreeWebApplication.Entities;

namespace TechTreeWebApplication.Areas.Identity.Pages.Account
{
    public class UserLoginFormModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        
        private readonly ILogger<UserLoginFormModel> _logger;
        
        public string? ReturnUrl { get; set; }
        
        public string? ErrorMessage { get; set; }

//        public LoginModel Input { get; set; }

        public UserLoginFormModel(SignInManager<ApplicationUser> signInManager, ILogger<UserLoginFormModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public PartialViewResult OnGetLoginPartial(string? returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            ReturnUrl = returnUrl;

            return Partial("_UserLoginForm", new Models.LoginModel());
        }
    }
}
