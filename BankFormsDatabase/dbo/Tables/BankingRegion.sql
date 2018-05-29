CREATE TABLE [dbo].[BankingRegion] (
    [Id]        INT          NOT NULL,
    [Caption]   VARCHAR (50) NOT NULL,
    [SortOrder] INT          CONSTRAINT [DF_BankingRegion_SortOrder] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_BankingRegion] PRIMARY KEY CLUSTERED ([Id] ASC)
);

