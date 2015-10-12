SELECT
    [TypeCd] AS [Key],
	[TypeName] AS [Value]
FROM [MATourTypes]
WHERE
	[LocaleCd] = @LocaleCd
    AND [TypeCd] NOT IN (@SkipCodes)
    AND ([DeleteFlag] = 0 OR @IgnoreDeleteFlag = 1)
ORDER BY
    [SortKey] ASC