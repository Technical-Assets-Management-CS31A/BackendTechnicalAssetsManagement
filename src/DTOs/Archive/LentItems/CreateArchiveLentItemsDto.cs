namespace BackendTechnicalAssetsManagement.src.DTOs.Archive.LentItems
{
    public class CreateArchiveLentItemsDto
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public string? Item { get; set; }
        public string? ItemName { get; set; }

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

        public byte[]? FrontStudentIdPicture { get; set; }

        // Guest-specific fields
        public byte[]? GuestImage { get; set; }
        public string? Organization { get; set; }
        public string? ContactNumber { get; set; }
        public string? Purpose { get; set; }
        public string? SupervisorName { get; set; }
    }
}
