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
    `RecipeId` INTEGER NOT NULL AUTO_INCREMENT,
    `Name` VARCHAR(100) NOT NULL,
    `Description` VARCHAR(250),
    `SourceCode` VARCHAR(50) NOT NULL,
    `CreatedBy` VARCHAR(50) NOT NULL,
    `CreatedDate` DATETIME NOT NULL,
    `UpdatedBy` VARCHAR(50),
    `UpdatedDate` DATETIME,
    CONSTRAINT `PK_Recipe` PRIMARY KEY (`RecipeId`)
);
