USE [Pharmacy]
GO
/****** Object:  StoredProcedure [dbo].[VendorProductViewAllByVendorId]    Script Date: 11/19/2021 2:55:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[VendorProductViewAllByProductName]
	   @vendorId varchar(50),
	    @productName varchar(500)
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
WHERE VP.vendorId=@vendorId and P.productName like '%'+@productName+'%'
ORDER BY P.productName


