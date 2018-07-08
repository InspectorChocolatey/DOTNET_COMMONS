USE [mtg]
GO

/****** Object:  Table [dbo].[ContactTable]    Script Date: 02/17/2016 08:48:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MtgSetTable](
	[SetID] [int] IDENTITY(1,1) NOT NULL,
	[SetName] [varchar](100) NOT NULL,
	[SetSize] [int],
	[SetRares] [int],
	[SetUncommons] [int],
	[SetCommons] [int],
	[SetBasicLands] [int],
	[SetReleaseDate] [datetime],
CONSTRAINT [PK_MtgSetTable] PRIMARY KEY CLUSTERED 
(
	[SetID] ASC
) WITH (
	PAD_INDEX  = OFF, 
	STATISTICS_NORECOMPUTE = OFF, 
	IGNORE_DUP_KEY = OFF, 
	ALLOW_ROW_LOCKS = ON, 
	ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  StoredProcedure [dbo].[UpdateSet]    Script Date: 02/17/2016 08:48:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UpdateSet]
(
	@SetID [INT],
	@SetName VARCHAR(100),
	@SetSize [INT],
	@SetRares [INT],
	@SetUncommons [INT],
	@SetCommons [INT],
	@SetBasicLands [INT],
	@SetReleaseDate [DATETIME]
)
AS
BEGIN
	UPDATE dbo.MtgSetTable SET SetName=@SetName,SetSize=@SetSize,SetRares=@SetRares,
								SetUncommons=@SetUncommons,SetCommons=@SetCommons,
								SetBasicLands=@SetBasicLands,SetReleaseDate=@SetReleaseDate WHERE SetID=@SetID
END
GO

/****** Object:  StoredProcedure [dbo].[SelectAllSet]    Script Date: 02/17/2016 08:48:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SelectAllSet]
AS
BEGIN
	SELECT SetID, 
		   SetName, 
		   SetSize, 
		   SetRares, 
		   SetUncommons, 
		   SetCommons, 
		   SetBasicLands, 
		   SetReleaseDate FROM MtgSetTable;
END
GO

/****** Object:  StoredProcedure [dbo].[InsertSet]    Script Date: 02/17/2016 08:48:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[InsertSet]
(
	@SetName VARCHAR(100),
	@SetSize [INT],
	@SetRares [INT],
	@SetUncommons [INT],
	@SetCommons [INT],
	@SetBasicLands [INT],
	@SetReleaseDate [DATETIME]
)
AS
BEGIN
	INSERT INTO dbo.MtgSetTable(SetName,SetSize,SetRares,SetUncommons,SetCommons,SetBasicLands,SetReleaseDate)
	VALUES (@SetName,@SetSize,@SetRares,@SetUncommons,@SetCommons,@SetBasicLands,@SetReleaseDate);
	SELECT SCOPE_IDENTITY();
END
GO

/****** Object:  StoredProcedure [dbo].[DeleteSet]    Script Date: 02/17/2016 08:48:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DeleteSet]
(
	@SetID [INT]
)
AS
BEGIN
	DELETE FROM dbo.MtgSetTable WHERE SetID=@SetID;
END
GO
