namespace NghienCuuKhoaHoc.General.Extension
{
    public static class PositionCouncil
    {
        public static string GetName(this Enum.PositionCouncil positionCouncil)
        {
            switch (positionCouncil)
            {
                case Enum.PositionCouncil.Chairman : return "Chủ tịch Hội đồng";
                    break;
                case Enum.PositionCouncil.Commissioner1 : case Enum.PositionCouncil.Commissioner2 : return "Ủy viên";
                    break;
                case Enum.PositionCouncil.Secretary : return "Thư ký";
                    break;
                default: return "Không có";
            }
        }
    }
}
