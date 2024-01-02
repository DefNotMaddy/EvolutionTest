-- Users Table
CREATE TABLE [dbo].[Users](
    [id] [int] NOT NULL,
    [name] [nvarchar](255) NULL,
    [username] [nvarchar](255) NULL,
    [email] [nvarchar](255) NULL,
    [phone] [nvarchar](255) NULL,
    [website] [nvarchar](255) NULL,
    [AdditionalColumn] [varchar](255) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
) ON [PRIMARY]
GO

-- Addresses Table
CREATE TABLE [dbo].[Addresses](
    [id] [int] NOT NULL,
    [user_id] [int] NULL,
    [street] [nvarchar](255) NULL,
    [suite] [nvarchar](255) NULL,
    [city] [nvarchar](255) NULL,
    [zipcode] [nvarchar](255) NULL,
    [lat] [decimal](10, 7) NULL,
    [lng] [decimal](10, 7) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([id])
) ON [PRIMARY]
GO

-- Companies Table
CREATE TABLE [dbo].[Companies](
    [id] [int] NOT NULL,
    [user_id] [int] NULL,
    [name] [nvarchar](255) NULL,
    [catchPhrase] [nvarchar](255) NULL,
    [bs] [nvarchar](255) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([id])
) ON [PRIMARY]
GO

-- Geos Table
CREATE TABLE [dbo].[Geos](
    [id] [int] NOT NULL,
    [address_id] [int] NULL,
    [lat] [decimal](10, 4) NULL,
    [lng] [decimal](10, 4) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([address_id]) REFERENCES [dbo].[Addresses] ([id])
) ON [PRIMARY]
GO

-- UserDetailView View
CREATE VIEW [dbo].[UserDetailView]
AS
SELECT u.id AS UserId, u.name AS UserName, u.username AS UserUsername, u.email AS UserEmail, u.phone AS UserPhone, u.website AS UserWebsite, u.AdditionalColumn, 
       a.street AS AddressStreet, a.suite AS AddressSuite, a.city AS AddressCity, a.zipcode AS AddressZipcode, g.lat AS GeoLat, g.lng AS GeoLng, 
       c.name AS CompanyName, c.catchPhrase AS CompanyCatchPhrase, c.bs AS CompanyBs, c.id
FROM dbo.Users AS u
INNER JOIN dbo.Addresses AS a ON u.id = a.user_id
INNER JOIN dbo.Geos AS g ON a.id = g.address_id
INNER JOIN dbo.Companies AS c ON u.id = c.user_id
GO