using Shared.Attributes;
using System;

namespace Shared
{
    public static class CountryEnum
    {
        public enum Countries
        {

            [ShortName("BG")]
            [LongName("Bulgaria")]
            Bulgaria = 1,

            [ShortName("RO")]
            [LongName("Romania")]
            Romania,

            [ShortName("GER")]
            //[LongName("Germany")]
            Germany,

            [ShortName("GRE")]
            [LongName("Greece")]
            Greece,

            [ShortName("ENG")]
            [LongName("England")]
            England,

            [ShortName("FRA")]
            [LongName("France")]
            France,

            [ShortName("ITA")]
            [LongName("Italy")]
            Italy
        }
    }
}

//string GetShortName(enum enumValue)
//{
//   == "LongName"
//    emuu
//}
