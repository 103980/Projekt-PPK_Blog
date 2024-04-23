using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Blog.Web.Models.ViewModels;
using Blog.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Blog.Web.Pages.Admin.Posty
{
    public class ListModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        public List<BlogPost> BlogPostList { get; set; }

        public ListModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        public async Task OnGet()
        {
            //var messageDescription = (string)TempData["MessageDesc"];

            //if (!string.IsNullOrWhiteSpace(messageDescription)) {
            //    ViewData["MessageDesc"] = messageDescription;
            //}

            var alertJson = (string)TempData["Alert"];
            if (alertJson != null)
            {
                ViewData["Alert"] = JsonSerializer.Deserialize<Alerts>(alertJson);
            }

            BlogPostList = (await blogPostRepository.GetAllAsync())?.ToList();
        }
    }
}
