namespace NghienCuuKhoaHoc.General.Extension
{
    public static class AcceptanceStatus
    {
        public static string GetName(this Enum.AcceptanceStatus? acceptanceStatus)
        {
            switch (acceptanceStatus)
            {
                case Enum.AcceptanceStatus.Fail : return "Chưa đạt yêu cầu";
                    break;
                case Enum.AcceptanceStatus.Pass : return "Đạt yêu cầu";
                    break;
                default: return "Không có";
            }
        }
        public static string GetClass(this Enum.AcceptanceStatus? acceptanceStatus)
        {
            switch (acceptanceStatus)
            {
                case Enum.AcceptanceStatus.Fail:
                    return "text-danger";
                    break;
                case Enum.AcceptanceStatus.Pass:
                    return "text-success";
                    break;
                default: return "text-warning";
            }
        }
        public static Enum.AcceptanceStatus ToAcceptanceStatus(this double? Score)
        {
            Enum.AcceptanceStatus res = Score < 5 ? Enum.AcceptanceStatus.Fail : Enum.AcceptanceStatus.Pass;
            return res;
        }
    }
}
