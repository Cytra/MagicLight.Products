CREATE TABLE [dbo].[Product]
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	[Category] NVARCHAR(50) NOT NULL,
    [SubCategory] NVARCHAR(50) NOT NULL,
    [SubSubCategoryName] NVARCHAR(50) NOT NULL,
    [Url] NVARCHAR(255) NOT NULL,
    [ProductImageLink] NVARCHAR(255) NOT NULL,
    [Description] NVARCHAR(max) NOT NULL,
    [ProductNumber] NVARCHAR(10) NOT NULL,
    [Categorija] NVARCHAR(50) NOT NULL,
    [Pavadinimas] NVARCHAR(50) NOT NULL,
    [Apibudinimas] NVARCHAR(max) NOT NULL,
)
