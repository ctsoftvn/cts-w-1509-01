SELECT
    ma.LocaleCd,
	cd1.CodeName AS LocaleName,
	ma.AccomCd,
	ma.AccomName,
	ma.SearchName,
	ma.Slug,
	ma.FileCd,
	ma.Notes,
	ma.SortKey,
	ma.VersionNo,
	ma.DeleteFlag,
	cd2.CodeName AS DeleteFlagName
FROM [MAAccoms] ma
	LEFT OUTER JOIN [MACodes] cd1
		ON (cd1.LocaleCd = @ContextLocale
			AND cd1.CodeGroupCd = @GrpCdLocales
			AND cd1.CodeCd = ma.LocaleCd)
	LEFT OUTER JOIN [MACodes] cd2
		ON (cd2.LocaleCd = @ContextLocale
			AND cd2.CodeGroupCd = @GrpCdDeleteFlag
			AND CAST(cd2.CodeCd AS BIT) = ma.DeleteFlag)
WHERE
	(ma.LocaleCd = @LocaleCd OR @LocaleCd IS NULL)
	AND (ma.AccomName LIKE '%' + @AccomName + '%'
		OR ma.SearchName LIKE '%' + @AccomName + '%'
		OR @AccomName IS NULL)
	AND (ma.Slug LIKE '%' + @Slug + '%' OR @Slug IS NULL)
	AND (ma.DeleteFlag = @DeleteFlag OR @DeleteFlag IS NULL)
ORDER BY
	\*OrderByClause*\,
	ma.SortKey ASC,
	cd1.SortKey ASC
	