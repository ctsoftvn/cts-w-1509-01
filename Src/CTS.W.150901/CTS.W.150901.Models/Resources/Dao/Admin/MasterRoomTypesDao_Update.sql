UPDATE [MARoomTypes]
SET
	[TypeName] = @TypeName,
	[SearchName] = @SearchName,
	[Slug] = @Slug,
	[Price] = @Price,
	[AdultPerRoom] = @AdultPerRoom,
	[FileCd] = @FileCd,
	[SortKey] = @SortKey,
	[VersionNo] = [VersionNo] + 1,
	[UpdateUser] = @UpdateUser,
	[UpdateDate] = @UpdateDate,
	[DeleteFlag] = @DeleteFlag
WHERE
	[LocaleCd] = @LocaleCd
	AND [TypeCd] = @TypeCd