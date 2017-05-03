using System;
using PostSharp.Aspects;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using PostSharp.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace CSTruter.Mvc.Samples.Sample3.Attributes
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ResourceTypeAttribute : TypeLevelAspect, IAspectProvider
    {
        private Type _resourceType;

        public ResourceTypeAttribute(Type resourceType)
        {
            _resourceType = resourceType;
        }

        protected IEnumerable<AspectInstance> GetValidationAttributes(IEnumerable<PropertyInfo> properties)
        {
            return properties.
                SelectMany(property => property.GetCustomAttributes<ValidationAttribute>().
                    Where(attribute => !string.IsNullOrEmpty(attribute.ErrorMessageResourceName) && attribute.ErrorMessageResourceType == null).
                    Select(validationAttribute =>
                    {
                        var constructor = validationAttribute.GetType().GetConstructor(Type.EmptyTypes);
                        var attribute = new ObjectConstruction(constructor);
                        attribute.NamedArguments["ErrorMessageResourceName"] = validationAttribute.ErrorMessageResourceName;
                        attribute.NamedArguments["ErrorMessageResourceType"] = _resourceType;
                        return new AspectInstance(property, new CustomAttributeIntroductionAspect(attribute));
                    })
                );
        }

        protected IEnumerable<AspectInstance> GetDisplayAttributes(IEnumerable<PropertyInfo> properties)
        {
            return properties.
               Where(property => property.GetCustomAttribute<DisplayAttribute>() == null).
               Select(property =>
               {
                   var attribute = new ObjectConstruction(typeof(DisplayAttribute).GetConstructor(Type.EmptyTypes));
                   attribute.NamedArguments["Name"] = property.Name;
                   attribute.NamedArguments["ResourceType"] = _resourceType;
                   return new AspectInstance(property, new CustomAttributeIntroductionAspect(attribute));
               });
        }

        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            var properties = ((Type)targetElement).
                GetProperties().
                Where(property => property.CanWrite);
            return GetDisplayAttributes(properties).Concat(GetValidationAttributes(properties));
        }
    }
}