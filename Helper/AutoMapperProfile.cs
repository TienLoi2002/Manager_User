using AutoMapper;
using Manager_User_API.DTO;
using Manager_User_API.Model;

namespace Manager_User_API.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ClaimDTO, Claim>().ReverseMap();
            CreateMap<FormDTO, Form>().ReverseMap();
            CreateMap<PositionDTO, Position>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
          //  CreateMap<UserClaim, UserClaimDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserRole, UserRoleDTO>().ReverseMap();
            CreateMap<RegisterDTO, User>();
        }
    }
}
