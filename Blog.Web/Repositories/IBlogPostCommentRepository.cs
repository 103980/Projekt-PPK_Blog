﻿using Blog.Web.Models.Domain;

namespace Blog.Web.Repositories
{
    public interface IBlogPostCommentRepository
    {
        Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment);

        Task <IEnumerable<BlogPostComment>> GetAllPostCommentsAsync(Guid blogPostId);
    }
}
