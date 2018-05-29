CREATE TABLE [dbo].[ComsMethod] (
    [Id]        INT          NOT NULL,
    [Caption]   VARCHAR (50) NOT NULL,
    [SortOrder] INT          CONSTRAINT [DF_ComsMethod_SortOrder] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ComsMethod] PRIMARY KEY CLUSTERED ([Id] ASC)
);

