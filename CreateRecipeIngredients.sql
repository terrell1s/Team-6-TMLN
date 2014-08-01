USE [Recipe]
GO

/****** Object:  Table [dbo].[RecipeIngredients]    Script Date: 08/01/2014 09:41:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RecipeIngredients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RecipeId] [int] NOT NULL,
	[IngredientId] [int] NOT NULL,
	[Amount] [int] NULL,
	[AmountSize] [text] NULL,
 CONSTRAINT [PK_RecipeIngredients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[RecipeIngredients]  WITH CHECK ADD  CONSTRAINT [FK_RecipeIngredients_Ingredients] FOREIGN KEY([IngredientId])
REFERENCES [dbo].[Ingredients] ([Id])
GO

ALTER TABLE [dbo].[RecipeIngredients] CHECK CONSTRAINT [FK_RecipeIngredients_Ingredients]
GO

ALTER TABLE [dbo].[RecipeIngredients]  WITH CHECK ADD  CONSTRAINT [FK_RecipeIngredients_Recipe] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipe] ([Id])
GO

ALTER TABLE [dbo].[RecipeIngredients] CHECK CONSTRAINT [FK_RecipeIngredients_Recipe]
GO

