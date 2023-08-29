USE [LMS_UMKM_Db]
INSERT INTO [dbo].[RfSubProducts]
           ([SubProductId]
           ,[Description]
           ,[ProductId]
           ,[Payroll]
           ,[CoreCode]
           ,[SchemaMaxInstallment]
           ,[MaximumYearBeforeRetirement]
           ,[TplSurveyCode]
           ,[DivisionCode]
           ,[DefpayCode]
           ,[DefIntType]
           ,[DefProvPctFee]
           ,[MaxProvPctFee]
           ,[DefAdmPcmFee]
           ,[BlockParam]
           ,[MaxPlanfond]
           ,[BjbMusisi]
           ,[MaximumMonthBeforeRetirement]
           ,[GradePeriodPension]
           ,[CreatedDate]
           ,[CreatedBy]
           ,[IsDeleted]
           ,[IsGracePeriod]
           ,[DIMType]
)
SELECT [SUBPRODUCTID]
      ,[SUBPRODUCTDESC]
      ,[PRODUCTID]
      ,[PAYROLL]
      ,[CORE_CODE]
      ,[SCHEMAMAXINST]
      ,isnull([MAXTHNSBLMPENSIUN],0)
      ,[TPLSURVEY_CODE]
      ,[DIVISI_CODE]
      ,[DEF_PAY_CODE]
      ,[DEF_INTTYPE]
      ,[DEF_PROVPCTFEE]
      ,[MAX_PROVPCTFEE]
      ,[DEF_ADMPCTFEE]
      ,[BLOCKPARAM]
      ,[MAX_PLAFOND]
      ,[BJBMUSISI]
      ,[MAXBLNSBLMPENSIUN]
      ,[MASATENGGANGTHT]   
      ,SYSDATETIME() as createdDate
	  ,'C0680A01-2886-49CE-B2A4-296FCACBE85B' as createdBY
	  ,0
	  ,1 as IsGracePeriod
	  ,'DL02' as DIMType
  FROM [10.6.231.76].[LMSCONSUMER].[dbo].[RFSUBPRODUCT]

  WHERE 
  1=1
  and [CORE_CODE] IN ('J9I','J9J','J9K')
