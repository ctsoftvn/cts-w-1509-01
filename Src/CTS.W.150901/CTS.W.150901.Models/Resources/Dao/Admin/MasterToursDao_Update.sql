UPDATE [MATours]
SET
	[TourName] = @TourName,
	[SearchName] = @SearchName,
	[Slug] = @Slug,
	[TourTypeCd] = @TourTypeCd,
	[Notes] = @Notes,
	[SortKey] = @SortKey,
	[VersionNo] = [VersionNo] + 1,
	[UpdateUser] = @UpdateUser,
	[UpdateDate] = @UpdateDate,
	[DeleteFlag] = @DeleteFlag
WHERE
	[LocaleCd] = @LocaleCd
	AND [TourCd] = @TourCd