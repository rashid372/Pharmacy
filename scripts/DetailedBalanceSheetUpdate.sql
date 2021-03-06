USE [Pharmacy]
GO
--[DetailedBalanceSheet] '11-14-2021','11-15-2021'
/****** Object:  StoredProcedure [dbo].[DetailedBalanceSheet]    Script Date: 11/14/2021 11:16:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[DetailedBalanceSheet]
	@fromDate DATETIME,
	@toDate DATETIME
AS
	
	--Liability
	WITH GroupInMainGroupP (accountGroupId,HierarchyLevel) AS
	(
		SELECT accountGroupId,
		1 AS HierarchyLevel
		FROM tbl_AccountGroup WHERE accountGroupId='1'
		UNION ALL
		SELECT e.accountGroupId,
		G.HierarchyLevel + 1 AS HierarchyLevel
		FROM tbl_AccountGroup AS e,GroupInMainGroupP G
		WHERE e.groupUnder=G.accountGroupId
	)
	SELECT     
		B.acccountLedgerName AS [Name],
		ISNULL(SUM(C.credit), 0)-ISNULL(SUM(C.debit), 0) AS Credit
	FROM         tbl_AccountLedger AS B 
	INNER JOIN   tbl_AccountGroup AS A ON B.accountGroupId = A.accountGroupId 
	LEFT OUTER JOIN tbl_LedgerPosting AS C ON B.ledgerId = C.ledgerId AND C.date <= @toDate 
	WHERE A.accountGroupId IN (SELECT accountGroupId FROM GroupInMainGroupP)
	group by B.acccountLedgerName
	having ISNULL(SUM(C.credit), 0)-ISNULL(SUM(C.debit), 0) !=0;
	
	
	
	--Asset
	WITH GroupInMainGroupP (accountGroupId,HierarchyLevel) AS
	(
		SELECT accountGroupId,
		1 AS HierarchyLevel
		FROM tbl_AccountGroup WHERE accountGroupId='2'
		UNION ALL
		SELECT e.accountGroupId,
		G.HierarchyLevel + 1 AS HierarchyLevel
		FROM tbl_AccountGroup AS e,GroupInMainGroupP G
		WHERE e.groupUnder=G.accountGroupId
	)
	SELECT     
		B.acccountLedgerName AS [Name],
		ISNULL(SUM(C.debit), 0)-ISNULL(SUM(C.credit), 0) AS Debit
	FROM         tbl_AccountLedger AS B 
	INNER JOIN   tbl_AccountGroup AS A ON B.accountGroupId = A.accountGroupId 
	LEFT OUTER JOIN tbl_LedgerPosting AS C ON B.ledgerId = C.ledgerId AND C.date <= @toDate 
	WHERE A.accountGroupId IN (SELECT accountGroupId FROM GroupInMainGroupP)
	group by B.acccountLedgerName
	having ISNULL(SUM(C.debit), 0)-ISNULL(SUM(C.credit), 0) !=0
	
	
	--closing Stock
	SELECT  (ISNULL(SUM(S.inwardQuantity), 0) - ISNULL(SUM(S.outwardQuantity), 0))*ISNULL(B.purchaseRate,0) AS [Closing Stock]
	FROM         tbl_Product AS P 
	INNER JOIN   tbl_ProductBatch AS B ON P.productId = B.productId 
	INNER JOIN   tbl_ProductGroup AS G ON P.productGroupId = G.productGroupId 
	LEFT OUTER JOIN  tbl_StockPosting AS S ON B.productBatchId = S.productBatchId AND S.date <= @toDate --AND S.voucherType ='Sales Invoice' 
	GROUP BY B.productId, P.productName,B.purchaseRate

