CREATE TABLE [dbo].[BankerBooking] (
    [Id]                  BIGINT        IDENTITY (1, 1) NOT NULL,
    [Company]             VARCHAR (100) NOT NULL,
    [ExistingClient]      BIT           NOT NULL,
    [Query]               VARCHAR (MAX) NOT NULL,
    [BankingRegionId]     INT           NOT NULL,
    [PreferredDate]       DATETIME      NOT NULL,
    [PreferredTimeSlotID] INT           NOT NULL,
    [DateCreated]         DATETIME      CONSTRAINT [DF_BankerBooking_DateCreated] DEFAULT (getdate()) NOT NULL,
    [LeadId]              BIGINT        NOT NULL,
    CONSTRAINT [PK_BankerBooking] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BankerBooking_BankingRegion] FOREIGN KEY ([BankingRegionId]) REFERENCES [dbo].[BankingRegion] ([Id]),
    CONSTRAINT [FK_BankerBooking_Lead] FOREIGN KEY ([LeadId]) REFERENCES [dbo].[Lead] ([Id]),
    CONSTRAINT [FK_BankerBooking_MeetingSlot] FOREIGN KEY ([PreferredTimeSlotID]) REFERENCES [dbo].[BankerMeetingSlot] ([Id])
);

