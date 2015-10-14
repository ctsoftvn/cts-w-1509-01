UPDATE [MABanners]
SET
	[BannerName] = @BannerName,
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
	AND [BannerCd] = @BannerCd