SELECT
    *
FROM [MAPages]
WHERE
	[Slug] = @Slug AND
	[LocaleCd] = @LocaleCd
	and [DeleteFlag] = 0