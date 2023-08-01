namespace Blasco.Common
{
    public static class EntityValidationConstants
    {
        public static class ProductProjectCategory
        {
            public const int NameMinLenght = 2;
            public const int NameMaxLenght = 50;
        }

        public static class Project
        {
            public const int TitleMinLenght = 2;
            public const int TitleMaxLenght = 50;

            public const int DescriptionMinLenght = 10;
            public const int DescriptionMaxLenght = 500;

            public const int ImageUrlMaxLength = 2048;
        }

        public static class Product
        {
            public const int TitleMinLenght = 2;
            public const int TitleMaxLenght = 50;

            public const int DescriptionMinLenght = 10;
            public const int DescriptionMaxLenght = 500;

            public const int ImageUrlMaxLength = 2048;

            public const int CityNameMinLenght = 2;
            public const int CityNameMaxLenght = 85;

            public const string PriceMinValue = "0";
            public const string PriceMaxValue = "1000000";
        }

        public static class Customer
        {
            public const int MaxNumEnumCustomerType = 2;
        }

        public static class ApplicationUser
        {
            public const int PassMinLenght = 6;
            public const int PassMaxLenght = 100;

            public const int PseudonymMinLenght = 1;
            public const int PseudonymMaxLenght = 20;

            public const int FirstNameMinLenght = 1;
            public const int FirstNameMaxLenght = 15;

            public const int LastNameMinLenght = 1;
            public const int LastNameMaxLenght = 15;
        }

        public static class Challenge
        {
            public const int TitleMinLenght = 2;
            public const int TitleMaxLenght = 50;

            public const int DescriptionMinLenght = 10;
            public const int DescriptionMaxLenght = 500;

            public const int ImageUrlMaxLength = 2048;

        }
    }
}
