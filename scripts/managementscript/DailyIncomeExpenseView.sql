USE [Pharmacy]
GO
/****** Object:  StoredProcedure [dbo].[DailyIncomeExpenseView]    Script Date: 11/23/2021 6:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[DailyIncomeExpenseView]
--DailyIncomeExpenseView '2021-11-22'
@date datetime
as
Select date,ISNULL(sum(qty*rate),0) as CounterSale,

(Select ISNULL(sum(convert(decimal,sd.description)),0) from tbl_salesDetails sd
inner join tbl_salesMaster sm ON sm.salesMasterId=sd.salesMasterId
where sm.date=@date) As SaleInvoice,

((Select ISNULL(sum(qty*rate),0) from tbl_counterSaleDetails csd
inner join tbl_counterSaleMaster csm ON csd.counterSaleMasterId=csm.counterSaleMasterId
Where csm.date=@date) + (Select ISNULL(sum((qty*rate)-discount),0) as Sale from tbl_salesDetails sd
inner join tbl_salesMaster sm ON sm.salesMasterId=sd.salesMasterId
where sm.date=@date)) as Totalsale,

(Select ISNULL(sum((qty*rate)-discount),0) from tbl_PurchaseDetails pd
inner join tbl_purchaseMaster pm ON pd.purchaseMasterId=pm.purchaseMasterId
where pm.date=@date) as PurchaseInvoice,

((((Select ISNULL(sum(qty*rate),0) from tbl_counterSaleDetails csd
inner join tbl_counterSaleMaster csm ON csd.counterSaleMasterId=csm.counterSaleMasterId
Where csm.date=@date) + (Select ISNULL(sum((qty*rate)-discount),0) from tbl_salesDetails sd
inner join tbl_salesMaster sm ON sm.salesMasterId=sd.salesMasterId
where sm.date=@date))-(Select ISNULL(sum((qty*rate)-discount),0) from tbl_PurchaseDetails pd
inner join tbl_purchaseMaster pm ON pd.purchaseMasterId=pm.purchaseMasterId 
where pm.date=@date))) as CashInHand

from tbl_counterSaleDetails csd
inner join tbl_counterSaleMaster csm ON csd.counterSaleMasterId=csm.counterSaleMasterId
Where csm.date=@date
group by csm.date
