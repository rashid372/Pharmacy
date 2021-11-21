USE [Pharmacy]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[PurchaseOrderMasterViewByVendorIdAndDate]
       @vendorId varchar(50),
	   @date date
     AS
     Select * FROM tbl_PurchaseOrderMaster
     WHERE vendorId=@vendorId and orderDate=@date
GO


