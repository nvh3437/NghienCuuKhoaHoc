namespace NghienCuuKhoaHoc.General.Extension
{
    public static class AcceptanceRate
    {
        public static string GetName(this Enum.AcceptanceRate? acceptanceRate)
        {
            switch (acceptanceRate)
            {
                case Enum.AcceptanceRate.Excellent : return "Tốt";
                    break;
                case Enum.AcceptanceRate.Good : return "Khá";
                    break;
                case Enum.AcceptanceRate.Fail : return "Chưa đạt yêu cầu";
                    break;
                case Enum.AcceptanceRate.Pass : return "Đạt yêu cầu";
                    break;
                default: return "Không có";
            }
        }
        public static string GetClass(this Enum.AcceptanceRate? acceptanceRate)
        {
            switch (acceptanceRate)
            {
                case Enum.AcceptanceRate.Excellent : return "text-success";
                    break;
                case Enum.AcceptanceRate.Good : return "text-info";
                    break;
                case Enum.AcceptanceRate.Fail : return "text-danger";
                    break;
                case Enum.AcceptanceRate.Pass : return "text-info";
                    break;
                default: return "text-warning";
            }
        }
        public static Enum.AcceptanceRate ToAcceptanceRate(this double? Score)
        {
            Enum.AcceptanceRate res = Score < 5 ? Enum.AcceptanceRate.Fail :
                    Score < 7 ? Enum.AcceptanceRate.Pass :
                    Score < 9 ? Enum.AcceptanceRate.Good : Enum.AcceptanceRate.Excellent;
            return res;
        }
    }
}
