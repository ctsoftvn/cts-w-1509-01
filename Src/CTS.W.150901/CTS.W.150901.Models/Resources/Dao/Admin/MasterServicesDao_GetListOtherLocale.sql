SELECT
    *
FROM [MAServices]
WHERE
	[LocaleCd] != @LocaleCd
	AND [ServiceCd] = @ServiceCd