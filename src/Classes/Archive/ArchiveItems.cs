using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BackendTechnicalAssetsManagement.src.Classes.Enums;

namespace BackendTechnicalAssetsManagement.src.Classes
{
    public class ArchiveItems
    {
        [Key]
        public Guid Id { get; set; }
        public string SerialNumber { get; set; } = string.Empty;
        public string? RfidUid { get; set; }
        public string? ImageUrl { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string ItemType { get; set; } = string.Empty;
        public string? ItemModel { get; set; }
        public string ItemMake { get; set; } = string.Empty;
        public string? Description { get; set; }

        public ItemCategory Category { get; set; }
        public ItemCondition Condition { get; set; }
        public ItemStatus Status { get; set; } = ItemStatus.Available;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public string? Location { get; set; }
    }
}
