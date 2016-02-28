/************************************************************
 * @title	CZSheetSwitcher.cs
 * @desc	シート（タブ？）切り替えクラス
 * @author	Noirand 2016
 ************************************************************/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CZSheetSwitcher : MonoBehaviour {
//===========================================================
// 変数宣言
//===========================================================
	//---------------------------------------------------
	// public
	//---------------------------------------------------
	public List<CZTab>	TabList		{ get {return m_TabList;} }

	//---------------------------------------------------
	// private
	//---------------------------------------------------
	private List<CZTab>	m_TabList;
	private ToggleGroup	m_TglGroup;

//===========================================================
// 関数定義
//===========================================================
	//---------------------------------------------------
	// コンストラクタ
	//---------------------------------------------------
	void Awake()
	{
		m_TabList	= new List<CZTab>();
		m_TglGroup	= GetComponent<ToggleGroup>();
	}
	//---------------------------------------------------
	// 最初の更新
	//---------------------------------------------------
	void Start()
	{
		// トップメニューをリストに追加しておく
		CZAdministrator.Admin.CreateTab("TopMenu");
		//m_TabList[0].Toggle.isOn = true;
	}
	//---------------------------------------------------
	// 更新処理
	//---------------------------------------------------
	void Update()
	{
		UpdateSheetPriority();
	}
	//---------------------------------------------------
	// チェックが入っているシートを最前面に表示
	//---------------------------------------------------
	private void UpdateSheetPriority()
	{
		string sFrontName = "";

		foreach (CZTab pTab in m_TabList)
		{
			if (pTab.IsOn)
			{
				sFrontName = pTab.Name;
				break;
			}
		}

		if (sFrontName == "TopMenu")
		{
			CZAdministrator.Admin.SheetMng.transform.FindChild(sFrontName).SetAsLastSibling();
		}
		else if (sFrontName != "")
		{
			foreach (CZTaskSheet pSheet in CZAdministrator.Admin.SheetMng.SheetList)
			{
				if (pSheet.Name == sFrontName)
				{
					pSheet.transform.SetAsLastSibling();
					break;
				}
			}
		}
	}
	//---------------------------------------------------
	// タブリストに追加
	//---------------------------------------------------
	public void AddList(CZTab pTab)
	{
		if (m_TabList != null)
		{
			m_TabList.Add(pTab);
			pTab.Toggle.group = m_TglGroup;
			pTab.Toggle.isOn = true;
		}
	}
	//---------------------------------------------------
//===========================================================
}
