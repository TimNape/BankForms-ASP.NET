CREATE TABLE [dbo].[BankerMeetingSlot] (
    [Id]        INT          NOT NULL,
    [Caption]   VARCHAR (50) NOT NULL,
    [SortOrder] INT          NOT NULL,
    CONSTRAINT [PK_MeetingSlot] PRIMARY KEY CLUSTERED ([Id] ASC)
);

