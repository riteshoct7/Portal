-- =============================================
-- Author:		<Ritesh Parekh>
-- Create date: <20th Nov 2021>
-- Description:	<Get list of states with country>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetStatesWithCountry]
	
	@StateID int,
	@Enabled  bit
AS
BEGIN

select S.StateId,S.StateName,S.StateDescription,S.Enabled,S.CountryId,C.CountryName,C.Description as CountryDescription,C.ISDCode
from States S
left outer join Countries C on S.CountryID = C.CountryID
where S.StateId = case when (@StateID is null or @StateID =0) then S.StateId else @StateID end
and S.Enabled  = case when (@Enabled  is null or @Enabled =0) then S.Enabled  else @Enabled end
order by S.StateId desc
	
END