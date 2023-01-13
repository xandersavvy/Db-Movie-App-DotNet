create database [movies]

use [Movies]




CREATE TABLE [userDb](
	[email] VARCHAR(500) PRIMARY KEY NOT NULL,
	[name] VARCHAR(MAX) NOT NULL ,
	[password] TEXT NOT NULL
)

CREATE TABLE [movieDb](
	[id] INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	[name] VARCHAR(MAX) NOT NULL,
	[year] INT
)



INSERT INTO [movieDb] ("name","year")
select 'Avatar2',2022
union
select 'RRR',2022
union 
select 'pathan',2023


select * from userDb
