CREATE TABLE [dbo].[CrdData]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [caller_id] VARCHAR(50) NOT NULL, 
    [recipient] VARCHAR(50) NOT NULL, 
    [call_date] DATETIME2 NOT NULL, 
    [end_time] DATETIME2 NOT NULL, 
    [duration] INT NOT NULL, 
    [cost] DECIMAL NOT NULL, 
    [reference] VARCHAR(50) NOT NULL, 
    [currency] VARCHAR(50) NOT NULL
)
