USE [Pharmacy]
GO

/****** Object:  StoredProcedure [dbo].[PurchaseOrderMasterEdit]    Script Date: 11/21/2021 6:22:58 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create procedure [dbo].[PurchaseOrderMasterEdit]
		@purchaseOrderMasterId bigint
	   ,@receivingDate date
	   ,@puchaseOrderTitle varchar(max)
	   ,@status varchar(50)
     AS 

	 UPDATE tbl_PurchaseOrderMaster set receivingDate=@receivingDate ,puchaseOrderTitle=@puchaseOrderTitle,status=@status
	 FROM  tbl_PurchaseOrderMaster WHERE  purchaseOrderMasterId=@purchaseOrderMasterId






GO


