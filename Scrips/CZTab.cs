/************************************************************
 * @title	CZTab.cs
 * @desc	タブ（トグル）クラス
 * @author	Noirand 2016
 ************************************************************/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CZTab : MonoBehaviour {
//===========================================================
// 変数宣言
//===========================================================
	//---------------------------------------------------
	// public
	//---------------------------------------------------
	public Toggle		Toggle		{ get { return m_Toggle; } }
	public string		Name		{ get { return m_txLabel.text; } }
	public bool			IsOn		{ get { return m_Toggle.isOn; } }

	//---------------------------------------------------
	// private
	//---------------------------------------------------
	private Toggle		m_Toggle;
	private Image		m_Image;
	private Text		m_txLabel;

//===========================================================
// 関数定義
//===========================================================
	//---------------------------------------------------
	// コンストラクタ
	//---------------------------------------------------
	void Awake()
	{
		m_Toggle	= GetComponent<Toggle>();
		m_Image		= transform.FindChild("Background").GetComponent<Image>();
		m_txLabel	= transform.FindChild("Label").GetComponent<Text>();
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
		m_txLabel.color = (IsOn) ? SCZDefine.FOCUS_TEXT_COLOR : SCZDefine.NORMAL_TEXT_COLOR;
		m_Image.color	= (IsOn) ? SCZDefine.FOCUS_LABEL_COLOR : SCZDefine.NORMAL_LABEL_COLOR;
	}
	//---------------------------------------------------
	// 名前設定
	//---------------------------------------------------
	public void SetName(string sName)
	{
		m_txLabel.text = sName;
	}
	//---------------------------------------------------
//===========================================================
}
