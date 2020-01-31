
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 01/26/2020 13:19:58
-- Generated from EDMX file: D:\a\bookwrm_03\bookwrm_03\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Bappa];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_productauthor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[products] DROP CONSTRAINT [FK_productauthor];
GO
IF OBJECT_ID(N'[dbo].[FK_beneficiaryproductbeneficiary]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[productbeneficiaries] DROP CONSTRAINT [FK_beneficiaryproductbeneficiary];
GO
IF OBJECT_ID(N'[dbo].[FK_beneficiarycalculationinvoicedetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[beneficiarycalculations] DROP CONSTRAINT [FK_beneficiarycalculationinvoicedetails];
GO
IF OBJECT_ID(N'[dbo].[FK_productbeneficiarybeneficiarycalculation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[beneficiarycalculations] DROP CONSTRAINT [FK_productbeneficiarybeneficiarycalculation];
GO
IF OBJECT_ID(N'[dbo].[FK_categoryproduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[products] DROP CONSTRAINT [FK_categoryproduct];
GO
IF OBJECT_ID(N'[dbo].[FK_customermyshelf]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[myshelves] DROP CONSTRAINT [FK_customermyshelf];
GO
IF OBJECT_ID(N'[dbo].[FK_invoiceheadercustomer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[invoiceheaders] DROP CONSTRAINT [FK_invoiceheadercustomer];
GO
IF OBJECT_ID(N'[dbo].[FK_invoiceheaderinvoicedetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[invoicedetails] DROP CONSTRAINT [FK_invoiceheaderinvoicedetails];
GO
IF OBJECT_ID(N'[dbo].[FK_productinvoicedetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[invoicedetails] DROP CONSTRAINT [FK_productinvoicedetails];
GO
IF OBJECT_ID(N'[dbo].[FK_myshelfinvoiceheader]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[myshelves] DROP CONSTRAINT [FK_myshelfinvoiceheader];
GO
IF OBJECT_ID(N'[dbo].[FK_languageproduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[products] DROP CONSTRAINT [FK_languageproduct];
GO
IF OBJECT_ID(N'[dbo].[FK_productmyshelf]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[myshelves] DROP CONSTRAINT [FK_productmyshelf];
GO
IF OBJECT_ID(N'[dbo].[FK_packagedetailsproduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[packagedetails] DROP CONSTRAINT [FK_packagedetailsproduct];
GO
IF OBJECT_ID(N'[dbo].[FK_producttypeproduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[products] DROP CONSTRAINT [FK_producttypeproduct];
GO
IF OBJECT_ID(N'[dbo].[FK_productproductbeneficiary]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[productbeneficiaries] DROP CONSTRAINT [FK_productproductbeneficiary];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[authors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[authors];
GO
IF OBJECT_ID(N'[dbo].[beneficiaries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[beneficiaries];
GO
IF OBJECT_ID(N'[dbo].[beneficiarycalculations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[beneficiarycalculations];
GO
IF OBJECT_ID(N'[dbo].[categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[categories];
GO
IF OBJECT_ID(N'[dbo].[customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[customers];
GO
IF OBJECT_ID(N'[dbo].[invoicedetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[invoicedetails];
GO
IF OBJECT_ID(N'[dbo].[invoiceheaders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[invoiceheaders];
GO
IF OBJECT_ID(N'[dbo].[languages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[languages];
GO
IF OBJECT_ID(N'[dbo].[myshelves]', 'U') IS NOT NULL
    DROP TABLE [dbo].[myshelves];
GO
IF OBJECT_ID(N'[dbo].[packagedetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[packagedetails];
GO
IF OBJECT_ID(N'[dbo].[productbeneficiaries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[productbeneficiaries];
GO
IF OBJECT_ID(N'[dbo].[products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[products];
GO
IF OBJECT_ID(N'[dbo].[producttypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[producttypes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'authors'
CREATE TABLE [dbo].[authors] (
    [authorid] smallint IDENTITY(1,1) NOT NULL,
    [authorname] nvarchar(max)  NOT NULL,
    [emailid] nvarchar(max)  NOT NULL,
    [contactno] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'beneficiaries'
CREATE TABLE [dbo].[beneficiaries] (
    [beneficiaryid] smallint IDENTITY(1,1) NOT NULL,
    [beneficiaryname] nvarchar(max)  NOT NULL,
    [accountno] nvarchar(max)  NOT NULL,
    [ifsccode] nvarchar(max)  NOT NULL,
    [bankname] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'beneficiarycalculations'
CREATE TABLE [dbo].[beneficiarycalculations] (
    [beneficiarycalid] smallint IDENTITY(1,1) NOT NULL,
    [purchasetype] nvarchar(max)  NOT NULL,
    [royaltyamt] float  NOT NULL,
    [productbeneficiary_productbeneficiaryid] smallint  NOT NULL,
    [invoicedetails_invoicedetailsid] smallint  NOT NULL
);
GO

-- Creating table 'categories'
CREATE TABLE [dbo].[categories] (
    [categoryid] smallint IDENTITY(1,1) NOT NULL,
    [description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'customers'
CREATE TABLE [dbo].[customers] (
    [customerid] smallint IDENTITY(1,1) NOT NULL,
    [fname] nvarchar(max)  NOT NULL,
    [lname] nvarchar(max)  NOT NULL,
    [address] nvarchar(max)  NOT NULL,
    [age] smallint  NOT NULL,
    [emailid] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL,
    [phoneno] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'invoicedetails'
CREATE TABLE [dbo].[invoicedetails] (
    [invoicedetailsid] smallint IDENTITY(1,1) NOT NULL,
    [amount] float  NOT NULL,
    [product_productid] smallint  NOT NULL,
    [invoiceheader_invoiceheaderid] smallint  NOT NULL
);
GO

-- Creating table 'invoiceheaders'
CREATE TABLE [dbo].[invoiceheaders] (
    [invoiceheaderid] smallint IDENTITY(1,1) NOT NULL,
    [date] datetime  NOT NULL,
    [totalamount] float  NOT NULL,
    [customer_customerid] smallint  NOT NULL
);
GO

-- Creating table 'languages'
CREATE TABLE [dbo].[languages] (
    [languageid] smallint IDENTITY(1,1) NOT NULL,
    [description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'myshelves'
CREATE TABLE [dbo].[myshelves] (
    [myshelfid] smallint IDENTITY(1,1) NOT NULL,
    [purchasedate] datetime  NULL,
    [enddate] datetime  NULL,
    [purchasetype] nvarchar(max)  NOT NULL,
    [rating] smallint  NULL,
    [customer_customerid] smallint  NOT NULL,
    [invoiceheader_invoiceheaderid] smallint  NOT NULL,
    [product_productid] smallint  NOT NULL
);
GO

-- Creating table 'packagedetails'
CREATE TABLE [dbo].[packagedetails] (
    [packagedetailsid] smallint IDENTITY(1,1) NOT NULL,
    [noofdays] int  NOT NULL,
    [noofbooks] int  NOT NULL,
    [product_productid] smallint  NOT NULL
);
GO

-- Creating table 'productbeneficiaries'
CREATE TABLE [dbo].[productbeneficiaries] (
    [productbeneficiaryid] smallint IDENTITY(1,1) NOT NULL,
    [royalty] int  NOT NULL,
    [beneficiary_beneficiaryid] smallint  NOT NULL,
    [product_productid] smallint  NOT NULL
);
GO

-- Creating table 'products'
CREATE TABLE [dbo].[products] (
    [productid] smallint IDENTITY(1,1) NOT NULL,
    [producttitle] nvarchar(max)  NOT NULL,
    [price] float  NOT NULL,
    [islibrary] bit  NOT NULL,
    [rentcost] float  NOT NULL,
    [rentmindays] int  NOT NULL,
    [shortdescription] nvarchar(max)  NOT NULL,
    [longdescription] nvarchar(max)  NOT NULL,
    [imgurl] nvarchar(max)  NOT NULL,
    [producturl] nvarchar(max)  NOT NULL,
    [avgrating] nvarchar(max)  NOT NULL,
    [isrent] bit  NOT NULL,
    [author_authorid] smallint  NOT NULL,
    [category_categoryid] smallint  NOT NULL,
    [language_languageid] smallint  NOT NULL,
    [producttype_producttypeid] smallint  NOT NULL
);
GO

-- Creating table 'producttypes'
CREATE TABLE [dbo].[producttypes] (
    [producttypeid] smallint IDENTITY(1,1) NOT NULL,
    [description] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [authorid] in table 'authors'
ALTER TABLE [dbo].[authors]
ADD CONSTRAINT [PK_authors]
    PRIMARY KEY CLUSTERED ([authorid] ASC);
GO

-- Creating primary key on [beneficiaryid] in table 'beneficiaries'
ALTER TABLE [dbo].[beneficiaries]
ADD CONSTRAINT [PK_beneficiaries]
    PRIMARY KEY CLUSTERED ([beneficiaryid] ASC);
GO

-- Creating primary key on [beneficiarycalid] in table 'beneficiarycalculations'
ALTER TABLE [dbo].[beneficiarycalculations]
ADD CONSTRAINT [PK_beneficiarycalculations]
    PRIMARY KEY CLUSTERED ([beneficiarycalid] ASC);
GO

-- Creating primary key on [categoryid] in table 'categories'
ALTER TABLE [dbo].[categories]
ADD CONSTRAINT [PK_categories]
    PRIMARY KEY CLUSTERED ([categoryid] ASC);
GO

-- Creating primary key on [customerid] in table 'customers'
ALTER TABLE [dbo].[customers]
ADD CONSTRAINT [PK_customers]
    PRIMARY KEY CLUSTERED ([customerid] ASC);
GO

-- Creating primary key on [invoicedetailsid] in table 'invoicedetails'
ALTER TABLE [dbo].[invoicedetails]
ADD CONSTRAINT [PK_invoicedetails]
    PRIMARY KEY CLUSTERED ([invoicedetailsid] ASC);
GO

-- Creating primary key on [invoiceheaderid] in table 'invoiceheaders'
ALTER TABLE [dbo].[invoiceheaders]
ADD CONSTRAINT [PK_invoiceheaders]
    PRIMARY KEY CLUSTERED ([invoiceheaderid] ASC);
GO

-- Creating primary key on [languageid] in table 'languages'
ALTER TABLE [dbo].[languages]
ADD CONSTRAINT [PK_languages]
    PRIMARY KEY CLUSTERED ([languageid] ASC);
GO

-- Creating primary key on [myshelfid] in table 'myshelves'
ALTER TABLE [dbo].[myshelves]
ADD CONSTRAINT [PK_myshelves]
    PRIMARY KEY CLUSTERED ([myshelfid] ASC);
GO

-- Creating primary key on [packagedetailsid] in table 'packagedetails'
ALTER TABLE [dbo].[packagedetails]
ADD CONSTRAINT [PK_packagedetails]
    PRIMARY KEY CLUSTERED ([packagedetailsid] ASC);
GO

-- Creating primary key on [productbeneficiaryid] in table 'productbeneficiaries'
ALTER TABLE [dbo].[productbeneficiaries]
ADD CONSTRAINT [PK_productbeneficiaries]
    PRIMARY KEY CLUSTERED ([productbeneficiaryid] ASC);
GO

-- Creating primary key on [productid] in table 'products'
ALTER TABLE [dbo].[products]
ADD CONSTRAINT [PK_products]
    PRIMARY KEY CLUSTERED ([productid] ASC);
GO

-- Creating primary key on [producttypeid] in table 'producttypes'
ALTER TABLE [dbo].[producttypes]
ADD CONSTRAINT [PK_producttypes]
    PRIMARY KEY CLUSTERED ([producttypeid] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [author_authorid] in table 'products'
ALTER TABLE [dbo].[products]
ADD CONSTRAINT [FK_productauthor]
    FOREIGN KEY ([author_authorid])
    REFERENCES [dbo].[authors]
        ([authorid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_productauthor'
CREATE INDEX [IX_FK_productauthor]
ON [dbo].[products]
    ([author_authorid]);
GO

-- Creating foreign key on [beneficiary_beneficiaryid] in table 'productbeneficiaries'
ALTER TABLE [dbo].[productbeneficiaries]
ADD CONSTRAINT [FK_beneficiaryproductbeneficiary]
    FOREIGN KEY ([beneficiary_beneficiaryid])
    REFERENCES [dbo].[beneficiaries]
        ([beneficiaryid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_beneficiaryproductbeneficiary'
CREATE INDEX [IX_FK_beneficiaryproductbeneficiary]
ON [dbo].[productbeneficiaries]
    ([beneficiary_beneficiaryid]);
GO

-- Creating foreign key on [invoicedetails_invoicedetailsid] in table 'beneficiarycalculations'
ALTER TABLE [dbo].[beneficiarycalculations]
ADD CONSTRAINT [FK_beneficiarycalculationinvoicedetails]
    FOREIGN KEY ([invoicedetails_invoicedetailsid])
    REFERENCES [dbo].[invoicedetails]
        ([invoicedetailsid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_beneficiarycalculationinvoicedetails'
CREATE INDEX [IX_FK_beneficiarycalculationinvoicedetails]
ON [dbo].[beneficiarycalculations]
    ([invoicedetails_invoicedetailsid]);
GO

-- Creating foreign key on [productbeneficiary_productbeneficiaryid] in table 'beneficiarycalculations'
ALTER TABLE [dbo].[beneficiarycalculations]
ADD CONSTRAINT [FK_productbeneficiarybeneficiarycalculation]
    FOREIGN KEY ([productbeneficiary_productbeneficiaryid])
    REFERENCES [dbo].[productbeneficiaries]
        ([productbeneficiaryid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_productbeneficiarybeneficiarycalculation'
CREATE INDEX [IX_FK_productbeneficiarybeneficiarycalculation]
ON [dbo].[beneficiarycalculations]
    ([productbeneficiary_productbeneficiaryid]);
GO

-- Creating foreign key on [category_categoryid] in table 'products'
ALTER TABLE [dbo].[products]
ADD CONSTRAINT [FK_categoryproduct]
    FOREIGN KEY ([category_categoryid])
    REFERENCES [dbo].[categories]
        ([categoryid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_categoryproduct'
CREATE INDEX [IX_FK_categoryproduct]
ON [dbo].[products]
    ([category_categoryid]);
GO

-- Creating foreign key on [customer_customerid] in table 'myshelves'
ALTER TABLE [dbo].[myshelves]
ADD CONSTRAINT [FK_customermyshelf]
    FOREIGN KEY ([customer_customerid])
    REFERENCES [dbo].[customers]
        ([customerid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_customermyshelf'
CREATE INDEX [IX_FK_customermyshelf]
ON [dbo].[myshelves]
    ([customer_customerid]);
GO

-- Creating foreign key on [customer_customerid] in table 'invoiceheaders'
ALTER TABLE [dbo].[invoiceheaders]
ADD CONSTRAINT [FK_invoiceheadercustomer]
    FOREIGN KEY ([customer_customerid])
    REFERENCES [dbo].[customers]
        ([customerid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_invoiceheadercustomer'
CREATE INDEX [IX_FK_invoiceheadercustomer]
ON [dbo].[invoiceheaders]
    ([customer_customerid]);
GO

-- Creating foreign key on [invoiceheader_invoiceheaderid] in table 'invoicedetails'
ALTER TABLE [dbo].[invoicedetails]
ADD CONSTRAINT [FK_invoiceheaderinvoicedetails]
    FOREIGN KEY ([invoiceheader_invoiceheaderid])
    REFERENCES [dbo].[invoiceheaders]
        ([invoiceheaderid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_invoiceheaderinvoicedetails'
CREATE INDEX [IX_FK_invoiceheaderinvoicedetails]
ON [dbo].[invoicedetails]
    ([invoiceheader_invoiceheaderid]);
GO

-- Creating foreign key on [product_productid] in table 'invoicedetails'
ALTER TABLE [dbo].[invoicedetails]
ADD CONSTRAINT [FK_productinvoicedetails]
    FOREIGN KEY ([product_productid])
    REFERENCES [dbo].[products]
        ([productid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_productinvoicedetails'
CREATE INDEX [IX_FK_productinvoicedetails]
ON [dbo].[invoicedetails]
    ([product_productid]);
GO

-- Creating foreign key on [invoiceheader_invoiceheaderid] in table 'myshelves'
ALTER TABLE [dbo].[myshelves]
ADD CONSTRAINT [FK_myshelfinvoiceheader]
    FOREIGN KEY ([invoiceheader_invoiceheaderid])
    REFERENCES [dbo].[invoiceheaders]
        ([invoiceheaderid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_myshelfinvoiceheader'
CREATE INDEX [IX_FK_myshelfinvoiceheader]
ON [dbo].[myshelves]
    ([invoiceheader_invoiceheaderid]);
GO

-- Creating foreign key on [language_languageid] in table 'products'
ALTER TABLE [dbo].[products]
ADD CONSTRAINT [FK_languageproduct]
    FOREIGN KEY ([language_languageid])
    REFERENCES [dbo].[languages]
        ([languageid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_languageproduct'
CREATE INDEX [IX_FK_languageproduct]
ON [dbo].[products]
    ([language_languageid]);
GO

-- Creating foreign key on [product_productid] in table 'myshelves'
ALTER TABLE [dbo].[myshelves]
ADD CONSTRAINT [FK_productmyshelf]
    FOREIGN KEY ([product_productid])
    REFERENCES [dbo].[products]
        ([productid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_productmyshelf'
CREATE INDEX [IX_FK_productmyshelf]
ON [dbo].[myshelves]
    ([product_productid]);
GO

-- Creating foreign key on [product_productid] in table 'packagedetails'
ALTER TABLE [dbo].[packagedetails]
ADD CONSTRAINT [FK_packagedetailsproduct]
    FOREIGN KEY ([product_productid])
    REFERENCES [dbo].[products]
        ([productid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_packagedetailsproduct'
CREATE INDEX [IX_FK_packagedetailsproduct]
ON [dbo].[packagedetails]
    ([product_productid]);
GO

-- Creating foreign key on [producttype_producttypeid] in table 'products'
ALTER TABLE [dbo].[products]
ADD CONSTRAINT [FK_producttypeproduct]
    FOREIGN KEY ([producttype_producttypeid])
    REFERENCES [dbo].[producttypes]
        ([producttypeid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_producttypeproduct'
CREATE INDEX [IX_FK_producttypeproduct]
ON [dbo].[products]
    ([producttype_producttypeid]);
GO

-- Creating foreign key on [product_productid] in table 'productbeneficiaries'
ALTER TABLE [dbo].[productbeneficiaries]
ADD CONSTRAINT [FK_productproductbeneficiary]
    FOREIGN KEY ([product_productid])
    REFERENCES [dbo].[products]
        ([productid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_productproductbeneficiary'
CREATE INDEX [IX_FK_productproductbeneficiary]
ON [dbo].[productbeneficiaries]
    ([product_productid]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------