using AutoMapper;
using BackendTechnicalAssetsManagement.src.Classes;
using BackendTechnicalAssetsManagement.src.DTOs.Archive.Items;
using BackendTechnicalAssetsManagement.src.DTOs.Item;
using BackendTechnicalAssetsManagement.src.Utils;
using TechnicalAssetManagementApi.Dtos.Item;

namespace BackendTechnicalAssetsManagement.src.Profiles
{
    public class ItemMappingProfile : Profile
    {
        public ItemMappingProfile()
        {
            CreateMap<Item, ItemDto>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src =>
                    src.Image != null && src.ImageMimeType != null ?
                    $"data:{src.ImageMimeType};base64,{Convert.ToBase64String(src.Image)}" :
                    null));

            CreateMap<ItemDto, Item>();

            CreateMap<CreateItemsDto, Item>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => ImageConverterUtils.ConvertIFormFileToByteArray(src.Image)))
                .ForMember(dest => dest.ImageMimeType, opt => opt.Ignore());

            CreateMap<UpdateItemsDto, Item>()
                .ForMember(dest => dest.Image, opt => opt.Ignore())
                .ForMember(dest => dest.SerialNumber, opt => opt.Ignore())
                .ForMember(dest => dest.ImageMimeType, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Item, CreateArchiveItemsDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.ToString()))
                .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => src.Condition.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

        }
    }
}
