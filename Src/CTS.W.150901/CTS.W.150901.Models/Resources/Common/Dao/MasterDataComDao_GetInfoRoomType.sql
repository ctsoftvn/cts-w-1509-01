SELECT
	*
FROM [MARoomTypes]
WHERE
	[LocaleCd] = @LocaleCd
	AND [TypeCd] = @TypeCd
	AND ([DeleteFlag] = 0 OR @IgnoreDeleteFlag = 1)