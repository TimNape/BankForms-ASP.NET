CREATE TABLE [dbo].[LeadComsMethod] (
    [ID]           BIGINT   IDENTITY (1, 1) NOT NULL,
    [LeadID]       BIGINT   NOT NULL,
    [ComsMethodID] INT      NOT NULL,
    [DateCreated]  DATETIME CONSTRAINT [DF_LeadComsMethod_DateCreated] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_LeadComsMethod] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_LeadComsMethod_ComsMethod] FOREIGN KEY ([ComsMethodID]) REFERENCES [dbo].[ComsMethod] ([Id]),
    CONSTRAINT [FK_LeadComsMethod_Lead] FOREIGN KEY ([LeadID]) REFERENCES [dbo].[Lead] ([Id])
);

