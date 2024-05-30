ALTER TABLE Singer
Drop COLUMN Id 

ALTER TABLE Singer
ALTER COLUMN CityId int NULL

ALTER TABLE Singer
ALTER COLUMN Age int NULL


EXEC sp_rename 'Singer.Code', 'Id', 'COLUMN';
