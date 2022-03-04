using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.SceneManagement;
using VmodMonkeMapLoader.Behaviours;
using VmodMonkeMapLoader.Models;

public class MapLoader : MonoBehaviour
{
	public string mapName = "Assets/Maps/gkz__beginnerblock.gtmap";

	// Start is called before the first frame update
	void Start()
	{
		//LoadMapFromPackageFile(mapName);
	}


	public void LoadMapFromPath(string filePath)
	{
		AssetBundle bundle = VmodMonkeMapLoader.Helpers.MapFileUtils.GetAssetBundleFromZip(filePath);
		//var assetNames = bundle.GetAllAssetNames();

		//Debug.Log("Asset count: " + assetNames.Length + ", assets: " + string.Join(";", assetNames));

		//Debug.Log("Asset name: " + mapInfo.PackageInfo.Descriptor.Name);

		string[] scenePath = bundle.GetAllScenePaths();

		SceneManager.LoadScene(scenePath[0], LoadSceneMode.Additive);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
