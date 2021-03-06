﻿SET IDENTITY_INSERT [dbo].[Line] ON
INSERT INTO [dbo].[Line] ([LineId], [Name]) VALUES (1, N'Line1')
INSERT INTO [dbo].[Line] ([LineId], [Name]) VALUES (2, N'LIne2')
INSERT INTO [dbo].[Line] ([LineId], [Name]) VALUES (3, N'Line3')
INSERT INTO [dbo].[Line] ([LineId], [Name]) VALUES (4, N'LIne4')
SET IDENTITY_INSERT [dbo].[Line] OFF


SET IDENTITY_INSERT [dbo].[Station] ON
INSERT INTO [dbo].[Station] ([StationId], [Name]) VALUES (1, N'Line1A')
INSERT INTO [dbo].[Station] ([StationId], [Name]) VALUES (2, N'Line1B')
INSERT INTO [dbo].[Station] ([StationId], [Name]) VALUES (3, N'Line1C')
INSERT INTO [dbo].[Station] ([StationId], [Name]) VALUES (4, N'Line1D')
INSERT INTO [dbo].[Station] ([StationId], [Name]) VALUES (5, N'Line2A')
INSERT INTO [dbo].[Station] ([StationId], [Name]) VALUES (6, N'Line2B')
INSERT INTO [dbo].[Station] ([StationId], [Name]) VALUES (7, N'Line1&2')
INSERT INTO [dbo].[Station] ([StationId], [Name]) VALUES (8, N'Line2&3')
INSERT INTO [dbo].[Station] ([StationId], [Name]) VALUES (9, N'Line3A')
INSERT INTO [dbo].[Station] ([StationId], [Name]) VALUES (1001, N'Line3B')
INSERT INTO [dbo].[Station] ([StationId], [Name]) VALUES (1002, N'Line3C')
INSERT INTO [dbo].[Station] ([StationId], [Name]) VALUES (1003, N'Line3D')
INSERT INTO [dbo].[Station] ([StationId], [Name]) VALUES (1004, N'Line2C')
INSERT INTO [dbo].[Station] ([StationId], [Name]) VALUES (1005, N'Line1&3')
SET IDENTITY_INSERT [dbo].[Station] OFF


INSERT INTO [dbo].[StationLine] ([LineId], [StationId], [OrderNumber]) VALUES (1, 1, 1)
INSERT INTO [dbo].[StationLine] ([LineId], [StationId], [OrderNumber]) VALUES (1, 2, 2)
INSERT INTO [dbo].[StationLine] ([LineId], [StationId], [OrderNumber]) VALUES (1, 3, 4)
INSERT INTO [dbo].[StationLine] ([LineId], [StationId], [OrderNumber]) VALUES (1, 4, 5)
INSERT INTO [dbo].[StationLine] ([LineId], [StationId], [OrderNumber]) VALUES (1, 7, 3)
INSERT INTO [dbo].[StationLine] ([LineId], [StationId], [OrderNumber]) VALUES (1, 1005, 6)
INSERT INTO [dbo].[StationLine] ([LineId], [StationId], [OrderNumber]) VALUES (2, 5, 1)
INSERT INTO [dbo].[StationLine] ([LineId], [StationId], [OrderNumber]) VALUES (2, 6, 3)
INSERT INTO [dbo].[StationLine] ([LineId], [StationId], [OrderNumber]) VALUES (2, 7, 2)
INSERT INTO [dbo].[StationLine] ([LineId], [StationId], [OrderNumber]) VALUES (2, 8, 4)
INSERT INTO [dbo].[StationLine] ([LineId], [StationId], [OrderNumber]) VALUES (2, 1004, 5)
INSERT INTO [dbo].[StationLine] ([LineId], [StationId], [OrderNumber]) VALUES (3, 8, 3)
INSERT INTO [dbo].[StationLine] ([LineId], [StationId], [OrderNumber]) VALUES (3, 9, 1)
INSERT INTO [dbo].[StationLine] ([LineId], [StationId], [OrderNumber]) VALUES (3, 1001, 2)
INSERT INTO [dbo].[StationLine] ([LineId], [StationId], [OrderNumber]) VALUES (3, 1002, 4)
INSERT INTO [dbo].[StationLine] ([LineId], [StationId], [OrderNumber]) VALUES (3, 1003, 5)
INSERT INTO [dbo].[StationLine] ([LineId], [StationId], [OrderNumber]) VALUES (3, 1005, 6)


INSERT INTO [dbo].[StationMapping] ([FromStaionId], [ToStationId], [LineId], [Distance], [IsDeleay]) VALUES (1, 2, 1, 10, 0)
INSERT INTO [dbo].[StationMapping] ([FromStaionId], [ToStationId], [LineId], [Distance], [IsDeleay]) VALUES (2, 7, 1, 11, 0)
INSERT INTO [dbo].[StationMapping] ([FromStaionId], [ToStationId], [LineId], [Distance], [IsDeleay]) VALUES (3, 4, 1, 10, 0)
INSERT INTO [dbo].[StationMapping] ([FromStaionId], [ToStationId], [LineId], [Distance], [IsDeleay]) VALUES (4, 1005, 1, 15, 0)
INSERT INTO [dbo].[StationMapping] ([FromStaionId], [ToStationId], [LineId], [Distance], [IsDeleay]) VALUES (5, 7, 2, 10, 0)
INSERT INTO [dbo].[StationMapping] ([FromStaionId], [ToStationId], [LineId], [Distance], [IsDeleay]) VALUES (6, 8, 2, 10, 0)
INSERT INTO [dbo].[StationMapping] ([FromStaionId], [ToStationId], [LineId], [Distance], [IsDeleay]) VALUES (7, 3, 1, 12, 0)
INSERT INTO [dbo].[StationMapping] ([FromStaionId], [ToStationId], [LineId], [Distance], [IsDeleay]) VALUES (7, 6, 2, 10, 0)
INSERT INTO [dbo].[StationMapping] ([FromStaionId], [ToStationId], [LineId], [Distance], [IsDeleay]) VALUES (8, 1002, 3, 10, 0)
INSERT INTO [dbo].[StationMapping] ([FromStaionId], [ToStationId], [LineId], [Distance], [IsDeleay]) VALUES (8, 1004, 2, 10, 0)
INSERT INTO [dbo].[StationMapping] ([FromStaionId], [ToStationId], [LineId], [Distance], [IsDeleay]) VALUES (9, 1001, 3, 10, 0)
INSERT INTO [dbo].[StationMapping] ([FromStaionId], [ToStationId], [LineId], [Distance], [IsDeleay]) VALUES (1001, 8, 3, 10, 0)
INSERT INTO [dbo].[StationMapping] ([FromStaionId], [ToStationId], [LineId], [Distance], [IsDeleay]) VALUES (1002, 1003, 3, 10, 0)
INSERT INTO [dbo].[StationMapping] ([FromStaionId], [ToStationId], [LineId], [Distance], [IsDeleay]) VALUES (1003, 1005, 3, 10, 0)


-- User data

SET IDENTITY_INSERT [dbo].[UserType] ON 
INSERT UserType(UserTypeId,[Type]) VALUES ('1', 'Admin')
INSERT UserType(UserTypeId,[Type]) VALUES ('2', 'Users')
SET IDENTITY_INSERT [dbo].[UserType] OFF

INSERT [User](UserName,[Password],TypeId) VALUES ('Admin','MXFhejJ3c3hA',1)
INSERT [User](UserName,[Password],TypeId)  VALUES ('User','MXFhejJ3c3hA',2)