UPDATE [Recipe].[dbo].[Recipe]
   SET [Name] = <Name, varchar(50),>
      ,[PrepTime] = <PrepTime, int,>
      ,[CookTime] = <CookTime, int,>
      ,[NumberServ] = <NumberServ, int,>
      ,[Steps] = <Steps, text,>
      ,[RecipeType] = <RecipeType, varchar(50),>
 WHERE <Search Conditions,,>
GO

