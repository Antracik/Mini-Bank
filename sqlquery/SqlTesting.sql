
--BETWEEN DATES--
SELECT us.Id, us.Email, reg.FirstName, reg.LastName, reg.[Address], c.[Name] AS 'Country' ,us.[Password],us.DateCreated, us.DateEdited , us.IsAdmin
 FROM [User] AS us
 LEFT JOIN Registrant AS reg ON reg.UserId = us.Id
 LEFT JOIN Country AS c ON c.Id = reg.CountryId
 WHERE us.DateCreated BETWEEN '2019-07-01'  AND '2019-08-18' 
 GO
 
 -------------------------------------------------------------------------------
  --GROUP BY--
SELECT st.Name AS 'Account Status', Count(acc.StatusId) AS 'Total'    FROM Account AS acc
 INNER JOIN [Status] AS st ON st.Id = acc.StatusId
 GROUP BY st.Name

 -------------------------------------------------------------------------------
 --PIVOT TABLE--

 --HARD VALUE PIVOT--
 SELECT * FROM(
 SELECT * FROM
 (SELECT * FROM 
		(SELECT acc.Balance AS Bal1, acc.Balance AS Bal2 ,acc.WalletId, cur.[Name]
			FROM Account AS acc
			INNER JOIN Currency AS cur ON cur.Id = acc.CurrencyId
		) AS T
		PIVOT(
			SUM(Bal1)
			FOR [Name] IN([BGN], [GBP],[USD]) ) AS Pivot_Table
			) AS T2
		UNPIVOT (
			Balance FOR Acc IN([BGN], [GBP],[USD]) ) AS tst 
		) AS T3
		PIVOT(
			COUNT(Acc)
			FOR [Acc] IN([BGN], [GBP],[USD])) AS TST2
			ORDER BY WalletId

-------------------------------------------------------------------------------
SELECT  reg.FirstName + ' ' + reg.LastName AS [Full Name] , tst.WalletId , [BGN], [USD],[GBP], cntBGN,cntUSD, cntGBP FROM 
		(SELECT acc.Balance, acc.WalletId, cur.[Name]
			FROM Account AS acc
			INNER JOIN Currency AS cur ON cur.Id = acc.CurrencyId
		) AS T
		PIVOT(
			SUM(Balance)
			FOR [Name] IN([BGN], [USD], [GBP]) ) AS P1
JOIN (
SELECT WalletId, [1] AS cntBGN, [2] AS cntUSD,[3] AS cntGBP FROM 
		(SELECT cur.Id, acc.WalletId, acc.CurrencyId
			FROM Account AS acc
			INNER JOIN Currency AS cur ON cur.Id = acc.CurrencyId
		) AS T2
		PIVOT(
			COUNT(Id)
			FOR [CurrencyId] IN([1], [2],[3]) ) AS P2) AS tst
			ON P1.WalletId = tst.WalletId 
INNER JOIN Wallet as wal ON wal.Id = tst.WalletId
INNER JOIN Registrant AS reg ON reg.Id = wal.RegistrantId;
-------------------------------------------------------------------------------
SELECT WalletId, SUM(BGN) AS BalanceBGN, SUM(GBP) AS BalanceGBP, SUM(USD) AS BalanceUSD
FROM 
(SELECT acc.Balance, cur.Id ,acc.WalletId, cur.[Name] AS N1, 'c' + cur.[Name] AS N2 
	FROM Account AS acc
	INNER JOIN Currency AS cur ON cur.Id = acc.CurrencyId
) AS T
PIVOT(
	SUM(Balance)
	FOR [N1] IN([BGN], [GBP],[USD]) ) 
	AS Pivot_Table
PIVOT(
	SUM(Id)
	FOR [N2] IN([cBGN], [cGBP],[cUSD]) ) AS P2
	GROUP BY WalletId
-------------------------------------------------------------------------------	
 --DYNAMIC VALUE PIVOT--
 DECLARE @columns NVARCHAR(MAX) ='';
 DECLARE @sql	  NVARCHAR(MAX) = '';

 SELECT
	@columns += QUOTENAME(Currency.Name) + ','
	FROM Currency
	ORDER BY Currency.[Name]

	SET @columns = LEFT(@columns, LEN(@columns) -1);

	SET @sql =
	'SELECT * FROM 
		(SELECT acc.Id, acc.WalletId, cur.[Name] 
			FROM Account AS acc
			INNER JOIN Currency AS cur ON cur.Id = acc.CurrencyId
		) AS T
		PIVOT(
			COUNT(Id)
			FOR [Name] IN('+ @columns +') ) AS Pivot_Table';

	EXECUTE sp_executesql @sql;

 --PIVOT TABLE PROCEDURE--
 EXEC PivotTableExample

 -------------------------------------------------------------------------------
SELECT us.Id, us.Email, reg.FirstName, reg.LastName, reg.[Address], c.[Name] ,us.[PasswordHash]
 FROM [AspNetUsers] AS us
 INNER JOIN Registrant AS reg ON reg.UserId = us.Id
 INNER JOIN Country AS c ON c.Id = reg.CountryId; 
 GO
 
 -------------------------------------------------------------------------------
SELECT reg.Id  AS 'Registrant Id',wal.Id AS 'Wallet Id' , wal.Number , walSt.[Name] AS 'Wallet Status' FROM Registrant AS reg
 INNER JOIN Wallet AS wal ON wal.RegistrantId = reg.Id
 INNER JOIN [Status] AS walSt ON walSt.Id = wal.WalletStatusId

 
 -------------------------------------------------------------------------------
SELECT wal.Id 'Wallet Id', wal.Number, walSt.Name AS 'Wallet Status' , acc.IBAN, acc.Balance, cur.[Name] AS 'Currency' , accSt.[Name] AS 'Account Status'  
 FROM Wallet AS wal
 INNER JOIN Account AS acc ON acc.WalletId = wal.Id
 INNER JOIN Currency AS cur ON cur.Id = acc.CurrencyId
 INNER JOIN [Status] AS walSt ON walSt.Id = wal.WalletStatusId
 INNER JOIN [Status] AS accSt ON accSt.Id = acc.StatusId
 ORDER BY wal.Id
 
 -------------------------------------------------------------------------------
SELECT * FROM [User]

SELECT Wallet.Id, Account.Id, Account.WalletId FROM Wallet
INNER JOIN Account ON Account.WalletId = Wallet.Id

SELECT * FROM Account

SELECT acc.[Id], 
		reg.[FirstName] + ' ' + reg.[LastName] AS ClientName, 
		cnt.[Name] AS ClientCountry, 
		acc.[Balance] , 
		cur.[Name] AS Currency, 
		us.[DateCreated] AS [Date]
		FROM Registrant AS reg
INNER JOIN Wallet AS wal ON wal.RegistrantId = reg.Id
INNER JOIN Account AS acc ON acc.WalletId = wal.Id
INNER JOIN Currency AS cur ON cur.Id = acc.CurrencyId
INNER JOIN Country AS cnt ON cnt.Id = reg.CountryId
INNER JOIN AspNetUsers AS us ON us.Id = reg.UserId
WHERE cnt.[Name] IN ('Bulgaria') AND us.DateCreated > CAST('2019-08-03' AS datetime2 ) AND us.DateCreated < CAST('2019-08-31' AS datetime2)

SELECT IDENT_CURRENT('Wallet') AS wal
SELECT IDENT_CURRENT('AspNetUsers') AS us
SELECT IDENT_CURRENT('Registrant') AS reg
SELECT IDENT_CURRENT('Account') AS acc

-- wall 9
-- us 23
-- reg 3
-- acc 56

SELECT * FROM Wallet

SELECT MAX(WalletId) FROM Account


USE Mini_Bank

SELECT DISTINCT(IBAN) FROM Account
WHERE IBAN IN(
SELECT IBAN FROM Account GROUP BY IBAN HAVING COUNT(*) > 1)
)