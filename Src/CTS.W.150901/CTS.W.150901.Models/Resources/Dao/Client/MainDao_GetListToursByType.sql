
SELECT
    *
FROM [MATours]
WHERE
	[TourTypeCd] = @TypeCd AND
	[LocaleCd] = @LocaleCd
	and [DeleteFlag] = 0
	order by SortKey asc