﻿using UnityEngine;
using System.Collections;
using Mugen;

[RequireComponent(typeof(SceneImageRes))]
public class StageMgr : MonoSingleton<StageMgr> {

	public string DefaultSceneRoot= string.Empty;
	public string DefaultSceneName = string.Empty;
	private SceneConfig m_Config = null;
    private SceneImageRes m_ImageRes = null;
    private string m_LoadedSceneName = string.Empty;
    private string m_LoadedSceneFileName = string.Empty;
    private int m_LastPalletGroupLink = -1;
    private int m_LastpalletImageLink = -1;

	public bool LoadOk = false;

    public void SetLastPalletLink(int palletGroupLink, int palletImageLink)
    {
        m_LastPalletGroupLink = palletGroupLink;
        m_LastpalletImageLink = palletImageLink;
    }

    public void LinkImageFramePalletLastLink(ImageFrame frame)
    {
        if (frame == null)
            return;
        frame._SetLocalPalletLink(m_LastPalletGroupLink, m_LastpalletImageLink);
    }

    public string LoadedSceneFileName
    {
        get
        {
            return m_LoadedSceneFileName;
        }
    }

	public void Clear()
	{
        DestroyScene();

		m_Config = null;
        if (m_ImageRes != null)
        {
            m_ImageRes.Clear();
        }
		LoadOk = false;
        m_LoadedSceneName = string.Empty;
        m_LoadedSceneFileName = string.Empty;
        m_LastPalletGroupLink = -1;
        m_LastpalletImageLink = -1;
	}

    public SceneImageRes ImageRes
    {
        get
        {
            if (m_ImageRes == null)
                m_ImageRes = GetComponent<SceneImageRes>();
            return m_ImageRes;
        }
    }

	void LoadConfig(string fileName)
	{
		Clear ();
		if (string.IsNullOrEmpty (fileName))
			return;
		m_Config = new SceneConfig ();
		LoadOk = m_Config.LoadFromFile (fileName);
	}

    private void CreateSceneLayer(IBg bg)
    {
		if (bg == null || bg.bgType == BgType.none)
            return;
        GameObject obj = new GameObject(bg.name, typeof(SceneLayerDisplay));
        var trans = obj.transform;
        trans.SetParent(this.transform, false);
        trans.localPosition = Vector3.zero;
        trans.localScale = Vector3.one;
        trans.localRotation = Quaternion.identity;

        var dislpay = obj.GetComponent<SceneLayerDisplay>();
        dislpay.layerno = bg.layerno;
		if (bg.bgType == BgType.normal)
			dislpay.InitStatic (bg as BgStaticInfo);
    }

    // 創建場景
    private void CreateScene()
    {
        SceneImageRes imgRes = this.ImageRes;
        if (imgRes == null || m_Config == null || !m_Config.IsVaild)
            return;
		var bgCfg = m_Config.BgCfg;
        if (bgCfg == null)
            return;
        for (int i = 0; i < bgCfg.BgCount; ++i)
        {
            IBg bg = bgCfg.GetBg(i);
            if (bg == null)
                continue;
            CreateSceneLayer(bg);
        }
    }

    // 进入当前场景
    public bool EnterCurrentScene()
    {
        SceneImageRes imgRes = this.ImageRes;
        if (imgRes == null || m_Config == null || !m_Config.IsVaild)
            return false;
        var bgCfg = m_Config.BgCfg;
        if (bgCfg == null)
            return false;
        var bgDef = m_Config.bgDef;
        if (bgDef == null || string.IsNullOrEmpty(bgDef.spr))
            return false;
        var name = bgDef.spr;
		name = GlobalConfigMgr.GetConfigFileNameNoExt(name);
        if (string.IsNullOrEmpty(name))
            return false;
        string sceneRoot;
        if (string.IsNullOrEmpty(DefaultSceneRoot))
        {
            sceneRoot = string.Format("{0}@{1}/{2}", AppConfig.GetInstance().SceneRootDir, DefaultSceneName, name);
            
        }
        else
        {
            sceneRoot = string.Format("{0}{1}/@{2}/{3}", AppConfig.GetInstance().SceneRootDir, DefaultSceneRoot, DefaultSceneName, name);
        }
        string fileName = string.Format("{0}.sff.bytes", sceneRoot);
        if (!imgRes.LoadScene(fileName, bgCfg))
            return false;

        m_LoadedSceneName = this.DefaultSceneName;
        m_LoadedSceneFileName = sceneRoot;
        // 創建場景
        CreateScene();

        

        return true;
    }

    public void LoadScene(string root)
    {
        if (string.IsNullOrEmpty(root))
            return;
        string fileName = string.Format("{0}{1}.def.txt", AppConfig.GetInstance().SceneRootDir, root);
        LoadConfig(fileName);
    }

    public void LoadDefaultScene(string root, string sceneName)
    {
        DefaultSceneRoot = root;
        DefaultSceneName = sceneName;
        LoadDefaultScene();
    }

    void DestroyScene()
    {
        // 刪除所有場景子節點
        this.transform.DestroyChildren();
    }

	void LoadDefaultScene()
	{
        if (string.Compare(m_LoadedSceneName, DefaultSceneName, true) == 0)
            return;
		Clear ();
		if (string.IsNullOrEmpty (DefaultSceneName))
			return;
		string root;
		if (string.IsNullOrEmpty (DefaultSceneRoot))
			root = string.Format ("@{0}/{0}", DefaultSceneName);
		else
			root = string.Format ("{0}/@{1}/{1}", DefaultSceneRoot, DefaultSceneName);
        LoadScene(root);
        // 如果成功則進入場景
        if (LoadOk)
        {
            EnterCurrentScene();
        }
	}

	void Start()
	{
		LoadDefaultScene ();
	}
}
