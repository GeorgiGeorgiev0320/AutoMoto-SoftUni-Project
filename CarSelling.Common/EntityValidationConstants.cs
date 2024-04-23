using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSelling.Common
{
    public static class EntityValidationConstants
    {
        public static class Category
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 3;
        }

        public static class Car
        {
            public const int ModelMaxLength = 50;
            public const int ModelMinLength = 3;

            public const int DescriptionMaxLength = 500;
            public const int DescriptionMinLength = 25;

            public const int ImageUrlMaxLength = 2048;

            public const string CarPriceMin = "0";
            public const string CarPriceMax = "3000000";

            public const string CarMileageMin = "0";
            public const string CarMileageMax = "2000000";

            public const string CarPowerMin = "1";
            public const string CarPowerMax = "5000";
        }

        public static class Make
        {
            public const int MakeMaxLength = 50;
            public const int MakeMinLength = 3;

        }
        public static class Seller
        {
            public const int PhoneMaxLength = 15;
            public const int PhoneMinLength = 7;

            public const int AddressMaxLength = 50;
            public const int AddressMinLength = 5;
        }

        public static class User
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 20;

            public const int LastNameMinLength = 2;
            public const int LastNameMaxLength = 20;

            public const int PasswordMaxLength = 60;
            public const int PasswordMinLength = 6;
        }
    }
}
