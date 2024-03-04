ALTER TABLE Song
DROP COLUMN SingerId  

ALTER TABLE Song
DROP CONSTRAINT FK_SongSinger

ALTER TABLE Song 
ADD ComposerName VARCHAR(50) NULL

ALTER TABLE Song 
ADD ProcessorName VARCHAR(50) NULL

ALTER TABLE Song
DROP CONSTRAINT FK_SongComposer

ALTER TABLE Song
DROP CONSTRAINT FK_SongProcessor

ALTER TABLE Song
DROP COLUMN ComposerId  

ALTER TABLE Song
DROP COLUMN ProcessorId  

ALTER TABLE Song
ALTER COLUMN ComposerName NVARCHAR(50) NOT NULL

ALTER TABLE Song
ALTER COLUMN ProcessorName NVARCHAR(50) NOT NULL

CREATE TABLE [dbo].[Subscriber]  (
    [Code]            INT            IDENTITY (1, 1) NOT NULL,
    [ID]            NVARCHAR (10)               NOT NULL,
    [FirstName]           NVARCHAR (50)     NOT NULL,
    [LastName]   NVARCHAR (50)           NOT NULL,
    PRIMARY KEY CLUSTERED ([Code] ASC),
);

INSERT INTO Subscriber
VALUES  ('765089484','Yossi', 'Levy'),
        ('770973873','Jacob', 'Cohen'),
        ('635876445','Rachel', 'Goldberg'),
        ('567688989','Benjamin', 'Katz'),
        ('525649890','Hannah' ,'Stein'),
        ('345678907','David ', 'Schwartz'),
        ('456789035','Ezra', 'Friedman'),
        ('456778990','Joshua', 'Abramowitz'),
        ('738908839','Leah ' ,'Rosenberg'),
        ('345678902','Miriam', 'Adler'),
        ('586740454','Isaac', 'Rosenbaum'),
        ('798092364','Nathan', 'Weisman')

CREATE TABLE [dbo].[SingerSongs]  (
    [Id]            INT     IDENTITY (1, 1) NOT NULL,
    [SingerId]      INT     NOT NULL,
    [SongId]        INT     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
);

INSERT INTO SingerSongs
VALUES  ('1', '1'),
        ('1', '2'),
        ('1', '3'),
        ('5', '4'),
        ('3', '5'),
        ('2', '6')

CREATE TABLE [dbo].[SubscriberSongs]  (
    [Id]            INT     IDENTITY (1, 1) NOT NULL,
    [SubscriberId]      INT     NOT NULL,
    [SongId]        INT     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
);

INSERT INTO SubscriberSongs
VALUES  ('1', '1'),
        ('1', '2'),
        ('1', '5'),
        ('2', '1'),
        ('2', '6'),
        ('2', '4'),
        ('2', '3'),
        ('3', '1'),
        ('3', '2'),
        ('4', '6'),
        ('4', '1'),
        ('4', '2'),
        ('5', '3'),
        ('5', '1'),
        ('6', '4'),
        ('6', '5'),
        ('6', '2'),
        ('7', '1'),
        ('7', '3'),
        ('8', '3'),
        ('8', '4'),
        ('8', '5'),
        ('9', '6'),
        ('10', '2'),
        ('11', '3'),
        ('11', '6'),
        ('12', '5')


