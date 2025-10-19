-- ---------------------------------------------------------------------- #
-- Author:                Jagel                                           #
-- Script type:           Database creation script                        #
-- ---------------------------------------------------------------------- #

-- ---------------------------------------------------------------------- #
-- Add table "User"                                                       #
-- ---------------------------------------------------------------------- #

CREATE TABLE [User] (
    [UserId]        INT             IDENTITY (1, 1) NOT NULL,
    [Email]         VARCHAR(100)    NOT NULL,
    [Username]      VARCHAR(50)     NOT NULL,
    [Name]          VARCHAR(100)    NOT NULL,
    [LastName]      VARCHAR(100)    NULL,
    [PasswordHash]  VARBINARY(MAX)  NOT NULL,
    [PasswordSalt]  VARBINARY(MAX)  NOT NULL,
    [Language]      VARCHAR(5)      NULL,

    CONSTRAINT [PK_User_Id] PRIMARY KEY CLUSTERED ([UserId]),
    CONSTRAINT [UQ_User_Email] UNIQUE ([Email])
);