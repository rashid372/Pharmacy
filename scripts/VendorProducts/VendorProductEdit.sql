USE [Pharmacy]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[VendorProductEdit]
       @productId varchar(50)
	   ,@vendorId varchar(50)
	   ,@purchaseRate decimal(18,2)
   AS 
   UPDATE tbl_VendorProducts 
   SET purchaseRate=@purchaseRate
  WHERE productId=@productId and vendorId=@vendorId


GO


