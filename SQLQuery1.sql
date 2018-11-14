
DROP TABLE [dbo].[MdDemoEmail];
GO

DROP TABLE [dbo].[MdDemoUser];
GO



CREATE TABLE [dbo].[MdDemoUser] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (1024) NULL,
    [LastName]  NVARCHAR (1024) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO




CREATE TABLE [dbo].[MdDemoEmail] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [UserId]       INT             NOT NULL,
    [EmailAddress] NVARCHAR (1024) NULL,
    [Verified] BIT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MdDemoEmail_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[MdDemoUser] ([Id])
);
GO




SET IDENTITY_INSERT [dbo].[MdDemoUser] ON
INSERT INTO [dbo].[MdDemoUser] ([Id], [FirstName], [LastName]) VALUES (1, N'Matthew', N'Dorn')
INSERT INTO [dbo].[MdDemoUser] ([Id], [FirstName], [LastName]) VALUES (2, N'John', N'Doe')
INSERT INTO [dbo].[MdDemoUser] ([Id], [FirstName], [LastName]) VALUES (3, N'Jane', N'Doe')
INSERT INTO [dbo].[MdDemoUser] ([Id], [FirstName], [LastName]) VALUES (4, N'Zoe', N'Allison')
INSERT INTO [dbo].[MdDemoUser] ([Id], [FirstName], [LastName]) VALUES (5, N'Matt', N'Matthews')
INSERT INTO [dbo].[MdDemoUser] ([Id], [FirstName], [LastName]) VALUES (6, N'asdf', N'asdf')
SET IDENTITY_INSERT [dbo].[MdDemoUser] OFF

SET IDENTITY_INSERT [dbo].[MdDemoEmail] ON
INSERT INTO [dbo].[MdDemoEmail] ([Id], [UserId], [EmailAddress]) VALUES (1, 1, N'dornm@fvtc.edu')
INSERT INTO [dbo].[MdDemoEmail] ([Id], [UserId], [EmailAddress]) VALUES (2, 1, N'dornmfvtc@gmail.com')
INSERT INTO [dbo].[MdDemoEmail] ([Id], [UserId], [EmailAddress]) VALUES (3, 5, N'mattmatthews@mattmatthews.com')
INSERT INTO [dbo].[MdDemoEmail] ([Id], [UserId], [EmailAddress]) VALUES (4, 4, N'zallison@hotmail.com')
INSERT INTO [dbo].[MdDemoEmail] ([Id], [UserId], [EmailAddress]) VALUES (5, 6, N'asdf@asdf.net')
INSERT INTO [dbo].[MdDemoEmail] ([Id], [UserId], [EmailAddress]) VALUES (6, 6, N'zxcv@zxcv.net')
SET IDENTITY_INSERT [dbo].[MdDemoEmail] OFF
