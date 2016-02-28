/************************************************************
 * @title	CZTab.cs
 * @desc	タブ（トグル）クラス
 * @author	Noirand 2016
 ************************************************************/
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class CZTab : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler {
//===========================================================
// 変数宣言
//===========================================================
	//---------------------------------------------------
	// public
	//---------------------------------------------------
	public void			SetSheet(CZTaskSheet pSheet)	{m_Sheet = pSheet;}

	public Toggle		Toggle		{ get { return m_Toggle; } }
	public string		Name		{ get { return m_txLabel.text; } }
	public bool			IsOn		{ get { return m_Toggle.isOn; } }

	//---------------------------------------------------
	// private
	//---------------------------------------------------
	private CZTaskSheet	m_Sheet;

	private GameObject	m_InputObj;
	private InputField	m_TabNameField;

	private Toggle		m_Toggle;
	private Image		m_Image;
	private Text		m_txLabel;
	private int			m_iPressCount;
	private bool		m_bPressed;		// 押されていれば true

//===========================================================
// 関数定義
//===========================================================
	//---------------------------------------------------
	// コンストラクタ
	//---------------------------------------------------
	void Awake()
	{
		m_Sheet	= null;

		m_Toggle	= GetComponent<Toggle>();
		m_Image		= transform.FindChild("Background").GetComponent<Image>();
		m_txLabel	= transform.FindChild("Label").GetComponent<Text>();

		m_InputObj	= transform.FindChild("TabNameField").gameObject;
		m_TabNameField	= m_InputObj.GetComponent<InputField>();

		m_iPressCount	= 0;
		m_bPressed	= false;
	}
	//---------------------------------------------------
	// 最初の更新
	//---------------------------------------------------
	void Start()
	{
		m_InputObj.SetActive(false);
	}
	//---------------------------------------------------
	// 更新処理
	//---------------------------------------------------
	void Update()
	{
		UpdateName();

		if (m_bPressed)
		{
			if (++m_iPressCount > SCZDefine.LONG_PRESS_TIME)
			{
				m_InputObj.SetActive(true);
				m_bPressed = false;
				m_iPressCount = 0;
			}
		}

		m_txLabel.color = (IsOn) ? SCZDefine.FOCUS_TEXT_COLOR : SCZDefine.NORMAL_TEXT_COLOR;
		m_Image.color	= (IsOn) ? SCZDefine.FOCUS_LABEL_COLOR : SCZDefine.NORMAL_LABEL_COLOR;
	}
	//---------------------------------------------------
	// タブおよびシートの名前更新
	//---------------------------------------------------
	private void UpdateName()
	{
		if (m_Sheet != null)
		{
			if (m_TabNameField.text != "")
			{
				SetName(m_TabNameField.text);
				m_Sheet.SetName(m_TabNameField.text);
			}
		}
	}
	//---------------------------------------------------
	// 名前設定
	//---------------------------------------------------
	public void SetName(string sName)
	{
		m_txLabel.text = sName;
	}
	//---------------------------------------------------
	// コールバック
	//---------------------------------------------------
	public void OnPointerDown(PointerEventData e)
	{
		if (!m_bPressed && m_Sheet != null)
		{
			m_bPressed = true;
			m_iPressCount = 0;
		}
	}
	//---------------------------------------------------
	public void OnPointerUp(PointerEventData e)
	{
		if (m_bPressed)
		{
			m_bPressed = false;
			m_iPressCount = 0;
		}
	}
	//---------------------------------------------------
	public void OnPointerExit(PointerEventData e)
	{
		if (m_bPressed)
		{
			m_bPressed = false;
			m_iPressCount = 0;
		}
		if (m_InputObj.activeSelf)
		{
			m_InputObj.SetActive(false);
		}
	}
	//---------------------------------------------------
//===========================================================
}
