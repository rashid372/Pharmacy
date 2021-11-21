USE [Pharmacy]
GO

/****** Object:  StoredProcedure [dbo].[PurchaseOrderDetailAdd]    Script Date: 11/21/2021 6:21:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[PurchaseOrderDetailAdd]
		@purchaseOrderMasterId bigint
	   ,@productId varchar(50)
	   ,@rate decimal(18,2)
	   ,@discount float
	   ,@qty decimal(18,2)
	   ,@freeQty decimal(18,2)
     AS 
	DECLARE @purchaseOrderDetailsId bigint,@itemCount int
 SET @itemCount=(SELECT count(*) FROM tbl_PurchaseOrderDetails where productId=@productId and purchaseOrderMasterId=@purchaseOrderMasterId)
 SET @purchaseOrderDetailsId=(SELECT ISNULL(MAX( purchaseOrderDetailsId+1),1) FROM tbl_PurchaseOrderDetails)

 if(@itemCount < 1)
 begin
     INSERT INTO tbl_PurchaseOrderDetails( 
		purchaseOrderMasterId,
		purchaseOrderDetailsId,
		productId,
		rate,
		discount,
		qty,
		freeQty
	  )
    VALUES(
	  @purchaseOrderMasterId
	  ,@purchaseOrderDetailsId
	  ,@productId
	  ,@rate
	  ,@discount
	  ,@qty
	  ,@freeQty
 )
      Select @purchaseOrderDetailsId
	  end





GO


