SELECT
	COUNT(*)
FROM [MAAccoms]
WHERE
	[AccomCd] <> @AccomCd
	AND [Slug] = @Slug