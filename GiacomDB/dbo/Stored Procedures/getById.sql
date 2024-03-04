CREATE PROCEDURE [dbo].[getById]
	@ic int
AS
	SELECT Id, caller_id,recipient,call_date,end_time,duration,cost,reference,currency
	FROM CrdData
