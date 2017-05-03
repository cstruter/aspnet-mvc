using CSTruter.Mvc.Samples.Sample2.Attributes;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace CSTruter.Mvc.Samples.Sample2.Providers
{
    public class ResourceTypeModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected void EnsureResourceTypeSet(ICustomTypeDescriptor customTypeDescriptor, Type resourceType)
        {
            var properties = customTypeDescriptor.GetProperties();
            foreach (var property in properties.OfType<PropertyDescriptor>())
            {
                foreach (var attribute in property.Attributes.OfType<Attribute>())
                {
                    if (attribute is ValidationAttribute)
                        ((ValidationAttribute)attribute).ErrorMessageResourceType = resourceType;
                    else if (attribute is DisplayAttribute)
                        ((DisplayAttribute)attribute).ResourceType = resourceType;
                }
            }
        }

        protected override ICustomTypeDescriptor GetTypeDescriptor(Type type)
        {
            var customTypeDescriptor = base.GetTypeDescriptor(type);
            var resourceTypeAttribute = type.GetCustomAttribute<ResourceTypeAttribute>();
            if (resourceTypeAttribute != null)
            {
                EnsureResourceTypeSet(customTypeDescriptor, resourceTypeAttribute.ResourceType);
            }
            return customTypeDescriptor;
        }
    }
}