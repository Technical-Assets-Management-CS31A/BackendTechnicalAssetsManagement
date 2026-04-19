using System.ComponentModel.DataAnnotations;

namespace BackendTechnicalAssetsManagement.src.DTOs.LentItems
{
    public class CreateLentItemsForGuestDto
    {
        /// <summary>
        /// RFID tag UID scanned directly from the physical item during the form fill.
        /// The backend resolves this to an ItemId + ItemName.
        /// </summary>
        [Required]
        public string TagUid { get; set; } = string.Empty;

        [Required]
        public string BorrowerFirstName { get; set; } = string.Empty;

        [Required]
        public string BorrowerLastName { get; set; } = string.Empty;

        /// <summary>
        /// Department, faculty, or organization the borrower belongs to.
        /// Replaces the old Student/Teacher role distinction.
        /// </summary>
        public string? Organization { get; set; }

        public string? ContactNumber { get; set; }

        /// <summary>
        /// Brief reason for borrowing the item.
        /// </summary>
        public string? Purpose { get; set; }

        /// <summary>
        /// Optional supervisor or in-charge name for reference.
        /// </summary>
        public string? SupervisorName { get; set; }

        [Required]
        public string Room { get; set; } = string.Empty;

        [Required]
        public string SubjectTimeSchedule { get; set; } = string.Empty;

        public DateTime? ReservedFor { get; set; }

        public string? Remarks { get; set; }

        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Guest photo captured at time of borrowing (raw bytes).
        /// </summary>
        public byte[]? GuestImage { get; set; }
    }
}
