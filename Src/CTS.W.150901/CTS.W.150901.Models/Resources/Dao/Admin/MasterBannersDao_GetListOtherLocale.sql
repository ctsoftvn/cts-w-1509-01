SELECT
    *
FROM [MABanners]
WHERE
	[LocaleCd] != @LocaleCd
	AND [BannerCd] = @BannerCd