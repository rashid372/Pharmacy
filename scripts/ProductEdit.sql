USE [Pharmacy]
GO
/****** Object:  StoredProcedure [dbo].[ProductEdit]    Script Date: 11/15/2021 11:44:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
		Created By :Sumana
*/
ALTER  PROCEDURE [dbo].[ProductEdit]
	
	@productId VARCHAR(50), 
	@productName VARCHAR(MAX), 
	@productGroupId VARCHAR(50), 
	@manufactureId VARCHAR(50), 
	@shelfId VARCHAR(50), 
	@genericNameId VARCHAR(50), 
	@stockMinimumLevel DECIMAL(18,4), 
	@stockMaximumLevel DECIMAL(18,4), 
	@medicineFor VARCHAR(MAX), 
	@description VARCHAR(MAX), 
    @unitId VARCHAR(50),
	@purchaseRate DECIMAL(18,4),
	@salesRate DECIMAL(18,4), 
	@packing DECIMAL(18,4)
AS 

UPDATE    tbl_Product
SET    
	productName = @productName, 
	productGroupId = @productGroupId, 
	manufactureId = @manufactureId, 
	shelfId = @shelfId, 
    genericNameId = @genericNameId, 
    stockMinimumLevel = @stockMinimumLevel, 
    stockMaximumLevel = @stockMaximumLevel, 
    medicineFor = @medicineFor, 
    description = @description, 
    unitId = @unitId,
	purchaseRate = @purchaseRate,
	salesRate = @salesRate, 
	packing=@packing
WHERE productId = @productId

