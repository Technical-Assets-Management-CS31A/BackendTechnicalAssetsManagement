using AutoMapper;
using BackendTechnicalAssetsManagement.src.Classes;
using BackendTechnicalAssetsManagement.src.DTOs;
using BackendTechnicalAssetsManagement.src.DTOs.LentItems;

namespace BackendTechnicalAssetsManagement.src.Profiles
{
    public class LentItemsMappingProfile : Profile
    {
        public LentItemsMappingProfile()
        {
            // Entity -> DTO
            CreateMap<LentItems, LentItemsDto>()
                .ForMember(dest => dest.TeacherFullName,
                    opt => opt.MapFrom(src =>
                        src.Teacher != null ? $"{src.Teacher.FirstName} {src.Teacher.LastName}"
                        : src.TeacherFullName))
                .ForMember(dest => dest.FrontStudentIdPicture, opt => opt.MapFrom(src =>
                    src.FrontStudentIdPicture != null
                        ? $"data:image/png;base64,{Convert.ToBase64String(src.FrontStudentIdPicture)}"
                        : null))
                .ForMember(dest => dest.GuestImage, opt => opt.MapFrom(src =>
                    src.GuestImage != null
                        ? $"data:image/png;base64,{Convert.ToBase64String(src.GuestImage)}"
                        : null));

            CreateMap<CreateLentItemDto, LentItems>()
                .ForMember(dest => dest.LentAt, opt => opt.Ignore())
                .ForMember(dest => dest.ItemName, opt => opt.Ignore())
                .ForMember(dest => dest.BorrowerFullName, opt => opt.Ignore())
                .ForMember(dest => dest.BorrowerRole, opt => opt.Ignore())
                .ForMember(dest => dest.StudentIdNumber, opt => opt.Ignore())
                .ForMember(dest => dest.TeacherFullName, opt => opt.Ignore());

            // DTO -> Entity (for update)
            CreateMap<UpdateLentItemDto, LentItems>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<ScanLentItemDto , LentItems>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateLentItemsForGuestDto, LentItems>()
                .ForMember(dest => dest.ItemId, opt => opt.Ignore())   // resolved from TagUid in service
                .ForMember(dest => dest.ItemName, opt => opt.Ignore()) // resolved from TagUid in service
                .ForMember(dest => dest.BorrowerRole, opt => opt.Ignore()) // always set to "Guest" in service
                .ForMember(dest => dest.BorrowerFullName, opt => opt.Ignore()); // built in service
        }
    }
}
