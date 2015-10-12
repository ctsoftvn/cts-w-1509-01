SELECT
	*
FROM [MAServices]
WHERE
	[LocaleCd] = @LocaleCd
	AND [ServiceCd] = @ServiceCd
	AND ([DeleteFlag] = 0 OR @IgnoreDeleteFlag = 1)