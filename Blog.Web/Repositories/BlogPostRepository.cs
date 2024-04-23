using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlogDbContext blogDbContext;

        public BlogPostRepository(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }
        
           

        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await blogDbContext.BlogPosts.AddAsync(blogPost);
            await blogDbContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingBlog = await blogDbContext.BlogPosts.FindAsync(id);
            if (existingBlog != null)
            {
                blogDbContext.BlogPosts.Remove(existingBlog);
                await blogDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
           return await blogDbContext.BlogPosts.ToListAsync();
        }

        public async Task<BlogPost> GetAsync(Guid id)
        {
            return await blogDbContext.BlogPosts.FindAsync(id);
        }

        public async Task<BlogPost> UpdateAsync(BlogPost blogPost)
        {
            var existingBlogPost = await blogDbContext.BlogPosts.FindAsync(blogPost.Id);

            if (existingBlogPost != null)
            {
                existingBlogPost.Heading = blogPost.Heading;
                existingBlogPost.PageTitle = blogPost.PageTitle;
                existingBlogPost.Content = blogPost.Content;
                existingBlogPost.ShortDescription = blogPost.ShortDescription;
                existingBlogPost.FeaturedImageUrl = blogPost.FeaturedImageUrl;
                existingBlogPost.UrlHandle = blogPost.UrlHandle;
                existingBlogPost.PublishedDate = blogPost.PublishedDate;
                existingBlogPost.Author = blogPost.Author;
                existingBlogPost.Visible = blogPost.Visible;
            }

            await blogDbContext.SaveChangesAsync();
            return existingBlogPost;
        }
    }

}