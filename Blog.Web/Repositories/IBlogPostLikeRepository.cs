using Blog.Web.Models.Domain;

namespace Blog.Web.Repositories
{
    public interface IBlogPostLikeRepository
    {
        Task<int> GetTotalLikesCount(Guid blogPostId);

        Task AddLikeForBlog(Guid blogPostId, Guid userId);

        Task<IEnumerable<BlogPostLike>> GetPostLikesCount(Guid blogPostId);
    }
}
