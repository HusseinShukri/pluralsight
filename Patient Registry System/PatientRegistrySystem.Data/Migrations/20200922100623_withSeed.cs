using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientRegistrySystem.Data.Migrations
{
    public partial class withSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    PrescriptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabTest = table.Column<string>(maxLength: 200, nullable: true),
                    ExtraInformation = table.Column<string>(maxLength: 500, nullable: true),
                    ExpiryDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.PrescriptionId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    Login = table.Column<string>(maxLength: 30, nullable: false),
                    Password = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    MedicineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    PrescriptionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.MedicineId);
                    table.ForeignKey(
                        name: "FK_Medicine_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicine_Prescription_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescription",
                        principalColumn: "PrescriptionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    DoctorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Address1 = table.Column<string>(maxLength: 50, nullable: false),
                    Address2 = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.DoctorId);
                    table.ForeignKey(
                        name: "FK_Doctor_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    Adress = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Record",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    PrescriptionId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Case = table.Column<string>(maxLength: 500, nullable: false),
                    ExtrInfo = table.Column<string>(maxLength: 500, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    ApprovedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Record", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_Record_Employee_ApprovedBy",
                        column: x => x.ApprovedBy,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Record_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "DoctorId");
                    table.ForeignKey(
                        name: "FK_Record_Prescription_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescription",
                        principalColumn: "PrescriptionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Record_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "CompanyId", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "Birzeit", "Birzeit Pharmaceutical Manufacturing Company" },
                    { 2, "Ramallah and Al-Bireh", "Jerusalem Pharmaceuticals" }
                });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "PrescriptionId", "ExpiryDate", "ExtraInformation", "LabTest" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "GASTREX on need", "Stomach Acid Test" },
                    { 2, new DateTime(2020, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "A&D Vit	2 times ber day for 2 weeks", "Vitamins Test" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "Name" },
                values: new object[,]
                {
                    { 1, "Patien" },
                    { 2, "General Practitioner" },
                    { 3, "Registration Employee" },
                    { 4, "Accountant" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Login", "Password", "Phone" },
                values: new object[,]
                {
                    { 1, "Hussein@Shukri.com", "Hussein", "Shukri", "1234", "1234", "1234" },
                    { 2, "Layan@Hassan.com", "Layan", "Hassan", "1234", "1234", "1234" },
                    { 3, "Hamza@Kamal.com", "Hamza", "Kamal", "1234", "1234", "1234" },
                    { 4, "Ali@Tahboub.com", "Ali", "Tahboub", "1234", "1234", "1234" },
                    { 5, "Mahran@Yacoub.com", "Mahran", "Yacoub", "1234", "1234", "1234" }
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "DoctorId", "Address1", "Address2", "UserId" },
                values: new object[] { 1, "Ramallah", "Amman", 3 });

            migrationBuilder.InsertData(
                table: "Medicine",
                columns: new[] { "MedicineId", "CompanyId", "Name", "PrescriptionId" },
                values: new object[,]
                {
                    { 1, 1, "GASTREX", 1 },
                    { 2, 1, "GASTREX", 2 },
                    { 3, 2, "A&D Vit", 2 }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 4 }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "Adress", "DoctorId", "UserId" },
                values: new object[] { 1, "Ramallah", 1, 4 });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "Adress", "DoctorId", "UserId" },
                values: new object[] { 2, "Amman", 1, 5 });

            migrationBuilder.InsertData(
                table: "Record",
                columns: new[] { "RecordId", "ApprovedBy", "Case", "DoctorId", "EndDate", "ExtrInfo", "PrescriptionId", "StartDate", "Status", "UserID" },
                values: new object[] { 1, 1, "Heartburn", 1, new DateTime(2020, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nothing here", 1, new DateTime(2020, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1 });

            migrationBuilder.InsertData(
                table: "Record",
                columns: new[] { "RecordId", "ApprovedBy", "Case", "DoctorId", "EndDate", "ExtrInfo", "PrescriptionId", "StartDate", "Status", "UserID" },
                values: new object[] { 2, 1, "Pregnant needs nutritions", 1, new DateTime(2020, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pregnancy Vitamins", 2, new DateTime(2020, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_UserId",
                table: "Doctor",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DoctorId",
                table: "Employee",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_UserId",
                table: "Employee",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_CompanyId",
                table: "Medicine",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_PrescriptionId",
                table: "Medicine",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Record_ApprovedBy",
                table: "Record",
                column: "ApprovedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Record_DoctorId",
                table: "Record",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Record_PrescriptionId",
                table: "Record",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Record_UserID",
                table: "Record",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "Record");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
