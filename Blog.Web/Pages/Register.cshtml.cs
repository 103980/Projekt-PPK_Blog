using Blog.Web.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Web.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;

        [BindProperty]
        public Register RegisterViewModel { get; set; }

        public RegisterModel(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = RegisterViewModel.Username,
                    Email = RegisterViewModel.Email

                };
                var identityResult = await userManager.CreateAsync(user, RegisterViewModel.Password);


                if (identityResult.Succeeded)
                {
                    var addRolesResult = await userManager.AddToRoleAsync(user, "User");

                    if (addRolesResult.Succeeded)
                    {

                        ViewData["Alert"] = new Alerts
                        {
                            Type = Enums.AlertType.Success,
                            Message = "U¿ytkownik zosta³ poprawnie zarejestrowany."
                        };
                        return Page();
                    }
                }

                ViewData["Alert"] = new Alerts
                {
                    Type = Enums.AlertType.Error,
                    Message = "Coœ posz³o nie tak..."
                };
                return Page();
            }
            else
            {
                return Page();
            }




        }
    }
}
