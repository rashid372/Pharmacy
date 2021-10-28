USE [Pharmacy]
GO

/****** Object:  StoredProcedure [dbo].[DailyIncomeExpense]    Script Date: 02/22/2016 18:03:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--Counter Sale
--select * from tbl_LedgerPosting where date='2016-02-19' and voucherType='Sales Incvoice'
CREATE Procedure [dbo].[DailyIncomeExpense]
--DailyIncomeExpense '2016-02-10'
@date datetime
As
--CounterSales
Select SUM(debit) as CounterSale,
--InvoiceSales
(Select SUM(debit) from tbl_LedgerPosting lp
inner join tbl_AccountLedger al ON lp.ledgerId=al.ledgerId
inner join tbl_SalesMaster sm ON lp.voucherNumber=sm.salesMasterId
and lp.ledgerId=sm.ledgerId
where lp.date=@date and lp.voucherType='Sales Invoice') AS SaleInvoice,

--TotalSales
((Select Coalesce(SUM(debit),0) from tbl_LedgerPosting lp
inner join tbl_AccountLedger al ON lp.ledgerId=al.ledgerId
inner join tbl_SalesMaster sm ON lp.voucherNumber=sm.salesMasterId
and lp.ledgerId=sm.ledgerId
where lp.date=@date and lp.voucherType='Sales Invoice')+(Select Coalesce(SUM(debit),0) as CounterSale
 from tbl_LedgerPosting lp
inner join tbl_AccountLedger al on lp.ledgerId=al.ledgerId
inner join tbl_CounterSaleMaster csm ON lp.voucherNumber=csm.counterSaleMasterId
 where voucherType='Counter Sale'
and lp.date=@date)) As TotalSale,
--(Select SUM(debit) from tbl_LedgerPosting lp
--inner join tbl_AccountLedger al ON lp.ledgerId=al.ledgerId
--inner join tbl_SalesMaster sm ON lp.voucherNumber=sm.salesMasterId
--and lp.ledgerId=sm.ledgerId
--where lp.date=@date and lp.voucherType='Sales Invoice' OR lp.voucherType='Counter Sale') AS TotalSales,

(Select SUM(credit) from tbl_LedgerPosting lp
inner join tbl_AccountLedger al on lp.ledgerId=al.ledgerId
inner join tbl_PurchaseMaster pm ON lp.voucherNumber=pm.purchaseMasterId
where voucherType='Purchase Invoice' 
and lp.date=@date) As PurchasesInvoice,


((Select SUM(debit) from tbl_LedgerPosting lp
inner join tbl_AccountLedger al on lp.ledgerId=al.ledgerId
inner join tbl_CounterSaleMaster csm ON lp.voucherNumber=csm.counterSaleMasterId
--inner join tbl_PurchaseMaster pm on pm.ledgerId=lp.ledgerId 7090
 where voucherType='Counter Sale'
and lp.date=@date)-(Select SUM(credit) from tbl_LedgerPosting lp
inner join tbl_AccountLedger al on lp.ledgerId=al.ledgerId
inner join tbl_PurchaseMaster pm ON lp.voucherNumber=pm.purchaseMasterId
where voucherType='Purchase Invoice' 
and lp.date=@date)) As CashInHand,

lp.Date
 from tbl_LedgerPosting lp
inner join tbl_AccountLedger al on lp.ledgerId=al.ledgerId
inner join tbl_CounterSaleMaster csm ON lp.voucherNumber=csm.counterSaleMasterId
--inner join tbl_PurchaseMaster pm on pm.ledgerId=lp.ledgerId 7090
 where voucherType='Counter Sale'
and lp.date=@date
Group by lp.date
GO


---------------------------------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SalesMasterInvoiceMax]

	
	AS
	
 SELECT ISNULL(MAX(convert( bigint,salesInvoiceNo) +1),1) as [Sales Invoice No]  FROM tbl_SalesMaster
 where isnumeric(salesInvoiceNo)!=0



GO