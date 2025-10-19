-- ---------------------------------------------------------------------- #
-- Author:                Jagel                                           #
-- Script type:           Database creation script                        #
-- ---------------------------------------------------------------------- #

-- ---------------------------------------------------------------------- #
-- Add table "Organization"                                               #
-- ---------------------------------------------------------------------- #

CREATE TABLE [Organization] (
    [OrganizationId]    INT             IDENTITY (1, 1) NOT NULL,
    [Name]              VARCHAR(100)    NOT NULL,
    [OrganizationCode]  VARCHAR(50)     NOT NULL,
    [UserOwnerId]       INT             NOT NULL,

    CONSTRAINT [PK_Organization_Id] PRIMARY KEY CLUSTERED ([OrganizationId]),
    CONSTRAINT [UQ_Organization_Code] UNIQUE ([OrganizationCode])
);

