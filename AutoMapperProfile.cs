using AutoMapper;
using Manager_User_API.DTO;
using Manager_User_API.Model;

namespace Manager_User_API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ClaimDTO, Claim>();
            CreateMap<Claim, ClaimDTO>();

            CreateMap<FormDTO, Form>();
            CreateMap<Form, FormDTO>();

            CreateMap<PositionDTO, Position>();
            CreateMap<Position, PositionDTO>();

            CreateMap<Role, RoleDTO>(); 
            CreateMap<RoleDTO, Role>();

            CreateMap<UserClaim, UserClaimDTO>();
            CreateMap<UserClaimDTO, UserClaim>();

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<UserRole, UserRoleDTO>();
            CreateMap<UserRoleDTO, UserRole>();
        }
    }
}
