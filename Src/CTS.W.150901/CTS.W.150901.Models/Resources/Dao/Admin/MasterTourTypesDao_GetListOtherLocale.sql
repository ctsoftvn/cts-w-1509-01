SELECT
    *
FROM [MATourTypes]
WHERE
	[LocaleCd] != @LocaleCd
	AND [TypeCd] = @TypeCd