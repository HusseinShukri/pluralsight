using AutoMapper;
using PatientRegistrySystem.Domain.Entities;
using PatientRegistrySystem.Domain.Dto;
using System.Linq;

namespace PatientRegistrySystem.API
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(r => r.Roles, r => r.MapFrom(r => r.UserRole.Select(ur => ur.Role)))
                .ForMember(e=>e.Employee,e=>e.MapFrom(e=>e.Employee))
                .ReverseMap();
            
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            
            CreateMap<Company, CompanytDto>().ReverseMap();
            
            CreateMap<Medicine, MedicineDto>()
                .ReverseMap();
            
            CreateMap<Prescription, PrescriptionDto>()
                .ForMember(m => m.Medicines, m => m.MapFrom(m => m.Medicines))
                .ReverseMap();

            CreateMap<Role, RoleDto>().ReverseMap();
            
            CreateMap<Record, RecordDto>()
                .ForMember(u => u.UserId, u => u.MapFrom(u => u.User))
                .ForMember(e => e.ApprovedBy, e => e.MapFrom(e => e.Employee))
                .ForMember(d => d.DoctorId, d => d.MapFrom(d => d.Doctor))
                .ForMember(p=>p.PrescriptionId,p=>p.MapFrom(p=>p.Prescription))
                .ReverseMap();
        }
    }
}
