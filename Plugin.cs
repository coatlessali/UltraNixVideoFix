using BepInEx;
using HarmonyLib;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace NixVideoFix
{
	[BepInPlugin("com.coatlessali.nixvideofix", "NixVideoFix", "1.0.0")]
	public class Plugin : BaseUnityPlugin
	{
		public static Plugin Instance;
		private void Awake()
		{
			Instance = this;
			Logger.LogInfo("Loading fix...");
			Harmony har = new Harmony("com.coatlessali.nixvideofix");
			har.PatchAll();
		}
	}
	
	[HarmonyPatch(typeof(SetVideoFilePath), "OnEnable")]
	class PatchOnEnable : MonoBehaviour
	{	
		// private string videoName;
		
		static void Prefix(ref string ___videoName)
		{
			if (!SceneHelper.IsPlayingCustom)
			{
				___videoName = ___videoName.Replace("mp4", "webm");
			}
		}
	}
}
