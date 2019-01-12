﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DefaultLoaderPlayer : MonoBehaviour {
	public string PlayerName = string.Empty;
	public string CnsName = string.Empty;


	public GlobalPlayerLoaderResult LoadResult = GlobalPlayerLoaderResult.None;
	public List<string> CnsNameList = null;
	public string LoadAnim = string.Empty;

	public void AddCnsName(string name)
	{
		if (string.IsNullOrEmpty (name))
			return;
		if (CnsNameList == null)
			CnsNameList = new List<string> ();
		if (!CnsNameList.Contains(name))
			CnsNameList.Add (name);
	}
}