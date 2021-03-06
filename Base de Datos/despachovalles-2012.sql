/*USE [master]
GO
/****** Object:  Database [despachovalles]    Script Date: 18/02/2018 05:17:57 p. m. ******/
CREATE DATABASE [despachovalles]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'despachovalles', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\despachovalles.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'despachovalles_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\despachovalles_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [despachovalles] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [despachovalles].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO*/
ALTER DATABASE [despachovalles] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [despachovalles] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [despachovalles] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [despachovalles] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [despachovalles] SET ARITHABORT OFF 
GO
ALTER DATABASE [despachovalles] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [despachovalles] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [despachovalles] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [despachovalles] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [despachovalles] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [despachovalles] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [despachovalles] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [despachovalles] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [despachovalles] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [despachovalles] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [despachovalles] SET  DISABLE_BROKER 
GO
ALTER DATABASE [despachovalles] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [despachovalles] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [despachovalles] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [despachovalles] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [despachovalles] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [despachovalles] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [despachovalles] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [despachovalles] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [despachovalles] SET  MULTI_USER 
GO
ALTER DATABASE [despachovalles] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [despachovalles] SET DB_CHAINING OFF 
GO
ALTER DATABASE [despachovalles] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [despachovalles] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [despachovalles]
GO
/****** Object:  User [gonzalo]    Script Date: 18/02/2018 05:17:57 p. m. ******/
CREATE USER [gonzalo] FOR LOGIN [gonzalo] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  StoredProcedure [dbo].[spdelete_appointment]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--eliminar cita
create proc [dbo].[spdelete_appointment]
@id int
as
delete from appointment
where id = @id

GO
/****** Object:  StoredProcedure [dbo].[spdelete_attorney]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--eliminar
create proc [dbo].[spdelete_attorney]
@id int
as
delete from attorney
where id = @id

GO
/****** Object:  StoredProcedure [dbo].[spdelete_custumer]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--eliminar
create proc [dbo].[spdelete_custumer]
@id int
as
delete from custumer
where id=@id

GO
/****** Object:  StoredProcedure [dbo].[spdelete_status_case_file]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--eliminar
create proc [dbo].[spdelete_status_case_file]
@id int
as
delete from type_custumer
where id = @id

GO
/****** Object:  StoredProcedure [dbo].[spdelete_type_case_file]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--eliminar
create proc [dbo].[spdelete_type_case_file]
@id int
as
delete from type_case_file
where id=@id

GO
/****** Object:  StoredProcedure [dbo].[spdelete_type_custumer]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--eliminar
create proc [dbo].[spdelete_type_custumer]
@id int
as
delete from type_custumer
where id = @id

GO
/****** Object:  StoredProcedure [dbo].[spdelete_type_payments]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--eliminar
create proc [dbo].[spdelete_type_payments]
@id int
as
delete from type_payments
where id = @id

GO
/****** Object:  StoredProcedure [dbo].[spInsert_appointment]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Insertar cita
CREATE proc [dbo].[spInsert_appointment]
@id int output,
@date_appountment date,
@custumer_id int,
@comments varchar(250)
as
insert into appointment(date_appountment,custumer_id,comments,created_at,updated_at)
values(@date_appountment,@custumer_id,@comments,GETDATE(),GETDATE())
GO
/****** Object:  StoredProcedure [dbo].[spinsert_attorney]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--insertar
create proc [dbo].[spinsert_attorney]
@id int output,
@name varchar(50),
@lastname varchar(100),
@rfc varchar(15),
@address varchar(250),
@cedula varchar(20)
as
insert into attorney(name,lastname,rfc,address,cedula,created_at,updated_at)
values(@name,@lastname,@rfc,@address,@cedula,GETDATE(),GETDATE())

GO
/****** Object:  StoredProcedure [dbo].[spinsert_custumer]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spinsert_custumer]
@id int output,
@name varchar(50),
@lastname varchar(150),
@phone varchar(12),
@movil varchar(12),
@email varchar(50),
@comments varchar(250),
@type_custumer_id int
as
insert into custumer(name,lastnmae,phone,movil,email,comments,type_custumer_id,created_at,updated_at)
values(@name,@lastname,@phone,@movil,@email,@comments,@type_custumer_id,GETDATE(),GETDATE())

GO
/****** Object:  StoredProcedure [dbo].[spinsert_status_case_file]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--insertar
CREATE proc [dbo].[spinsert_status_case_file]
@id int output,
@name varchar(50)
as
insert into status_case_file(name,created_at,updated)
values(@name,GETDATE(),GETDATE())
GO
/****** Object:  StoredProcedure [dbo].[spinsert_type_case_file]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spinsert_type_case_file]
@id int output,
@name varchar(50)
as insert into type_case_file (name, created_at,udated_at)
values (@name,GETDATE(),GETDATE())

GO
/****** Object:  StoredProcedure [dbo].[spinsert_type_custumer]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--insertar
create proc [dbo].[spinsert_type_custumer]
@id int output,
@name varchar(50)
as
insert into type_custumer (name,created_at,updated_at)
values(@name,GETDATE(),GETDATE())

GO
/****** Object:  StoredProcedure [dbo].[spinsert_type_payments]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--insertar
create proc [dbo].[spinsert_type_payments]
@id int output,
@name varchar(50)
as
insert into type_payments(name,created_at,updated_at)
values(@name,GETDATE(),GETDATE())

GO
/****** Object:  StoredProcedure [dbo].[spsearch_appointments_date]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--mostrar citas por fecha
CREATE proc [dbo].[spsearch_appointments_date]
@date date
as
select  dbo.appointment.id,dbo.custumer.name AS NombreCliente, dbo.appointment.date_appountment,dbo.appointment.comments,
dbo.appointment.comments,dbo.appointment.custumer_id from dbo.appointment INNER JOIN
dbo.custumer ON dbo.appointment.custumer_id = dbo.custumer.id
where dbo.appointment.date_appountment = @date
order by dbo.appointment.id asc
GO
/****** Object:  StoredProcedure [dbo].[spsearch_attorney]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--buscar por nombre
create proc [dbo].[spsearch_attorney]
@textsearch varchar(50)
as
select * from attorney
where name like @textsearch + '%'

GO
/****** Object:  StoredProcedure [dbo].[spsearch_custumer]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- buscar por nombre
create proc [dbo].[spsearch_custumer]
@textsearch varchar(50)
as
select dbo.custumer.id, dbo.custumer.name, dbo.custumer.lastnmae, dbo.custumer.phone, dbo.custumer.movil, dbo.custumer.email,dbo.custumer.comments,
dbo.custumer.type_custumer_id, dbo.type_custumer.name AS  TipoUsuario, dbo.custumer.created_at, dbo.custumer.updated_at
from dbo.custumer INNER JOIN dbo.type_custumer ON dbo.custumer.type_custumer_id = dbo.type_custumer.id
where dbo.custumer.name like @textsearch + '%'
order by dbo.custumer.id desc

GO
/****** Object:  StoredProcedure [dbo].[spsearch_status_case_file]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spsearch_status_case_file]
@textsearch varchar(50)
as
select * from status_case_file
where name like @textsearch + '%'

GO
/****** Object:  StoredProcedure [dbo].[spsearch_type_case_file]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--buscar por nombre
create proc [dbo].[spsearch_type_case_file]
@textsearch varchar(50)
as
select * from type_case_file
where name like @textsearch + '%'

GO
/****** Object:  StoredProcedure [dbo].[spsearch_type_custumer]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--buscar por nombre
create proc [dbo].[spsearch_type_custumer]
@textsearch varchar(50)
as
select * from type_custumer
where name like @textsearch + '%'

GO
/****** Object:  StoredProcedure [dbo].[spsearch_type_payments]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--buscar por nombre
create proc [dbo].[spsearch_type_payments]
@textsearch varchar(50)
as
select * from type_payments
where name like @textsearch + '%'

GO
/****** Object:  StoredProcedure [dbo].[spshow_attorney]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spshow_attorney]
as 
select top 200 * from attorney
order by id desc

GO
/****** Object:  StoredProcedure [dbo].[spshow_custumers]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--mostrar usuarios
create proc [dbo].[spshow_custumers]
as
select top 200 dbo.custumer.id, dbo.custumer.name, dbo.custumer.lastnmae, dbo.custumer.phone, dbo.custumer.movil, dbo.custumer.email,dbo.custumer.comments,
dbo.custumer.type_custumer_id, dbo.type_custumer.name AS  TipoUsuario, dbo.custumer.created_at, dbo.custumer.updated_at
from dbo.custumer INNER JOIN dbo.type_custumer ON dbo.custumer.type_custumer_id = dbo.type_custumer.id
order by dbo.custumer.id desc

GO
/****** Object:  StoredProcedure [dbo].[spshow_status_case_file]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--mostrar
create proc [dbo].[spshow_status_case_file]
as 
select top 200 * from status_case_file
order by id desc

GO
/****** Object:  StoredProcedure [dbo].[spshow_type_case_file]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--mostrar
create proc [dbo].[spshow_type_case_file]
as
select top 200 * from type_case_file
order by id desc

GO
/****** Object:  StoredProcedure [dbo].[spshow_type_custumer]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spshow_type_custumer]
as 
select top 200 * from type_custumer
order by id desc

GO
/****** Object:  StoredProcedure [dbo].[spshow_type_payments]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spshow_type_payments]
as 
select top 200 * from type_payments
order by id desc

GO
/****** Object:  StoredProcedure [dbo].[spupdate_appointment]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Ediatr cita
CREATE proc [dbo].[spupdate_appointment]
@id int,
@date_appountment date,
@custumer_id int,
@comments varchar(250)
as
update appointment set date_appountment = @date_appountment, custumer_id = @custumer_id,
comments = @comments where id = @id

GO
/****** Object:  StoredProcedure [dbo].[spupdate_attorney]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Editar
create proc [dbo].[spupdate_attorney]
@id int output,
@name varchar(50),
@lastname varchar(100),
@rfc varchar(15),
@address varchar(250),
@cedula varchar(20)
as
update attorney set name = @name, lastname = @lastname,
rfc = @rfc, address = @address, cedula = @cedula, updated_at = GETDATE()
where id = @id

GO
/****** Object:  StoredProcedure [dbo].[spupdate_custumer]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- editar 
create proc [dbo].[spupdate_custumer]
@id int,
@name varchar(50),
@lastname varchar(150),
@phone varchar(12),
@movil varchar(12),
@email varchar(50),
@comments varchar(250),
@type_custumer_id int
as
update custumer set name = @name, lastnmae = @lastname,phone=@phone,movil=@movil,email=@email,comments=@comments,type_custumer_id=@type_custumer_id
where id =@id

GO
/****** Object:  StoredProcedure [dbo].[spupdate_status_case_file]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spupdate_status_case_file]
@id int,
@name varchar(50)
as
update status_case_file set name = @name
where id = @id

GO
/****** Object:  StoredProcedure [dbo].[spupdate_type_case_file]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--editar
create proc [dbo].[spupdate_type_case_file]
@id int,
@name varchar(50)
as
update type_case_file set name=@name
where id=@id

GO
/****** Object:  StoredProcedure [dbo].[spupdate_type_custumer]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spupdate_type_custumer]
@id int,
@name varchar(50)
as
update type_custumer set name = @name
where id = @id

GO
/****** Object:  StoredProcedure [dbo].[spupdate_type_payments]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Editar
create proc [dbo].[spupdate_type_payments]
@id int,
@name varchar(50)
as
update type_payments set name = @name
where id = @id

GO
/****** Object:  Table [dbo].[appointment]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[appointment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date_appountment] [date] NOT NULL,
	[custumer_id] [int] NOT NULL,
	[comments] [varchar](250) NOT NULL,
	[created_at] [date] NOT NULL,
	[updated_at] [date] NOT NULL,
 CONSTRAINT [PK_appintments] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[attachment_case_file]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[attachment_case_file](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[binary_file] [varbinary](max) NOT NULL,
	[case_file_id] [int] NOT NULL,
	[created_at] [date] NOT NULL,
	[updated_at] [date] NOT NULL,
 CONSTRAINT [PK_attachment_case_file] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[attorney]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[attorney](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[lastname] [varchar](100) NOT NULL,
	[rfc] [varchar](15) NULL,
	[address] [varchar](250) NULL,
	[cedula] [varchar](20) NULL,
	[created_at] [date] NOT NULL,
	[updated_at] [date] NOT NULL,
 CONSTRAINT [PK_attorney] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[case_file]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[case_file](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type_case_file_id] [int] NOT NULL,
	[attorney_id] [int] NOT NULL,
	[custumer_id] [int] NOT NULL,
	[name_contrary] [varchar](150) NULL,
	[attorney_contrary] [varchar](150) NULL,
	[affair_contrary] [varchar](150) NULL,
	[court_contrary] [varchar](150) NULL,
	[status_id] [int] NOT NULL,
	[no_case_file] [varchar](15) NOT NULL,
	[comments] [varchar](250) NULL,
	[total] [money] NOT NULL,
	[created_at] [date] NOT NULL,
	[updated_at] [date] NOT NULL,
 CONSTRAINT [PK_case_file] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[custumer]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[custumer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[lastnmae] [varchar](150) NOT NULL,
	[phone] [varchar](12) NULL,
	[movil] [varchar](12) NULL,
	[email] [varchar](50) NULL,
	[comments] [varchar](250) NULL,
	[type_custumer_id] [int] NOT NULL,
	[created_at] [date] NOT NULL,
	[updated_at] [date] NULL,
 CONSTRAINT [PK_custumer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[custumer_attachment]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[custumer_attachment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[binary_file] [varbinary](max) NOT NULL,
	[custumer_id] [int] NOT NULL,
	[created_at] [date] NOT NULL,
	[update_at] [date] NOT NULL,
 CONSTRAINT [PK_custumer_attachment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[payment]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[casefile_id] [int] NOT NULL,
	[payment] [money] NOT NULL,
	[type_payment] [int] NOT NULL,
	[created_at] [date] NOT NULL,
	[updated_at] [date] NOT NULL,
 CONSTRAINT [PK_payment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[status_case_file]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[status_case_file](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[created_at] [date] NOT NULL,
	[updated] [date] NOT NULL,
 CONSTRAINT [PK_status_case_file] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[type_case_file]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[type_case_file](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[created_at] [date] NOT NULL,
	[udated_at] [date] NOT NULL,
 CONSTRAINT [PK_type_case_file] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[type_custumer]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[type_custumer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[created_at] [date] NOT NULL,
	[updated_at] [date] NOT NULL,
 CONSTRAINT [PK_type_attachment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[type_payments]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[type_payments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[created_at] [date] NOT NULL,
	[updated_at] [date] NOT NULL,
 CONSTRAINT [PK_typepayments] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[update]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[update](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[case_file_id] [int] NOT NULL,
	[description] [varbinary](50) NOT NULL,
	[created_at] [date] NOT NULL,
	[updated_at] [date] NOT NULL,
 CONSTRAINT [PK_update] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[user]    Script Date: 18/02/2018 05:17:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[attorney_id] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[lastname] [varchar](150) NOT NULL,
	[rol] [varchar](50) NOT NULL,
	[created_at] [date] NOT NULL,
	[updated_at] [date] NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[appointment] ON 

INSERT [dbo].[appointment] ([id], [date_appountment], [custumer_id], [comments], [created_at], [updated_at]) VALUES (1, CAST(0xA0180B00 AS Date), 1, N'comentarios sdfsdfsdfsdfd', CAST(0xE53D0B00 AS Date), CAST(0xE53D0B00 AS Date))
INSERT [dbo].[appointment] ([id], [date_appountment], [custumer_id], [comments], [created_at], [updated_at]) VALUES (6, CAST(0xE63D0B00 AS Date), 1, N'NO COMMENTS', CAST(0xE53D0B00 AS Date), CAST(0xE53D0B00 AS Date))
INSERT [dbo].[appointment] ([id], [date_appountment], [custumer_id], [comments], [created_at], [updated_at]) VALUES (7, CAST(0xF03D0B00 AS Date), 2, N'NO HAY COMMENTARIOS', CAST(0xE53D0B00 AS Date), CAST(0xE53D0B00 AS Date))
SET IDENTITY_INSERT [dbo].[appointment] OFF
SET IDENTITY_INSERT [dbo].[attorney] ON 

INSERT [dbo].[attorney] ([id], [name], [lastname], [rfc], [address], [cedula], [created_at], [updated_at]) VALUES (2, N'NAME11', N'APE11', N'RDC11', N'DIRE11', N'CED11', CAST(0xE23D0B00 AS Date), CAST(0xE23D0B00 AS Date))
SET IDENTITY_INSERT [dbo].[attorney] OFF
SET IDENTITY_INSERT [dbo].[custumer] ON 

INSERT [dbo].[custumer] ([id], [name], [lastnmae], [phone], [movil], [email], [comments], [type_custumer_id], [created_at], [updated_at]) VALUES (1, N'GONZA', N'ZAVALA MENDOZA', N'3815208', N'4811048410', N'GONZALOZAVALAMENDOZA@GMAIL.COM', N'COMENTARIOS....', 4, CAST(0xE43D0B00 AS Date), CAST(0xE43D0B00 AS Date))
INSERT [dbo].[custumer] ([id], [name], [lastnmae], [phone], [movil], [email], [comments], [type_custumer_id], [created_at], [updated_at]) VALUES (2, N'ALEJANDRA', N'MARTINEZ MARTINEZ', N'1231458', N'555478241', N'ALE@GMAIL.COM', N'NO HAY COMENTARIOS', 3, CAST(0xE53D0B00 AS Date), CAST(0xE53D0B00 AS Date))
SET IDENTITY_INSERT [dbo].[custumer] OFF
SET IDENTITY_INSERT [dbo].[status_case_file] ON 

INSERT [dbo].[status_case_file] ([id], [name], [created_at], [updated]) VALUES (1, N'EDI', CAST(0xE23D0B00 AS Date), CAST(0xE23D0B00 AS Date))
INSERT [dbo].[status_case_file] ([id], [name], [created_at], [updated]) VALUES (2, N'EDITADO', CAST(0xE23D0B00 AS Date), CAST(0xE23D0B00 AS Date))
SET IDENTITY_INSERT [dbo].[status_case_file] OFF
SET IDENTITY_INSERT [dbo].[type_case_file] ON 

INSERT [dbo].[type_case_file] ([id], [name], [created_at], [udated_at]) VALUES (2, N'PRUEBA', CAST(0xE13D0B00 AS Date), CAST(0xE13D0B00 AS Date))
INSERT [dbo].[type_case_file] ([id], [name], [created_at], [udated_at]) VALUES (3, N'PRUEBA2', CAST(0xE13D0B00 AS Date), CAST(0xE13D0B00 AS Date))
SET IDENTITY_INSERT [dbo].[type_case_file] OFF
SET IDENTITY_INSERT [dbo].[type_custumer] ON 

INSERT [dbo].[type_custumer] ([id], [name], [created_at], [updated_at]) VALUES (2, N'CLIENTE', CAST(0xE33D0B00 AS Date), CAST(0xE33D0B00 AS Date))
INSERT [dbo].[type_custumer] ([id], [name], [created_at], [updated_at]) VALUES (3, N'EMPRESA', CAST(0xE33D0B00 AS Date), CAST(0xE33D0B00 AS Date))
INSERT [dbo].[type_custumer] ([id], [name], [created_at], [updated_at]) VALUES (4, N'PROCURADOR', CAST(0xE33D0B00 AS Date), CAST(0xE33D0B00 AS Date))
SET IDENTITY_INSERT [dbo].[type_custumer] OFF
ALTER TABLE [dbo].[appointment]  WITH CHECK ADD  CONSTRAINT [FK_appointment_custumer] FOREIGN KEY([custumer_id])
REFERENCES [dbo].[custumer] ([id])
GO
ALTER TABLE [dbo].[appointment] CHECK CONSTRAINT [FK_appointment_custumer]
GO
ALTER TABLE [dbo].[attachment_case_file]  WITH CHECK ADD  CONSTRAINT [FK_attachment_case_file_case_file] FOREIGN KEY([case_file_id])
REFERENCES [dbo].[case_file] ([id])
GO
ALTER TABLE [dbo].[attachment_case_file] CHECK CONSTRAINT [FK_attachment_case_file_case_file]
GO
ALTER TABLE [dbo].[case_file]  WITH CHECK ADD  CONSTRAINT [FK_case_file_attorney] FOREIGN KEY([attorney_id])
REFERENCES [dbo].[attorney] ([id])
GO
ALTER TABLE [dbo].[case_file] CHECK CONSTRAINT [FK_case_file_attorney]
GO
ALTER TABLE [dbo].[case_file]  WITH CHECK ADD  CONSTRAINT [FK_case_file_custumer] FOREIGN KEY([custumer_id])
REFERENCES [dbo].[custumer] ([id])
GO
ALTER TABLE [dbo].[case_file] CHECK CONSTRAINT [FK_case_file_custumer]
GO
ALTER TABLE [dbo].[case_file]  WITH CHECK ADD  CONSTRAINT [FK_case_file_status_case_file] FOREIGN KEY([status_id])
REFERENCES [dbo].[status_case_file] ([id])
GO
ALTER TABLE [dbo].[case_file] CHECK CONSTRAINT [FK_case_file_status_case_file]
GO
ALTER TABLE [dbo].[case_file]  WITH CHECK ADD  CONSTRAINT [FK_case_file_type_case_file] FOREIGN KEY([type_case_file_id])
REFERENCES [dbo].[type_case_file] ([id])
GO
ALTER TABLE [dbo].[case_file] CHECK CONSTRAINT [FK_case_file_type_case_file]
GO
ALTER TABLE [dbo].[custumer]  WITH CHECK ADD  CONSTRAINT [FK_custumer_type_custumer] FOREIGN KEY([type_custumer_id])
REFERENCES [dbo].[type_custumer] ([id])
GO
ALTER TABLE [dbo].[custumer] CHECK CONSTRAINT [FK_custumer_type_custumer]
GO
ALTER TABLE [dbo].[custumer_attachment]  WITH CHECK ADD  CONSTRAINT [FK_custumer_attachment_custumer] FOREIGN KEY([custumer_id])
REFERENCES [dbo].[custumer] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[custumer_attachment] CHECK CONSTRAINT [FK_custumer_attachment_custumer]
GO
ALTER TABLE [dbo].[payment]  WITH CHECK ADD  CONSTRAINT [FK_payment_case_file] FOREIGN KEY([casefile_id])
REFERENCES [dbo].[case_file] ([id])
GO
ALTER TABLE [dbo].[payment] CHECK CONSTRAINT [FK_payment_case_file]
GO
ALTER TABLE [dbo].[payment]  WITH CHECK ADD  CONSTRAINT [FK_payment_type_payments] FOREIGN KEY([type_payment])
REFERENCES [dbo].[type_payments] ([id])
GO
ALTER TABLE [dbo].[payment] CHECK CONSTRAINT [FK_payment_type_payments]
GO
ALTER TABLE [dbo].[update]  WITH CHECK ADD  CONSTRAINT [FK_update_case_file] FOREIGN KEY([case_file_id])
REFERENCES [dbo].[case_file] ([id])
GO
ALTER TABLE [dbo].[update] CHECK CONSTRAINT [FK_update_case_file]
GO
ALTER TABLE [dbo].[user]  WITH CHECK ADD  CONSTRAINT [FK_user_attorney] FOREIGN KEY([attorney_id])
REFERENCES [dbo].[attorney] ([id])
GO
ALTER TABLE [dbo].[user] CHECK CONSTRAINT [FK_user_attorney]
GO
USE [master]
GO
ALTER DATABASE [despachovalles] SET  READ_WRITE 
GO
