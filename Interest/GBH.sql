INSERT INTO [dbo].[RfSubProductInterests]
           ([TplCode]
           ,[ProductId]
           ,[SubProductId]
           ,[JobCode]
           ,[GolCode]
           ,[PngktCode]
           ,[MinAge]
           ,[MaxAge]
           ,[MinTenor]
           ,[MaxTenor]
           ,[TplPrio]
           ,[InterestNew]
           ,[InterestTopUp]
           ,[InterestRepeat]
           ,[MusisiNew]
           ,[MusisiTopUp]
           ,[MusisiRepeat]
           ,[Active]
           ,[CreateBy]
           ,[CreateDate]
           ,[BranchId]
           ,[StartDate]
           ,[EndDate]
           ,[BaseRate]
           ,[ParamSpread]
           ,[BaseRateYear]
           ,[InterestType]
           ,[InterestPromoType]
           ,[BatchId]
           ,[BatchIdSeq]
           ,[GracePeriodCode]
           ,[IsDeleted]
           ,[CompanyId])
SELECT
	   [TPL_CODE]
      ,[PRODUCTID]
      ,[SUBPRODUCTID]
      ,[JOB_CODE]
      ,[GOL_CODE]
      ,[PNGKT_CODE]
      ,[MINAGE]
      ,[MAXAGE]
      ,[MINTENOR]
      ,[MAXTENOR]
      ,[TPL_PRIO]
      ,[INTEREST] + [PARAMSPREAD] as [InterestNew]
	  ,[INTEREST] + [PARAMSPREAD] as [InterestTopup]
	  ,[INTEREST] + [PARAMSPREAD] as [InterestRepeat]
	  ,[INTEREST] + [PARAMSPREAD] - 0.5 as [MusisiNew]
	  ,[INTEREST] + [PARAMSPREAD] - 0.5 as [MusisiTopup]
	  ,[INTEREST] + [PARAMSPREAD] - 0.5 as [MusisiRepeat]
      ,[ACTIVE]
      ,'C0680A01-2886-49CE-B2A4-296FCACBE85B'
      ,SYSDATETIME()
      ,[BRANCHID]
      ,[STARTDATE]
      ,[ENDDATE]
      ,[BASERATE]
      ,[PARAMSPREAD]
      ,[BASERATEYEAR]
      ,[INT_TYPE]
      ,null
      ,[BATCHID]
      ,[BATCHID_SEQ]
      ,[GRACEPERIOD_CODE]
	  ,0
	  ,null
  FROM [RFSUBPRODUCTINTPROD] a
where
1=1
and a.Active = 1
and convert(datetime,endDate,103) > getdate()
and a.subproductId = 'G6H'
and a.intPromo_type = 'N001'


