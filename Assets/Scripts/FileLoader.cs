using SFB;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileLoader : MonoBehaviour
{
    void Start()
    {
		string map = StandaloneFileBrowser.OpenFilePanel("Select Map", @"C:\Program Files (x86)\Steam\steamapps\common\Gorilla Tag\BepInEx\plugins\MonkeMapLoader\CustomMaps", "gtmap", false)[0];
		string replay = StandaloneFileBrowser.OpenFilePanel("Select Replay", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\GorillaKZ\Replays", "gtrec", false)[0];
        GetComponent<MapLoader>().LoadMapFromPath(map);
        GetComponent<ReplayLoader>().LoadReplay(replay);
    }
}
