﻿using UnityEngine;
using VmodMonkeMapLoader.Models;

namespace VmodMonkeMapLoader.Helpers
{
    public class Constants
    {
        public const int MaskLayerHeadTrigger = 15;
        public const int MaskLayerHandTrigger = 18;
        public const int MaskLayerPlayerTrigger = 20;
        public const string DefaultShaderName = "Standard";
        //public const string CustomMapsFolderName = "CustomMaps";
        public const string CustomMapsFolderName = "Assets/Maps";
        public const string MiscObjectsFolderName = "Misc";
        public const string PluginVersion = "1.0.0";
        public static MapInfo MapInfoError = new MapInfo
        {
            PackageInfo = new MapPackageInfo
            {
                Descriptor = new Descriptor
                {
                    Author = "[error]",
                    Name = "[error]",
                    Description = "[error]"
                }
            }
        };
    }
}