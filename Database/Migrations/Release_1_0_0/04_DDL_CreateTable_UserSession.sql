-- ---------------------------------------------------------------------- #
-- Author:                Jagel                                           #
-- Script type:           Database creation script                        #
-- ---------------------------------------------------------------------- #

-- ---------------------------------------------------------------------- #
-- Add table "UserSession"                                               #
-- ---------------------------------------------------------------------- #
CREATE TABLE [UserSession] (
    [UserSessionId] INT             IDENTITY (1, 1) NOT NULL,
    [AuthScheme]    VARCHAR(50)     NULL,
    [JWT]           VARCHAR(250)    NULL,
    [CreatedDate]   DATETIME        NULL,
    [EndDate]       DATETIME        NULL,
    [UserId]        INT             NULL,
    
    CONSTRAINT [PK_UserSession_Id] PRIMARY KEY CLUSTERED ([UserSessionId]),
    CONSTRAINT [FK_UserSession_User] FOREIGN KEY ([UserId]) REFERENCES [User] ([UserId])
);
