USE [FlashShop]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/13/2024 4:13:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 12/13/2024 4:13:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/13/2024 4:13:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/13/2024 4:13:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/13/2024 4:13:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/13/2024 4:13:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/13/2024 4:13:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[RoleId] [nvarchar](256) NULL,
	[Token] [nvarchar](max) NULL,
	[FullName] [nvarchar](255) NULL,
	[Address] [nvarchar](255) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 12/13/2024 4:13:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 12/13/2024 4:13:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Price] [decimal](15, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
	[ImgLink] [nvarchar](max) NULL,
	[Description] [nvarchar](255) NULL,
	[Author] [nvarchar](100) NULL,
	[Publication] [int] NULL,
	[Point] [real] NULL,
	[CategoryId] [int] NOT NULL,
	[PublisherId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 12/13/2024 4:13:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 12/13/2024 4:13:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderCode] [nvarchar](max) NULL,
	[UserName] [nvarchar](max) NULL,
	[dateTime] [datetime2](7) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdersDetails]    Script Date: 12/13/2024 4:13:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdersDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[OrderCode] [nvarchar](max) NULL,
	[BookId] [int] NOT NULL,
	[Price] [decimal](18, 4) NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_OrdersDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publisher]    Script Date: 12/13/2024 4:13:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publisher](
	[PublisherId] [int] IDENTITY(1,1) NOT NULL,
	[PublisherName] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PublisherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ratings]    Script Date: 12/13/2024 4:13:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ratings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Rating] [nvarchar](max) NULL,
 CONSTRAINT [PK_Ratings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 12/13/2024 4:13:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[FullName] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/13/2024 4:13:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[userID] [int] IDENTITY(1,1) NOT NULL,
	[userName] [nvarchar](max) NOT NULL,
	[email] [nvarchar](max) NOT NULL,
	[account] [nvarchar](max) NOT NULL,
	[password] [nvarchar](20) NOT NULL,
	[typeUser] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241109174926_FirstMigration', N'8.0.10')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241204084044_IdentityMigration', N'8.0.10')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241206095026_CreateCheckout', N'8.0.10')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241206131647_Edittype', N'8.0.10')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241209100008_AddTokentoUser', N'8.0.10')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241210055722_RatingsMigration', N'8.0.10')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241212151721_StatisticalTable', N'8.0.10')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241213053921_AddUserDetails', N'8.0.10')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'C0996633-80AF-4731-91C8-532F034761C3', N'User', N'USER', N'FCFA0111-B587-4A50-9E26-98C1A14FF0B7')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'E2067DF4-6526-4C07-BB1A-5EC43AC2D335', N'Admin', N'ADMIN', N'D2D0C99C-D13F-4A2B-9466-467FC110AE26')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'14e9f038-1592-4f50-8ad1-d0bfad1f89de', N'C0996633-80AF-4731-91C8-532F034761C3')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c5e8a8a8-512d-4a51-adf4-d502883f450b', N'C0996633-80AF-4731-91C8-532F034761C3')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c8396a2b-b867-40fc-a424-0a48fde569ed', N'C0996633-80AF-4731-91C8-532F034761C3')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'68302394-9332-4d0f-a1ad-7a6a4317aca6', N'E2067DF4-6526-4C07-BB1A-5EC43AC2D335')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [RoleId], [Token], [FullName], [Address]) VALUES (N'14e9f038-1592-4f50-8ad1-d0bfad1f89de', N'TD', N'TD', N'phiduong@gmail.com', N'PHIDUONG@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEPvoKTFzc6PsLdVE9NZXPYM+jy58ybPprK5kmoMI8vCLeI0DCKmSH9zg2Sr8ONMdrw==', N'OHJVGCGOU3KHGID32M4ECRICJAC52BU3', N'901dd48f-6a16-42b0-b95a-e5ae601af9fb', NULL, 0, 0, NULL, 1, 0, NULL, N'90b5bda1-5daf-47ff-81e0-b36a66189769', NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [RoleId], [Token], [FullName], [Address]) VALUES (N'68302394-9332-4d0f-a1ad-7a6a4317aca6', N'admin', N'ADMIN', N'6351071014@st.utc2.edu.vn', N'6351071014@ST.UTC2.EDU.VN', 0, N'AQAAAAIAAYagAAAAED7tHSm/IQIQKRKvJI3cC8AmD6pEzIK6AQppw5kpNNpoP2V64PRgaiCF7EUl8wr3Vg==', N'GTBCYJPMPBGVFHJAKYBVKGKK64XAU3VU', N'50609dff-5225-439f-a698-a93761fb7d5c', NULL, 0, 0, NULL, 1, 0, N'E2067DF4-6526-4C07-BB1A-5EC43AC2D335', NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [RoleId], [Token], [FullName], [Address]) VALUES (N'6f88c578-60d5-48ee-ba1c-43b7a6ef6a1e', N'tranduong', N'TRANDUONG', N'phiduong.it.hcm@gmail.com', N'PHIDUONG.IT.HCM@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEFduOqdH8zdu2wkVwmVqcmgCuJpbvEN8IvnbhewetONjvlCR18AM3WqADCG5G50K4w==', N'5UE5IG52DQUJZQYPBKBDTG7FK5MWR7PY', N'24f172f6-9201-4c70-981b-837954093049', NULL, 0, 0, NULL, 1, 0, N'C0996633-80AF-4731-91C8-532F034761C3', N'a13b590b-2d46-490b-ba0d-8ef0288f7530', NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [RoleId], [Token], [FullName], [Address]) VALUES (N'c5e8a8a8-512d-4a51-adf4-d502883f450b', N'admin2', N'ADMIN2', N'phiduong1@gmail.com', N'PHIDUONG1@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEBzS0K3Vc78unzsSr6PWAj5LB9ZqVtkqq82asRQSHaXiuPRnPlFSN0byUVVfOaE8Sg==', N'LYCIX5DZ6XMB6PK3LLQ7D7B2Q7FW2KY4', N'18a252b6-8cfa-4c8d-b7f2-bd04d0124a9a', NULL, 0, 0, NULL, 1, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [RoleId], [Token], [FullName], [Address]) VALUES (N'c8396a2b-b867-40fc-a424-0a48fde569ed', N'user1', N'USER1', N'phiduong10ccva@gmail.com', N'PHIDUONG10CCVA@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAELtsxE2/b/hg56Oz2+CVzWJkHIxf4NVdRxPnEGNkAyLUt9W4RzAabA865JVe5b/FuA==', N'FJU5VZ5PUAR6UFVCVPBRBEVC2S3YQPY3', N'f4f8f7a3-c5e7-47a1-a8ed-38048689a66d', NULL, 0, 0, NULL, 1, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [RoleId], [Token], [FullName], [Address]) VALUES (N'edbdf3f0-e850-49b3-830d-5cef3b9f9ad4', N'admin1', N'ADMIN1', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEOB3JU/nQCkNbf6+yiObppKo8+C7W9hCyHGEk6Xrhq8KYFzun6af0C0+EzaJiusOrQ==', N'K63ABEIJGQ2T47JCVJT4TJR4UIRNMQHX', N'332d5788-22bf-4009-99f6-f1c2404ca4fc', NULL, 0, 0, NULL, 1, 0, N'E2067DF4-6526-4C07-BB1A-5EC43AC2D335', NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Books] ON 
GO
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Quantity], [ImgLink], [Description], [Author], [Publication], [Point], [CategoryId], [PublisherId]) VALUES (1, N'Thám tử lừng danh Conan', CAST(50.00 AS Decimal(15, 2)), 91, N'13a2ac5a-f34c-4fa6-ac22-f15b62157f2d_book1.jpg', N'Thám tử lừng danh Conan | Cuộc điều tra giữa biển khơi Phần 1', N'Aoyama Gosho', 1996, 8, 2, 2)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Quantity], [ImgLink], [Description], [Author], [Publication], [Point], [CategoryId], [PublisherId]) VALUES (3, N'Doraemon tập 1', CAST(49.00 AS Decimal(15, 2)), 27, N'book2.jpg', N'Truyện tranh Doraemon tập 1', N'Fujio F. Fujiko', 2000, 9, 2, 1)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Quantity], [ImgLink], [Description], [Author], [Publication], [Point], [CategoryId], [PublisherId]) VALUES (12, N'Hoàng Tử Bé', CAST(30.00 AS Decimal(15, 2)), 0, N'book3.jpg', N'Sách thiếu nhi Hoàng Tử Bé', N'Antoine de Saint-Exupery', 2004, 7, 1, 1)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Quantity], [ImgLink], [Description], [Author], [Publication], [Point], [CategoryId], [PublisherId]) VALUES (13, N'Trạng Quỷnh', CAST(30.00 AS Decimal(15, 2)), 0, N'book4.jpg', N'Sách Thiếu nhi Trạng Quỷnh', N'Kim Khánh', 2010, 9, 1, 1)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Quantity], [ImgLink], [Description], [Author], [Publication], [Point], [CategoryId], [PublisherId]) VALUES (15, N'Doraemon', CAST(44.00 AS Decimal(15, 2)), 7, N'book5.jpg', N'Câu chuyện về chú mèo máy đến từ tương lai và những người bạn', N'Fujiko F. Fujio', 1970, 8, 2, 2)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Quantity], [ImgLink], [Description], [Author], [Publication], [Point], [CategoryId], [PublisherId]) VALUES (16, N'Combo Truyện 7 Viên Ngọc Rồng', CAST(130.00 AS Decimal(15, 2)), 99, N'f1dbaa09-3c6f-49c2-a102-5860e7a34a78_book6.jpg', N'Combo 4 chương truyện 7 viên ngọc rồng 1 2 3 4. Nói về cuộc chiến của Songoku và các đối thủ đáng gờm', N'Akira Toriyama', 1986, 4.9, 2, 1)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Quantity], [ImgLink], [Description], [Author], [Publication], [Point], [CategoryId], [PublisherId]) VALUES (17, N'One Piece Chap 91', CAST(60.00 AS Decimal(15, 2)), 120, N'820a687c-0512-48b0-a575-7abbfe680a94_18.jpg', N'Hành trình trở thành Vua Hải Tặc của Luffy và băng Mũ Rơm chương 91', N'Eiichiro Oda', 1997, 5, 2, 2)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Quantity], [ImgLink], [Description], [Author], [Publication], [Point], [CategoryId], [PublisherId]) VALUES (21, N'Tuổi trẻ đáng giá bao nhiêu', CAST(31.00 AS Decimal(15, 2)), 1, N'31fb8a1e-6b7a-4728-bca2-7019993eeb31_book7.jpg', N'Bạn hối tiếc vì không nắm bắt lấy một cơ hội nào đó, chẳng có ai phải mất ngủ., Bạn trải qua những ngày tháng nhạt nhẽo với công việc bạn ...', N'Rosie Nguyễn', 2016, 4.5, 9, 8)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Quantity], [ImgLink], [Description], [Author], [Publication], [Point], [CategoryId], [PublisherId]) VALUES (24, N'Truyện tranh Doreamon', CAST(35.00 AS Decimal(15, 2)), 1, N'6a118d80-780c-4819-9e55-2222845d9bc3_book8.jpg', N'Tập truyện tranh Doreamon | Chú mèo máy đến từ tương, tập 31', N'Fujiko F. Fujio', 2012, 4.5, 2, 2)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Quantity], [ImgLink], [Description], [Author], [Publication], [Point], [CategoryId], [PublisherId]) VALUES (25, N'Tin học 12', CAST(23.00 AS Decimal(15, 2)), 1, N'58663a4b-e2af-4ba3-9ec6-86e8af0bc57f_book9.jpg', N'Sách môn tin học 12 | Định hướng ứng dụng. Dành cho học sinh trung học phổ thông lớp 12', N'Bộ Giáo dục và Đào tạo', 2021, 5, 8, 3)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Quantity], [ImgLink], [Description], [Author], [Publication], [Point], [CategoryId], [PublisherId]) VALUES (26, N'Cấu trúc dữ liệu và giải thuật', CAST(36.00 AS Decimal(15, 2)), 1, N'3d8f6d11-1ebf-48b6-9b88-2768b3f497ca_book10.jpg', N'Sách cấu trúc dữ liệu và giải thuật dành cho sinh viên Công nghệ thông tin và các ngành liên quan. Giúp sinh viên nắm vững kiến thức về cấu trúc dữ liệu và các thuật toán', N'PSG TS. Hàn Viết Thuận', 2018, 4.9, 8, 11)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Quantity], [ImgLink], [Description], [Author], [Publication], [Point], [CategoryId], [PublisherId]) VALUES (27, N'Tình mẫu tử độc hại', CAST(23.00 AS Decimal(15, 2)), 1, N'41b73dde-2ad7-4640-acdf-56a426ab20af_book11.jpg', N'Sách tình mẫu tử độc hại, Khi tình yêu của mẹ trở thành gánh nặng tâm lý cho con, Sách nói về tình cảm của cha mẹ dành cho con và con cái đối với cha mẹ. Một cuốn sách thật sự hấp dẫn', N'Vũ Linh Na', 2020, 4.9, 3, 9)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Quantity], [ImgLink], [Description], [Author], [Publication], [Point], [CategoryId], [PublisherId]) VALUES (28, N'Tam Thể', CAST(36.00 AS Decimal(15, 2)), 3, N'7b2e29e4-84b8-4de4-aba4-440da8b44df8_book12.jpg', N'Tam Thể là quyển tiểu thuyết khoa học viễn tưởng của nhà văn người Trung Quốc. Tên sách phỏng theo Bài toán ba vật thể trong Cơ học. Đây là cuốn đầu tiên trong bộ ba Chuyện cũ Trái Đất, được người Trung gọi là Tam Thể', N'Lưu Từ Hân', 2006, 4.4, 6, 6)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Quantity], [ImgLink], [Description], [Author], [Publication], [Point], [CategoryId], [PublisherId]) VALUES (29, N'Lời Tiên Tri Cuối Cùng', CAST(37.00 AS Decimal(15, 2)), 1, N'6174b05e-83d5-404d-8b9e-c25ba9747cfc_book14.jpg', N'Cuốn sách "Lời Tiên Tri Cuối Cùng" là một cuốn sách Khoa học - Viễn tưởng, nội dung hấp dẫn, gay gấn', N'Naomi Novik', 2010, 4.3, 6, 10)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Quantity], [ImgLink], [Description], [Author], [Publication], [Point], [CategoryId], [PublisherId]) VALUES (30, N'Sách hướng dẫn Chiêm Tinh', CAST(33.00 AS Decimal(15, 2)), 12, N'3e90c7e7-9fa5-428a-95dd-b65c43bac705_book15.jpg', N'Sách hướng dẫn Chiêm Tinh cho người mới bắt đầu, dịch bởi Vân Anh. Kiến thức Chiêm Tinh toàn diện cho người mới bắt đầu.', N'Stefanie Caponi', 2020, 4.5, 5, 9)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Price], [Quantity], [ImgLink], [Description], [Author], [Publication], [Point], [CategoryId], [PublisherId]) VALUES (31, N'Tin hoc', CAST(150.00 AS Decimal(15, 2)), 20, N'a04b6760-b1a8-4ab6-9231-48ebf5368cdd_Screenshot 2024-12-10 212854.png', N'sach huong dan', N'van hoc', 2006, 7, 8, 9)
GO
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (1, N'Sách thiếu nhi')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (2, N'Truyện tranh')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (3, N'Sách tâm lý - tình cảm')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (4, N'Sách văn hóa-xã hội')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (5, N'Sách hướng dẫn')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (6, N'Sách khoa học - viễn tưởng')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (7, N'Sách lịch sử')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (8, N'Sách giáo khoa')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (9, N'Khác')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [dateTime], [Status]) VALUES (13, N'a6406e1c-383e-4cba-8a56-adc53b3f548a', N'6351071014@st.utc2.edu.vn', CAST(N'2024-12-11T01:37:58.4863766' AS DateTime2), 1)
GO
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [dateTime], [Status]) VALUES (14, N'5c8fb6dd-c6dc-4ae3-a0e9-ce2a1ad51cb1', N'6351071014@st.utc2.edu.vn', CAST(N'2024-12-11T01:39:53.0587699' AS DateTime2), 1)
GO
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [dateTime], [Status]) VALUES (15, N'c349b070-878c-4c27-8f99-6d5c3dd47fc3', N'6351071014@st.utc2.edu.vn', CAST(N'2024-12-11T01:46:12.6583569' AS DateTime2), 1)
GO
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [dateTime], [Status]) VALUES (16, N'6adbf015-c317-42d6-bdc5-ef510b987d9d', N'6351071014@st.utc2.edu.vn', CAST(N'2024-12-11T02:10:42.8298416' AS DateTime2), 1)
GO
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [dateTime], [Status]) VALUES (17, N'6c873b2e-161a-4e56-b631-6b3059db4a34', N'6351071014@st.utc2.edu.vn', CAST(N'2024-12-11T02:11:47.9491336' AS DateTime2), 1)
GO
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [dateTime], [Status]) VALUES (18, N'1f92fcc6-62e7-450e-8c14-c08098f94aae', N'6351071014@st.utc2.edu.vn', CAST(N'2024-12-11T02:18:16.1733242' AS DateTime2), 1)
GO
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [dateTime], [Status]) VALUES (19, N'e7ca08cf-b261-40eb-8263-a4af969d302a', N'6351071014@st.utc2.edu.vn', CAST(N'2024-12-11T02:18:33.2526461' AS DateTime2), 1)
GO
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [dateTime], [Status]) VALUES (20, N'91ed65c4-b0ff-4123-a23f-9d36160aa31b', N'6351071014@st.utc2.edu.vn', CAST(N'2024-12-11T02:28:09.7180986' AS DateTime2), 0)
GO
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [dateTime], [Status]) VALUES (21, N'4732e4fc-c989-4eea-9318-d3d87bce3faf', N'6351071014@st.utc2.edu.vn', CAST(N'2024-12-11T16:31:09.4314571' AS DateTime2), 1)
GO
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [dateTime], [Status]) VALUES (22, N'f9d19273-a04f-4d34-a2d0-26e0446f10da', N'phiduong10ccva@gmail.com', CAST(N'2024-12-11T16:35:10.8568215' AS DateTime2), 1)
GO
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [dateTime], [Status]) VALUES (23, N'bacfdb6b-811b-46ca-a880-edd3eada14ef', N'6351071014@st.utc2.edu.vn', CAST(N'2024-12-12T19:57:11.5115131' AS DateTime2), 0)
GO
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [dateTime], [Status]) VALUES (24, N'3142cb1b-a130-49ae-90d2-94cd4199e131', N'6351071014@st.utc2.edu.vn', CAST(N'2024-12-12T23:26:21.0057455' AS DateTime2), 0)
GO
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [dateTime], [Status]) VALUES (25, N'10412cc5-3228-4a3c-ba49-a84c123336b5', N'6351071014@st.utc2.edu.vn', CAST(N'2024-12-13T00:26:59.4598960' AS DateTime2), 3)
GO
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [dateTime], [Status]) VALUES (26, N'8a1a6b01-dd4f-4df4-8cc1-167d72c97130', N'6351071014@st.utc2.edu.vn', CAST(N'2024-12-13T00:30:46.5616820' AS DateTime2), 0)
GO
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [dateTime], [Status]) VALUES (27, N'75ae5158-f342-4e5e-b368-ea5c2da71667', N'6351071014@st.utc2.edu.vn', CAST(N'2024-12-13T02:31:39.4086421' AS DateTime2), 0)
GO
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [dateTime], [Status]) VALUES (28, N'30d6210c-62bb-4365-aa5f-5b5cd6f4bbed', N'6351071014@st.utc2.edu.vn', CAST(N'2024-12-13T03:27:09.2235941' AS DateTime2), 3)
GO
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [dateTime], [Status]) VALUES (29, N'c542efcf-b1e0-4d24-b6b6-4ae86869e30e', N'6351071014@st.utc2.edu.vn', CAST(N'2024-12-13T03:27:18.0740319' AS DateTime2), 0)
GO
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [dateTime], [Status]) VALUES (30, N'ca997cf5-11d9-41cd-acd9-e42837b09d1a', N'6351071014@st.utc2.edu.vn', CAST(N'2024-12-13T07:56:57.9187728' AS DateTime2), 3)
GO
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [dateTime], [Status]) VALUES (31, N'65c71544-2bcb-4c81-abd4-c59501a23156', N'phiduong1@gmail.com', CAST(N'2024-12-13T10:19:31.1862294' AS DateTime2), 0)
GO
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [dateTime], [Status]) VALUES (32, N'f91ab878-005f-4517-9279-c2e9b2e86808', N'6351071014@st.utc2.edu.vn', CAST(N'2024-12-13T13:40:18.9771449' AS DateTime2), 3)
GO
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [dateTime], [Status]) VALUES (33, N'a51697ee-ccdf-4625-b874-f429869f86c5', N'6351071014@st.utc2.edu.vn', CAST(N'2024-12-13T13:40:23.1292954' AS DateTime2), 2)
GO
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [dateTime], [Status]) VALUES (34, N'29c8adf3-d12a-4b32-a727-c0ce694f8e8e', N'6351071014@st.utc2.edu.vn', CAST(N'2024-12-13T14:11:16.4980746' AS DateTime2), 1)
GO
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [dateTime], [Status]) VALUES (35, N'd3865337-31ec-4b87-ac67-d9378ccc9462', N'6351071014@st.utc2.edu.vn', CAST(N'2024-12-13T14:11:59.9399013' AS DateTime2), 1)
GO
INSERT [dbo].[Orders] ([Id], [OrderCode], [UserName], [dateTime], [Status]) VALUES (36, N'c9cecbc5-3376-408e-bc45-1af0963fa60c', N'6351071014@st.utc2.edu.vn', CAST(N'2024-12-13T14:22:14.6977363' AS DateTime2), 2)
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[OrdersDetails] ON 
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (1, N'6351071014@st.utc2.edu.vn', N'1f92fcc6-62e7-450e-8c14-c08098f94aae', 3, CAST(49.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (2, N'6351071014@st.utc2.edu.vn', N'e7ca08cf-b261-40eb-8263-a4af969d302a', 3, CAST(49.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (3, N'6351071014@st.utc2.edu.vn', N'91ed65c4-b0ff-4123-a23f-9d36160aa31b', 16, CAST(130.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (4, N'6351071014@st.utc2.edu.vn', N'91ed65c4-b0ff-4123-a23f-9d36160aa31b', 24, CAST(35.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (5, N'6351071014@st.utc2.edu.vn', N'91ed65c4-b0ff-4123-a23f-9d36160aa31b', 17, CAST(60.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (6, N'6351071014@st.utc2.edu.vn', N'4732e4fc-c989-4eea-9318-d3d87bce3faf', 1, CAST(50.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (7, N'6351071014@st.utc2.edu.vn', N'4732e4fc-c989-4eea-9318-d3d87bce3faf', 3, CAST(49.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (8, N'6351071014@st.utc2.edu.vn', N'4732e4fc-c989-4eea-9318-d3d87bce3faf', 12, CAST(30.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (9, N'phiduong10ccva@gmail.com', N'f9d19273-a04f-4d34-a2d0-26e0446f10da', 16, CAST(130.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (10, N'phiduong10ccva@gmail.com', N'f9d19273-a04f-4d34-a2d0-26e0446f10da', 12, CAST(30.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (11, N'6351071014@st.utc2.edu.vn', N'bacfdb6b-811b-46ca-a880-edd3eada14ef', 3, CAST(49.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (12, N'6351071014@st.utc2.edu.vn', N'3142cb1b-a130-49ae-90d2-94cd4199e131', 1, CAST(50.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (13, N'6351071014@st.utc2.edu.vn', N'3142cb1b-a130-49ae-90d2-94cd4199e131', 3, CAST(49.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (14, N'6351071014@st.utc2.edu.vn', N'10412cc5-3228-4a3c-ba49-a84c123336b5', 1, CAST(50.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (15, N'6351071014@st.utc2.edu.vn', N'10412cc5-3228-4a3c-ba49-a84c123336b5', 3, CAST(49.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (16, N'6351071014@st.utc2.edu.vn', N'8a1a6b01-dd4f-4df4-8cc1-167d72c97130', 12, CAST(30.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (17, N'6351071014@st.utc2.edu.vn', N'8a1a6b01-dd4f-4df4-8cc1-167d72c97130', 16, CAST(130.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (18, N'6351071014@st.utc2.edu.vn', N'75ae5158-f342-4e5e-b368-ea5c2da71667', 3, CAST(49.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (19, N'6351071014@st.utc2.edu.vn', N'75ae5158-f342-4e5e-b368-ea5c2da71667', 16, CAST(130.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (20, N'6351071014@st.utc2.edu.vn', N'75ae5158-f342-4e5e-b368-ea5c2da71667', 12, CAST(30.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (21, N'6351071014@st.utc2.edu.vn', N'c542efcf-b1e0-4d24-b6b6-4ae86869e30e', 1, CAST(50.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (22, N'6351071014@st.utc2.edu.vn', N'c542efcf-b1e0-4d24-b6b6-4ae86869e30e', 3, CAST(49.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (23, N'6351071014@st.utc2.edu.vn', N'ca997cf5-11d9-41cd-acd9-e42837b09d1a', 13, CAST(30.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (24, N'6351071014@st.utc2.edu.vn', N'ca997cf5-11d9-41cd-acd9-e42837b09d1a', 15, CAST(44.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (25, N'phiduong1@gmail.com', N'65c71544-2bcb-4c81-abd4-c59501a23156', 1, CAST(50.0000 AS Decimal(18, 4)), 4)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (26, N'phiduong1@gmail.com', N'65c71544-2bcb-4c81-abd4-c59501a23156', 15, CAST(44.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (27, N'phiduong1@gmail.com', N'65c71544-2bcb-4c81-abd4-c59501a23156', 3, CAST(49.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (28, N'6351071014@st.utc2.edu.vn', N'a51697ee-ccdf-4625-b874-f429869f86c5', 1, CAST(50.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (29, N'6351071014@st.utc2.edu.vn', N'29c8adf3-d12a-4b32-a727-c0ce694f8e8e', 1, CAST(50.0000 AS Decimal(18, 4)), 2)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (30, N'6351071014@st.utc2.edu.vn', N'd3865337-31ec-4b87-ac67-d9378ccc9462', 15, CAST(44.0000 AS Decimal(18, 4)), 1)
GO
INSERT [dbo].[OrdersDetails] ([Id], [UserName], [OrderCode], [BookId], [Price], [Quantity]) VALUES (31, N'6351071014@st.utc2.edu.vn', N'c9cecbc5-3376-408e-bc45-1af0963fa60c', 1, CAST(50.0000 AS Decimal(18, 4)), 1)
GO
SET IDENTITY_INSERT [dbo].[OrdersDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Publisher] ON 
GO
INSERT [dbo].[Publisher] ([PublisherId], [PublisherName]) VALUES (1, N'NXB Kim Đồng')
GO
INSERT [dbo].[Publisher] ([PublisherId], [PublisherName]) VALUES (2, N'NXB Trẻ')
GO
INSERT [dbo].[Publisher] ([PublisherId], [PublisherName]) VALUES (3, N'NXB Giáo dục Việt Nam')
GO
INSERT [dbo].[Publisher] ([PublisherId], [PublisherName]) VALUES (4, N'NXB Lao động')
GO
INSERT [dbo].[Publisher] ([PublisherId], [PublisherName]) VALUES (5, N'NXB Phụ nữ Việt Nam')
GO
INSERT [dbo].[Publisher] ([PublisherId], [PublisherName]) VALUES (6, N'NXB Tổng hợp TP. Hồ Chí Minh')
GO
INSERT [dbo].[Publisher] ([PublisherId], [PublisherName]) VALUES (7, N'NXB Lao động')
GO
INSERT [dbo].[Publisher] ([PublisherId], [PublisherName]) VALUES (8, N'NXB Thanh niên')
GO
INSERT [dbo].[Publisher] ([PublisherId], [PublisherName]) VALUES (9, N'NXB Nhã Nam')
GO
INSERT [dbo].[Publisher] ([PublisherId], [PublisherName]) VALUES (10, N'NXB Đông A')
GO
INSERT [dbo].[Publisher] ([PublisherId], [PublisherName]) VALUES (11, N'NXB Đại học quốc gia')
GO
INSERT [dbo].[Publisher] ([PublisherId], [PublisherName]) VALUES (12, N'Khác')
GO
SET IDENTITY_INSERT [dbo].[Publisher] OFF
GO
SET IDENTITY_INSERT [dbo].[UserDetails] ON 
GO
INSERT [dbo].[UserDetails] ([Id], [UserId], [FullName], [PhoneNumber], [Address]) VALUES (1, N'68302394-9332-4d0f-a1ad-7a6a4317aca6', N'Duong', N'0348102000', N'dddd')
GO
SET IDENTITY_INSERT [dbo].[UserDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([userID], [userName], [email], [account], [password], [typeUser]) VALUES (1, N'admin', N'phiduong.it.hcm@gmail.com', N'admin', N'admin', 1)
GO
INSERT [dbo].[Users] ([userID], [userName], [email], [account], [password], [typeUser]) VALUES (2, N'admin1', N'nguyentrannhuy1104@gmail.com', N'admin1', N'admin1', 1)
GO
INSERT [dbo].[Users] ([userID], [userName], [email], [account], [password], [typeUser]) VALUES (3, N'admintest', N'fgh@gmail.com', N'admintest', N'1234', 1)
GO
INSERT [dbo].[Users] ([userID], [userName], [email], [account], [password], [typeUser]) VALUES (4, N'TranDuong', N'6351071014@st.utc2.edu.vn', N'testadmi', N'testadmi', 1)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Books] ADD  DEFAULT ((0)) FOR [CategoryId]
GO
ALTER TABLE [dbo].[Books] ADD  DEFAULT ((0)) FOR [PublisherId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Publisher_PublisherId] FOREIGN KEY([PublisherId])
REFERENCES [dbo].[Publisher] ([PublisherId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Publisher_PublisherId]
GO
ALTER TABLE [dbo].[OrdersDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrdersDetails_Books] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([BookId])
GO
ALTER TABLE [dbo].[OrdersDetails] CHECK CONSTRAINT [FK_OrdersDetails_Books]
GO
ALTER TABLE [dbo].[OrdersDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrdersDetails_Books_BookId] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([BookId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrdersDetails] CHECK CONSTRAINT [FK_OrdersDetails_Books_BookId]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK_Ratings_Books_BookId] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([BookId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK_Ratings_Books_BookId]
GO
ALTER TABLE [dbo].[UserDetails]  WITH CHECK ADD  CONSTRAINT [FK_UserDetails_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[UserDetails] CHECK CONSTRAINT [FK_UserDetails_AspNetUsers_UserId]
GO
