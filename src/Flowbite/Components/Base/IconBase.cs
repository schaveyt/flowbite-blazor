using Microsoft.AspNetCore.Components;

namespace Flowbite.Components.Base;

/// <summary>
/// Base class for icon components providing common functionality.
/// </summary>
public abstract class IconBase : ComponentBase
{
    /// <summary>
    /// Additional CSS class names to apply to the icon.
    /// </summary>
    [Parameter]
    public string? CssClass { get; set; }

    /// <summary>
    /// Whether the icon should be hidden from screen readers.
    /// </summary>
    [Parameter]
    public bool AriaHidden { get; set; } = true;

    /// <summary>
    /// Additional attributes to be applied to the SVG element.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    /// <summary>
    /// Gets the combined CSS classes including base and additional classes.
    /// </summary>
    protected string CombinedClassNames
    {
        get
        {
            var classes = new List<string> { "h-5 w-5" };
            if (!string.IsNullOrEmpty(CssClass))
            {
                classes.AddRange(CssClass.Split(' ').Where(c => !string.IsNullOrEmpty(c)));
            }
            return string.Join(" ", classes.Distinct());
        }
    }
}
