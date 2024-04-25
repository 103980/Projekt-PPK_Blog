using Blog.Web.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Web.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public Login LoginViewModel { get; set; }

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string ReturnUrl)
        {
            var SignInResult = await signInManager.PasswordSignInAsync(LoginViewModel.UserName, LoginViewModel.Password, false, false);

            if (SignInResult.Succeeded)
            {
                if (!string.IsNullOrWhiteSpace(ReturnUrl)) {
                return RedirectToPage(ReturnUrl);
                }
                return RedirectToPage("Index");
            }
            else
            {
                ViewData["Alert"] = new Alerts
                {
                    Type = Enums.AlertType.Error,
                    Message = "Niepoprawne dane logowania."
                };
                return Page();
            }
        }
    }
}
