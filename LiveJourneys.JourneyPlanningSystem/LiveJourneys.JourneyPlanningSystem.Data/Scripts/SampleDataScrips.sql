USE [LiveJourneysDb]
GO

TRUNCATE TABLE [StationMapping]
TRUNCATE TABLE [StationLine]
TRUNCATE TABLE [User]

DELETE FROM [Station]
DELETE FROM [Line]
DELETE FROM [UserType]

DBCC CHECKIDENT ('[Station]', RESEED, 0);
DBCC CHECKIDENT ('[Line]', RESEED, 0);
DBCC CHECKIDENT ('[UserType]', RESEED, 0);

GO


SET IDENTITY_INSERT [dbo].[Line] ON 

INSERT [dbo].[Line] ([LineId], [Name]) VALUES (1, N'PurpuleLine')
INSERT [dbo].[Line] ([LineId], [Name]) VALUES (2, N'YellowLine')
INSERT [dbo].[Line] ([LineId], [Name]) VALUES (3, N'GreenLine')
INSERT [dbo].[Line] ([LineId], [Name]) VALUES (4, N'RedLine')
INSERT [dbo].[Line] ([LineId], [Name]) VALUES (5, N'Kovan')
INSERT [dbo].[Line] ([LineId], [Name]) VALUES (6, N'Serangoon')
INSERT [dbo].[Line] ([LineId], [Name]) VALUES (7, N'Woodlight')
INSERT [dbo].[Line] ([LineId], [Name]) VALUES (8, N'PotangPasir')
INSERT [dbo].[Line] ([LineId], [Name]) VALUES (9, N'BoonKeng')
SET IDENTITY_INSERT [dbo].[Line] OFF
SET IDENTITY_INSERT [dbo].[Station] ON 

INSERT [dbo].[Station] ([StationId], [Name]) VALUES (1, N'Punggol')
INSERT [dbo].[Station] ([StationId], [Name]) VALUES (2, N'Senkang')
INSERT [dbo].[Station] ([StationId], [Name]) VALUES (3, N'Buangok')
INSERT [dbo].[Station] ([StationId], [Name]) VALUES (4, N'Huogang')
INSERT [dbo].[Station] ([StationId], [Name]) VALUES (5, N'Kovan')
INSERT [dbo].[Station] ([StationId], [Name]) VALUES (6, N'Serangoon')
INSERT [dbo].[Station] ([StationId], [Name]) VALUES (7, N'Woodlight')
INSERT [dbo].[Station] ([StationId], [Name]) VALUES (8, N'PotangPasir')
INSERT [dbo].[Station] ([StationId], [Name]) VALUES (9, N'BoonKeng')
SET IDENTITY_INSERT [dbo].[Station] OFF
INSERT [dbo].[StationLine] ([LineId], [StationId], [OrderNumber]) VALUES (1, 1, 1)
INSERT [dbo].[StationLine] ([LineId], [StationId], [OrderNumber]) VALUES (1, 2, 2)
INSERT [dbo].[StationLine] ([LineId], [StationId], [OrderNumber]) VALUES (2, 3, 1)
INSERT [dbo].[StationLine] ([LineId], [StationId], [OrderNumber]) VALUES (2, 4, 2)
INSERT [dbo].[StationLine] ([LineId], [StationId], [OrderNumber]) VALUES (2, 5, 3)
INSERT [dbo].[StationMapping] ([FromStaionId], [ToStationId], [LineId], [Distance], [IsDeleay]) VALUES (1, 2, 1, 10, 0)
INSERT [dbo].[StationMapping] ([FromStaionId], [ToStationId], [LineId], [Distance], [IsDeleay]) VALUES (1, 7, 2, 10, 0)
INSERT [dbo].[StationMapping] ([FromStaionId], [ToStationId], [LineId], [Distance], [IsDeleay]) VALUES (1, 8, 3, 11, 0)
INSERT [dbo].[StationMapping] ([FromStaionId], [ToStationId], [LineId], [Distance], [IsDeleay]) VALUES (2, 3, 1, 10, 0)
INSERT [dbo].[StationMapping] ([FromStaionId], [ToStationId], [LineId], [Distance], [IsDeleay]) VALUES (2, 5, 4, 10, 0)
INSERT [dbo].[StationMapping] ([FromStaionId], [ToStationId], [LineId], [Distance], [IsDeleay]) VALUES (3, 4, 1, 10, 0)
INSERT [dbo].[StationMapping] ([FromStaionId], [ToStationId], [LineId], [Distance], [IsDeleay]) VALUES (5, 6, 1, 15, 0)

SET IDENTITY_INSERT [dbo].[UserType] ON 
INSERT UserType(UserTypeId,[Type]) VALUES ('1', 'Admin')
INSERT UserType(UserTypeId,[Type]) VALUES ('2', 'Users')
SET IDENTITY_INSERT [dbo].[UserType] OFF

INSERT [User](UserName,[Password],TypeId) VALUES ('Admin','MXFhejJ3c3hA',1)
INSERT [User](UserName,[Password],TypeId)  VALUES ('User','MXFhejJ3c3hA',2)
