using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Blog.Web.Models.ViewModels;
using Blog.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Blog.Web.Pages.Admin.Posty
{
    public class AddModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }

        public AddModel(IBlogPostRepository blogPostRepository)
        {
           
            this.blogPostRepository = blogPostRepository;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            var blogPost = new BlogPost()
            {
                Heading = AddBlogPostRequest.Heading,
                PageTitle = AddBlogPostRequest.PageTitle,
                Content = AddBlogPostRequest.Content,
                ShortDescription = AddBlogPostRequest.ShortDescription,
                FeaturedImageUrl = AddBlogPostRequest.FeaturedImageUrl,
                UrlHandle = AddBlogPostRequest.UrlHandle,
                PublishedDate = AddBlogPostRequest.PublishedDate,
                Author = AddBlogPostRequest.Author,
                Visible = AddBlogPostRequest.Visible
            };
            await blogPostRepository.AddAsync(blogPost);

            var alert = new Alerts
            {
                Type = Enums.AlertType.Success,
                Message = "Poprawnie utworzono nowy post!"
            };

           TempData ["Alert"] = JsonSerializer.Serialize(alert);

            return RedirectToPage("/Admin/Posty/List");
        }
    }
}
