USE [Pharmacy]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[VendorProductDelete]
       @productId varchar(50)
	   ,@vendorId varchar(50)
AS
DELETE FROM tbl_VendorProducts
  WHERE productId=@productId and vendorId=@vendorId

GO


