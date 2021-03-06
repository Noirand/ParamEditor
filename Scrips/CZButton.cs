﻿/************************************************************
 * @title	CZButton.cs
 * @desc	汎用ボタンクラス
 * @author	Noirand 2016
 ************************************************************/
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;

public class CZButton : MonoBehaviour {
//===========================================================
// 変数宣言
//===========================================================
	//---------------------------------------------------
	// public
	//---------------------------------------------------
	public void	SetName(string sName)	{m_txtName.text = sName;}

	public Image	Image	{ get { return m_Image; } }
	public Text		TxtName	{ get { return m_txtName; } }

	//---------------------------------------------------
	// private
	//---------------------------------------------------
	private Button		m_Button;
	private Text		m_txtName;
	private Image		m_Image;

//===========================================================
// 関数定義
//===========================================================
	//---------------------------------------------------
	// コンストラクタ
	//---------------------------------------------------
	void Awake()
	{
		m_Button	= GetComponent<Button>();
		m_txtName	= transform.FindChild("Text").GetComponent<Text>();
		m_Image		= GetComponent<Image>();
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
	// コールバックの設定
	//---------------------------------------------------
	public void SetBtnCallBack(UnityAction pAct)
	{
		m_Button.onClick.AddListener(pAct);
	}
	//---------------------------------------------------
//===========================================================
}
