
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/18/2015 17:11:44
-- Generated from EDMX file: C:\Exercises\MVC\AspNetMvcTrainingKit\Labs\aspNetMVC\Ex02-DevelopingMvcApp\begin\MvcSampleApp\Models\AdventureWorks.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AdventureWorksLT2012];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[SalesLT].[FK_CustomerAddress_Address_AddressID]', 'F') IS NOT NULL
    ALTER TABLE [SalesLT].[CustomerAddress] DROP CONSTRAINT [FK_CustomerAddress_Address_AddressID];
GO
IF OBJECT_ID(N'[SalesLT].[FK_CustomerAddress_Customer_CustomerID]', 'F') IS NOT NULL
    ALTER TABLE [SalesLT].[CustomerAddress] DROP CONSTRAINT [FK_CustomerAddress_Customer_CustomerID];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[SalesLT].[Address]', 'U') IS NOT NULL
    DROP TABLE [SalesLT].[Address];
GO
IF OBJECT_ID(N'[SalesLT].[Customer]', 'U') IS NOT NULL
    DROP TABLE [SalesLT].[Customer];
GO
IF OBJECT_ID(N'[SalesLT].[CustomerAddress]', 'U') IS NOT NULL
    DROP TABLE [SalesLT].[CustomerAddress];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [AddressID] int IDENTITY(1,1) NOT NULL,
    [AddressLine1] nvarchar(60)  NOT NULL,
    [AddressLine2] nvarchar(60)  NULL,
    [City] nvarchar(30)  NOT NULL,
    [StateProvince] nvarchar(50)  NOT NULL,
    [CountryRegion] nvarchar(50)  NOT NULL,
    [PostalCode] nvarchar(15)  NOT NULL,
    [rowguid] uniqueidentifier  NOT NULL,
    [ModifiedDate] datetime  NOT NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [CustomerID] int IDENTITY(1,1) NOT NULL,
    [NameStyle] bit  NOT NULL,
    [Title] nvarchar(8)  NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [MiddleName] nvarchar(50)  NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [Suffix] nvarchar(10)  NULL,
    [CompanyName] nvarchar(128)  NULL,
    [SalesPerson] nvarchar(256)  NULL,
    [EmailAddress] nvarchar(50)  NULL,
    [Phone] nvarchar(25)  NULL,
    [PasswordHash] varchar(128)  NOT NULL,
    [PasswordSalt] varchar(10)  NOT NULL,
    [rowguid] uniqueidentifier  NOT NULL,
    [ModifiedDate] datetime  NOT NULL
);
GO

-- Creating table 'CustomerAddresses'
CREATE TABLE [dbo].[CustomerAddresses] (
    [CustomerID] int  NOT NULL,
    [AddressID] int  NOT NULL,
    [AddressType] nvarchar(50)  NOT NULL,
    [rowguid] uniqueidentifier  NOT NULL,
    [ModifiedDate] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AddressID] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([AddressID] ASC);
GO

-- Creating primary key on [CustomerID] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([CustomerID] ASC);
GO

-- Creating primary key on [CustomerID], [AddressID] in table 'CustomerAddresses'
ALTER TABLE [dbo].[CustomerAddresses]
ADD CONSTRAINT [PK_CustomerAddresses]
    PRIMARY KEY CLUSTERED ([CustomerID], [AddressID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AddressID] in table 'CustomerAddresses'
ALTER TABLE [dbo].[CustomerAddresses]
ADD CONSTRAINT [FK_CustomerAddress_Address_AddressID]
    FOREIGN KEY ([AddressID])
    REFERENCES [dbo].[Addresses]
        ([AddressID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerAddress_Address_AddressID'
CREATE INDEX [IX_FK_CustomerAddress_Address_AddressID]
ON [dbo].[CustomerAddresses]
    ([AddressID]);
GO

-- Creating foreign key on [CustomerID] in table 'CustomerAddresses'
ALTER TABLE [dbo].[CustomerAddresses]
ADD CONSTRAINT [FK_CustomerAddress_Customer_CustomerID]
    FOREIGN KEY ([CustomerID])
    REFERENCES [dbo].[Customers]
        ([CustomerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------