# Unity Ink compiler plugin example

This simple example shows how to create and use a compiler plugin for [Ink](https://github.com/inkle/ink), the narrative scripting language.

Ink compiler plugins let you add functionality to the Ink compilation process in a simple way, without having to modify Ink source code. 

This example works with the [Ink Unity integration](https://github.com/inkle/ink-unity-integration/).

## Description

Ink compiler plugins implement the **Ink.Compiler.IPlugin** interface. At compile time, the Ink compiler's **PluginManager** class finds and uses plugins in locations specified in **Ink.Compiler.Options.pluginDirectories**.

*Tools/ExampleInkPlugin/* contains a .NET project for a plugin that modifies the text of the compiled story file. The .csproj file contains a post-build instruction to copy the built .dll to *Assests/Plugins* in the Unity project. 

*UnityProject/ink-compiler-plugin-example* is a Unity project with a script that compiles an Ink file using the plugin. The source Ink file is in *Assets/Ink* and the compiled Ink (with additional text added by the plugin) in *StreamingAsets/CompiledInk*. To run the script, use the menu option **Tools > Compile Ink to Streaming Assets**.

Note: the Ink Unity integration package doesn't currently expose the **Ink.Compiler.Options.pluginDirectories** property for its default compiler. This example demonstrates manual compilation, but the same principles apply if you want to modify the package source.

## Compatibility
Created with Unity 6.0 and Ink Unity integration version 1.2.1, but there's nothing fancy in here that shouldn't work in older versions.
