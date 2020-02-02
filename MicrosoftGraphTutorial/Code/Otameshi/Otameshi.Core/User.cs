namespace Otameshi.Core
{
    public class User
    {
        public string DisplayName { get; }

        public string MobilePhone { get; }

        public string JobTitle { get; }

        public User(
            string displayName,
            string mobilePhone,
            string jobTitle)
        {
            DisplayName = displayName;
            MobilePhone = mobilePhone;
            JobTitle = jobTitle;
        }

        public override string ToString()
        {
            return $"[Name:{DisplayName}, Phone:{MobilePhone}, Title:{JobTitle}]";
        }
    }
}
