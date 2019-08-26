using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Shared;
using Shared.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Mini_Bank.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static string ShortCountryName(this IHtmlHelper helper, CountryEnum.Countries country)
        {
            var enumValueMemberInfo = GetEnumValueMemberInfo(country);

            var valueAttribute = enumValueMemberInfo.GetCustomAttribute(typeof(ShortNameAttribute), false);

            return valueAttribute != null ? valueAttribute.ToString() : country.ToString();
        }

        public static string LongCountryName(this IHtmlHelper helper, CountryEnum.Countries country)
        {
            var enumValueMemberInfo = GetEnumValueMemberInfo(country);

            var valueAttribute = enumValueMemberInfo.GetCustomAttribute(typeof(LongNameAttribute), false);

            return valueAttribute != null ? valueAttribute.ToString() : country.ToString(); 
        }

        private static MemberInfo GetEnumValueMemberInfo(CountryEnum.Countries country)
        {
            var enumType = typeof(CountryEnum.Countries);

            var memberInfo = enumType.GetMember(enumType.GetEnumName(country));

            return memberInfo.FirstOrDefault(m => m.DeclaringType == enumType);
        }

    }
}
