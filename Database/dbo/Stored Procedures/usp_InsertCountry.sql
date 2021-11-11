-- =============================================
-- Author:		<Ritesh>
-- Create date: <11th Nov 2021>
-- Description:	<Insert record in Country>
-- =============================================
CREATE PROCEDURE usp_InsertCountry
 @CountryName nvarchar(max)
,@ISDCode nvarchar(max)
,@Description nvarchar(max)
,@Enabled bit
,@ReturnVal int output
	
AS
--example to call stored procedure
--Declare @ID int   
--exec usp_InsertCountry 'Test','Test','Test',1,@ID OUTPUT  
--PRINT @ID
BEGIN

INSERT INTO [dbo].[Countries]
           ([CountryName]
           ,[ISDCode]
           ,[Description]
           ,[Enabled])
     VALUES
           (  @CountryName 
             ,@ISDCode 
             ,@Description 
             ,@Enabled 
		   )
    set @ReturnVal  = SCOPE_IDENTITY()
	return @ReturnVal

END