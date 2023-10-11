CREATE TABLE [dbo].[OpenWeather] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [datehour]   DATETIME2 (7)  NOT NULL,
    [country]    NVARCHAR (MAX) NOT NULL,
    [city]       NVARCHAR (MAX) NOT NULL,
    [lat]        NVARCHAR (MAX) NOT NULL,
    [lon]        NVARCHAR (MAX) NOT NULL,
    [temp]       NVARCHAR (MAX) NOT NULL,
    [feels_like] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_OpenWeather] PRIMARY KEY CLUSTERED ([Id] ASC)
);

