using USP_Domain.Enums;

namespace USP_Domain.Extentions;

public class EnumExtentions
{
    public static readonly string ValidCategoryList =
        string.Join(',', Category.List.Select(x =>x.Name + "-" + x.Value));  
}