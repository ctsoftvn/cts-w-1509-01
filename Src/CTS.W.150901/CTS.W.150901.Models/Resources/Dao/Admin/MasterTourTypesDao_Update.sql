UPDATE [MATourTypes]
SET
	[TypeName] = @TypeName,
	[SearchName] = @SearchName,
	[Slug] = @Slug,
	[FileCd] = @FileCd,
	[SortKey] = @SortKey,
	[VersionNo] = [VersionNo] + 1,
	[UpdateUser] = @UpdateUser,
	[UpdateDate] = @UpdateDate,
	[DeleteFlag] = @DeleteFlag
WHERE
	[LocaleCd] = @LocaleCd
	AND [TypeCd] = @TypeCd