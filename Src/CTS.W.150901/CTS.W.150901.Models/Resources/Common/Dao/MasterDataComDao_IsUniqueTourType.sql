SELECT
	COUNT(*)
FROM [MATourTypes]
WHERE
	[TypeCd] <> @TypeCd
	AND [Slug] = @Slug