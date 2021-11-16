USE [Pharmacy]
GO

/****** Object:  Table [dbo].[tbl_VendorProducts]    Script Date: 11/15/2021 2:06:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tbl_VendorProducts](
	[productId] [varchar](50) NOT NULL,
	[vendorId] [varchar](50) NOT NULL,
	[purchaseRate] [decimal](18, 2) NULL,
	[createdBy] [varchar](50) NULL,
	[creationDate] [date] NULL,
 CONSTRAINT [PK_tbl_VendorProducts] PRIMARY KEY CLUSTERED 
(
	[productId] ASC,
	[vendorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


