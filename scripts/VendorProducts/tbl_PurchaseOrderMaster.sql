USE [Pharmacy]
GO

/****** Object:  Table [dbo].[tbl_PurchaseOrderMaster]    Script Date: 11/15/2021 2:05:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tbl_PurchaseOrderMaster](
	[vendorId] [varchar](50) NULL,
	[purchaseOrderMasterId] [bigint] NOT NULL,
	[orderDate] [date] NULL,
	[receivingDate] [date] NULL,
	[amount] [decimal](18, 2) NULL,
	[createdBy] [varchar](50) NULL,
	[creationDate] [date] NULL,
 CONSTRAINT [PK_tbl_PurchaseOrderMaster] PRIMARY KEY CLUSTERED 
(
	[purchaseOrderMasterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


