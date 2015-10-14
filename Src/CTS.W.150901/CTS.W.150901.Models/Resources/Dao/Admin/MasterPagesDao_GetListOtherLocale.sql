SELECT
    *
FROM [MAPages]
WHERE
	[LocaleCd] != @LocaleCd
	AND [PageCd] = @PageCd