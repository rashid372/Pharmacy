USE [Pharmacy]
GO
/****** Object:  StoredProcedure [dbo].[ProductViewAllDetails]    Script Date: 11/15/2021 11:52:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ProductViewAllDetails]
		/*
<Author      :Ajith.kr>
<Date        :>
<Description :To view all values >
*/
	@productId varchar(50)
AS
	SELECT     tbl_Product.productId, tbl_Product.productName, tbl_Product.productGroupId, tbl_ProductGroup.productGroupName, tbl_Product.manufactureId, 
	                      tbl_Manufacturer.manufactureName, tbl_Product.shelfId, tbl_Shelf.shelfName, tbl_Product.genericNameId, tbl_GenericName.genericName, 
	                      tbl_Product.stockMinimumLevel, tbl_Product.stockMaximumLevel, tbl_Product.medicineFor, tbl_Product.description, tbl_Product.unitId, 
	                      tbl_Unit.unitName,
						   tbl_Product.purchaseRate,
						    tbl_Product.salesRate,
							 tbl_Product.packing
	FROM         tbl_Product INNER JOIN
	                      tbl_ProductGroup ON tbl_Product.productGroupId = tbl_ProductGroup.productGroupId LEFT OUTER JOIN
	                      tbl_GenericName ON tbl_Product.genericNameId = tbl_GenericName.genericNameId LEFT OUTER JOIN
	                      tbl_Shelf ON tbl_Product.shelfId = tbl_Shelf.shelfId LEFT OUTER JOIN
	                      tbl_Manufacturer ON tbl_Product.manufactureId = tbl_Manufacturer.manufactureId LEFT OUTER JOIN
	                      tbl_Unit ON tbl_Product.unitId = tbl_Unit.unitId
	WHERE     (tbl_Product.productId = @productId)

