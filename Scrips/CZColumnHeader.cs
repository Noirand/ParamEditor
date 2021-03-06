﻿/************************************************************
 * @title	CZColumnHeader.cs
 * @desc	列先頭クラス
 * @author	Noirand 2016
 ************************************************************/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CZColumnHeader : MonoBehaviour {
//===========================================================
// 変数宣言
//===========================================================
	//---------------------------------------------------
	// public
	//---------------------------------------------------
	public List<CZParamCell>	CellList	{ get {return m_CellList;} }
	public SCZDefine.COL_TYPE	ColType		{ get {return (SCZDefine.COL_TYPE)m_SelType.value;} }

	public string		ColName		{ get {return m_ColName.text;} }
	public float		ColSizeW	{ get { return m_vColSize.x; } }

	//---------------------------------------------------
	// private
	//---------------------------------------------------
	private List<CZParamCell>	m_CellList;

	private Text		m_ColName;		// 列の名前（変数名）
	private Dropdown	m_SelType;
	private Vector2		m_vColSize;

//===========================================================
// 関数定義
//===========================================================
	//---------------------------------------------------
	// コンストラクタ
	//---------------------------------------------------
	void Awake()
	{
		m_CellList	= new List<CZParamCell>();
		m_ColName	= transform.FindChild("InputName").FindChild("Text").GetComponent<Text>();
		m_SelType	= transform.FindChild("SelType").GetComponent<Dropdown>();

		m_vColSize	= m_ColName.GetComponent<RectTransform>().sizeDelta;
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
	// セルの生成
	//---------------------------------------------------
	public CZParamCell CreateCell()
	{
		CZParamCell pRet = null;

		if (CZAdministrator.Admin.PrefCell != null)
		{
			GameObject pObj = Instantiate(CZAdministrator.Admin.PrefCell) as GameObject;
			pObj.name = "Cell_" + m_CellList.Count;
			pObj.transform.SetParent(transform);
			float fPosY = (SCZDefine.CELL_SIZE.y + 12) * m_CellList.Count * (-1) - 72;
			pObj.transform.localPosition	= new Vector3(0, fPosY, 0);
			pObj.transform.localScale		= Vector3.one;

			pRet = pObj.GetComponent<CZParamCell>();
			m_CellList.Add(pRet);
		}

		return pRet;
	}
	//---------------------------------------------------
//===========================================================
}
