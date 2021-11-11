-- =============================================
-- Author:		<Ritesh Paekh>
-- Create date: <11th Nov 2021>
-- Description:	<Get Countries>
-- =============================================
CREATE PROCEDURE usp_SelectCountry 
	@CountryID int,
	@Enabled bit
AS
BEGIN

	select C.CountryId,C.CountryName,C.ISDCode,C.Description,C.Enabled 
	from Countries C
	where 
	C.CountryId = case when (@CountryID is null or @CountryID =0) 
					  then C.CountryId
					  else @CountryID  
				  end
    and
	C.Enabled = case when (@Enabled is null) 
					  then C.Enabled
					  else @Enabled  
				  end
   order by C.CountryId desc
    	                    	
END