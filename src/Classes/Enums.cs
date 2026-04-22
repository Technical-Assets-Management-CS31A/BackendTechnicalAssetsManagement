namespace BackendTechnicalAssetsManagement.src.Classes
{
    public class Enums
    {
        //Color code New = Green, Good = Teal/Blue, Defective = Red, NeedsRepair = Orange, Refurbished = Purple
        public enum ItemCondition { New, Good, Defective, Refurbished, NeedRepair }

        public enum ItemCategory { Electronics, Keys, MediaEquipment, Tools, Miscellaneous }

        public enum UserRole { SuperAdmin, Admin, Staff, Teacher, Student }

        public enum  LentItemsStatus { Pending, Reserved, Approved, Denied, Canceled, Borrowed, Returned, Expired }

        public enum ItemStatus { Available, Borrowed, Reserved, Unavailable, Archived }

        public enum ActivityLogCategory { BorrowedItem, Returned, Reserved, Approved, Denied, Canceled, Expired, StatusChange, General }
    }
}
    