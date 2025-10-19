-- ---------------------------------------------------------------------- #
-- Author:                Jagel                                           #
-- Script type:           Database creation script                        #
-- ---------------------------------------------------------------------- #

-- ---------------------------------------------------------------------- #
-- Add table "OrganizationUser"                                          #
-- ---------------------------------------------------------------------- #

CREATE TABLE [OrganizationUser] (
    [OrganizationUserId]    INT         IDENTITY (1, 1) NOT NULL,
    [UserStatus]            VARCHAR(50) NOT NULL,
    [OrganizationId]        INT         NULL,
    [UserId]                INT         NULL,

    CONSTRAINT [PK_OrganizationUser_Id] PRIMARY KEY CLUSTERED ([OrganizationUserId]),
    CONSTRAINT [FK_OrganizationUser_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [Organization] ([OrganizationId]),
    CONSTRAINT [FK_OrganizationUser_User] FOREIGN KEY ([UserId]) REFERENCES [User] ([UserId])
);
