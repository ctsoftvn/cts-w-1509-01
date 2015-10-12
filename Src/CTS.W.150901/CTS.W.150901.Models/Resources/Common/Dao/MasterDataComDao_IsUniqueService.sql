SELECT
	COUNT(*)
FROM [MAServices]
WHERE
	[ServiceCd] <> @ServiceCd
	AND [Slug] = @Slug