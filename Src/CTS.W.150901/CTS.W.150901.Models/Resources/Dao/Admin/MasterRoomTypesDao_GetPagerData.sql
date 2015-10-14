SELECT
    mr.LocaleCd,
	cd1.CodeName AS LocaleName,
	mr.TypeCd,
	mr.TypeName,
	mr.SearchName,
	mr.Slug,
	mr.Price,
	mr.AdultPerRoom,
	mr.FileCd,
	mr.SortKey,
	mr.VersionNo,
	mr.DeleteFlag,
	cd2.CodeName AS DeleteFlagName
FROM [MARoomTypes] mr
	LEFT OUTER JOIN [MACodes] cd1
		ON (cd1.LocaleCd = @ContextLocale
			AND cd1.CodeGroupCd = @GrpCdLocales
			AND cd1.CodeCd = mr.LocaleCd)
	LEFT OUTER JOIN [MACodes] cd2
		ON (cd2.LocaleCd = @ContextLocale
			AND cd2.CodeGroupCd = @GrpCdDeleteFlag
			AND CAST(cd2.CodeCd AS BIT) = mr.DeleteFlag)
WHERE
	(mr.LocaleCd = @LocaleCd OR @LocaleCd IS NULL)
	AND (mr.TypeName LIKE '%' + @TypeName + '%'
		OR mr.SearchName LIKE '%' + @TypeName + '%'
		OR @TypeName IS NULL)
	AND (mr.Slug LIKE '%' + @Slug + '%' OR @Slug IS NULL)
	AND (mr.DeleteFlag = @DeleteFlag OR @DeleteFlag IS NULL)
ORDER BY
	\*OrderByClause*\,
	mr.SortKey ASC,
	cd1.SortKey ASC
	