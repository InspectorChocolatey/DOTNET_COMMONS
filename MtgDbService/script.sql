USE [WCFContactDB]
GO






/****** Object:  Table [dbo].[ContactTable]    Script Date: 02/17/2016 08:48:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContactTable](
	[ContactID] [int] IDENTITY(1,1) NOT NULL,
	[ContactName] [varchar](100) NOT NULL,
	[ContactAddress] [varchar](100) NULL,
	[ContactNumber] [varchar](100) NULL,
	[ContactDOB] [datetime] NULL,
	[ContactIncome] [money] NULL,
 CONSTRAINT [PK_ContactTable] PRIMARY KEY CLUSTERED 
(
	[ContactID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO









/****** Object:  StoredProcedure [dbo].[UpdateContact]    Script Date: 02/17/2016 08:48:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UpdateContact]
(
@ContactID INT,
@ContactName VARCHAR(100),
@ContactAddress VARCHAR(100),
@ContactNumber VARCHAR(100),
@ContactDOB DATETIME,
@ContactIncome Money
)
AS
BEGIN
	UPDATE dbo.ContactTable SET ContactName=@ContactName,ContactAddress=@ContactAddress,ContactNumber=@ContactNumber,
								ContactDOB=@ContactDOB,ContactIncome=@ContactIncome WHERE ContactID=@ContactID
END
GO









/****** Object:  StoredProcedure [dbo].[SelectAllContact]    Script Date: 02/17/2016 08:48:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SelectAllContact]
AS
BEGIN
	SELECT     ContactID, ContactName, ContactAddress, ContactNumber, ContactDOB, ContactIncome
FROM         ContactTable
END
GO





/****** Object:  StoredProcedure [dbo].[InsertContact]    Script Date: 02/17/2016 08:48:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[InsertContact]
(
@ContactName VARCHAR(100),
@ContactAddress VARCHAR(100),
@ContactNumber VARCHAR(100),
@ContactDOB DATETIME,
@ContactIncome Money
)
AS
BEGIN
	INSERT INTO dbo.ContactTable(ContactName,ContactAddress,ContactNumber,ContactDOB,ContactIncome)
	VALUES (@ContactName,@ContactAddress,@ContactNumber,@ContactDOB,@ContactIncome);
	SELECT SCOPE_IDENTITY();
END
GO









/****** Object:  StoredProcedure [dbo].[DeleteContact]    Script Date: 02/17/2016 08:48:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DeleteContact]
(
@ContactID INT
)
AS
BEGIN
	DELETE FROM dbo.ContactTable WHERE ContactID=@ContactID
END
GO
