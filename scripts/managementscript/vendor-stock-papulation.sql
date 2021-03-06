
 select Distinct convert(int,ledgerId) from [Pharmacy].[dbo].[tbl_PurchaseMaster] order by convert(int,ledgerId)
 
 select * FROM [Pharmacy].[dbo].[tbl_Vendor] order by vendorName

 select * FROM [Pharmacy].[dbo].[tbl_AccountLedger] where ledgerId in (select Distinct convert(int,ledgerId) from [Pharmacy].[dbo].[tbl_PurchaseMaster] ) order by acccountLedgerName

 select * from [Pharmacy].[dbo].[tbl_VendorProducts]
    select * FROM [Pharmacy].[dbo].[tbl_AccountLedger] where acccountLedgerName like '%fai%'

  select * FROM  [Pharmacy].[dbo].[tbl_Vendor]  V,[Pharmacy].[dbo].[tbl_VendorProducts] VP,[Pharmacy].[dbo].[tbl_PurchaseMaster] PM,[Pharmacy].[dbo].[tbl_PurchaseDetails] PD,tbl_ProductBatch B
  where V.vendorId=VP.vendorId and v.ledgerId=PM.ledgerId and PD.purchaseMasterId=PM.purchaseMasterId
  and PD.productBatchId=B.productBatchId 
  and B.productId=vp.productId


  select * from [Pharmacy].[dbo].[tbl_VendorProducts]

  select * into tbl_VendorProducts_bkp11282021 from [Pharmacy].[dbo].[tbl_VendorProducts]
  --truncate table  [Pharmacy].[dbo].[tbl_VendorProducts]

  --insert into [Pharmacy].[dbo].[tbl_VendorProducts]
  --  select distinct b.productId,v.vendorId,0.0,1,GETDATE() FROM  [Pharmacy].[dbo].[tbl_Vendor]  V,[Pharmacy].[dbo].[tbl_PurchaseMaster] PM,[Pharmacy].[dbo].[tbl_PurchaseDetails] PD,tbl_ProductBatch B
  --where  v.ledgerId=PM.ledgerId and PD.purchaseMasterId=PM.purchaseMasterId
  --and PD.productBatchId=B.productBatchId 
  --group by  v.vendorId,b.productId

  --update [Pharmacy].[dbo].[tbl_VendorProducts] set purchaseRate=B.purchaseRate  from [Pharmacy].[dbo].[tbl_VendorProducts] VP ,tbl_ProductBatch B
  --where VP.productid=b.productid 





     

    select PP.* FROM [Pharmacy].[dbo].[tbl_PurchaseDetails] P , tbl_ProductBatch B,tbl_Product PP,[Pharmacy].[dbo].[tbl_PurchaseMaster] PM
	where P.productBatchId=B.productBatchId and B.productId=PP.productId and PM.purchaseMasterId=P.purchaseMasterId
	and PM.ledgerId=284

	--update [Pharmacy].[dbo].[tbl_Vendor] set ledgerId=255   FROM [Pharmacy].[dbo].[tbl_Vendor] where vendorId=3
	--update [Pharmacy].[dbo].[tbl_Vendor] set ledgerId=257   FROM [Pharmacy].[dbo].[tbl_Vendor] where vendorId=4

	--update [Pharmacy].[dbo].[tbl_Vendor] set ledgerId=247   FROM [Pharmacy].[dbo].[tbl_Vendor] where vendorId=11
	--update [Pharmacy].[dbo].[tbl_Vendor] set ledgerId=248   FROM [Pharmacy].[dbo].[tbl_Vendor] where vendorId=26
	--update [Pharmacy].[dbo].[tbl_Vendor] set ledgerId=249   FROM [Pharmacy].[dbo].[tbl_Vendor] where vendorId=27

	--update [Pharmacy].[dbo].[tbl_Vendor] set ledgerId=187,vendorName='INAM ENTERPRISES'   FROM [Pharmacy].[dbo].[tbl_Vendor] where vendorId=10
	--update [Pharmacy].[dbo].[tbl_Vendor] set ledgerId=308,vendorName='AHSAN TRADERS RAJANPUR'   FROM [Pharmacy].[dbo].[tbl_Vendor] where vendorId=13
	--update [Pharmacy].[dbo].[tbl_Vendor] set ledgerId=262,vendorName='AL SHIFA ENTERPRISES'   FROM [Pharmacy].[dbo].[tbl_Vendor] where vendorId=14
	--update [Pharmacy].[dbo].[tbl_Vendor] set ledgerId=261,vendorName='ALI GOHAR & COMPANY'   FROM [Pharmacy].[dbo].[tbl_Vendor] where vendorId=15

	--update [Pharmacy].[dbo].[tbl_Vendor] set ledgerId=263,vendorName='BALUCH ENTERPRISES'   FROM [Pharmacy].[dbo].[tbl_Vendor] where vendorId=7
	--update [Pharmacy].[dbo].[tbl_Vendor] set ledgerId=254,vendorName='GLOBAL PHARMA'   FROM [Pharmacy].[dbo].[tbl_Vendor] where vendorId=18
	--update [Pharmacy].[dbo].[tbl_Vendor] set ledgerId=30,vendorName='KAMRAN TRADERS'   FROM [Pharmacy].[dbo].[tbl_Vendor] where vendorId=17
	--update [Pharmacy].[dbo].[tbl_Vendor] set ledgerId=260,vendorName='MULLER & PHIPPS PAKISTAN'   FROM [Pharmacy].[dbo].[tbl_Vendor] where vendorId=9

	--update [Pharmacy].[dbo].[tbl_Vendor] set ledgerId=284,vendorName='ZAIN INTERPRISES (A)'   FROM [Pharmacy].[dbo].[tbl_Vendor] where vendorId=22
	--update [Pharmacy].[dbo].[tbl_Vendor] set ledgerId=193,vendorName='ZAIN INTERPRISES (C)'   FROM [Pharmacy].[dbo].[tbl_Vendor] where vendorId=5
	--update [Pharmacy].[dbo].[tbl_Vendor] set ledgerId=52,vendorName='UDL DISTRIBUTION'   FROM [Pharmacy].[dbo].[tbl_Vendor] where vendorId=19
	--update [Pharmacy].[dbo].[tbl_Vendor] set ledgerId=19,vendorName='RAMZAN & SONS'   FROM [Pharmacy].[dbo].[tbl_Vendor] where vendorId=8
	--update [Pharmacy].[dbo].[tbl_Vendor] set ledgerId=24,vendorName='PHARMA ZONE'   FROM [Pharmacy].[dbo].[tbl_Vendor] where vendorId=6
	--update [Pharmacy].[dbo].[tbl_Vendor] set ledgerId=51,vendorName='Nestle'   FROM [Pharmacy].[dbo].[tbl_Vendor] where vendorId=28
	--update [Pharmacy].[dbo].[tbl_Vendor] set ledgerId=252,vendorName='NAWEED SHAHEED'   FROM [Pharmacy].[dbo].[tbl_Vendor] where vendorId=12
	--update [Pharmacy].[dbo].[tbl_Vendor] set ledgerId=30,vendorName='KAMRAN TRADERS'   FROM [Pharmacy].[dbo].[tbl_Vendor] where vendorId=17
