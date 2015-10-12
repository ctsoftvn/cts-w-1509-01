SELECT
	*
FROM [MAPhotos]
WHERE
	[TypeCd] = @TypeCd
	AND [CategoryCd] = @CategoryCd
	AND ([DeleteFlag] = 0 OR @IgnoreDeleteFlag = 1)