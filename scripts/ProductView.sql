USE [Pharmacy]
GO
/****** Object:  StoredProcedure [dbo].[ProductView]    Script Date: 11/15/2021 11:47:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
		used by :sumana
		Created By :Sumana
*/
ALTER  PROCEDURE [dbo].[ProductView]
	
	@productId VARCHAR(50)
AS 

SELECT     
	productId AS [ID], 
	productName AS [Name], 
	productGroupId AS [Group ID], 
	manufactureId AS [Manufacture ID], 
	shelfId AS [Shelf ID], 
	genericNameId AS [Generic ID], 
	stockMinimumLevel AS [Stock Minimum Level], 
	stockMaximumLevel AS [Stock Maximum Level], 
	medicineFor AS [Medicine For],
	description AS [Description], 
	unitId AS [Unit ID],
	purchaseRate as [Purchase Rate],
	salesRate as [Sales Rate], 
	packing as Packing
	
    
FROM         tbl_Product
WHERE productId = @productId

