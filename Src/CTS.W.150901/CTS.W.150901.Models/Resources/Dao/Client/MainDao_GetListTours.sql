﻿
SELECT
    *
FROM [MATours]
WHERE
	[LocaleCd] = @LocaleCd
	and [DeleteFlag] = 0
	order by SortKey asc