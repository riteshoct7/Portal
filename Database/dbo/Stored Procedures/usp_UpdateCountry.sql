-- =============================================
-- Author:		<Ritesh Parekh>
-- Create date: <11th Nov 2021>
-- Description:	<Update Country>
-- =============================================
CREATE PROCEDURE [dbo].[usp_UpdateCountry]
 @CountryId int
,@CountryName nvarchar(max)
,@ISDCode nvarchar(max)
,@Description nvarchar(max)
,@Enabled bit

AS

BEGIN
UPDATE [dbo].[Countries]
   SET [CountryName] = @CountryName 
      ,[ISDCode] = @ISDCode
      ,[Description] = @Description
      ,[Enabled] = @Enabled
 WHERE CountryId = @CountryId


	
END