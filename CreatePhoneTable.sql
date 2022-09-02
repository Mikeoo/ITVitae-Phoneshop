CREATE TABLE [dbo].[phones] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Stock]       INT           NULL,
    [Brand]       VARCHAR (50)  NULL,
    [Type]        VARCHAR (50)  NULL,
    [Description] VARCHAR (MAX) NULL,
    [Price]       FLOAT (53)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);