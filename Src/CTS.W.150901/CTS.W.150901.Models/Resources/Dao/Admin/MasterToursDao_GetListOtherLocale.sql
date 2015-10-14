SELECT
    *
FROM [MATours]
WHERE
	[LocaleCd] != @LocaleCd
	AND [TourCd] = @TourCd