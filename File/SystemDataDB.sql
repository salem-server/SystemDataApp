USE [master]
GO
/****** Object:  Database [SystemDataDB]    Script Date: 02/07/2024 4:29:51 AM ******/
CREATE DATABASE [SystemDataDB]
GO

USE [SystemDataDB]
GO
/****** Object:  Table [dbo].[Branch]    Script Date: 02/07/2024 4:29:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branch](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[NameAr] [nvarchar](50) NULL,
	[NameEn] [nvarchar](50) NULL,
 CONSTRAINT [PK_Branch] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 02/07/2024 4:29:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomerSupplier]    Script Date: 02/07/2024 4:29:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerSupplier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[IsType] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Address] [nvarchar](max) NULL,
	[Tel1] [nvarchar](50) NULL,
	[Tel2] [nvarchar](50) NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
	[AccountCode] [int] NULL,
 CONSTRAINT [PK_CustomerSupplier] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 02/07/2024 4:29:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[InvoiceNum] [int] NULL,
	[OrderDate] [date] NULL,
	[OrderDateAdd] [date] NULL,
	[UserCode] [int] NULL,
	[CustomerSupplierCode] [int] NULL,
	[InvoiceType] [int] NULL,
	[Total] [float] NULL,
	[Pay] [float] NULL,
	[Stay] [float] NULL,
	[Discount] [float] NULL,
	[DiscountValue] [float] NULL,
	[TotalAfterDiscount] [float] NULL,
	[Tax] [float] NULL,
	[TaxValue] [float] NULL,
	[TotalAfterTax] [float] NULL,
	[BranchCode] [int] NULL,
	[CashPay] [float] NULL,
	[VisaPay] [float] NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InvoiceDetails]    Script Date: 02/07/2024 4:29:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Num] [int] NULL,
	[InvoiceCode] [int] NULL,
	[ProductCode] [int] NULL,
	[Price] [float] NULL,
	[Qty] [float] NULL,
	[Amount] [float] NULL,
	[Discount] [float] NULL,
	[DiscountValue] [float] NULL,
	[AmountAfterDiscount] [float] NULL,
	[Tax] [float] NULL,
	[TaxValue] [float] NULL,
	[AmountAfterTax] [float] NULL,
	[UnitProductCode] [int] NULL,
	[Fator] [float] NULL,
	[StoreCode] [int] NULL,
 CONSTRAINT [PK_InvoiceDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 02/07/2024 4:29:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Qty] [float] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
	[IsType] [int] NULL,
	[CategoryCode] [int] NULL,
	[Img] [image] NULL,
	[BranchCode] [int] NULL,
	[StoreCode] [int] NULL,
	[Discount] [float] NULL,
	[Tax] [float] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Store]    Script Date: 02/07/2024 4:29:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[BranchCode] [int] NULL,
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UnitName]    Script Date: 02/07/2024 4:29:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnitName](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_UnitName] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UnitProduct]    Script Date: 02/07/2024 4:29:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnitProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Barcode] [nvarchar](50) NULL,
	[Factor] [float] NULL,
	[PriceBuy] [float] NULL,
	[PriceSale] [float] NULL,
	[ProductCode] [int] NULL,
	[UnitNameCode] [int] NULL,
 CONSTRAINT [PK_UnitProduct] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 02/07/2024 4:29:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[FullName] [nvarchar](50) NULL,
	[Tel] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[IsAdmin] [bit] NULL,
	[BranchCode] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Branch] ON 

INSERT [dbo].[Branch] ([Id], [Code], [NameAr], [NameEn]) VALUES (3, 1, N'فرع رئيسي', N'Branch Main')
INSERT [dbo].[Branch] ([Id], [Code], [NameAr], [NameEn]) VALUES (4, 2, N'فرع 2', N'Branch 2')
INSERT [dbo].[Branch] ([Id], [Code], [NameAr], [NameEn]) VALUES (5, 3, N'الفرع 3', N'br 3')
INSERT [dbo].[Branch] ([Id], [Code], [NameAr], [NameEn]) VALUES (9, 4, N'عع', N'en')
SET IDENTITY_INSERT [dbo].[Branch] OFF
SET IDENTITY_INSERT [dbo].[Store] ON 

INSERT [dbo].[Store] ([Id], [Code], [Name], [BranchCode]) VALUES (1, 1, N'المخزن الرئيسي', 1)
INSERT [dbo].[Store] ([Id], [Code], [Name], [BranchCode]) VALUES (2, 2, N'مخزن القاهرة', 1)
INSERT [dbo].[Store] ([Id], [Code], [Name], [BranchCode]) VALUES (3, 3, N'مخزن كازبلانكا 2 ', 3)
INSERT [dbo].[Store] ([Id], [Code], [Name], [BranchCode]) VALUES (4, 4, N'مخزن غزة ♥', 2)
INSERT [dbo].[Store] ([Id], [Code], [Name], [BranchCode]) VALUES (5, 5, N'مخزن طرابلس', 2)
INSERT [dbo].[Store] ([Id], [Code], [Name], [BranchCode]) VALUES (6, 6, N'سي س121', 2)
SET IDENTITY_INSERT [dbo].[Store] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Code], [UserName], [Password], [FullName], [Tel], [Email], [Address], [IsAdmin], [BranchCode]) VALUES (1, 1, N'admin', N'admin', N'سالم نت', N'0101010', NULL, NULL, 1, 1)
INSERT [dbo].[Users] ([Id], [Code], [UserName], [Password], [FullName], [Tel], [Email], [Address], [IsAdmin], [BranchCode]) VALUES (2, 2, N'user', N'123', N'علي حسين', N'0123456', NULL, NULL, 0, 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Branch] FOREIGN KEY([BranchCode])
REFERENCES [dbo].[Branch] ([Code])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Branch]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_CustomerSupplier] FOREIGN KEY([CustomerSupplierCode])
REFERENCES [dbo].[CustomerSupplier] ([Code])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_CustomerSupplier]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Users] FOREIGN KEY([UserCode])
REFERENCES [dbo].[Users] ([Code])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Users]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_Invoice] FOREIGN KEY([InvoiceCode])
REFERENCES [dbo].[Invoice] ([Code])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_Invoice]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_Store] FOREIGN KEY([StoreCode])
REFERENCES [dbo].[Store] ([Code])
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_Store]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_UnitProduct] FOREIGN KEY([UnitProductCode])
REFERENCES [dbo].[UnitProduct] ([Code])
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_UnitProduct]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Branch] FOREIGN KEY([BranchCode])
REFERENCES [dbo].[Branch] ([Code])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Branch]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryCode])
REFERENCES [dbo].[Category] ([Code])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Store] FOREIGN KEY([StoreCode])
REFERENCES [dbo].[Store] ([Code])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Store]
GO
ALTER TABLE [dbo].[UnitProduct]  WITH CHECK ADD  CONSTRAINT [FK_UnitProduct_Product] FOREIGN KEY([ProductCode])
REFERENCES [dbo].[Product] ([Code])
GO
ALTER TABLE [dbo].[UnitProduct] CHECK CONSTRAINT [FK_UnitProduct_Product]
GO
ALTER TABLE [dbo].[UnitProduct]  WITH CHECK ADD  CONSTRAINT [FK_UnitProduct_UnitName] FOREIGN KEY([UnitNameCode])
REFERENCES [dbo].[UnitName] ([Code])
GO
ALTER TABLE [dbo].[UnitProduct] CHECK CONSTRAINT [FK_UnitProduct_UnitName]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Branch] FOREIGN KEY([BranchCode])
REFERENCES [dbo].[Branch] ([Code])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Branch]
GO
USE [master]
GO
ALTER DATABASE [SystemDataDB] SET  READ_WRITE 
GO
