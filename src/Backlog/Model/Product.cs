using System.Collections.Generic;
using Backlog.Data.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Model
{
    [SoftDelete("IsDeleted")]
    public class Product
    {
        public int Id { get; set; }
        [ForeignKey("Tenant")]
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public ICollection<Epic> Epics { get; set; } = new HashSet<Epic>();
        public ICollection<ProductSprint> ProductSprints { get; set; } = new HashSet<ProductSprint>();
        public ICollection<Category> Categories { get; set; } = new HashSet<Category>();
        public ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
        public bool IsDeleted { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}
