SELECT
    mb.LocaleCd,
	cd1.CodeName AS LocaleName,
	mb.BannerCd,
	mb.BannerName,
	mb.SearchName,
	mb.FileCd,
	mb.Notes,
	mb.SortKey,
	mb.VersionNo,
	mb.DeleteFlag,
	cd2.CodeName AS DeleteFlagName
FROM [MABanners] mb
	LEFT OUTER JOIN [MACodes] cd1
		ON (cd1.LocaleCd = @ContextLocale
			AND cd1.CodeGroupCd = @GrpCdLocales
			AND cd1.CodeCd = mb.LocaleCd)
	LEFT OUTER JOIN [MACodes] cd2
		ON (cd2.LocaleCd = @ContextLocale
			AND cd2.CodeGroupCd = @GrpCdDeleteFlag
			AND CAST(cd2.CodeCd AS BIT) = mb.DeleteFlag)
WHERE
	(mb.LocaleCd = @LocaleCd OR @LocaleCd IS NULL)
	AND (mb.BannerName LIKE '%' + @BannerName + '%'
		OR mb.SearchName LIKE '%' + @BannerName + '%'
		OR @BannerName IS NULL)
	AND (mb.DeleteFlag = @DeleteFlag OR @DeleteFlag IS NULL)
ORDER BY
	\*OrderByClause*\,
	mb.SortKey ASC,
	cd1.SortKey ASC
	