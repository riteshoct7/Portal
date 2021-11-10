CREATE TABLE [dbo].[Countries] (
    [CountryId]   INT            IDENTITY (1, 1) NOT NULL,
    [CountryName] NVARCHAR (MAX) NOT NULL,
    [ISDCode]     NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [Enabled]     BIT            NOT NULL,
    CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED ([CountryId] ASC)
);

