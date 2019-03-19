CREATE DATA  [HospitalDB]
USE [HospitalDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_CheckHoliday]    Script Date: 31.01.2019 05:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CheckHoliday]
@workerType INT
AS
BEGIN
	DECLARE @workerID INT
	DECLARE @finishDate Date
	DECLARE HolidayCursor CURSOR FOR  
	SELECT worker_id,DATEADD(day,duration,[date]) AS 'FinisDate' FROM WorkerLeave
	WHERE is_deleted=0 AND is_finished=0 AND worker_type=@workerType
	OPEN HolidayCursor
	WHILE @@FETCH_STATUS = 0  
	   BEGIN  
	   FETCH NEXT FROM HolidayCursor INTO @workerID,@finishDate
		IF (SELECT GETDATE()) > @finishDate
		BEGIN
			IF @workerType=1
			BEGIN
				DECLARE @tempDoc INT =(SELECT TOP 1 temp_doc FROM WorkerLeave WHERE worker_type=@workerType AND worker_id=@workerID AND is_finished=0)
				UPDATE Doctor SET isTemp=0 WHERE id=@tempDoc;
				UPDATE Doctor SET onHoliday=0 WHERE id=@workerID;
				UPDATE WorkerLeave SET is_finished=1 WHERE worker_id=@workerID AND worker_type=@workerType AND is_finished=0;
			END
			IF @workerType=2
			BEGIN
				UPDATE WorkerLeave SET is_finished=1 WHERE worker_type=@workerType AND worker_id=@workerID AND is_finished=0
				IF @@ROWCOUNT > 0
				BEGIN
					UPDATE Nurse SET onHoliday=0 WHERE id=@workerID
				END
			END
		END
	   END
	CLOSE HolidayCursor
	DEALLOCATE HolidayCursor
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetDate]    Script Date: 31.01.2019 05:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetDate]
	
AS
BEGIN
	SELECT getdate()
END

GO
/****** Object:  StoredProcedure [dbo].[sp_NumberOfDailyPatient]    Script Date: 31.01.2019 05:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_NumberOfDailyPatient] 
	@DocID INT
AS
BEGIN
	DECLARE @PatientCount INT
	DECLARE @Tarih Date=(select convert(varchar, getdate(), 23))
	DECLARE @Tarih2 Date=DATEADD(day,1,@Tarih)
	SET @PatientCount= (SELECT COUNT(1) FROM Appointment 
	WHERE appointment_date<@tarih2 AND appointment_date>@tarih AND doctor_id=@DocID)
	RETURN @PatientCount
END

GO
/****** Object:  StoredProcedure [dbo].[sp_SetHoliday]    Script Date: 31.01.2019 05:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SetHoliday]
	@workerID INT,
	@workerType INT
AS
BEGIN
	IF @workerType=1
	BEGIN
		UPDATE Doctor SET onHoliday=1 WHERE id=@workerID
	END
	IF @workerType=2
	BEGIN
		UPDATE Nurse SET onHoliday=1 WHERE id=@workerID
	END
END

GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 31.01.2019 05:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[doctor_id] [int] NOT NULL,
	[patient_id] [int] NOT NULL,
	[unit_id] [int] NOT NULL,
	[polyclinic_id] [int] NOT NULL,
	[appointment_date] [datetime] NOT NULL,
	[preemptor] [bit] NOT NULL,
	[situation] [bit] NOT NULL,
	[is_deleted] [bit] NOT NULL,
 CONSTRAINT [PK__Appointm__EBC4FFD8A7111209] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 31.01.2019 05:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[identity_no] [nvarchar](20) NOT NULL,
	[full_name] [nvarchar](100) NOT NULL,
	[birthdate] [date] NOT NULL,
	[phone] [nvarchar](20) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[address] [nvarchar](300) NOT NULL,
	[annual_leave] [tinyint] NOT NULL,
	[annual_leave_report] [tinyint] NOT NULL,
	[daily_patients] [int] NOT NULL,
	[extra_patients] [int] NOT NULL,
	[salary] [decimal](18, 0) NOT NULL,
	[adult] [bit] NOT NULL,
	[operation] [bit] NOT NULL,
	[number_of_operated_person] [int] NOT NULL,
	[unit_id] [int] NOT NULL,
	[polyclinic_id] [int] NOT NULL,
	[onHoliday] [bit] NOT NULL,
	[isTemp] [bit] NOT NULL,
	[is_deleted] [bit] NOT NULL,
 CONSTRAINT [PK__Doctor__9B8490DC86F06FB9] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Nurse]    Script Date: 31.01.2019 05:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nurse](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[unit_id] [int] NOT NULL,
	[identity_no] [nvarchar](11) NOT NULL,
	[full_name] [nvarchar](100) NOT NULL,
	[phone] [nvarchar](11) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[address] [nvarchar](500) NOT NULL,
	[birth_date] [datetime] NOT NULL,
	[annual_leave] [tinyint] NOT NULL,
	[annual_leave_report] [tinyint] NOT NULL,
	[salary] [decimal](10, 2) NOT NULL,
	[work_type] [tinyint] NOT NULL,
	[chief_nurse] [bit] NOT NULL,
	[polyclinic_ID] [int] NOT NULL,
	[onHoliday] [bit] NOT NULL,
	[is_deleted] [bit] NOT NULL,
 CONSTRAINT [PK_nurseid] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Patient]    Script Date: 31.01.2019 05:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[identity_no] [nvarchar](11) NOT NULL,
	[full_name] [nvarchar](100) NOT NULL,
	[birthdate] [date] NOT NULL,
	[phone] [nvarchar](11) NOT NULL,
	[address] [nvarchar](300) NOT NULL,
	[blood_type] [int] NOT NULL,
	[social_security] [int] NOT NULL,
	[is_deleted] [bit] NULL,
 CONSTRAINT [PK__Sick__1F450E985CC5AD7F] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Polyclinic]    Script Date: 31.01.2019 05:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Polyclinic](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[address] [nvarchar](500) NOT NULL,
	[is_deleted] [bit] NOT NULL,
 CONSTRAINT [PK_polyclinic] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Unit]    Script Date: 31.01.2019 05:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[polyclinic_id] [int] NOT NULL,
	[unit_name] [nvarchar](50) NOT NULL,
	[unit_maxDoc] [tinyint] NOT NULL,
	[unit_maxNurse] [tinyint] NOT NULL,
	[is_deleted] [bit] NOT NULL,
 CONSTRAINT [PK__unit__3214EC27AA3BA4C1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 31.01.2019 05:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[full_name] [nvarchar](50) NOT NULL,
	[wrongCount] [int] NOT NULL,
	[isActive] [bit] NOT NULL,
	[is_deleted] [bit] NOT NULL,
 CONSTRAINT [PK_USERS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkerLeave]    Script Date: 31.01.2019 05:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkerLeave](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[worker_id] [int] NOT NULL,
	[worker_type] [int] NOT NULL,
	[duration] [int] NOT NULL,
	[leave_type] [int] NOT NULL,
	[date] [date] NOT NULL,
	[is_finished] [bit] NOT NULL,
	[temp_doc] [int] NOT NULL,
	[is_deleted] [bit] NOT NULL,
 CONSTRAINT [PK_WorkerLeave] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Appointment] ON 

GO
INSERT [dbo].[Appointment] ([id], [doctor_id], [patient_id], [unit_id], [polyclinic_id], [appointment_date], [preemptor], [situation], [is_deleted]) VALUES (1, 1, 1, 1, 1, CAST(0x0000A9DF00107AC0 AS DateTime), 0, 1, 0)
GO
INSERT [dbo].[Appointment] ([id], [doctor_id], [patient_id], [unit_id], [polyclinic_id], [appointment_date], [preemptor], [situation], [is_deleted]) VALUES (2, 1, 2, 2, 2, CAST(0x0000A9DF00107AC0 AS DateTime), 1, 1, 0)
GO
INSERT [dbo].[Appointment] ([id], [doctor_id], [patient_id], [unit_id], [polyclinic_id], [appointment_date], [preemptor], [situation], [is_deleted]) VALUES (4, 1, 1, 1, 3, CAST(0x0000A9DF00107AC0 AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[Appointment] ([id], [doctor_id], [patient_id], [unit_id], [polyclinic_id], [appointment_date], [preemptor], [situation], [is_deleted]) VALUES (9, 5, 2, 1, 1, CAST(0x0000A9DF0089D516 AS DateTime), 1, 0, 0)
GO
INSERT [dbo].[Appointment] ([id], [doctor_id], [patient_id], [unit_id], [polyclinic_id], [appointment_date], [preemptor], [situation], [is_deleted]) VALUES (19, 5, 2, 1, 2, CAST(0x0000A9DF009A2007 AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[Appointment] ([id], [doctor_id], [patient_id], [unit_id], [polyclinic_id], [appointment_date], [preemptor], [situation], [is_deleted]) VALUES (21, 5, 1, 1, 1, CAST(0x0000A9DF00A72A0F AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[Appointment] ([id], [doctor_id], [patient_id], [unit_id], [polyclinic_id], [appointment_date], [preemptor], [situation], [is_deleted]) VALUES (25, 1, 2, 2, 1, CAST(0x0000A9DF014C5042 AS DateTime), 0, 0, 0)
GO
INSERT [dbo].[Appointment] ([id], [doctor_id], [patient_id], [unit_id], [polyclinic_id], [appointment_date], [preemptor], [situation], [is_deleted]) VALUES (26, 6, 2, 1, 2, CAST(0x0000A9E300400C5D AS DateTime), 0, 1, 0)
GO
INSERT [dbo].[Appointment] ([id], [doctor_id], [patient_id], [unit_id], [polyclinic_id], [appointment_date], [preemptor], [situation], [is_deleted]) VALUES (1026, 7, 2, 7, 1, CAST(0x0000A9E60049FB90 AS DateTime), 0, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Appointment] OFF
GO
SET IDENTITY_INSERT [dbo].[Doctor] ON 

GO
INSERT [dbo].[Doctor] ([id], [identity_no], [full_name], [birthdate], [phone], [email], [address], [annual_leave], [annual_leave_report], [daily_patients], [extra_patients], [salary], [adult], [operation], [number_of_operated_person], [unit_id], [polyclinic_id], [onHoliday], [isTemp], [is_deleted]) VALUES (1, N'11111', N'Kamil', CAST(0x3AF90A00 AS Date), N'5455555', N'c@c.com', N'pendik', 0, 0, 3, 20, CAST(10000 AS Decimal(18, 0)), 0, 0, 0, 11, 2, 0, 0, 0)
GO
INSERT [dbo].[Doctor] ([id], [identity_no], [full_name], [birthdate], [phone], [email], [address], [annual_leave], [annual_leave_report], [daily_patients], [extra_patients], [salary], [adult], [operation], [number_of_operated_person], [unit_id], [polyclinic_id], [onHoliday], [isTemp], [is_deleted]) VALUES (5, N'22222', N'Murat', CAST(0x3AF90A00 AS Date), N'5454554545', N'qwewqeqwe', N'qweqweqweqweqw', 0, 0, 20, 20, CAST(4000 AS Decimal(18, 0)), 0, 0, 0, 9, 1, 0, 0, 0)
GO
INSERT [dbo].[Doctor] ([id], [identity_no], [full_name], [birthdate], [phone], [email], [address], [annual_leave], [annual_leave_report], [daily_patients], [extra_patients], [salary], [adult], [operation], [number_of_operated_person], [unit_id], [polyclinic_id], [onHoliday], [isTemp], [is_deleted]) VALUES (6, N'12312312412', N'Yavuz ÜNALAN', CAST(0x3A3F0B00 AS Date), N'555 444 44 12', N'a@a.com', N'qweqwew', 0, 0, 20, 20, CAST(5500 AS Decimal(18, 0)), 1, 1, 0, 9, 1, 0, 0, 0)
GO
INSERT [dbo].[Doctor] ([id], [identity_no], [full_name], [birthdate], [phone], [email], [address], [annual_leave], [annual_leave_report], [daily_patients], [extra_patients], [salary], [adult], [operation], [number_of_operated_person], [unit_id], [polyclinic_id], [onHoliday], [isTemp], [is_deleted]) VALUES (7, N'11122233344', N'Yakup ÜNALAN', CAST(0x3E3F0B00 AS Date), N'555 444 33 22', N'b@b.com', N'qweqweqweqwe', 0, 0, 20, 20, CAST(50000 AS Decimal(18, 0)), 1, 1, 0, 9, 1, 0, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[Doctor] OFF
GO
SET IDENTITY_INSERT [dbo].[Nurse] ON 

GO
INSERT [dbo].[Nurse] ([id], [unit_id], [identity_no], [full_name], [phone], [email], [address], [birth_date], [annual_leave], [annual_leave_report], [salary], [work_type], [chief_nurse], [polyclinic_ID], [onHoliday], [is_deleted]) VALUES (1, 11, N'123123', N'Asuman K.', N'555221444', N'qwe', N'qweqwe', CAST(0x0000A9DC0040D7DD AS DateTime), 0, 0, CAST(123.00 AS Decimal(10, 2)), 0, 1, 2, 0, 0)
GO
INSERT [dbo].[Nurse] ([id], [unit_id], [identity_no], [full_name], [phone], [email], [address], [birth_date], [annual_leave], [annual_leave_report], [salary], [work_type], [chief_nurse], [polyclinic_ID], [onHoliday], [is_deleted]) VALUES (3, 9, N'123123', N'Alev K.', N'1122154545', N'qwe', N'qweqwe', CAST(0x0000A9DC0040D7DD AS DateTime), 0, 0, CAST(123.00 AS Decimal(10, 2)), 0, 0, 1, 0, 0)
GO
INSERT [dbo].[Nurse] ([id], [unit_id], [identity_no], [full_name], [phone], [email], [address], [birth_date], [annual_leave], [annual_leave_report], [salary], [work_type], [chief_nurse], [polyclinic_ID], [onHoliday], [is_deleted]) VALUES (6, 9, N'1540', N'Eyþan A.', N'sadasdsa', N'qweqweqw', N'dasdasdas', CAST(0x0000A9DF014BAFD6 AS DateTime), 0, 0, CAST(3100.00 AS Decimal(10, 2)), 0, 1, 1, 0, 1)
GO
SET IDENTITY_INSERT [dbo].[Nurse] OFF
GO
SET IDENTITY_INSERT [dbo].[Patient] ON 

GO
INSERT [dbo].[Patient] ([id], [identity_no], [full_name], [birthdate], [phone], [address], [blood_type], [social_security], [is_deleted]) VALUES (1, N'11938187244', N'qweqwqwe', CAST(0x373F0B00 AS Date), N'qweqw', N'qweqw', 1, 0, 0)
GO
INSERT [dbo].[Patient] ([id], [identity_no], [full_name], [birthdate], [phone], [address], [blood_type], [social_security], [is_deleted]) VALUES (2, N'11938187244', N'yavuz', CAST(0x233F0B00 AS Date), N'555555', N'eqweqweqwe', 4, 0, 0)
GO
INSERT [dbo].[Patient] ([id], [identity_no], [full_name], [birthdate], [phone], [address], [blood_type], [social_security], [is_deleted]) VALUES (3, N'1213221', N'qweqwe', CAST(0x3A3F0B00 AS Date), N'85455', N'qwewqewq', 5, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Patient] OFF
GO
SET IDENTITY_INSERT [dbo].[Polyclinic] ON 

GO
INSERT [dbo].[Polyclinic] ([id], [name], [address], [is_deleted]) VALUES (1, N'Pendik Devlet', N'Pendik / Ýstanbul', 0)
GO
INSERT [dbo].[Polyclinic] ([id], [name], [address], [is_deleted]) VALUES (2, N'Kartal Devlet', N'Kartal / Ýstanbul', 0)
GO
INSERT [dbo].[Polyclinic] ([id], [name], [address], [is_deleted]) VALUES (3, N'Tuzla Devlet', N'Tuzla / Ýstanbul', 0)
GO
SET IDENTITY_INSERT [dbo].[Polyclinic] OFF
GO
SET IDENTITY_INSERT [dbo].[Unit] ON 

GO
INSERT [dbo].[Unit] ([id], [polyclinic_id], [unit_name], [unit_maxDoc], [unit_maxNurse], [is_deleted]) VALUES (1, 3, N'KBB', 20, 20, 0)
GO
INSERT [dbo].[Unit] ([id], [polyclinic_id], [unit_name], [unit_maxDoc], [unit_maxNurse], [is_deleted]) VALUES (2, 2, N'deneme3', 20, 20, 0)
GO
INSERT [dbo].[Unit] ([id], [polyclinic_id], [unit_name], [unit_maxDoc], [unit_maxNurse], [is_deleted]) VALUES (7, 1, N'KBB', 20, 20, 0)
GO
INSERT [dbo].[Unit] ([id], [polyclinic_id], [unit_name], [unit_maxDoc], [unit_maxNurse], [is_deleted]) VALUES (8, 1, N'Dahiliye', 20, 20, 0)
GO
INSERT [dbo].[Unit] ([id], [polyclinic_id], [unit_name], [unit_maxDoc], [unit_maxNurse], [is_deleted]) VALUES (9, 1, N'Göz Hastalýklarý', 20, 20, 0)
GO
INSERT [dbo].[Unit] ([id], [polyclinic_id], [unit_name], [unit_maxDoc], [unit_maxNurse], [is_deleted]) VALUES (10, 1, N'Göðüs Hastalýklarý', 20, 20, 0)
GO
INSERT [dbo].[Unit] ([id], [polyclinic_id], [unit_name], [unit_maxDoc], [unit_maxNurse], [is_deleted]) VALUES (11, 2, N'Göðüs Hastalýklarý', 20, 20, 0)
GO
INSERT [dbo].[Unit] ([id], [polyclinic_id], [unit_name], [unit_maxDoc], [unit_maxNurse], [is_deleted]) VALUES (12, 2, N'KBB', 20, 20, 0)
GO
INSERT [dbo].[Unit] ([id], [polyclinic_id], [unit_name], [unit_maxDoc], [unit_maxNurse], [is_deleted]) VALUES (13, 3, N'Kadýn Doðum', 20, 20, 0)
GO
INSERT [dbo].[Unit] ([id], [polyclinic_id], [unit_name], [unit_maxDoc], [unit_maxNurse], [is_deleted]) VALUES (14, 3, N'Göðüs Hastalýklarý', 20, 20, 0)
GO
INSERT [dbo].[Unit] ([id], [polyclinic_id], [unit_name], [unit_maxDoc], [unit_maxNurse], [is_deleted]) VALUES (15, 3, N'Dahiliye', 20, 20, 0)
GO
SET IDENTITY_INSERT [dbo].[Unit] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

GO
INSERT [dbo].[Users] ([id], [username], [password], [full_name], [wrongCount], [isActive], [is_deleted]) VALUES (7, N'skyfall3406', N'kasap3406', N'Yavuz ÜNLÜ', 0, 1, 0)
GO
INSERT [dbo].[Users] ([id], [username], [password], [full_name], [wrongCount], [isActive], [is_deleted]) VALUES (8, N'darkleon', N'kasap3406', N'yakup', 0, 1, 0)
GO
INSERT [dbo].[Users] ([id], [username], [password], [full_name], [wrongCount], [isActive], [is_deleted]) VALUES (9, N'a@a.com', N'11938187244', N'Yavuz', 0, 1, 0)
GO
INSERT [dbo].[Users] ([id], [username], [password], [full_name], [wrongCount], [isActive], [is_deleted]) VALUES (10, N'b@b.com', N'11122233344', N'Yakup ÜNLÜ', 0, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[WorkerLeave] ON 

GO
INSERT [dbo].[WorkerLeave] ([id], [worker_id], [worker_type], [duration], [leave_type], [date], [is_finished], [temp_doc], [is_deleted]) VALUES (4, 1, 1, 1, 2, CAST(0x383F0B00 AS Date), 1, 0, 0)
GO
INSERT [dbo].[WorkerLeave] ([id], [worker_id], [worker_type], [duration], [leave_type], [date], [is_finished], [temp_doc], [is_deleted]) VALUES (11, 1, 2, 1, 1, CAST(0x383F0B00 AS Date), 1, 0, 0)
GO
INSERT [dbo].[WorkerLeave] ([id], [worker_id], [worker_type], [duration], [leave_type], [date], [is_finished], [temp_doc], [is_deleted]) VALUES (12, 1, 2, 1, 1, CAST(0x383F0B00 AS Date), 1, 0, 0)
GO
INSERT [dbo].[WorkerLeave] ([id], [worker_id], [worker_type], [duration], [leave_type], [date], [is_finished], [temp_doc], [is_deleted]) VALUES (18, 6, 1, 1, 1, CAST(0x383F0B00 AS Date), 1, 1, 0)
GO
INSERT [dbo].[WorkerLeave] ([id], [worker_id], [worker_type], [duration], [leave_type], [date], [is_finished], [temp_doc], [is_deleted]) VALUES (23, 6, 1, 20, 1, CAST(0x253F0B00 AS Date), 1, 1, 0)
GO
INSERT [dbo].[WorkerLeave] ([id], [worker_id], [worker_type], [duration], [leave_type], [date], [is_finished], [temp_doc], [is_deleted]) VALUES (24, 6, 2, 1, 1, CAST(0x383F0B00 AS Date), 1, 0, 0)
GO
INSERT [dbo].[WorkerLeave] ([id], [worker_id], [worker_type], [duration], [leave_type], [date], [is_finished], [temp_doc], [is_deleted]) VALUES (25, 1, 1, 1, 1, CAST(0x383F0B00 AS Date), 1, 6, 0)
GO
INSERT [dbo].[WorkerLeave] ([id], [worker_id], [worker_type], [duration], [leave_type], [date], [is_finished], [temp_doc], [is_deleted]) VALUES (26, 1, 1, 1, 1, CAST(0x383F0B00 AS Date), 1, 6, 0)
GO
INSERT [dbo].[WorkerLeave] ([id], [worker_id], [worker_type], [duration], [leave_type], [date], [is_finished], [temp_doc], [is_deleted]) VALUES (27, 1, 2, 1, 1, CAST(0x383F0B00 AS Date), 1, 0, 0)
GO
INSERT [dbo].[WorkerLeave] ([id], [worker_id], [worker_type], [duration], [leave_type], [date], [is_finished], [temp_doc], [is_deleted]) VALUES (28, 1, 1, 1, 1, CAST(0x383F0B00 AS Date), 1, 5, 0)
GO
INSERT [dbo].[WorkerLeave] ([id], [worker_id], [worker_type], [duration], [leave_type], [date], [is_finished], [temp_doc], [is_deleted]) VALUES (29, 1, 2, 1, 1, CAST(0x363F0B00 AS Date), 1, 0, 0)
GO
INSERT [dbo].[WorkerLeave] ([id], [worker_id], [worker_type], [duration], [leave_type], [date], [is_finished], [temp_doc], [is_deleted]) VALUES (30, 1, 1, 1, 1, CAST(0x383F0B00 AS Date), 1, 5, 0)
GO
INSERT [dbo].[WorkerLeave] ([id], [worker_id], [worker_type], [duration], [leave_type], [date], [is_finished], [temp_doc], [is_deleted]) VALUES (31, 1, 2, 1, 1, CAST(0x383F0B00 AS Date), 1, 0, 0)
GO
INSERT [dbo].[WorkerLeave] ([id], [worker_id], [worker_type], [duration], [leave_type], [date], [is_finished], [temp_doc], [is_deleted]) VALUES (32, 1, 2, 1, 1, CAST(0x3A3F0B00 AS Date), 1, 0, 0)
GO
INSERT [dbo].[WorkerLeave] ([id], [worker_id], [worker_type], [duration], [leave_type], [date], [is_finished], [temp_doc], [is_deleted]) VALUES (33, 1, 2, 1, 1, CAST(0x383F0B00 AS Date), 1, 0, 0)
GO
INSERT [dbo].[WorkerLeave] ([id], [worker_id], [worker_type], [duration], [leave_type], [date], [is_finished], [temp_doc], [is_deleted]) VALUES (34, 1, 2, 1, 1, CAST(0x383F0B00 AS Date), 1, 0, 0)
GO
INSERT [dbo].[WorkerLeave] ([id], [worker_id], [worker_type], [duration], [leave_type], [date], [is_finished], [temp_doc], [is_deleted]) VALUES (35, 1, 2, 1, 1, CAST(0x383F0B00 AS Date), 1, 0, 0)
GO
INSERT [dbo].[WorkerLeave] ([id], [worker_id], [worker_type], [duration], [leave_type], [date], [is_finished], [temp_doc], [is_deleted]) VALUES (36, 1, 1, 1, 1, CAST(0x383F0B00 AS Date), 1, 6, 0)
GO
INSERT [dbo].[WorkerLeave] ([id], [worker_id], [worker_type], [duration], [leave_type], [date], [is_finished], [temp_doc], [is_deleted]) VALUES (37, 1, 1, 25, 1, CAST(0x173F0B00 AS Date), 1, 5, 0)
GO
SET IDENTITY_INSERT [dbo].[WorkerLeave] OFF
GO
ALTER TABLE [dbo].[Appointment] ADD  CONSTRAINT [DF_Appointment_is_deleted]  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[Doctor] ADD  CONSTRAINT [DF_Doctor_AnnualLeave]  DEFAULT ((0)) FOR [annual_leave]
GO
ALTER TABLE [dbo].[Doctor] ADD  CONSTRAINT [DF_Doctor_PaidAnnualLeave]  DEFAULT ((0)) FOR [annual_leave_report]
GO
ALTER TABLE [dbo].[Doctor] ADD  CONSTRAINT [DF_Doctor_daily_patients]  DEFAULT ((20)) FOR [daily_patients]
GO
ALTER TABLE [dbo].[Doctor] ADD  CONSTRAINT [DF_Doctor_extra_patients]  DEFAULT ((20)) FOR [extra_patients]
GO
ALTER TABLE [dbo].[Doctor] ADD  CONSTRAINT [DF_Doctor_number_of_operated_person]  DEFAULT ((0)) FOR [number_of_operated_person]
GO
ALTER TABLE [dbo].[Doctor] ADD  CONSTRAINT [DF_Doctor_onHoliday]  DEFAULT ((0)) FOR [onHoliday]
GO
ALTER TABLE [dbo].[Doctor] ADD  CONSTRAINT [DF_Doctor_isTemp]  DEFAULT ((0)) FOR [isTemp]
GO
ALTER TABLE [dbo].[Doctor] ADD  CONSTRAINT [DF_Doctor_is_deleted]  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[Nurse] ADD  CONSTRAINT [DF_Nurse_annual_leave]  DEFAULT ((0)) FOR [annual_leave]
GO
ALTER TABLE [dbo].[Nurse] ADD  CONSTRAINT [DF_Nurse_annual_leave_report]  DEFAULT ((0)) FOR [annual_leave_report]
GO
ALTER TABLE [dbo].[Nurse] ADD  CONSTRAINT [DF_Nurse_onHoliday]  DEFAULT ((0)) FOR [onHoliday]
GO
ALTER TABLE [dbo].[Nurse] ADD  CONSTRAINT [DF_Nurse_is_deleted]  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[Patient] ADD  CONSTRAINT [DF_Patient_is_deleted]  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[Polyclinic] ADD  CONSTRAINT [DF_Polyclinic_is_deleted]  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[Unit] ADD  CONSTRAINT [DF_Unit_unit_maxDoc]  DEFAULT ((20)) FOR [unit_maxDoc]
GO
ALTER TABLE [dbo].[Unit] ADD  CONSTRAINT [DF_Unit_unit_maxNurse]  DEFAULT ((20)) FOR [unit_maxNurse]
GO
ALTER TABLE [dbo].[Unit] ADD  CONSTRAINT [DF_Unit_is_deleted]  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_USERS_password]  DEFAULT ((123456)) FOR [password]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_USERS_wrongCount]  DEFAULT ((0)) FOR [wrongCount]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_USERS_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_is_deleted]  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[WorkerLeave] ADD  CONSTRAINT [DF_WorkerLeave_date]  DEFAULT (getdate()) FOR [date]
GO
ALTER TABLE [dbo].[WorkerLeave] ADD  CONSTRAINT [DF_WorkerLeave_is_finished]  DEFAULT ((0)) FOR [is_finished]
GO
ALTER TABLE [dbo].[WorkerLeave] ADD  CONSTRAINT [DF_WorkerLeave_temp_doc]  DEFAULT ((0)) FOR [temp_doc]
GO
ALTER TABLE [dbo].[WorkerLeave] ADD  CONSTRAINT [DF_WorkerLeave_is_deleted]  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Doctor] FOREIGN KEY([doctor_id])
REFERENCES [dbo].[Doctor] ([id])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_Doctor]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Patient] FOREIGN KEY([patient_id])
REFERENCES [dbo].[Patient] ([id])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_Patient]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_Doctor_Unit] FOREIGN KEY([unit_id])
REFERENCES [dbo].[Unit] ([id])
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_Doctor_Unit]
GO
ALTER TABLE [dbo].[Nurse]  WITH CHECK ADD  CONSTRAINT [FK_Nurse_Unit] FOREIGN KEY([unit_id])
REFERENCES [dbo].[Unit] ([id])
GO
ALTER TABLE [dbo].[Nurse] CHECK CONSTRAINT [FK_Nurse_Unit]
GO
ALTER TABLE [dbo].[Unit]  WITH CHECK ADD  CONSTRAINT [FK_Unit_Polyclinic] FOREIGN KEY([polyclinic_id])
REFERENCES [dbo].[Polyclinic] ([id])
GO
ALTER TABLE [dbo].[Unit] CHECK CONSTRAINT [FK_Unit_Polyclinic]
GO
/****** Object:  Trigger [dbo].[checkPatientNumber]    Script Date: 31.01.2019 05:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[checkPatientNumber]
ON	[dbo].[Appointment]
AFTER INSERT
AS
	DECLARE @doctor_id INT =(SELECT I.doctor_id FROM inserted I)
	DECLARE @isTemp bit
	DECLARE @dp INT
	DECLARE @dpr INT
	SELECT @dp=d.daily_patients,@dpr=D.extra_patients,@isTemp=D.isTemp FROM Doctor D WHERE D.id=@doctor_id
	declare @count int
	EXEC @count=[dbo].[sp_NumberOfDailyPatient] @DocID= @doctor_id
	IF @isTemp = 0
	BEGIN
		IF @count > @dp
		BEGIN
		RAISERROR ('Doctor has reached to daily limit', 16, 1)
		END
	END
	IF @isTemp=1
	BEGIN
		IF @count > @dp+@dpr
		BEGIN
		RAISERROR ('Doctor has reached to daily limit', 16, 1)
		END
	END
	RETURN


GO
/****** Object:  Trigger [dbo].[checkPatientNumberU]    Script Date: 31.01.2019 05:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[checkPatientNumberU]	
   ON [dbo].[Appointment]
   AFTER UPDATE
AS 
   DECLARE @doctor_id INT =(SELECT I.doctor_id FROM inserted I)
	DECLARE @isTemp bit
	DECLARE @dp INT
	DECLARE @dpr INT
	SELECT @dp=d.daily_patients,@dpr=D.extra_patients,@isTemp=D.isTemp FROM Doctor D WHERE D.id=@doctor_id
	declare @count int
	EXEC @count=[dbo].[sp_NumberOfDailyPatient] @DocID= @doctor_id
	IF @isTemp = 0
	BEGIN
		IF @count > @dp
		BEGIN
		RAISERROR ('Doctor has reached to daily limit', 16, 1)
		END
	END
	IF @isTemp=1
	BEGIN
		IF @count > @dp+@dpr
		BEGIN
		RAISERROR ('Doctor has reached to daily limit', 16, 1)
		END
	END
	RETURN

GO
/****** Object:  Trigger [dbo].[doctorInsert]    Script Date: 31.01.2019 05:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[doctorInsert]
ON	[dbo].[Doctor]
AFTER INSERT
AS
	DECLARE @username NVARCHAR(50)
	DECLARE @password NVARCHAR(50)
	DECLARE @name NVARCHAR(50)
	SELECT @password=I.identity_no,@name=I.full_name,@username=I.email FROM inserted I
	INSERT INTO Users (username,password,full_name) VALUES(@username,@password,@name)


GO
/****** Object:  Trigger [dbo].[AnnualLeaves]    Script Date: 31.01.2019 05:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[AnnualLeaves]
ON [dbo].[WorkerLeave]
AFTER INSERT
AS
	DECLARE @worker_id INT
	DECLARE @worker_type INT
	DECLARE @duration INT
	DECLARE @leave_type INT
	DECLARE @count INT
	SELECT @worker_id=I.worker_id,@duration=I.duration,@leave_type=I.leave_type,@worker_type=I.worker_type FROM inserted I
	SELECT @count=SUM(duration) FROM [dbo].[WorkerLeave] WHERE worker_id=@worker_id AND worker_type=@worker_type
	IF @count > 45
	BEGIN
	RAISERROR ('Worker reached max leave duration...', 16, 1)
	END
RETURN

GO
/****** Object:  Trigger [dbo].[setHoliday]    Script Date: 31.01.2019 05:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[setHoliday]
ON [dbo].[WorkerLeave]
AFTER INSERT
AS
DECLARE @workerID INT
DECLARE @workerType INT
DECLARE @tempDocID INT
SELECT @workerID=I.worker_id,@workerType=I.worker_type,@tempDocID=I.temp_doc FROM inserted I
IF @workerType=1
BEGIN
UPDATE Doctor SET onHoliday=1 WHERE id=@workerID
UPDATE Doctor SET isTemp=1 WHERE id=@tempDocID
END
IF @workerType=2
BEGIN
UPDATE Nurse SET onHoliday=1 WHERE id=@workerID
END

GO
