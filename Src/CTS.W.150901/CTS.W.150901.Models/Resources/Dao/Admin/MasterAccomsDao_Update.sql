UPDATE [MAAccoms]
SET
	[AccomName] = @AccomName,
	[SearchName] = @SearchName,
	[Slug] = @Slug,
	[FileCd] = @FileCd,
	[Notes] = @Notes,
	[SortKey] = @SortKey,
	[VersionNo] = [VersionNo] + 1,
	[UpdateUser] = @UpdateUser,
	[UpdateDate] = @UpdateDate,
	[DeleteFlag] = @DeleteFlag
WHERE
	[LocaleCd] = @LocaleCd
	AND [AccomCd] = @AccomCd