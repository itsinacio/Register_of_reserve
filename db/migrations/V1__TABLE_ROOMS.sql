CREATE TABLE [dbo].[Rooms](
    [Id] bigint NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Available] bit NOT NULL,
    [UnavailabilityReason] varchar(255), 
    [NameRoom] varchar(255) NOT NULL,
    [Capacity] tinyint NOT NULL,
    [Projector] bit NOT NULL
)