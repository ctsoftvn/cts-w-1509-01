SELECT
	COUNT(*)
FROM [MATours]
WHERE
	[TourCd] <> @TourCd
	AND [Slug] = @Slug