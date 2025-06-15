using Ink;
using Ink.Parsed;

namespace ExampleInkPlugin
{
    /// <summary>
    /// Minimal demonstration of a working Ink plugin.
    /// When you compile Ink using this plugin, the plugin simply adds some text
    /// to the start of the main Ink file.
    ///
    /// The .csproj file references the compiled Ink-Libraries.dll in the Unity project,
    /// which Unity generates automatically from the Ink Unity integration package. This
    /// allows the plugin to reference the Ink namespace.
    /// </summary>
    public class ExampleInkPlugin : IPlugin
    {
        public void PreParse(ref string storyContent)
        {
            storyContent = "The following text has been pre-parsed by ExampleInkPlugin:\n\n" + storyContent;
        }

        public void PostParse(ref Story parsedStory)
        {
            // Do nothing
        }

        public void PostExport(Story parsedStory, ref Ink.Runtime.Story runtimeStory)
        {
            // Do nothing
        }
    }
}
