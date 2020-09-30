using AutoMapper;
using PatientRegistrySystem.DB.Entities;
using PatientRegistrySystem.Domain.Dto;
using System.Linq;

namespace PatientRegistrySystem.DB.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(r => r.Roles, r => r.MapFrom(rr => rr.UserRole.Select(ur => ur.Role)))
                .ForMember(e=>e.Employee,e=>e.MapFrom(ee=>ee.Employee))
                .ReverseMap();
            
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            
            CreateMap<Company, CompanytDto>().ReverseMap();
            
            CreateMap<Medicine, MedicineDto>()
                .ReverseMap();
            
            CreateMap<Prescription, PrescriptionDto>()
                .ForMember(m => m.Medicines, m => m.MapFrom(mm => mm.Medicines))
                .ReverseMap();

            CreateMap<Role, RoleDto>().ReverseMap();
            
            CreateMap<Record, RecordDto>()
                .ForMember(u => u.UserId, u => u.MapFrom(uu => uu.User))
                .ForMember(e => e.ApprovedBy, e => e.MapFrom(ee => ee.Employee))
                .ForMember(d => d.DoctorId, d => d.MapFrom(dd => dd.Doctor))
                .ForMember(p=>p.PrescriptionId,p=>p.MapFrom(pp=>pp.Prescription))
                .ReverseMap();
        }
    }
}
