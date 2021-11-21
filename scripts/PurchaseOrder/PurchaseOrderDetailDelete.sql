USE [Pharmacy]
GO

/****** Object:  StoredProcedure [dbo].[PurchaseOrderDetailDelete]    Script Date: 11/21/2021 6:21:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PurchaseOrderDetailDelete]
@purchaseOrderDetailsId bigint

AS
DELETE FROM tbl_PurchaseOrderDetails	
where
		purchaseOrderDetailsId=@purchaseOrderDetailsId



GO


