USE [Pharmacy]
GO

/****** Object:  StoredProcedure [dbo].[PurchaseOrderMasterAdd]    Script Date: 11/21/2021 6:22:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[PurchaseOrderMasterAdd]
	   @vendorId varchar(50)
	   ,@receivingDate date
	   ,@puchaseOrderTitle varchar(max)
	   ,@createdBy varchar(50)
     AS 
	 	    DECLARE @purchaseOrderMasterId bigint
 SET @purchaseOrderMasterId=(SELECT ISNULL(MAX( purchaseOrderMasterId+1),1) FROM tbl_PurchaseOrderMaster)


     INSERT INTO tbl_PurchaseOrderMaster( 
      vendorId
	,purchaseOrderMasterId
	,orderDate
	,receivingDate
	,puchaseOrderTitle
	,status
	  ,createdBy
	  ,creationDate )
    VALUES(
      @vendorId
	  ,@purchaseOrderMasterId
	  ,GETDATE()
	  ,@receivingDate
	  ,@puchaseOrderTitle
	  ,'Active'
      ,@createdBy
	  ,GETDATE() )
      Select @purchaseOrderMasterId





GO


