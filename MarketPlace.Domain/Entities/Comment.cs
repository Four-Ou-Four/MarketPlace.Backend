using MarketPlace.Domain.Common.Entities;

namespace MarketPlace.Domain.Entities;

public class Comment : AuditableEntity
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public string Content { get; set; }
    public Guid? ParentCommentId { get; set; }
    public User User { get; set; }
    public Product Product { get; set; }
    public Comment ParentComment { get; set; }
    public IEnumerable<Comment> Replies { get; set; }
}
