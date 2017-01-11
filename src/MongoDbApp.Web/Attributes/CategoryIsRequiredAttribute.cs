using System.ComponentModel.DataAnnotations;

namespace MongoDbApp.Web.Attributes
{
    public class CategoryIsRequiredAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string parsedValue = value as string;

            if (string.IsNullOrEmpty(parsedValue))
            {
                return false;
            }

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Category must be chosen.";
        }
    }
}
