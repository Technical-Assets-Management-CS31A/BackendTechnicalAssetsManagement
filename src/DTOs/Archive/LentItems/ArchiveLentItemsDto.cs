using BackendTechnicalAssetsManagement.src.Classes;
using BackendTechnicalAssetsManagement.src.DTOs.Item;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTechnicalAssetsManagement.src.DTOs.Archive.LentItems
{
    public class ArchiveLentItemsDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? LentItemId { get; set; }
        public ItemDto? Item { get; set; }

        public Guid? UserId { get; set; }
        public string? User { get; set; }

        public Guid? TeacherId { get; set; }
        public string? Teacher { get; set; }

        // Denormalized fields
        public string? BorrowerFullName { get; set; }
        public string? BorrowerRole { get; set; }
        public string? StudentIdNumber { get; set; }
        public string? TeacherFullName { get; set; }

        public string? Room { get; set; }
        public string? SubjectTimeSchedule { get; set; }

        public DateTime? LentAt { get; set; }
        public DateTime? ReturnedAt { get; set; }

        public string? Status { get; set; }// Possible values: "Lent", "Returned"
        public string? Remarks { get; set; }

        public bool IsHiddenFromUser { get; set; } = false;

        public string? TagUid { get; set; }       // RFID tag UID of the item being borrowed
        public string? StudentRfid { get; set; }  // RFID UID of the student's ID card

        public DateTime? ReservedFor { get; set; }  // When the user plans to use the item

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public string? FrontStudentIdPicture { get; set; }

        // Guest-specific fields
        public string? GuestImage { get; set; }
        public string? Organization { get; set; }
        public string? ContactNumber { get; set; }
        public string? Purpose { get; set; }
        public string? SupervisorName { get; set; }
    }
}
