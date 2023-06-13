using System;
using System.IO;
using Fish;
using Resources.Patterns.Fish;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.AssetImporters;

namespace Editor {

    /// <summary>
    /// Imports any Microsoft Excel files as an asset. By default, Unity cannot Resource.Load() the "xlsx" file
    /// extension. Therefore, we need to create and attach an asset to it that Unity can read.
    /// <a href="https://gist.github.com/fabSchneider/2aab06bd3b34e50a2c085a9660ae9550">The example I mostly copied.</a>
    /// <remarks>
    /// Created by William. I mostly copied the link above, but I had to heavily modify the other bits of it.
    /// Instead of reading the text, I chose to read the bytes instead.
    /// </remarks>
    /// </summary>
    [ScriptedImporter(1, "xlsx")]
    public class ExcelImporter : ScriptedImporter
    {
        public override void OnImportAsset(AssetImportContext ctx)
        {
            // Read bytes from file.
            CustomTextAsset asset = CustomTextAsset.CreateAsset(File.ReadAllBytes(ctx.assetPath));

            // Checking if the asset is null.
            if (asset.IsUnityNull()) throw new NullReferenceException("Unable to read bytes...");
            if (0 == asset.bytes.Length) throw new Exception("Imported excel file has 0 bytes...");

            // Attaching the asset to the excel file in unity.
            ctx.AddObjectToAsset("excel", asset);
            ctx.SetMainObject(asset);

            // Create the asset in Unity.
            FishFileReader fileReader = new FishFileReader();
            fileReader.Initialize(asset);
        }
    }

    [CustomEditor(typeof(ExcelImporter))]
    internal class ExcelImporterEditor : AssetImporterEditor
    {
        protected override bool needsApplyRevert => false;
        public override void OnInspectorGUI(){ }
    }
}
