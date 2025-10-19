-- ---------------------------------------------------------------------- #
-- Author:                Jagel                                           #
-- Script type:           Database creation script                        #
-- ---------------------------------------------------------------------- #

-- ---------------------------------------------------------------------- #
-- Add table "Recipe"                                                     #
-- ---------------------------------------------------------------------- #

CREATE TABLE Recipe (
    [RecipeId]      INT             IDENTITY (1, 1) NOT NULL,
    [Name]          VARCHAR(100)    NOT NULL,
    [Description]   VARCHAR(250)    NULL,
    [Steps]         VARCHAR(5000)   NULL,
    [CreatedBy]     VARCHAR(50)     NOT NULL,
    [CreatedDate]   DATETIME        NOT NULL,
    [UpdatedBy]     VARCHAR(50),
    [UpdatedDate]   DATETIME,

    CONSTRAINT [PK_Recipe_Id] PRIMARY KEY CLUSTERED ([RecipeId])
);

