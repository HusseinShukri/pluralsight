using Microsoft.EntityFrameworkCore;
using PatientRegistrySystem.Domain.Entities;
using System;

namespace PatientRegistrySystem.Data
{
    public static class PationtsSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    FirstName = "Hussein",
                    LastName = "Shukri",
                    Login = "1234",
                    Password = "1234",
                    Phone = "1234",
                    Email = "Hussein@Shukri.com"
                },
                new User
                {
                    UserId = 2,
                    FirstName = "Layan",
                    LastName = "Hassan",
                    Login = "1234",
                    Password = "1234",
                    Phone = "1234",
                    Email = "Layan@Hassan.com"

                },
                new User
                {
                    UserId = 3,
                    FirstName = "Hamza",
                    LastName = "Kamal",
                    Login = "1234",
                    Password = "1234",
                    Phone = "1234",
                    Email = "Hamza@Kamal.com"
                },
                new User
                {
                    UserId = 4,
                    FirstName = "Ali",
                    LastName = "Tahboub",
                    Login = "1234",
                    Password = "1234",
                    Phone = "1234",
                    Email = "Ali@Tahboub.com"

                },
                new User
                {
                    UserId = 5,
                    FirstName = "Mahran",
                    LastName = "Yacoub",
                    Login = "1234",
                    Password = "1234",
                    Phone = "1234",
                    Email = "Mahran@Yacoub.com"
                }
                );
            #endregion
            #region Role
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, Name = "Patien" },
                new Role { RoleId = 2, Name = "General Practitioner" },
                new Role { RoleId = 3, Name = "Registration Employee" },
                new Role { RoleId = 4, Name = "Accountant" }
                );
            #endregion
            #region UserRole
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { RoleId = 1, UserId = 1 },
                new UserRole { RoleId = 1, UserId = 2 },
                new UserRole { RoleId = 2, UserId = 3 },
                new UserRole { RoleId = 3, UserId = 4 },
                new UserRole { RoleId = 4, UserId = 5 },
                new UserRole { RoleId = 1, UserId = 5 }//something wrong here 
                );
            #endregion
            #region Doctor
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { DoctorId = 1, UserId = 3, Address1 = "Ramallah", Address2 = "Amman" });
            #endregion
            #region Employee
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, UserId = 4, DoctorId = 1, Adress = "Ramallah" },
                new Employee { EmployeeId = 2, UserId = 5, DoctorId = 1, Adress = "Amman" }
               );
            #endregion
            #region Company
            modelBuilder.Entity<Company>().HasData(
                new Company { CompanyId = 1, Name = "Birzeit Pharmaceutical Manufacturing Company", Address = "Birzeit" },
                new Company { CompanyId = 2, Name = "Jerusalem Pharmaceuticals", Address = "Ramallah and Al-Bireh" }
                );
            #endregion
            #region Medicine
            //annanonymous Medicine to be able to couble with prescription one-to-many relationship
            modelBuilder.Entity<Medicine>().HasData(
                new { MedicineId = 1, CompanyId = 1, Name = "GASTREX", PrescriptionId = 1 },
                new { MedicineId = 2, CompanyId = 1, Name = "GASTREX", PrescriptionId = 2 },
                new { MedicineId = 3, CompanyId = 2, Name = "A&D Vit", PrescriptionId = 2 }
                );
            #endregion
            #region Prescription
            modelBuilder.Entity<Prescription>().HasData(
                new Prescription
                {
                    PrescriptionId = 1,
                    LabTest = "Stomach Acid Test",
                    ExtraInformation = "GASTREX on need",
                    ExpiryDate = new DateTime(2020, 6, 17)

                },
                new Prescription
                {
                    PrescriptionId = 2,
                    LabTest = "Vitamins Test",
                    ExtraInformation = "A&D Vit	2 times ber day for 2 weeks",
                    ExpiryDate = new DateTime(2020, 5, 5)
                });
            #endregion
            #region Record
            modelBuilder.Entity<Record>().HasData(
                new Record
                {
                    RecordId = 1,
                    UserID = 1,
                    PrescriptionId = 1,
                    DoctorId = 1,
                    StartDate = new DateTime(2020, 5, 15),
                    EndDate = new DateTime(2020, 5, 16),
                    Case = "Heartburn",
                    ExtrInfo = "Nothing here",
                    Status = 0,
                    ApprovedBy = 1
                },
                new Record
                {
                    RecordId = 2,
                    UserID = 2,
                    PrescriptionId = 2,
                    DoctorId = 1,
                    StartDate = new DateTime(2020, 4, 4),
                    EndDate = new DateTime(2020, 4, 5),
                    Case = "Pregnant needs nutritions",
                    ExtrInfo = "Pregnancy Vitamins",
                    Status = 0,
                    ApprovedBy = 1
                });
            #endregion
        }
    }
}
