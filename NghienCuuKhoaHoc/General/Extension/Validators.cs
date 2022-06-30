using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace NghienCuuKhoaHoc.General.Extension
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class DateMoreThanAttribute : ValidationAttribute
    {
        public string OtherProperty { get; set; }

        public DateMoreThanAttribute(string otherProperty)
        {
            this.OtherProperty = otherProperty;
        }
        public override bool IsValid(object value)
        {
            try
            {
                var x = Convert.ToDateTime(value);
                if (x > Convert.ToDateTime(OtherProperty))
                {
                    return true;
                }
                return false;
            }
            catch { return false; }
        }
        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
              ErrorMessageString, name);
        }
    }
}
