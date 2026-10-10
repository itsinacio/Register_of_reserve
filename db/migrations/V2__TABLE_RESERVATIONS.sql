CREATE TABLE [dbo].[Reservations](
    [Id] bigint NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Status] tinyint NOT NULL,
    [EmployeeName] varchar(255) NOT NULL,
    [StartOfReserve] DATETIME NOT NULL,
    [EndOfReserve] DATETIME NOT NULL,
    [RoomID] bigint NOT NULL FOREIGN KEY REFERENCES [dbo].[Rooms]([Id])
)