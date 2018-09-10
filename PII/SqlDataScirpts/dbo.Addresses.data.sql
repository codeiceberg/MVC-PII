SET IDENTITY_INSERT [dbo].[Addresses] ON
INSERT INTO [dbo].[Addresses] ([Id], [HouseBlockLotNo], [Street], [SubdivisionVillage], [Zip], [BarangayId], [CityMunicipalityId], [ProvinceId], [Latitude], [Longitude], [AddressTypeId], [PersonId]) VALUES (1, N'3349-A', N'Narra Street', N'Centennial II', 1602, 182, 993, 49, NULL, NULL, 1, 5)
INSERT INTO [dbo].[Addresses] ([Id], [HouseBlockLotNo], [Street], [SubdivisionVillage], [Zip], [BarangayId], [CityMunicipalityId], [ProvinceId], [Latitude], [Longitude], [AddressTypeId], [PersonId]) VALUES (2, N'123', N'1st Street', N'Donasco Village', 8300, 1179, 1548, 77, NULL, NULL, 2, 5)
SET IDENTITY_INSERT [dbo].[Addresses] OFF
