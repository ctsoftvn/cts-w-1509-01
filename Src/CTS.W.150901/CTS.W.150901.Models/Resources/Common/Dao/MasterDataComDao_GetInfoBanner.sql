SELECT
	*
FROM [MABanners]
WHERE
	[LocaleCd] = @LocaleCd
	AND [BannerCd] = @BannerCd
	AND ([DeleteFlag] = 0 OR @IgnoreDeleteFlag = 1)