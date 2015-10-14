SELECT
    mt.LocaleCd,
	cd1.CodeName AS LocaleName,
	mt.TypeCd,
	mt.TypeName,
	mt.SearchName,
	mt.Slug,
	mt.FileCd,
	mt.SortKey,
	mt.VersionNo,
	mt.DeleteFlag,
	cd2.CodeName AS DeleteFlagName
FROM [MATourTypes] mt
	LEFT OUTER JOIN [MACodes] cd1
		ON (cd1.LocaleCd = @ContextLocale
			AND cd1.CodeGroupCd = @GrpCdLocales
			AND cd1.CodeCd = mt.LocaleCd)
	LEFT OUTER JOIN [MACodes] cd2
		ON (cd2.LocaleCd = @ContextLocale
			AND cd2.CodeGroupCd = @GrpCdDeleteFlag
			AND CAST(cd2.CodeCd AS BIT) = mt.DeleteFlag)
WHERE
	(mt.LocaleCd = @LocaleCd OR @LocaleCd IS NULL)
	AND (mt.TypeName LIKE '%' + @TypeName + '%'
		OR mt.SearchName LIKE '%' + @TypeName + '%'
		OR @TypeName IS NULL)
	AND (mt.Slug LIKE '%' + @Slug + '%' OR @Slug IS NULL)
	AND (mt.DeleteFlag = @DeleteFlag OR @DeleteFlag IS NULL)
ORDER BY
	\*OrderByClause*\,
	mt.SortKey ASC,
	cd1.SortKey ASC
	