USE [Pharmacy]
GO

/****** Object:  StoredProcedure [dbo].[AccountLedgerAdd]    Script Date: 11/17/2021 6:36:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[VendorProductAdd]
       @productId varchar(50)
	   ,@vendorId varchar(50)
	   ,@purchaseRate decimal(18,2)
	   ,@createdBy varchar(50)
     AS 
	 DECLARE @recordCount INT= (select count(*) from tbl_VendorProducts where productId=@productId and vendorId=@vendorId)
IF @recordCount > 0
   BEGIN
      UPDATE tbl_VendorProducts 
   SET purchaseRate=@purchaseRate
  WHERE productId=@productId and vendorId=@vendorId
   Select @productId
   END
    ELSE
BEGIN
     INSERT INTO tbl_VendorProducts( 
       productId
      ,vendorId
	  ,purchaseRate
	  ,createdBy
	  ,creationDate )
    VALUES(@productId
      ,@vendorId
      ,@purchaseRate
      ,@createdBy
	  ,GETDATE() )
      Select @productId
	  END


GO


