using System;

namespace Shared.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ShortNameAttribute : Attribute
    {
        private readonly string _shortName;

        public ShortNameAttribute(string shortName)
        {
            _shortName = shortName;
        }

        public override string ToString()
        {
            return _shortName;
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class LongNameAttribute : Attribute
    {
        private readonly string _longName;

        public LongNameAttribute(string longName)
        {
            _longName = longName;
        }

        public override string ToString()
        {
            return _longName;
        }
    }
    
}