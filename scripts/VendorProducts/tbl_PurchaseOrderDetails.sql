USE [Pharmacy]
GO

/****** Object:  Table [dbo].[tbl_PurchaseOrderDetails]    Script Date: 11/15/2021 2:05:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_PurchaseOrderDetails](
	[purchaseOrderMasterId] [bigint] NOT NULL,
	[purchaseOrderDetailsId] [bigint] NOT NULL,
	[rate] [decimal](18, 2) NULL,
	[discount] [float] NULL,
	[qty] [decimal](18, 2) NULL,
	[freeQty] [decimal](18, 2) NULL,
 CONSTRAINT [PK_tbl_PurchaseOrderDetails] PRIMARY KEY CLUSTERED 
(
	[purchaseOrderMasterId] ASC,
	[purchaseOrderDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


