CREATE TABLE [dbo].[ToppingType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ToppingTypeName] NCHAR(20) NULL, 
    [ToppingTypeDescripion] NCHAR(50) NULL,
    [IsAvailable] BIT NULL, 
    [CreatedBy] NCHAR(30) NULL, 
    [CreatedDate] DATETIME NULL, 
    [UpdatedBy] NCHAR(30) NULL, 
    [UpdatedOn] DATETIME NULL, 
)
