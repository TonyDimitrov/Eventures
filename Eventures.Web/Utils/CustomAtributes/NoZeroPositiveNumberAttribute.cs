using System.ComponentModel.DataAnnotations;

namespace Eventures.Web.Utils.CustomAtributes
{
    public class NoZeroPositiveNumberAttribute : ValidationAttribute
    {
        

        public override bool IsValid(object value)
        {
            decimal number;

            if (decimal.TryParse(value.ToString(), out number))
            {
                if (number > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
