SELECT
	COUNT(*)
FROM [MAPages]
WHERE
	[PageCd] <> @PageCd
	AND [Slug] = @Slug