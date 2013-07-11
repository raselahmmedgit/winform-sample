USE winform_db
GO

-- =============================================
-- Author:		<Rasel Ahmmed>
-- Create date: <2013-07-08>
-- Description:	<Create User Type for List of Students with param value type>
-- =============================================
CREATE TYPE dbo.StudentType AS TABLE 
( 
	StudentId INT NULL,
	StudentName NVARCHAR(50) NULL,
	StudentAddress NVARCHAR(50) NULL,
	StudentMobile NVARCHAR(50) NULL,
	StudentEmail NVARCHAR(50) NULL,
	BatchId INT NULL,
	SubjectId INT NULL   
) 
GO

-- =============================================
-- Author:		<Rasel Ahmmed>
-- Create date: <2013-07-08>
-- Description:	<Insert Students data with param value type>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertStudents] 
 @students StudentType READONLY,
 @result NVARCHAR(100) out,
 @message NVARCHAR(100) out
AS
BEGIN
	
SET NOCOUNT ON; 

INSERT dbo.Student(StudentId, StudentName, StudentAddress, StudentMobile, StudentEmail) 
SELECT StudentId, StudentName, StudentAddress, StudentMobile, StudentEmail FROM @students;
	
INSERT dbo.StudentBatch(StudentId, BatchId) 
SELECT StudentId, BatchId FROM @students;

INSERT dbo.StudentSubject(StudentId, SubjectId) 
SELECT StudentId, SubjectId FROM @students;	
	
IF(@@ERROR<>0)
  BEGIN
   SET @result='Fail'
   SET @message='Could not insert details'
   RETURN 0;
  END

SET @result='Success'
SET @message='Data saved successfully'
RETURN 0; 
	
END

GO

-- USER THIS SP

DECLARE @RC2 INT
DECLARE @students StudentType
DECLARE @result NVARCHAR(100)
DECLARE @message NVARCHAR(100)

INSERT INTO @students(StudentId, StudentName, StudentAddress, StudentMobile, StudentEmail, BatchId, SubjectId) 
VALUES (1, 'Rasel','Cantorment','01911045573','raselahmmed@gmail.com', 1, 1 ), 
	(2, 'Shamim','Mirpur','01911045573','shamim@gmail.com', 1, 1), 
	(3, 'Mim','Uttara','01911045573','mim@gmail.com', 1, 1)

EXECUTE @RC2 = [winform_db].[dbo].[sp_InsertStudents] 
   @students
  ,@result OUTPUT
  ,@message OUTPUT

print @result
print @message