SELECT
    mt.LocaleCd,
	cd1.CodeName AS LocaleName,
	mt.TourCd,
	mt.TourName,
	mt.SearchName,
	mt.Slug,
	mt.TourTypeCd,
	mtt.TypeName AS TourTypeName,
	mt.Notes,
	mt.SortKey,
	mt.VersionNo,
	mt.DeleteFlag,
	cd2.CodeName AS DeleteFlagName,
	mm.MetaTitle,
	mm.MetaDesc,
	mm.MetaKeys
FROM [MATours] mt
	INNER JOIN [MATourTypes] mtt
		ON (mtt.LocaleCd = @BasicLocale
			AND mtt.TypeCd = mt.TourTypeCd
			AND mtt.DeleteFlag = 0)
	LEFT OUTER JOIN [MACodes] cd1
		ON (cd1.LocaleCd = @ContextLocale
			AND cd1.CodeGroupCd = @GrpCdLocales
			AND cd1.CodeCd = mt.LocaleCd)
	LEFT OUTER JOIN [MACodes] cd2
		ON (cd2.LocaleCd = @ContextLocale
			AND cd2.CodeGroupCd = @GrpCdDeleteFlag
			AND CAST(cd2.CodeCd AS BIT) = mt.DeleteFlag)
	LEFT OUTER JOIN [MAMetas] mm
		ON (mm.LocaleCd = mt.LocaleCd
			AND mm.MetaCd = mt.TourCd
			AND mm.GroupCd = @GrpMetaMaTours)
WHERE
	(mt.LocaleCd = @LocaleCd OR @LocaleCd IS NULL)
	AND (mt.TourName LIKE '%' + @TourName + '%'
		OR mt.SearchName LIKE '%' + @TourName + '%'
		OR @TourName IS NULL)
	AND (mt.Slug LIKE '%' + @Slug + '%' OR @Slug IS NULL)
	AND (mt.TourTypeCd = @TourTypeCd OR @TourTypeCd IS NULL)
	AND (mt.DeleteFlag = @DeleteFlag OR @DeleteFlag IS NULL)
ORDER BY
	\*OrderByClause*\,
	mt.SortKey ASC,
	cd1.SortKey ASC
	