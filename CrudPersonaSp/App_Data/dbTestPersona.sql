USE [master]
GO
/****** Object:  Database [dbTestPersona]    Script Date: 11/05/2017 12:46:49 p. m. ******/
CREATE DATABASE [dbTestPersona]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbTestPersona', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\dbTestPersona.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'dbTestPersona_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\dbTestPersona_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [dbTestPersona] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbTestPersona].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbTestPersona] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbTestPersona] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbTestPersona] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbTestPersona] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbTestPersona] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbTestPersona] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [dbTestPersona] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbTestPersona] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbTestPersona] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbTestPersona] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbTestPersona] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbTestPersona] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbTestPersona] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbTestPersona] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbTestPersona] SET  ENABLE_BROKER 
GO
ALTER DATABASE [dbTestPersona] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbTestPersona] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbTestPersona] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbTestPersona] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbTestPersona] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbTestPersona] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbTestPersona] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbTestPersona] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbTestPersona] SET  MULTI_USER 
GO
ALTER DATABASE [dbTestPersona] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbTestPersona] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbTestPersona] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbTestPersona] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [dbTestPersona] SET DELAYED_DURABILITY = DISABLED 
GO
USE [dbTestPersona]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 11/05/2017 12:46:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Persona](
	[idPersona] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[direccion] [varchar](50) NOT NULL,
	[imagen] [image] NULL,
	[nacimiento] [date] NULL,
	[telefono] [varchar](15) NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[idPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[Persona_Delete]    Script Date: 11/05/2017 12:46:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  TU_NOMBRE
-- Create date: 04/05/17
-- =============================================
CREATE PROCEDURE [dbo].[Persona_Delete]
  @idPersona INT = NULL

AS
 SET NOCOUNT OFF;

    DELETE FROM Persona
    WHERE (@idPersona IS NULL OR @idPersona=idPersona)

-- =====UPDATE==================================
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[Persona_Exists]    Script Date: 11/05/2017 12:46:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  TU_NOMBRE
-- Create date: 04/05/17
-- =============================================
CREATE PROCEDURE [dbo].[Persona_Exists]
  @idPersona INT = NULL
 ,@exists int output
AS
 SET NOCOUNT OFF;
    IF EXISTS (
 SELECT idPersona
    FROM Persona
    WHERE ( @idPersona=idPersona)

 )
 SET @exists = 1
 ELSE SET @exists = 0

GO
/****** Object:  StoredProcedure [dbo].[Persona_Insert]    Script Date: 11/05/2017 12:46:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  TU_NOMBRE
-- Create date: 04/05/17
-- =============================================
CREATE PROCEDURE [dbo].[Persona_Insert]
  @idPersona INT = NULL
 ,@nombre VARCHAR(50) = NULL
 ,@direccion VARCHAR(50) = NULL
 ,@imagen IMAGE = NULL
 ,@nacimiento DATE = NULL
 ,@telefono VARCHAR(15) = NULL
 ,@email VARCHAR(50) = NULL
AS
 SET NOCOUNT OFF;

    INSERT INTO Persona(
     idPersona
    ,nombre
    ,direccion
    ,imagen
    ,nacimiento
    ,telefono
    ,email
 )
 VALUES(
     @idPersona
    ,@nombre
    ,@direccion
    ,@imagen
    ,@nacimiento
    ,@telefono
    ,@email
 )

-- =====DELETE==================================
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[Persona_Listar]    Script Date: 11/05/2017 12:46:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Persona_Listar]
as
begin
	select* from Persona
end
GO
/****** Object:  StoredProcedure [dbo].[Persona_Select]    Script Date: 11/05/2017 12:46:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  TU_NOMBRE
-- Create date: 04/05/17
-- =============================================
CREATE PROCEDURE [dbo].[Persona_Select]
  @idPersona INT = NULL
AS
 SET NOCOUNT OFF;

    SELECT idPersona
    ,nombre
    ,direccion
    ,imagen
    ,nacimiento
    ,telefono
    ,email
    FROM Persona
    WHERE ( @idPersona=idPersona)


-- =====EXISTS==================================
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[Persona_Update]    Script Date: 11/05/2017 12:46:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  TU_NOMBRE
-- Create date: 04/05/17
-- =============================================
CREATE PROCEDURE [dbo].[Persona_Update]
  @idPersona INT = NULL
 ,@nombre VARCHAR(50) = NULL
 ,@direccion VARCHAR(50) = NULL
 ,@imagen IMAGE = NULL
 ,@nacimiento DATE = NULL
 ,@telefono VARCHAR(15) = NULL
 ,@email VARCHAR(50) = NULL
AS
 SET NOCOUNT OFF;

    UPDATE Persona SET 
      idPersona = @idPersona
     ,nombre = @nombre
     ,direccion = @direccion
     ,imagen = @imagen
     ,nacimiento = @nacimiento
     ,telefono = @telefono
     ,email = @email
    WHERE ( @idPersona=idPersona)


-- =====SELECT==================================
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[select_max_id_persona]    Script Date: 11/05/2017 12:46:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[select_max_id_persona](@idPersona int output)
as
begin
	select @idPersona = max(idPersona)
	from Persona
	return @idPersona
end
GO
/****** Object:  StoredProcedure [dbo].[sp_generate]    Script Date: 11/05/2017 12:46:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_generate]  
  @tableName AS VARCHAR(100)  
AS  
  
--CAPITALIZE TABLENAME  
SET @tableName = UPPER(LEFT(@tableName,1)) + RIGHT(@tableName, LEN(@tableName) -1)  
  
--SALTO DE LÍNEA  
DECLARE @nl AS CHAR  
SET @nl = CHAR(10) + CHAR(13)   
  
--CABECERA  
DECLARE @spHeaders AS VARCHAR(1000)  
SET @spHeaders = 'SET ANSI_NULLS ON' + @nl +  
'GO' + @nl +  
'SET QUOTED_IDENTIFIER ON' + @nl +  
'GO' + @nl +  
'-- =============================================' + @nl +  
'-- Author:  TU_NOMBRE' + @nl +  
'-- Create date: ' + CONVERT(VARCHAR, GETDATE(), 3) + @nl +  
'-- ============================================='  
  
DECLARE @table AS VARCHAR(MAX)  
DECLARE @column AS VARCHAR(MAX)  
DECLARE @data_type AS VARCHAR(MAX)  
DECLARE @length AS INT  
DECLARE @precision AS INT  
DECLARE @scale AS INT  
  
--PARÁMETROS  
DECLARE @spParameters AS VARCHAR(MAX) SET @spParameters = ''  
  
--LISTA DE CAMPOS  
DECLARE @fieldList AS VARCHAR(MAX) SET @fieldList = ''  
  
--LISTA DE CAMPOS PARA EL SET DEL UPDATE  
DECLARE @fieldSetList AS VARCHAR(MAX) SET @fieldSetList = ''  
  
--LISTA DE PARÁMETROS PARA EL INSERT  
DECLARE @insertParameters AS VARCHAR(MAX) SET @insertParameters = ''  
  
--CONDICIONES  
DECLARE @spConditions AS VARCHAR(MAX) SET @spConditions = ''  
  
DECLARE c CURSOR STATIC FOR  
select table_name, column_name, data_type, character_maximum_length,numeric_precision, numeric_scale from information_schema.columns where table_name = @tableName order by ordinal_position  
OPEN c FETCH NEXT FROM c INTO @table, @column, @data_type, @length, @precision, @scale  
WHILE @@FETCH_STATUS = 0 BEGIN  
  
 SET @spParameters = @spParameters + (CASE WHEN LEN(@spParameters) >0 THEN @nl + ' ,' ELSE '  ' END) + '@' + @column + ' ' + UPPER(@data_type) + (CASE @data_type WHEN 'VARCHAR' THEN '('+CAST(@length AS VARCHAR)+')' WHEN 'DECIMAL' THEN '('+CAST(@precision AS VARCHAR)+', '+CAST(@scale AS VARCHAR)+')' ELSE '' END) + ' = NULL'  
 SET @fieldList = @fieldList + (CASE WHEN LEN(@fieldList) >0 THEN @nl + '    ,' ELSE '' END) + @column  
 SET @spConditions = @spConditions + (CASE WHEN LEN(@spConditions) >0 THEN @nl + '   AND ' ELSE '' END) + '(@' + @column + ' IS NULL OR @' + @column + '=' + @column + ')'  
 SET @fieldSetList = @fieldSetList + (CASE WHEN LEN(@fieldSetList) >0 THEN @nl + '     ,' ELSE '      ' END) + @column + ' = @' + @column  
 SET @insertParameters = @insertParameters + (CASE WHEN LEN(@insertParameters) >0 THEN @nl + '    ,' ELSE '' END) + '@' + @column  
  
 FETCH NEXT FROM c INTO @table, @column, @data_type, @length, @precision, @scale  
END  
CLOSE c DEALLOCATE c  
  
--********************************  
--*********** SELECT *************  
--********************************  
DECLARE @SELECT AS VARCHAR(MAX)  
SET @SELECT = @spHeaders + @nl  
SET @SELECT = @SELECT + 'CREATE PROCEDURE ' + @tableName + '_Select' + @nl  
SET @SELECT = @SELECT + @spParameters + @nl  
SET @SELECT = @SELECT + 'AS' + @nl + ' SET NOCOUNT OFF;' + @nl + @nl  
SET @SELECT = @SELECT + '    SELECT ' + @fieldList + @nl  
SET @SELECT = @SELECT + '    FROM ' + @table + @nl  
SET @SELECT = @SELECt + '    WHERE ' + @spConditions + @nl  
  
--********************************  
--*********** UPDATE *************  
--********************************  
DECLARE @UPDATE AS VARCHAR(MAX)  
SET @UPDATE = @spHeaders + @nl  
SET @UPDATE = @UPDATE + 'CREATE PROCEDURE ' + @tableName + '_Update' + @nl  
SET @UPDATE = @UPDATE + @spParameters + @nl  
SET @UPDATE = @UPDATE + 'AS' + @nl + ' SET NOCOUNT OFF;' + @nl + @nl  
SET @UPDATE = @UPDATE + '    UPDATE ' + @table + ' SET ' + @nl  
SET @UPDATE = @UPDATE + @fieldSetList + @nl  
SET @UPDATE = @UPDATE + '    WHERE ' + @spConditions + @nl  
  
--********************************  
--*********** DELETE *************  
--********************************  
DECLARE @DELETE AS VARCHAR(MAX)  
SET @DELETE = @spHeaders + @nl  
SET @DELETE = @DELETE + 'CREATE PROCEDURE ' + @tableName + '_Delete' + @nl  
SET @DELETE = @DELETE + @spParameters + @nl  
SET @DELETE = @DELETE + 'AS' + @nl + ' SET NOCOUNT OFF;' + @nl + @nl  
SET @DELETE = @DELETE + '    DELETE FROM ' + @table + @nl  
SET @DELETE = @DELETE + '    WHERE ' + @spConditions + @nl  
  
--********************************  
--*********** INSERT *************  
--********************************  
DECLARE @INSERT AS VARCHAR(MAX)  
SET @INSERT = @spHeaders + @nl  
SET @INSERT = @INSERT + 'CREATE PROCEDURE ' + @tableName + '_Insert' + @nl  
SET @INSERT = @INSERT + @spParameters + @nl  
SET @INSERT = @INSERT + 'AS' + @nl + ' SET NOCOUNT OFF;' + @nl + @nl  
SET @INSERT = @INSERT + '    INSERT INTO ' + @table + '(' + @nl  
SET @INSERT = @INSERT + '     ' + @fieldList + @nl  
SET @INSERT = @INSERT + ' )' + @nl + ' VALUES(' + @nl + '     ' + @insertParameters + @nl  
SET @INSERT = @INSERT + ' )' + @nl  
  
--********************************  
--*********** EXISTS *************  
--********************************  
DECLARE @EXISTS AS VARCHAR(MAX)  
SET @EXISTS = @spHeaders + @nl  
SET @EXISTS = @EXISTS + 'CREATE PROCEDURE ' + @tableName + '_Exists' + @nl  
SET @EXISTS = @EXISTS + @spParameters + @nl  
SET @EXISTS = @EXISTS + ' ,@exists BIT OUT' + @nl  
SET @EXISTS = @EXISTS + 'AS' + @nl + ' SET NOCOUNT OFF;' + @nl + @nl  
SET @EXISTS = @EXISTS + '    IF EXISTS (' + @nl + ' SELECT ' + LEFT(@fieldList,CHARINDEX(@nl,@fieldList))  
SET @EXISTS = @EXISTS + '    FROM ' + @table + @nl  
SET @EXISTS = @EXISTS + '    WHERE ' + @spConditions + @nl + ' )' + @nl  
SET @EXISTS = @EXISTS + ' SET @exists = 1' + @nl + ' ELSE SET @exists = 0'  
  
--MOSTRAR GENERADOS  
PRINT + '-- =====INSERT==================================' + @nl + @INSERT  
PRINT + '-- =====DELETE==================================' + @nl + @DELETE  
PRINT + '-- =====UPDATE==================================' + @nl + @UPDATE  
PRINT + '-- =====SELECT==================================' + @nl + @SELECT  
PRINT + '-- =====EXISTS==================================' + @nl + @EXISTS  
GO
USE [master]
GO
ALTER DATABASE [dbTestPersona] SET  READ_WRITE 
GO
