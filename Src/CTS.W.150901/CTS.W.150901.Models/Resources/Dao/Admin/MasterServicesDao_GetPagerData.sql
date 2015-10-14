SELECT
    ms.LocaleCd,
	cd1.CodeName AS LocaleName,
	ms.ServiceCd,
	ms.ServiceName,
	ms.SearchName,
	ms.Slug,
	ms.FileCd,
	ms.Notes,
	ms.SortKey,
	ms.VersionNo,
	ms.DeleteFlag,
	cd2.CodeName AS DeleteFlagName
FROM [MAServices] ms
	LEFT OUTER JOIN [MACodes] cd1
		ON (cd1.LocaleCd = @ContextLocale
			AND cd1.CodeGroupCd = @GrpCdLocales
			AND cd1.CodeCd = ms.LocaleCd)
	LEFT OUTER JOIN [MACodes] cd2
		ON (cd2.LocaleCd = @ContextLocale
			AND cd2.CodeGroupCd = @GrpCdDeleteFlag
			AND CAST(cd2.CodeCd AS BIT) = ms.DeleteFlag)
WHERE
	(ms.LocaleCd = @LocaleCd OR @LocaleCd IS NULL)
	AND (ms.ServiceName LIKE '%' + @ServiceName + '%'
		OR ms.SearchName LIKE '%' + @ServiceName + '%'
		OR @ServiceName IS NULL)
	AND (ms.Slug LIKE '%' + @Slug + '%' OR @Slug IS NULL)
	AND (ms.DeleteFlag = @DeleteFlag OR @DeleteFlag IS NULL)
ORDER BY
	\*OrderByClause*\,
	ms.SortKey ASC,
	cd1.SortKey ASC
	