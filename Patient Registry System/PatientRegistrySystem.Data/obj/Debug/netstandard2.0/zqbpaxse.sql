IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Companies] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Address] nvarchar(max) NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Docters] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [Address1] nvarchar(max) NULL,
    [Address2] nvarchar(max) NULL,
    CONSTRAINT [PK_Docters] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Employees] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [DoctorId] int NOT NULL,
    [Adress] nvarchar(max) NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [PrescriptionMedicines] (
    [PrescriptionId] int NOT NULL,
    [MedicineId] int NOT NULL,
    CONSTRAINT [PK_PrescriptionMedicines] PRIMARY KEY ([PrescriptionId], [MedicineId])
);

GO

CREATE TABLE [Prescriptions] (
    [Id] int NOT NULL IDENTITY,
    [LabTest] nvarchar(max) NULL,
    [ExtraInformation] datetime2 NOT NULL,
    [ExpiryDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Prescriptions] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Records] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [DoctorId] int NOT NULL,
    [PrescriptionId] int NOT NULL,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NOT NULL,
    [Case] nvarchar(max) NULL,
    [ExtraInformation] nvarchar(max) NULL,
    [Status] int NOT NULL,
    [ApprovedBy] int NOT NULL,
    CONSTRAINT [PK_Records] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Roles] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [Login] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Phone] int NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Medicines] (
    [Id] int NOT NULL IDENTITY,
    [CompanyId] int NOT NULL,
    [Name] nvarchar(max) NULL,
    [PrescriptionsId] int NULL,
    CONSTRAINT [PK_Medicines] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Medicines_Prescriptions_PrescriptionsId] FOREIGN KEY ([PrescriptionsId]) REFERENCES [Prescriptions] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [UserRoles] (
    [UserId] int NOT NULL,
    [RoleId] int NOT NULL,
    [UsersId] int NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_UserRoles_Users_UsersId] FOREIGN KEY ([UsersId]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Medicines_PrescriptionsId] ON [Medicines] ([PrescriptionsId]);

GO

CREATE INDEX [IX_UserRoles_UsersId] ON [UserRoles] ([UsersId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200914195615_init', N'3.1.8');

GO

