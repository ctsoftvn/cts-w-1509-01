UPDATE [MAPages]
SET
	[PageName] = @PageName,
	[SearchName] = @SearchName,
	-- [Slug] = @Slug,
	[Content] = @Content,
	[VersionNo] = [VersionNo] + 1,
	[UpdateUser] = @UpdateUser,
	[UpdateDate] = @UpdateDate
WHERE
	[LocaleCd] = @LocaleCd
	AND [PageCd] = @PageCd