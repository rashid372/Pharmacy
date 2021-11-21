USE [Pharmacy]
GO

/****** Object:  StoredProcedure [dbo].[PurchaseOrderDetailsViewAllByVendorId]    Script Date: 11/21/2021 6:21:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--PurchaseOrderDetailsViewAllByVendorId 13
CREATE PROCEDURE [dbo].[PurchaseOrderDetailsViewAllByVendorId]
	@vendorId varchar(50)
AS
SELECT     
     PM.vendorId
	 ,PD.productId
	 ,PM.purchaseOrderMasterId
	 ,PM.orderDate
	 ,PM.receivingDate
	 ,PD.rate
	 ,PD.qty
	 ,PD.purchaseOrderDetailsId
	 ,PD.freeQty
	 ,PD.discount
	 ,P.productName
	 ,PM.puchaseOrderTitle
FROM  tbl_PurchaseOrderMaster PM inner join  tbl_PurchaseOrderDetails PD
on PD.purchaseOrderMasterId=PM.purchaseOrderMasterId
INNER JOIN tbl_Product P
on PD.productId=P.productId
where PM.status='Active' and PM.vendorId=@vendorId 
--and PM.orderDate=GETDATE()



GO


