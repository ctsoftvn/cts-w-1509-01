SELECT
    *
FROM [MAPhotos]
WHERE
	[LocaleCd] != @LocaleCd
	AND [PhotoCd] = @PhotoCd