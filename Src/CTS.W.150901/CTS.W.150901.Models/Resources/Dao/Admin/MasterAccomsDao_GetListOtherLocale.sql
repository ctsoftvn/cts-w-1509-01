SELECT
    *
FROM [MAAccoms]
WHERE
	[LocaleCd] != @LocaleCd
	AND [AccomCd] = @AccomCd