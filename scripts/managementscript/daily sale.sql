select CS.counterSaleMasterId,P.productName,B.purchaseRate,CS.rate as salesRate,(CS.rate - B.purchaseRate) profit,((CS.rate - B.purchaseRate) *qty) as TotalSale
 from tbl_CounterSaleDetails CS,tbl_ProductBatch B,tbl_Product P,tbl_CounterSaleMaster CM
where CS.productbatchId=b.productBatchId and b.productId=p.productId and CS.counterSaleMasterId=CM.counterSaleMasterId and (CS.rate - B.purchaseRate) < 0 
and CM.date >= '11-15-2021' and  CM.date <= '11-23-2021'
order by CONVERT(int,CS.counterSaleMasterId) desc

select sum(TotalSale) from
(select CS.counterSaleMasterId,P.productName,B.purchaseRate,CS.rate as salesRate,(CS.rate - B.purchaseRate) profit,((CS.rate - B.purchaseRate) *qty) as TotalSale
 from tbl_CounterSaleDetails CS,tbl_ProductBatch B,tbl_Product P,tbl_CounterSaleMaster CM
where CS.productbatchId=b.productBatchId and b.productId=p.productId and CS.counterSaleMasterId=CM.counterSaleMasterId and (CS.rate - B.purchaseRate) > 0 
and CM.date >= '11-01-2021' and  CM.date <= '11-23-2021') tbl

select CS.salesMasterId,P.productName,B.purchaseRate,CS.rate as salesRate,(CS.rate - B.purchaseRate) profit,((CS.rate - B.purchaseRate) *qty) as TotalSale
 from tbl_SalesDetails CS,tbl_ProductBatch B,tbl_Product P,tbl_CounterSaleMaster CM
where CS.productbatchId=b.productBatchId and b.productId=p.productId and CS.salesMasterId=CM.counterSaleMasterId and (CS.rate - B.purchaseRate) > 0 
and CM.date >= '11-01-2021' and  CM.date <= '11-23-2021'
order by CONVERT(int,CS.salesMasterId) desc

select sum(TotalSale) from
(select CS.salesMasterId,P.productName,B.purchaseRate,CS.rate as salesRate,(CS.rate - B.purchaseRate) profit,((CS.rate - B.purchaseRate) *qty) as TotalSale
 from tbl_SalesDetails CS,tbl_ProductBatch B,tbl_Product P,tbl_CounterSaleMaster CM
where CS.productbatchId=b.productBatchId and b.productId=p.productId and CS.salesMasterId=CM.counterSaleMasterId and (CS.rate - B.purchaseRate) > 0 
and CM.date >= '11-01-2021' and  CM.date <= '11-23-2021') tbl


select * from tbl_SalesDetails


select * from tbl_CounterSaleDetails

select * from tbl_CounterSaleMaster order by date desc