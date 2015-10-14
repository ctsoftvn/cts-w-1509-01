SELECT
	*
FROM [MAAccoms]
WHERE
	[LocaleCd] = @LocaleCd
	AND [AccomCd] = @AccomCd
	AND ([DeleteFlag] = 0 OR @IgnoreDeleteFlag = 1)