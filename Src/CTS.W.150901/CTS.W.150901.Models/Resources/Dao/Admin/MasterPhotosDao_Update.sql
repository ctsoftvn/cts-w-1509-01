UPDATE [MAPhotos]
SET
	[PhotoName] = @PhotoName,
	[SearchName] = @SearchName,
	[FileCd] = @FileCd,
	[Notes] = @Notes,
	[SortKey] = @SortKey,
	[VersionNo] = [VersionNo] + 1,
	[UpdateUser] = @UpdateUser,
	[UpdateDate] = @UpdateDate,
	[DeleteFlag] = @DeleteFlag
WHERE
	[LocaleCd] = @LocaleCd
	AND [PhotoCd] = @PhotoCd