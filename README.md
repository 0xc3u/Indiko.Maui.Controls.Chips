![](nuget.png)

# ChipsView Component for MAUI.NET
Enhance your MAUI.NET applications with a flexible, customizable ChipsView component. Easily display a collection of chips for tagging, selections, or inputs with extensive customization options.

## Build Status
![ci](https://github.com/0xc3u/Indiko.Maui.Controls.Chips/actions/workflows/ci.yml/badge.svg)

## Install Controls
[![NuGet](https://img.shields.io/nuget/v/Indiko.Maui.Controls.Chips.svg?label=NuGet)](https://www.nuget.org/packages/Indiko.Maui.Controls.Chips/)

Available on [NuGet](http://www.nuget.org/packages/Indiko.Maui.Controls.Chips).

Install with the dotnet CLI: `dotnet add package Indiko.Maui.Controls.Chips`, or through the NuGet Package Manager in Visual Studio.


## Features
- `Customizable Appearance`: Tailor the chips' look and feel to fit your app's theme, including colors, border radius, and padding.
- `Data Binding`: Easily bind a collection of items to the ChipsView for dynamic chip content.
- `Selection`: Support for single or multiple selections within the chips collection.
- `Events`: Handle chip click, selection, and deletion events to trigger actions within your app.
- `Icons & Images`: Add icons or images to chips for a more informative and visually appealing presentation.

## Bindable Properties

The `ChipsView` component offers several bindable properties to customize the Chips rendering:

- `ItemSource`: The collection of items to be displayed as chips.
- `SelectedItems`: The collection of selected items within the chips.

### Platform supported

| Platform | Minimum Version Supported |
|----------|--------------------------|
| iOS      |   14.2+         |
| Android  |   21+   |

### Dependency Injection

You will first need to register the `Indiko.Maui.Controls.Chips` with the `MauiAppBuilder` following the same pattern that the .NET MAUI Essentials libraries follow.

```csharp
builder.UseMauiApp<App>()
	   .UseChipsView();
```

## Usage

To use the `ChipsView` in your MAUI.NET application, include it in your XAML or C# code and bind or set the `ChipsText` property to your Chips-formatted string. Customize the appearance using the available bindable properties to match your application's design.

```xml
xmlns:idk="clr-namespace:Indiko.Maui.Controls.Chips;assembly=Indiko.Maui.Controls.Chips"

...

<idk:ChipsView ItemSource="{Binding Chips}" 
               AlignContent="Start"
               JustifyContent="Start" Wrap="Wrap" />
```

Ensure to include the namespace reference for `ChipsView` in your XAML or add the component programmatically in your C# code.
