USE [Pharmacy]
GO

/****** Object:  Table [dbo].[tbl_PurchaseOrderDetails]    Script Date: 11/21/2021 6:19:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tbl_PurchaseOrderDetails](
	[purchaseOrderMasterId] [bigint] NOT NULL,
	[purchaseOrderDetailsId] [bigint] NOT NULL,
	[productId] [varchar](50) NOT NULL,
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

SET ANSI_PADDING OFF
GO


