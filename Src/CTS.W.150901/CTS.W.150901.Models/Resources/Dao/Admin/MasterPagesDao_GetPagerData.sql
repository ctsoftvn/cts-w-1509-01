SELECT
    mp.LocaleCd,
	cd1.CodeName AS LocaleName,
	mp.PageCd,
	mp.PageName,
	mp.SearchName,
	mp.Slug,
	mp.Content,
	mp.Notes,
	mp.SortKey,
	mp.VersionNo,
	mm.MetaTitle,
	mm.MetaDesc,
	mm.MetaKeys
FROM [MAPages] mp
	LEFT OUTER JOIN [MACodes] cd1
		ON (cd1.LocaleCd = @ContextLocale
			AND cd1.CodeGroupCd = @GrpCdLocales
			AND cd1.CodeCd = mp.LocaleCd)
	LEFT OUTER JOIN [MAMetas] mm
		ON (mm.LocaleCd = mp.LocaleCd
			AND mm.MetaCd = mp.PageCd
			AND mm.GroupCd = @GrpMetaMaPages)
WHERE
	(mp.LocaleCd = @LocaleCd OR @LocaleCd IS NULL)
ORDER BY
	\*OrderByClause*\,
	mp.SortKey ASC,
	cd1.SortKey ASC
	