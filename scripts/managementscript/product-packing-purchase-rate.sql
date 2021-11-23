select *
--update tbl_Product set packing=1,stockMinimumLevel=1,stockMaximumLevel=5 
 from tbl_Product where productName like '%syp%' and Packing is NULL and productId in
 (
select productId from
(select productId,purchaseRate from 
(select B.productBatchId,productId,purchaseRate from tbl_ProductBatch B,tbl_StockPosting P
 where b.productBatchId=P.productBatchId and productId in (
 select productId from tbl_Product where productName like '%syp%' and Packing is NULL
 )) tbl
 group by productId,purchaseRate) tbl2
 group by productId
 having count(*) = 1
 )

 update tbl_Product set purchaseRate=tbl4.purchaseRate  from tbl_Product P,
(select productId,purchaseRate from 
(select B.productBatchId,productId,purchaseRate from tbl_ProductBatch B,tbl_StockPosting P
 where b.productBatchId=P.productBatchId and productId in (
 select productId from tbl_Product where productName like '%syp%' 
 )) tbl
 where productId in
 (
select productId from
(select productId,purchaseRate from 
(select B.productBatchId,productId,purchaseRate from tbl_ProductBatch B,tbl_StockPosting P
 where b.productBatchId=P.productBatchId and productId in (
 select productId from tbl_Product where productName like '%syp%' 
 )) tbl
  where purchaseRate > 0
 group by productId,purchaseRate) tbl2
 group by productId
 having count(*) = 1
 ))tbl4
 where P.productId=tbl4.productId

 ---creame
  update tbl_Product set purchaseRate=tbl4.purchaseRate,Packing=1
  --select *
    from tbl_Product P,
(select productId,purchaseRate from 
(select B.productBatchId,productId,purchaseRate from tbl_ProductBatch B,tbl_StockPosting P
 where b.productBatchId=P.productBatchId and productId in (
 select productId from tbl_Product where productName like '%cream%' 
 )) tbl
 where productId in
 (
select productId from
(select productId,purchaseRate from 
(select B.productBatchId,productId,purchaseRate from tbl_ProductBatch B,tbl_StockPosting P
 where b.productBatchId=P.productBatchId and productId in (
 select productId from tbl_Product where productName like '%cream%' 
 )) tbl
  where purchaseRate > 0
 group by productId,purchaseRate) tbl2
 group by productId
 having count(*) = 1
 ))tbl4
 where P.productId=tbl4.productId

  ---creame
 -- update tbl_Product set purchaseRate=tbl4.purchaseRate,Packing=1
  --select *
    from tbl_Product P,
(select productId,purchaseRate from 
(select B.productBatchId,productId,purchaseRate from tbl_ProductBatch B,tbl_StockPosting P
 where b.productBatchId=P.productBatchId and productId in (
 select productId from tbl_Product where productName like '%inj%' 
 )) tbl
 where productId in
 (
select productId from
(select productId,purchaseRate from 
(select B.productBatchId,productId,purchaseRate from tbl_ProductBatch B,tbl_StockPosting P
 where b.productBatchId=P.productBatchId and productId in (
 select productId from tbl_Product where productName like '%inj%' 
 )) tbl
  where purchaseRate > 0
 group by productId,purchaseRate) tbl2
 group by productId
 having count(*) = 1
 ))tbl4
 where P.productId=tbl4.productId
