SELECT
	*
FROM [MAPhotos]
WHERE
	[LocaleCd] = @LocaleCd
	AND [PhotoCd] = @PhotoCd
	AND ([DeleteFlag] = 0 OR @IgnoreDeleteFlag = 1)