UPDATE [MAMetas]
SET
	MetaTitle = @MetaTitle,
	MetaDesc = @MetaDesc,
	MetaKeys = @MetaKeys,
	VersionNo = VersionNo + 1,
	UpdateUser = @UpdateUser,
	UpdateDate = @UpdateDate,
	DeleteFlag = @DeleteFlag
WHERE
	LocaleCd = @LocaleCd
	AND GroupCd = @GroupCd
	AND MetaCd = @MetaCd