namespace NghienCuuKhoaHoc.General.Extension
{
    public static class DateTimeExtend
    {
        public static string? ToDate(this DateTime? dateTime)
        {
            try
            {
                return dateTime.Value.ToString("yyyy-MM-dd");
            }
            catch { return null; }
        }
    }
}
