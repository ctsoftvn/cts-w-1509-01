SELECT
	*
FROM [MAPages]
WHERE
	[LocaleCd] = @LocaleCd
	AND [PageCd] = @PageCd
	AND ([DeleteFlag] = 0 OR @IgnoreDeleteFlag = 1)