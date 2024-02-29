CREATE TABLE [dbo].[Subscribers]  (
    [Code]            INT            IDENTITY (1, 1) NOT NULL,
    [ID]            NVARCHAR (10)               NOT NULL,
    [FirstName]           NVARCHAR (50)     NOT NULL,
    [LastName]   NVARCHAR (50)           NOT NULL,
    PRIMARY KEY CLUSTERED ([Code] ASC),
);

INSERT INTO Subscribers
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