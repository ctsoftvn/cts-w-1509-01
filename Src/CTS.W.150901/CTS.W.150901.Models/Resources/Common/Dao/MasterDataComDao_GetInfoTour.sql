SELECT
	*
FROM [MATours]
WHERE
	[LocaleCd] = @LocaleCd
	AND [TourCd] = @TourCd
	AND ([DeleteFlag] = 0 OR @IgnoreDeleteFlag = 1)