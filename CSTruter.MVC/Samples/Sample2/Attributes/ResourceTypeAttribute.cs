using System;

namespace CSTruter.Mvc.Samples.Sample2.Attributes
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ResourceTypeAttribute : Attribute
    {
        public Type ResourceType { get; set; }

        public ResourceTypeAttribute(Type resourceType)
        {
            ResourceType = resourceType;
        }
    }
}