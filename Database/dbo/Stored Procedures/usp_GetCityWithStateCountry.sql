
-- =============================================
-- Author:		<Ritesh>
-- Create date: <24th Nov 2021>
-- Description:	<Get Details of city with state and country>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetCityWithStateCountry]		
	@CityId int,
	@Enabled  bit
AS
BEGIN
	

    
	SELECT C.CityId,C.CityName,C.CityDescription,C.Enabled,C.StateId,S.StateName,S.StateDescription as StateDescription,
	       COU.CountryName,COU.Description as CountryDescription,COU.ISDCode,S.CountryId
	from Cities C
	left outer join States S on C.StateId = S.StateId
	left outer join Countries COU on S.CountryId = COU.CountryId
	where C.CityId = case when (@CityId is null or @CityId =0) then C.CityId else @CityId end
	and C.Enabled = case when (@Enabled is null or @Enabled =0) then C.Enabled else @Enabled end
	order by C.CityId desc
END