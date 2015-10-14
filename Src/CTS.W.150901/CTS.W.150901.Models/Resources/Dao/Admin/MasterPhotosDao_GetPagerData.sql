SELECT
    mp.LocaleCd,
	cd1.CodeName AS LocaleName,
	mp.PhotoCd,
	mp.PhotoName,
	mp.SearchName,
	mp.FileCd,
	mp.Notes,
	mp.SortKey,
	mp.VersionNo,
	mp.DeleteFlag,
	cd2.CodeName AS DeleteFlagName
FROM [MAPhotos] mp
	LEFT OUTER JOIN [MACodes] cd1
		ON (cd1.LocaleCd = @ContextLocale
			AND cd1.CodeGroupCd = @GrpCdLocales
			AND cd1.CodeCd = mp.LocaleCd)
	LEFT OUTER JOIN [MACodes] cd2
		ON (cd2.LocaleCd = @ContextLocale
			AND cd2.CodeGroupCd = @GrpCdDeleteFlag
			AND CAST(cd2.CodeCd AS BIT) = mp.DeleteFlag)
WHERE
	(mp.LocaleCd = @LocaleCd OR @LocaleCd IS NULL)
	AND (mp.PhotoName LIKE '%' + @PhotoName + '%'
		OR mp.SearchName LIKE '%' + @PhotoName + '%'
		OR @PhotoName IS NULL)
	AND (mp.DeleteFlag = @DeleteFlag OR @DeleteFlag IS NULL)
ORDER BY
	\*OrderByClause*\,
	mp.SortKey ASC,
	cd1.SortKey ASC
	