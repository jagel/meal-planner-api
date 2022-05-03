# ---------------------------------------------------------------------- #
# Author:                Jagel                                           #
# Script type:           Database creation script                        #
# ---------------------------------------------------------------------- #


# ---------------------------------------------------------------------- #
# Add tables                                                             #
# ---------------------------------------------------------------------- #

# ---------------------------------------------------------------------- #
# Add table "Recipe"                                                     #
# ---------------------------------------------------------------------- #

CREATE TABLE `Recipe` (
    `RecipeId`      INTEGER         NOT NULL AUTO_INCREMENT,
    `Name`          VARCHAR(100)    NOT NULL,
    `Description`   VARCHAR(250),
    `Steps`         VARCHAR(5000),
    `CreatedBy`     VARCHAR(50)     NOT NULL,
    `CreatedDate`   DATETIME        NOT NULL,
    `UpdatedBy`     VARCHAR(50),
    `UpdatedDate`   DATETIME,

    CONSTRAINT `PK_Recipe` PRIMARY KEY (`RecipeId`)
);

# ---------------------------------------------------------------------- #
# Add table "MealProduct"                                                #
# ---------------------------------------------------------------------- #
CREATE TABLE `RecipeProduct` (
    `RecipeProductId`       INTEGER         NOT NULL AUTO_INCREMENT,
    `Name`                  VARCHAR(100)    NOT NULL,
    `Amount`                INTEGER         NOT NULL,
    `Fractionary`           VARCHAR(5),
    `MeasureType`           VARCHAR(100)    NOT NULL,
    `RecipeId`              INTEGER         NOT NULL,

    CONSTRAINT `PK_RecipeProduct` PRIMARY KEY (`RecipeProductId`)
);

ALTER TABLE `RecipeProduct` ADD CONSTRAINT `Recipe_RecipeProduct` 
    FOREIGN KEY (`RecipeId`) REFERENCES `Recipe` (`RecipeId`);