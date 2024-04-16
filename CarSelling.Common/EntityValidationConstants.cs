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

            public const int CarMileageMin = 0;
            public const int CarMileageMax = 2000000;

            public const int CarPowerMin = 1;
            public const int CarPowerMax = 5000;
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
    }
}
