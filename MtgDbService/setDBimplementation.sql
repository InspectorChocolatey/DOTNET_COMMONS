/*
	Technical References:

	(microsoft documentation) 
	DELETE (Transact-SQL)
	https://docs.microsoft.com/en-us/sql/t-sql/statements/delete-transact-sql?view=sql-server-2017


	(microsoft documentation) 
	UPDATE (Transact-SQL)
	https://docs.microsoft.com/en-us/sql/t-sql/queries/update-transact-sql?view=sql-server-2017
*/
USE mtg;

SELECT * FROM set;

/* My Implementation */
CREATE TABLE SetTable
(
	Id INT PRIMARY KEY IDENTITY,
	SetName varchar(50),
	SetSize int,
	SetRares int,
	SetUncommons int,
	SetCommons int,
	BasicLands int,
	ReleaseDate datetime,
)
GO
/*
Source references:

	Master Setlists:
	https://mtg.gamepedia.com/Set

	Alpha (Limited Edition)
	https://mtg.gamepedia.com/Alpha

	Beta (Limited Edition)
	https://mtg.gamepedia.com/Beta

	Unlimited Edition
	https://mtg.gamepedia.com/Unlimited_Edition


	Arabian Nights
		https://mtg.gamepedia.com/Arabian_Nights	
		Set Size: 78
	Antiquities
		https://mtg.gamepedia.com/Antiquities
	Revised Edition
		https://mtg.gamepedia.com/Revised_Edition
	Legends
		https://mtg.gamepedia.com/Legends
	The Dark
		https://mtg.gamepedia.com/The_Dark
	Fallen Empires
		https://mtg.gamepedia.com/Fallen_Empires
	Fourth Edition
		https://mtg.gamepedia.com/Fourth_Edition
	Ice Age
		https://mtg.gamepedia.com/Ice_Age
	Chronicles
		https://mtg.gamepedia.com/Chronicles
	Renaissance
		wtf is this set???
	Homelands
		https://mtg.gamepedia.com/Homelands
	Alliances
		https://mtg.gamepedia.com/Alliances
	Mirage
		https://mtg.gamepedia.com/Mirage
	Visions
		https://mtg.gamepedia.com/Visions
	Fifth Edition
		https://mtg.gamepedia.com/Fifth_Edition
	Portal
		https://mtg.gamepedia.com/Portal
	Weatherlight
		https://mtg.gamepedia.com/Weatherlight
	Tempest
		https://mtg.gamepedia.com/Tempest
	Stronghold
		https://mtg.gamepedia.com/Stronghold
	Exodus
		https://mtg.gamepedia.com/Exodus
	Portal Second Age
		https://mtg.gamepedia.com/Portal_Second_Age
	Unglued:
		https://mtg.gamepedia.com/Unglued
	Sixth Edition
		https://mtg.gamepedia.com/Sixth_Edition
	Urza's Saga
		https://mtg.gamepedia.com/Urza%27s_Saga
	Anthologies
		https://mtg.gamepedia.com/Anthologies
	Urza's Legacy
		https://mtg.gamepedia.com/Urza%27s_Legacy
	Urza's Destiny
		https://mtg.gamepedia.com/Urza%27s_Destiny
	Portal Three Kingdoms
		https://mtg.gamepedia.com/Portal_Three_Kingdoms	
	Starter 1999
		https://mtg.gamepedia.com/Starter_1999
	Prophecy
		https://mtg.gamepedia.com/Prophecy
	Invasion
		https://mtg.gamepedia.com/Invasion
	7th Edition
		https://mtg.gamepedia.com/Seventh_Edition
	Apocalypse
		https://mtg.gamepedia.com/Apocalypse
	Odyssey
		https://mtg.gamepedia.com/Odyssey	
	Torment
		https://mtg.gamepedia.com/Torment
	Judgement
		https://mtg.gamepedia.com/Judgment





	
	Onslaught
		https://mtg.gamepedia.com/Onslaught
	Legions
		https://mtg.gamepedia.com/Legions
	Scourge
		https://mtg.gamepedia.com/Scourge
	Eight Edition
		https://mtg.gamepedia.com/Eighth_Edition

	// (-; Upto Date in SqlServer

	Mirrodin
		https://mtg.gamepedia.com/Mirrodin
	Darksteel
	
	Fifth Dawn

	Champions of Kamigawa

	Betrayers of Kamigawa

	Saviors of Kamigawa


	Ravnica City of Guild

	Guildpact

	Dissention

		
*/



/*
Set:

	SetName varchar(50),
	SetSize int,
	SetRares int,
	SetUncommons int,
	SetCommons int,
	BasicLands int,
	ReleaseDate datetime,
*/

INSERT INTO SetTable VALUES
(
	'Alpha (Limited Edition)',
	295, 
	116, 
	95, 
	74, 
	10,
	'August 5, 1993'
),
(
	'Beta (Limited Edition)',
	302, 
	117, 
	95, 
	74, 
	15,
	'October 1993'	
),
(
	'Unlimited Edition',
	302, 
	117, 
	95, 
	75, 
	15,
	'December 1, 1993'	
),
(
	
),
(
	
)
GO

SELECT Id, 
	SetSize,
	SetRares,
	SetUncommons,
	SetCommons,
	BasicLands,
	ReleaseDate FROM SetTable;


SELECT Id, 
	SetSize,
	SetRares,
	SetUncommons,
	SetCommons,
	BasicLands,
	ReleaseDate FROM SetTable 
	WHERE Id=3;

DELETE FROM [dbo].[SetTable]
WHERE Id=3;


UPDATE [dbo].[SetTable]
SET ReleaseDate = 'December 1, 1993'
WHERE Id = 3;