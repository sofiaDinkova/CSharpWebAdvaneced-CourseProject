﻿namespace Blasco.Common
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
    }
}