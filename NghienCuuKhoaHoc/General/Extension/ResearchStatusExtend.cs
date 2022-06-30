using NghienCuuKhoaHoc.General.Enum;

namespace NghienCuuKhoaHoc.General.Extension
{
    public static class ResearchStatusExtend
    {
        public static string GetName(this ResearchStatus? ResearchStatus)
        {
            switch (ResearchStatus)
            {
                case General.Enum.ResearchStatus.Handed : return "Đã bàn giao";
                    break;
                case General.Enum.ResearchStatus.Defended : return "Đã bảo vệ trước Hội đồng";
                    break;
                case General.Enum.ResearchStatus.Inspected : return "Đã nghiệm thu";
                    break;
                default: return "Không có";
            }
        }
        public static string GetClass(this ResearchStatus? ResearchStatus)
        {
            switch (ResearchStatus)
            {
                case General.Enum.ResearchStatus.Handed : return "text-warning";
                    break;
                case General.Enum.ResearchStatus.Defended : return "text-info";
                    break;
                case General.Enum.ResearchStatus.Inspected : return "text-success";
                    break;
                default: return "";
            }
        }
    }
}
