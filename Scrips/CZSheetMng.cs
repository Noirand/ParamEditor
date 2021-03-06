﻿/************************************************************
 * @title	CZSheetMng.cs
 * @desc	シートマネージャ
 * @author	Noirand
 ************************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CZSheetMng : MonoBehaviour {
//===========================================================
// 変数宣言
//===========================================================
	//---------------------------------------------------
	// public
	//---------------------------------------------------
	public List<CZTaskSheet>	SheetList	{ get {return m_SheetList;} }

	//---------------------------------------------------
	// private
	//---------------------------------------------------
	private List<CZTaskSheet>	m_SheetList;

//===========================================================
// 関数定義
//===========================================================
	//---------------------------------------------------
	// コンストラクタ
	//---------------------------------------------------
	void Awake()
	{
		Initialize();
	}
	//---------------------------------------------------
	// 最初の更新
	//---------------------------------------------------
	void Start()
	{
	
	}
	//---------------------------------------------------
	// 更新処理
	//---------------------------------------------------
	void Update()
	{
	
	}
	//---------------------------------------------------
	// 初期化
	//---------------------------------------------------
	void Initialize()
	{
		m_SheetList = new List<CZTaskSheet>();
	}
	//---------------------------------------------------
	// 新規シート作成
	//---------------------------------------------------
	public void CreateSheet()
	{
		if (CZAdministrator.Admin.PrefSheet != null)
		{
			GameObject pObj = Instantiate(CZAdministrator.Admin.PrefSheet) as GameObject;
			if (pObj != null)
			{
				CZTaskSheet pSheet = pObj.GetComponent<CZTaskSheet>();
				pSheet.transform.SetParent(transform);
				pSheet.name	= "Sheet_" + m_SheetList.Count;
				pSheet.transform.localPosition	= new Vector3(80-560, 0+360, 0);
				pSheet.transform.localScale		= Vector3.one;
				m_SheetList.Add(pSheet);

				// つくったシートに対応するタブもつくる
				CZAdministrator.Admin.CreateTab(pSheet.name, pSheet);
			}
		}
	}
	//---------------------------------------------------
//===========================================================
}
