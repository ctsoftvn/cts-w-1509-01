SELECT
    *
FROM [MARoomTypes]
WHERE
	[LocaleCd] != @LocaleCd
	AND [TypeCd] = @TypeCd