
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/14/2018 09:29:13
-- Generated from EDMX file: C:\Users\kk2\source\repos\Kurse\13082018ASPNET4LPZ\Training\EFModelFirstDemo\EFModelFirstDemoDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EFModelFirstDemoDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Students'
CREATE TABLE [dbo].[Students] (
    [StudentId] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Courses'
CREATE TABLE [dbo].[Courses] (
    [CourseId] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Enrollments'
CREATE TABLE [dbo].[Enrollments] (
    [EnrollmentId] int IDENTITY(1,1) NOT NULL,
    [StudentId] int  NOT NULL,
    [CourseId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [StudentId] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [PK_Students]
    PRIMARY KEY CLUSTERED ([StudentId] ASC);
GO

-- Creating primary key on [CourseId] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [PK_Courses]
    PRIMARY KEY CLUSTERED ([CourseId] ASC);
GO

-- Creating primary key on [EnrollmentId] in table 'Enrollments'
ALTER TABLE [dbo].[Enrollments]
ADD CONSTRAINT [PK_Enrollments]
    PRIMARY KEY CLUSTERED ([EnrollmentId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [StudentId] in table 'Enrollments'
ALTER TABLE [dbo].[Enrollments]
ADD CONSTRAINT [FK_StudentEnrollment]
    FOREIGN KEY ([StudentId])
    REFERENCES [dbo].[Students]
        ([StudentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentEnrollment'
CREATE INDEX [IX_FK_StudentEnrollment]
ON [dbo].[Enrollments]
    ([StudentId]);
GO

-- Creating foreign key on [CourseId] in table 'Enrollments'
ALTER TABLE [dbo].[Enrollments]
ADD CONSTRAINT [FK_CourseEnrollment]
    FOREIGN KEY ([CourseId])
    REFERENCES [dbo].[Courses]
        ([CourseId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseEnrollment'
CREATE INDEX [IX_FK_CourseEnrollment]
ON [dbo].[Enrollments]
    ([CourseId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------