-- =============================================
-- Author:		<Ritesh>
-- Create date: <11th Nov 2021>
-- Description:	<Used to Delete Country>
-- =============================================
CREATE PROCEDURE usp_DeleteCountry
	@CountryID int
	
AS
BEGIN

	-- For Physical Delete	
	delete from Countries where  CountryId = @CountryID

	-- For updating status to delete
	--update Countries set Enabled = 0 where CountryId = @CountryID
	
END