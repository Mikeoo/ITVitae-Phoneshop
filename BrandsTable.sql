CREATE TABLE [dbo].[brands] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

INSERT INTO brands (Name) VALUES ('Huawei')
INSERT INTO brands (Name) VALUES ('Samsung')
INSERT INTO brands (Name) VALUES ('Apple')
INSERT INTO brands (Name) VALUES ('Google')
INSERT INTO brands (Name) VALUES ('Xiaomi')

begin transaction

    ALTER TABLE [dbo].[phones] 
        DROP COLUMN Brand

    ALTER TABLE [dbo].[phones] 
        ADD brandid Int NULL

    insert into brands (Name) values ('Motorola');
    insert into brands (Name) values ('Oneplus');
    insert into brands (Name) values ('Poco');

    update phones set brandid = (select id from brands where name='Huawei') where Type='P30'
    update phones set brandid = (select id from brands where name='Samsung') where Type='Galaxy A52'
    update phones set brandid = (select id from brands where name='Apple') where Type='Iphone 11'
    update phones set brandid = (select id from brands where name='Google') where Type='Pixel 4a'
    update phones set brandid = (select id from brands where name='Xiaomi') where Type='Redmi Note 10 Pro'
    update phones set brandid = (select id from brands where name='Apple') where Type='iPhone 12 Pro 128GB Zwart'
    update phones set brandid = (select id from brands where name='Motorola') where Type='Moto G20 Blauw'
    update phones set brandid = (select id from brands where name='Oneplus') where Type='Nord 2 128GB Grijs'
    update phones set brandid = (select id from brands where name='Poco') where Type='X3 Pro 128GB Zwart'

rollback transaction