CREATE TABLE [dbo].[ToppingsInvetoryList]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ToppingName] NCHAR(30) NOT NULL, 
    [ToppingDescription] NCHAR(100) NULL, 
    [ToppingTypeId] INT NULL, 
    [IsNonVeg] BIT NULL, 
    [IsAvailable] BIT NULL, 
    [ToppingCost] MONEY NULL, 
    [CreatedDate] DATETIME NULL, 
    [CreatedBy] NCHAR(30) NULL, 
    [UpdatedDate] DATETIME NULL, 
    [UpdatedBy] NCHAR(30) NULL, 
    CONSTRAINT [FK_ToppingsInventoryList_ToppingType] FOREIGN KEY (ToppingTypeId) REFERENCES [ToppingType](Id) 
)