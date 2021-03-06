USE [Pharmacy]
GO
/****** Object:  StoredProcedure [dbo].[ProductAdd]    Script Date: 11/15/2021 11:40:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
		Created By :Sumana
*/
ALTER  PROCEDURE [dbo].[ProductAdd]
	
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

INSERT INTO tbl_Product
(
	productId, 
	productName, 
	productGroupId, 
	manufactureId, 
	shelfId, 
	genericNameId, 
	stockMinimumLevel, 
	stockMaximumLevel, 
	medicineFor, 
	description, 
    unitId,
	purchaseRate,
	salesRate, 
	packing 
)
VALUES     
(
	@productId, 
	@productName, 
	@productGroupId, 
	@manufactureId, 
	@shelfId, 
	@genericNameId, 
	@stockMinimumLevel, 
	@stockMaximumLevel, 
	@medicineFor, 
	@description, 
    @unitId,
	@purchaseRate,
	@salesRate, 
	@packing 
)
SELECT @productId

