using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Blog.Web.Models.ViewModels;
using Blog.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Blog.Web.Pages.Admin.Posty
{
    public class EditModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        [BindProperty]
        public BlogPost BlogPost { get; set; }

        [BindProperty]
        public IFormFile FeaturedImage { get; set; }

        public EditModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        public async Task OnGet(Guid id)
        {
            BlogPost = await blogPostRepository.GetAsync(id);

        }

        public async Task <IActionResult> OnPostEdit() 
        {
            try
            {
                //throw new Exception();

                await blogPostRepository.UpdateAsync(BlogPost);

                ViewData["Alert"] = new Alerts
                {
                    Type = Enums.AlertType.Success,
                    Message = "Post zosta³ poprawnie zmodyfikowany!"
                    
                };
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = new Alerts
                {
                    Message = "Post nie zosta³ poprawnie zmodyfikowany!",
                    Type = Enums.AlertType.Error
                };

            }

            return Page();
            //return RedirectToPage("/Admin/Posty/List");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var deleted = await blogPostRepository.DeleteAsync(BlogPost.Id);
            if (deleted)
            {

                var alert = new Alerts
                {
                    Type = Enums.AlertType.Success,
                    Message = "Poprawnie usuniêto post!"
                };

                TempData["Alert"] = JsonSerializer.Serialize(alert);

                return RedirectToPage("/Admin/Posty/List");

            }
            
            return Page();
        }
    }
}
