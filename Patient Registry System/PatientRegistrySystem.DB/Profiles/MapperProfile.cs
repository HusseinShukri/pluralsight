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
                .ForMember(e => e.Employee, e => e.MapFrom(ee => ee.Employee))
                .ReverseMap();

            CreateMap<Employee, EmployeeDto>().ReverseMap();

            CreateMap<Doctor, DoctorDto>().ReverseMap();

            CreateMap<Company, CompanytDto>().ReverseMap();

            CreateMap<Medicine, MedicineDto>()
                .ReverseMap();

            CreateMap<Prescription, PrescriptionDto>()
                .ForMember(m => m.Medicines, m => m.MapFrom(mm => mm.Medicines))
                .ReverseMap();

            CreateMap<Role, RoleDto>().ReverseMap();

            CreateMap<Record, RecordDto>()
                .ForMember(u => u.PatinetName, u => u.MapFrom(uu => uu.User.FirstName + " " + uu.User.LastName))
                .ForMember(d => d.DoctorName, d => d.MapFrom(dd => dd.Doctor.User.FirstName + " " + dd.Doctor.User.LastName))
                //.ForMember(p => p.Prescription, p => p.MapFrom(pp => pp.Prescription))
                .ForMember(e => e.ApprovedBy, e => e.MapFrom(ee => ee.Employee.User.FirstName + " " + ee.Employee.User.LastName))
                .ReverseMap();
        }
    }
}
