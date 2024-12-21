using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Flowbite.Components.Base;

namespace Flowbite.Components;

/// <summary>
/// Alert component for displaying contextual feedback messages.
/// </summary>
public partial class Alert
{
    private string BaseClasses => "flex flex-col gap-2 p-4 text-sm";
    private string RoundedClasses => "rounded-lg";
    private string BorderAccentClasses => "border-t-4";

    /// <summary>
    /// The main text content of the alert.
    /// </summary>
    [Parameter]
    public string? Text { get; set; }

    /// <summary>
    /// Optional emphasized text that appears before the main text.
    /// </summary>
    [Parameter]
    public string? TextEmphasis { get; set; }

    /// <summary>
    /// Optional custom content for complex scenarios.
    /// This allows for custom HTML when Text/TextEmphasis isn't sufficient.
    /// </summary>
    [Parameter]
    public RenderFragment? CustomContent { get; set; }

    /// <summary>
    /// The color variant of the alert.
    /// </summary>
    [Parameter]
    public AlertColor Color { get; set; } = AlertColor.Info;

    /// <summary>
    /// Optional icon to display at the start of the alert.
    /// The icon will inherit the alert's color scheme.
    /// </summary>
    [Parameter]
    public IconBase? Icon { get; set; }

    /// <summary>
    /// Optional additional content to display below the main alert content.
    /// </summary>
    [Parameter]
    public RenderFragment? AdditionalContent { get; set; }

    /// <summary>
    /// Event callback for when the alert is dismissed.
    /// </summary>
    [Parameter]
    public EventCallback<MouseEventArgs> OnDismiss { get; set; }

    /// <summary>
    /// Whether the alert should have rounded corners.
    /// </summary>
    [Parameter]
    public bool Rounded { get; set; } = true;

    /// <summary>
    /// Whether the alert should have a colored border accent at the top.
    /// </summary>
    [Parameter]
    public bool WithBorderAccent { get; set; }

    /// <summary>
    /// Additional attributes to be applied to the alert container.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    private string ClassNames => string.Join(" ", new[]
    {
        BaseClasses,
        GetColorClasses(),
        Rounded ? RoundedClasses : null,
        WithBorderAccent ? BorderAccentClasses : null,
        AdditionalAttributes?.ContainsKey("class") == true ? AdditionalAttributes["class"]?.ToString() : null
    }.Where(c => !string.IsNullOrEmpty(c)));

    private string GetColorClasses() => Color switch
    {
        AlertColor.Info => "border-cyan-500 bg-cyan-100 text-cyan-700 dark:bg-cyan-200 dark:text-cyan-800",
        AlertColor.Gray => "border-gray-500 bg-gray-100 text-gray-700 dark:bg-gray-700 dark:text-gray-300",
        AlertColor.Failure => "border-red-500 bg-red-100 text-red-700 dark:bg-red-200 dark:text-red-800",
        AlertColor.Success => "border-green-500 bg-green-100 text-green-700 dark:bg-green-200 dark:text-green-800",
        AlertColor.Warning => "border-yellow-500 bg-yellow-100 text-yellow-700 dark:bg-yellow-200 dark:text-yellow-800",
        AlertColor.Red => "border-red-500 bg-red-100 text-red-700 dark:bg-red-200 dark:text-red-800",
        AlertColor.Green => "border-green-500 bg-green-100 text-green-700 dark:bg-green-200 dark:text-green-800",
        AlertColor.Yellow => "border-yellow-500 bg-yellow-100 text-yellow-700 dark:bg-yellow-200 dark:text-yellow-800",
        AlertColor.Blue => "border-blue-500 bg-blue-100 text-blue-700 dark:bg-blue-200 dark:text-blue-800",
        AlertColor.Cyan => "border-cyan-500 bg-cyan-100 text-cyan-700 dark:bg-cyan-200 dark:text-cyan-800",
        AlertColor.Pink => "border-pink-500 bg-pink-100 text-pink-700 dark:bg-pink-200 dark:text-pink-800",
        AlertColor.Lime => "border-lime-500 bg-lime-100 text-lime-700 dark:bg-lime-200 dark:text-lime-800",
        AlertColor.Dark => "border-gray-600 bg-gray-800 text-gray-200 dark:bg-gray-900 dark:text-gray-300",
        AlertColor.Indigo => "border-indigo-500 bg-indigo-100 text-indigo-700 dark:bg-indigo-200 dark:text-indigo-800",
        AlertColor.Purple => "border-purple-500 bg-purple-100 text-purple-700 dark:bg-purple-200 dark:text-purple-800",
        AlertColor.Teal => "border-teal-500 bg-teal-100 text-teal-700 dark:bg-teal-200 dark:text-teal-800",
        AlertColor.Light => "border-gray-400 bg-gray-50 text-gray-600 dark:bg-gray-500 dark:text-gray-200",
        _ => "border-cyan-500 bg-cyan-100 text-cyan-700 dark:bg-cyan-200 dark:text-cyan-800"
    };

    private string GetIconColorClass() => Color switch
    {
        AlertColor.Info or AlertColor.Cyan => "text-cyan-500",
        AlertColor.Success or AlertColor.Green => "text-green-500",
        AlertColor.Warning or AlertColor.Yellow => "text-yellow-500",
        AlertColor.Failure or AlertColor.Red => "text-red-500",
        AlertColor.Blue => "text-blue-500",
        AlertColor.Pink => "text-pink-500",
        AlertColor.Lime => "text-lime-500",
        AlertColor.Dark => "text-gray-500",
        AlertColor.Indigo => "text-indigo-500",
        AlertColor.Purple => "text-purple-500",
        AlertColor.Teal => "text-teal-500",
        AlertColor.Light => "text-gray-400",
        _ => "text-gray-500"
    };

    private string GetDismissButtonClasses() => Color switch
    {
        AlertColor.Info => "-m-1.5 ml-auto inline-flex h-8 w-8 rounded-lg p-1.5 bg-cyan-100 text-cyan-500 hover:bg-cyan-200 focus:ring-2 focus:ring-cyan-400 dark:bg-cyan-200 dark:text-cyan-600 dark:hover:bg-cyan-300",
        AlertColor.Gray => "-m-1.5 ml-auto inline-flex h-8 w-8 rounded-lg p-1.5 bg-gray-100 text-gray-500 hover:bg-gray-200 focus:ring-2 focus:ring-gray-400 dark:bg-gray-700 dark:text-gray-300 dark:hover:bg-gray-800 dark:hover:text-white",
        AlertColor.Failure => "-m-1.5 ml-auto inline-flex h-8 w-8 rounded-lg p-1.5 bg-red-100 text-red-500 hover:bg-red-200 focus:ring-2 focus:ring-red-400 dark:bg-red-200 dark:text-red-600 dark:hover:bg-red-300",
        AlertColor.Success => "-m-1.5 ml-auto inline-flex h-8 w-8 rounded-lg p-1.5 bg-green-100 text-green-500 hover:bg-green-200 focus:ring-2 focus:ring-green-400 dark:bg-green-200 dark:text-green-600 dark:hover:bg-green-300",
        AlertColor.Warning => "-m-1.5 ml-auto inline-flex h-8 w-8 rounded-lg p-1.5 bg-yellow-100 text-yellow-500 hover:bg-yellow-200 focus:ring-2 focus:ring-yellow-400 dark:bg-yellow-200 dark:text-yellow-600 dark:hover:bg-yellow-300",
        AlertColor.Red => "-m-1.5 ml-auto inline-flex h-8 w-8 rounded-lg p-1.5 bg-red-100 text-red-500 hover:bg-red-200 focus:ring-2 focus:ring-red-400 dark:bg-red-200 dark:text-red-600 dark:hover:bg-red-300",
        AlertColor.Green => "-m-1.5 ml-auto inline-flex h-8 w-8 rounded-lg p-1.5 bg-green-100 text-green-500 hover:bg-green-200 focus:ring-2 focus:ring-green-400 dark:bg-green-200 dark:text-green-600 dark:hover:bg-green-300",
        AlertColor.Yellow => "-m-1.5 ml-auto inline-flex h-8 w-8 rounded-lg p-1.5 bg-yellow-100 text-yellow-500 hover:bg-yellow-200 focus:ring-2 focus:ring-yellow-400 dark:bg-yellow-200 dark:text-yellow-600 dark:hover:bg-yellow-300",
        AlertColor.Blue => "-m-1.5 ml-auto inline-flex h-8 w-8 rounded-lg p-1.5 bg-blue-100 text-blue-500 hover:bg-blue-200 focus:ring-2 focus:ring-blue-400 dark:bg-blue-200 dark:text-blue-600 dark:hover:bg-blue-300",
        AlertColor.Cyan => "-m-1.5 ml-auto inline-flex h-8 w-8 rounded-lg p-1.5 bg-cyan-100 text-cyan-500 hover:bg-cyan-200 focus:ring-2 focus:ring-cyan-400 dark:bg-cyan-200 dark:text-cyan-600 dark:hover:bg-cyan-300",
        AlertColor.Pink => "-m-1.5 ml-auto inline-flex h-8 w-8 rounded-lg p-1.5 bg-pink-100 text-pink-500 hover:bg-pink-200 focus:ring-2 focus:ring-pink-400 dark:bg-pink-200 dark:text-pink-600 dark:hover:bg-pink-300",
        AlertColor.Lime => "-m-1.5 ml-auto inline-flex h-8 w-8 rounded-lg p-1.5 bg-lime-100 text-lime-500 hover:bg-lime-200 focus:ring-2 focus:ring-lime-400 dark:bg-lime-200 dark:text-lime-600 dark:hover:bg-lime-300",
        AlertColor.Dark => "-m-1.5 ml-auto inline-flex h-8 w-8 rounded-lg p-1.5 bg-gray-100 text-gray-500 hover:bg-gray-200 focus:ring-2 focus:ring-gray-400 dark:bg-gray-200 dark:text-gray-600 dark:hover:bg-gray-300",
        AlertColor.Indigo => "-m-1.5 ml-auto inline-flex h-8 w-8 rounded-lg p-1.5 bg-indigo-100 text-indigo-500 hover:bg-indigo-200 focus:ring-2 focus:ring-indigo-400 dark:bg-indigo-200 dark:text-indigo-600 dark:hover:bg-indigo-300",
        AlertColor.Purple => "-m-1.5 ml-auto inline-flex h-8 w-8 rounded-lg p-1.5 bg-purple-100 text-purple-500 hover:bg-purple-200 focus:ring-2 focus:ring-purple-400 dark:bg-purple-200 dark:text-purple-600 dark:hover:bg-purple-300",
        AlertColor.Teal => "-m-1.5 ml-auto inline-flex h-8 w-8 rounded-lg p-1.5 bg-teal-100 text-teal-500 hover:bg-teal-200 focus:ring-2 focus:ring-teal-400 dark:bg-teal-200 dark:text-teal-600 dark:hover:bg-teal-300",
        AlertColor.Light => "-m-1.5 ml-auto inline-flex h-8 w-8 rounded-lg p-1.5 bg-gray-50 text-gray-500 hover:bg-gray-100 focus:ring-2 focus:ring-gray-200 dark:bg-gray-600 dark:text-gray-200 dark:hover:bg-gray-700 dark:hover:text-white",
        _ => "-m-1.5 ml-auto inline-flex h-8 w-8 rounded-lg p-1.5 bg-cyan-100 text-cyan-500 hover:bg-cyan-200 focus:ring-2 focus:ring-cyan-400 dark:bg-cyan-200 dark:text-cyan-600 dark:hover:bg-cyan-300"
    };
}

/// <summary>
/// Defines the available color variants for the Alert component.
/// </summary>
public enum AlertColor
{
    Info,
    Gray,
    Failure,
    Success,
    Warning,
    Red,
    Green,
    Yellow,
    Blue,
    Cyan,
    Pink,
    Lime,
    Dark,
    Indigo,
    Purple,
    Teal,
    Light
}
