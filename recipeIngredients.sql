UPDATE [Recipe].[dbo].[RecipeIngredients]
   SET [RecipeId] = <RecipeId, int,>
      ,[IngredientId] = <IngredientId, int,>
      ,[Amount] = <Amount, int,>
      ,[AmountSize] = <AmountSize, text,>
 WHERE <Search Conditions,,>
GO

