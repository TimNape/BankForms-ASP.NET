CREATE TABLE [dbo].[Lead] (
    [Id]           BIGINT        IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (50)  NOT NULL,
    [Surname]      VARCHAR (50)  NOT NULL,
    [TitleId]      INT           NOT NULL,
    [IdentityNo]   VARCHAR (20)  NULL,
    [ContactNo]    VARCHAR (50)  NOT NULL,
    [EmailAddress] VARCHAR (100) NULL,
    [DateCreated]  DATETIME      CONSTRAINT [DF_Lead_DateCreated] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Lead] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Lead_Title] FOREIGN KEY ([TitleId]) REFERENCES [dbo].[Title] ([Id])
);

