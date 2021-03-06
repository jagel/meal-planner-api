# ---------------------------------------------------------------------- #
# Author:                Jagel                                           #
# Script type:           Database creation script                        #
# ---------------------------------------------------------------------- #


# ---------------------------------------------------------------------- #
# Add tables                                                             #
# ---------------------------------------------------------------------- #

# ---------------------------------------------------------------------- #
# Add table "User"                                                       #
# ---------------------------------------------------------------------- #

CREATE TABLE `User` (
    `UserId`        INTEGER         NOT NULL AUTO_INCREMENT,
    `Email`         VARCHAR(100)    NOT NULL,
    `Username`      VARCHAR(50)     NOT NULL,
    `Name`          VARCHAR(100)    NOT NULL,
    `LastName`      VARCHAR(100)    NULL,
    `PasswordHash`  BLOB            NOT NULL,
    `PasswordSalt`  BLOB            NOT NULL,
    `Language`      VARCHAR(5),

    CONSTRAINT `PK_User`        PRIMARY KEY (`UserId`),
    CONSTRAINT `TUC_User_email` UNIQUE      (`UserId`, `Email`)
);

# ---------------------------------------------------------------------- #
# Add table "UserSession"                                               #
# ---------------------------------------------------------------------- #
CREATE TABLE `UserSession` (
    `UserSessionId` INTEGER NOT NULL AUTO_INCREMENT,
    `AuthScheme` VARCHAR(50),
    `JWT` VARCHAR(250),
    `CreatedDate` DATETIME,
    `EndDate` DATETIME,
    `UserId` INTEGER,
    CONSTRAINT `PK_UserSession` PRIMARY KEY (`UserSessionId`)
);

ALTER TABLE `UserSession` ADD CONSTRAINT `User_UserSession` 
    FOREIGN KEY (`UserId`) REFERENCES `User` (`UserId`);

# ---------------------------------------------------------------------- #
# Add table "Organization"                                               #
# ---------------------------------------------------------------------- #

CREATE TABLE `Organization` (
    `OrganizationId`    INTEGER         NOT NULL AUTO_INCREMENT,
    `Name`              VARCHAR(100)    NOT NULL,
    `OrganizationCode`  VARCHAR(50)     NOT NULL,
    `UserOwnerId`       INTEGER         NOT NULL,

    CONSTRAINT `PK_Organization`        PRIMARY KEY (`OrganizationId`),
    CONSTRAINT `TUC_Organization_code`  UNIQUE      (`OrganizationId`, `OrganizationCode`)
);

# ---------------------------------------------------------------------- #
# Add table "OrganizationUser:"                                          #
# ---------------------------------------------------------------------- #

CREATE TABLE `OrganizationUser` (
    `OrganizationUserId`    INTEGER     NOT NULL AUTO_INCREMENT,
    `UserStatus`            VARCHAR(50) NOT NULL,
    `OrganizationId`        INTEGER,
    `UserId`                INTEGER,

    CONSTRAINT `PK_OrganizationUser` PRIMARY KEY (`OrganizationUserId`)
);

ALTER TABLE `OrganizationUser` ADD CONSTRAINT `Organization_OrganizationUser` 
    FOREIGN KEY (`OrganizationId`) REFERENCES `Organization` (`OrganizationId`);

ALTER TABLE `OrganizationUser` ADD CONSTRAINT `User_OrganizationUser` 
    FOREIGN KEY (`UserId`) REFERENCES `User` (`UserId`);
