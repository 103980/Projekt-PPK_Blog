using Blog.Web.Models.Domain;
using Blog.Web.Models.ViewModels;
using Blog.Web.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Pages.Blogs
{
    public class DetailsModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IBlogPostLikeRepository blogPostLikeRepository;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IBlogPostCommentRepository blogPostCommentRepository;

        public BlogPost BlogPost { get; set; }

        public List<BlogComment> Comments { get; set; }

        public int TotalLikes { get; set; }

        public bool isLiked { get; set; }

        [BindProperty]
        public Guid BlogPostId { get; set; }

        [BindProperty]
        [Required]
        [MinLength(1)]
        [MaxLength(254)]
        public string CommentContent { get; set; }

        public DetailsModel(IBlogPostRepository blogPostRepository,
                            IBlogPostLikeRepository blogPostLikeRepository,
                            SignInManager<IdentityUser> signInManager,
                            UserManager<IdentityUser> userManager,
                            IBlogPostCommentRepository blogPostCommentRepository)

        {
            this.blogPostRepository = blogPostRepository;
            this.blogPostLikeRepository = blogPostLikeRepository;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.blogPostCommentRepository = blogPostCommentRepository;
        }



        public async Task<IActionResult> OnGet(string urlHandle)
        {
            await GetBlog(urlHandle);
            return Page();
        }

        public async Task<IActionResult> OnPost(string urlHandle)
        {
            if (ModelState.IsValid)
            {
                if (signInManager.IsSignedIn(User) && !string.IsNullOrWhiteSpace(CommentContent))
                {

                    var userId = userManager.GetUserId(User);

                    var comment = new BlogPostComment()
                    {
                        BlogPostId = BlogPostId,
                        Description = CommentContent,
                        DateAdded = DateTime.Now,
                        UserId = Guid.Parse(userId)
                    };

                    await blogPostCommentRepository.AddAsync(comment);
                }

                return RedirectToPage("/blogs/details", new { urlHandle = urlHandle });
            }


            await GetBlog(urlHandle);
            return Page();



        }

        private async Task GetComments()
        {
            var blogPostComments = await blogPostCommentRepository.GetAllPostCommentsAsync(BlogPost.Id);

            var blogcommentsViewModel = new List<BlogComment>();

            foreach(var blogPostComment in blogPostComments)
            {
                blogcommentsViewModel.Add(new BlogComment 
                {
                    DateAdded = blogPostComment.DateAdded,
                    Description = blogPostComment.Description,
                    Username = (await userManager.FindByIdAsync(blogPostComment.UserId.ToString())).UserName
                });
            }

            Comments = blogcommentsViewModel;

        }

        private async Task GetBlog(string urlHandle)
        {
            BlogPost = await blogPostRepository.GetAsync(urlHandle);

            if (BlogPost != null)
            {

                BlogPostId = BlogPost.Id;
                if (signInManager.IsSignedIn(User))
                {
                    var likes = await blogPostLikeRepository.GetPostLikesCount(BlogPost.Id);

                    var userId = userManager.GetUserId(User);

                    isLiked = likes.Any(x => x.UserId == Guid.Parse(userId));

                    await GetComments();

                }

                TotalLikes = await blogPostLikeRepository.GetTotalLikesCount(BlogPost.Id);
            }
        }

    }
}
