using System;
using System.Collections.Generic;
using System.IO;
using Ink;
using UnityEditor;
using UnityEngine;

namespace Code.Editor
{
    public static class CustomInkCompiler
    {
        /// <summary>
        /// Simple example method that compiles an Ink story using Ink plugins, and
        /// saves the resulting .json to the StreamingAssets folder for runtime loading.
        /// </summary>
        ///
        [MenuItem("Tools/Compile Ink to Streaming Assets")]
        public static void CompileToStreamingAssets()
        {
            try
            {
                var pluginDirectory = Path.Combine(Application.dataPath, "Plugins");
                var mainInkFilePath = Path.Combine(Application.dataPath, "Ink/Story.ink");
                var outputFilePath = Path.Combine(Application.streamingAssetsPath, "CompiledInk/Story.json");

                var mainInkFileText = File.ReadAllText(mainInkFilePath);

                var inkCompilerOptions = new Compiler.Options
                {
                    countAllVisits = true,
                    pluginDirectories = new List<string> { pluginDirectory },
                    fileHandler = new UnityInkFileHandler(Path.GetDirectoryName(mainInkFilePath)),
                    sourceFilename = mainInkFilePath
                };

                var inkCompiler = new Compiler(mainInkFileText, inkCompilerOptions);
                var compiledStory = inkCompiler.Compile();

                File.WriteAllText(outputFilePath, compiledStory.ToJson());
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}