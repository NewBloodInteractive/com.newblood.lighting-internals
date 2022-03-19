using System;

namespace NewBlood
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    sealed class MetadataNameAttribute : Attribute
    {
        public string Name { get; }

        public MetadataNameAttribute(string name)
        {
            Name = name;
        }
    }
}
