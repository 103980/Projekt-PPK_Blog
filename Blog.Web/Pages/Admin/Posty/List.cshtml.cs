using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Web.Pages.Admin.Posty
{
    public class ListModel : PageModel
    {
        private readonly BlogDbContext blogDbContext;

        public List<BlogPost> BlogPostList { get; set; }

        public ListModel(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        public void OnGet()
        {
            BlogPostList = blogDbContext.BlogPosts.ToList();
        }
    }
}
