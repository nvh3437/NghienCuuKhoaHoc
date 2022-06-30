namespace NghienCuuKhoaHoc.General.Extension
{
    public static class StringExtend
    {
        public static string ToStringId(this string Str)
        {
            List<string> letters = Str.Split(' ').ToList();
            var res = "";
            letters.ForEach(letter => { 
                res += letter.Substring(0,1);
            });
            return res;
        }
        public static DateTime? ToDateTime(this string Str)
        {
            try
            {
                var birth = Str.Split("-");
                return new DateTime(int.Parse(birth[0]), int.Parse(birth[1]), int.Parse(birth[2]), 0, 0, 0);
            }
            catch { return null; }
        }
    }
}
