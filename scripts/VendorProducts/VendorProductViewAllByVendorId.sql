USE [Pharmacy]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

alter PROCEDURE [dbo].[VendorProductViewAllByVendorId]
	   @vendorId varchar(50)
AS
SELECT     
	P.productId
	,P.productName
	,ISNULL(VP.purchaseRate,0) as [vendorPurchaseRate]
	,ISNULL(P.purchaseRate,0) as [productPurchaseRate]
	,V.vendorName
	,V.vendorId
FROM tbl_Product P INNER JOIN tbl_VendorProducts VP
on P.productId=VP.productId
INNER JOIN tbl_Vendor V
on VP.vendorId=V.vendorId
WHERE VP.vendorId=@vendorId
ORDER BY P.productName


GO


