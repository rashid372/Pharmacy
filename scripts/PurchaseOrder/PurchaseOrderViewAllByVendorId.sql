USE [Pharmacy]
GO

/****** Object:  StoredProcedure [dbo].[PurchaseOrderViewAllByVendorId]    Script Date: 11/21/2021 6:23:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[PurchaseOrderViewAllByVendorId]
	   @vendorId varchar(50)
AS

	WITH PurchaseOrderItems  AS
	(
			SELECT DISTINCT    
				P.productId
				,P.productName
				,ISNULL(VP.purchaseRate,0) as [vendorPurchaseRate]
				,ISNULL(P.purchaseRate,0) as [productPurchaseRate]
				,V.vendorId
				,ISNULL(SD.qty,0) as [Stock]
				,ISNULL((select  sum([count]) from	(select PB.productid,sum(qty) as [count] FROM tbl_CounterSaleDetails CSD INNER JOIN tbl_ProductBatch PB on CSD.productbatchId=PB.productBatchId INNER JOIN tbl_Product P on PB.productId=P.productId 
				group by PB.productId
				union
				select PB.productid,sum(qty) as [count] FROM tbl_SalesDetails S INNER JOIN tbl_ProductBatch PB on S.productbatchId=PB.productBatchId 
				group by PB.productId) as tbl where productId=P.productId),0) as RunningIndex
			--	,ISNULL(((select SUM(qty) FROM tbl_CounterSaleDetails CSD INNER JOIN tbl_ProductBatch PB on CSD.productbatchId=PB.productBatchId INNER JOIN tbl_Product P on PB.productId=P.productId where CSD.productbatchId=B.productBatchId) +  (select SUM(qty) FROM tbl_SalesDetails S INNER JOIN tbl_ProductBatch PB on S.productbatchId=PB.productBatchId where S.productbatchId=PB.productBatchId)),0) as [RunningIndex]
				, ROW_NUMBER() OVER(PARTITION BY P.productId ORDER BY P.productId) AS DuplicateCount
			FROM 
			tbl_Product P INNER JOIN tbl_ProductBatch B
			on P.productId=B.productId
			INNER JOIN tbl_StockDetails SD
			on B.productBatchId=SD.productBatchId
			inner JOIN tbl_VendorProducts VP
			on P.productId=VP.productId
			INNER JOIN tbl_Vendor V
			on VP.vendorId=V.vendorId	
			WHERE VP.vendorId=@vendorId
	)
	SELECT productId,productName,vendorPurchaseRate,productPurchaseRate,vendorId,Stock,RunningIndex     
FROM PurchaseOrderItems where DuplicateCount <=1
union
SELECT     
	P.productId
	,P.productName
	,ISNULL(VP.purchaseRate,0) as [vendorPurchaseRate]
	,ISNULL(P.purchaseRate,0) as [productPurchaseRate]
	,V.vendorId
	,0 as [Stock]
	,0 as [RunningIndex]
FROM tbl_Product P INNER JOIN tbl_VendorProducts VP
on P.productId=VP.productId
INNER JOIN tbl_Vendor V
on VP.vendorId=V.vendorId
WHERE VP.vendorId=@vendorId and P.productId not in (select productId from PurchaseOrderItems)
ORDER BY   [RunningIndex] desc,productName asc


GO


