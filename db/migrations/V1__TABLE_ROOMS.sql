CREATE TABLE [dbo].[Rooms](
    [Id] bigint NOT NULL PRIMARY KEY IDENTITY(1,1),
    [NameRoom] varchar(255) NOT NULL,
    [Capacity] tinyint NOT NULL,
    [Projector] bit NOT NULL
)