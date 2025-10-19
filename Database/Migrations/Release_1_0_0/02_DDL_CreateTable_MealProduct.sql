-- ---------------------------------------------------------------------- #
-- Author:                Jagel                                           #
-- Script type:           Database creation script                        #
-- ---------------------------------------------------------------------- #

-- ---------------------------------------------------------------------- #
-- Add table "RecipeProduct"                                                #
-- ---------------------------------------------------------------------- #
CREATE TABLE RecipeProduct (
    [RecipeProductId]         INT           IDENTITY (1, 1) NOT NULL,
    [Name]                    VARCHAR(100)  NOT NULL,
    [Quantity]                INT           NOT NULL,
    [Fractionary]             VARCHAR(5)    NULL,
    [MeasureType]             VARCHAR(100)  NOT NULL,
    [RecipeId]                INT           NOT NULL,

    CONSTRAINT [PK_RecipeProduct_Id] PRIMARY KEY CLUSTERED (RecipeProductId),
    CONSTRAINT [FK_RecipeProduct_Recipe] FOREIGN KEY ([RecipeId]) REFERENCES [Recipe] ([RecipeId])
);