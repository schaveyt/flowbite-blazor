using Microsoft.AspNetCore.Components;

namespace Flowbite.Base
{
    /// <summary>
    /// Base class for Flowbite Blazor components, providing common functionality and styling.
    /// </summary>
    public abstract class FlowbiteComponentBase : ComponentBase
    {
        /// <summary>
        /// Additional CSS classes to apply to the component.
        /// </summary>
        [Parameter]
        public string? Class { get; set; }

        /// <summary>
        /// Combines default component classes with additional user-provided classes.
        /// </summary>
        /// <param name="defaultClasses">The default CSS classes for the component</param>
        /// <returns>A combined string of CSS classes</returns>
        protected string? CombineClasses(string? defaultClasses)
        {
            if (string.IsNullOrWhiteSpace(defaultClasses) && string.IsNullOrWhiteSpace(Class))
                return null;

            return $"{defaultClasses} {Class}".Trim();
        }
    }
}
