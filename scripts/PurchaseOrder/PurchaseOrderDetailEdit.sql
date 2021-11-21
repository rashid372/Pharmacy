USE [Pharmacy]
GO

/****** Object:  StoredProcedure [dbo].[PurchaseOrderDetailEdit]    Script Date: 11/21/2021 6:21:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create procedure [dbo].[PurchaseOrderDetailEdit]
		@purchaseOrderMasterId bigint
		,@purchaseOrderDetailsId bigint
	   ,@rate decimal(18,2)
	   ,@discount float
	   ,@qty decimal(18,2)
	   ,@freeQty decimal(18,2)
     AS 
	update tbl_PurchaseOrderDetails set rate=@rate , discount=@discount ,qty=@qty,freeQty=@freeQty
	from tbl_PurchaseOrderDetails
	where purchaseOrderMasterId=@purchaseOrderMasterId and  purchaseOrderDetailsId=@purchaseOrderDetailsId



GO


