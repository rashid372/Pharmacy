USE [Pharmacy]
GO

/****** Object:  StoredProcedure [dbo].[PurchaseOrderMasterDelete]    Script Date: 11/21/2021 6:22:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[PurchaseOrderMasterDelete]
       @purchaseOrderMasterId bigint
     AS
     DELETE FROM tbl_PurchaseOrderMaster
     WHERE purchaseOrderMasterId=@purchaseOrderMasterId



GO


