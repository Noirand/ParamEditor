/************************************************************
 * @title	CZTaskSheet.cs
 * @desc	シートタスククラス
 * @author	Noirand
 ************************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CZTaskSheet : MonoBehaviour {
//===========================================================
// 変数宣言
//===========================================================
	//---------------------------------------------------
	// public
	//---------------------------------------------------
	public enum EZ_STATE_ID
	{
		 INIT	= 0
		,RUN
		,TERM
	}

	public string	Name	{ get { return m_sName; } }

	//---------------------------------------------------
	// private
	//---------------------------------------------------
	private EZ_STATE_ID		m_eState;

	private List<CZColumnHeader>	m_ClmList;
	private CZButton	m_BtnClm;
	private CZButton	m_BtnRow;
	private RectTransform	m_RectTr;

	private string	m_sName;		// シート名
	private int		m_iRowNum;

//===========================================================
// 関数定義
//===========================================================
	//---------------------------------------------------
	// コンストラクタ
	//---------------------------------------------------
	void Awake ()
	{
		m_eState	= EZ_STATE_ID.INIT;
		m_ClmList	= new List<CZColumnHeader>();
		m_iRowNum	= 0;
		m_RectTr	= GetComponent<RectTransform>();
	}
	//---------------------------------------------------
	// 最初の更新
	//---------------------------------------------------
	void Start ()
	{
		CreateClmHeader();
		m_BtnClm	= CZAdministrator.Admin.CreateButton(transform, SCZDefine.COL_BTN_POS, "BtnClm");
		m_BtnRow	= CZAdministrator.Admin.CreateButton(transform, SCZDefine.ROW_BTN_POS, "BtnRow");

		m_BtnClm.GetComponent<RectTransform>().anchorMax =
			m_BtnClm.GetComponent<RectTransform>().anchorMin =
				new Vector2(0, 1);
		m_BtnRow.GetComponent<RectTransform>().anchorMax =
			m_BtnRow.GetComponent<RectTransform>().anchorMin =
				new Vector2(0, 1);
		m_BtnClm.transform.localPosition = SCZDefine.COL_BTN_POS;
		m_BtnRow.transform.localPosition = SCZDefine.ROW_BTN_POS;

		m_BtnClm.Image.color	= SCZDefine.COL_BTN_COLOR;
		m_BtnRow.Image.color	= SCZDefine.ROW_BTN_COLOR;
		m_BtnClm.SetName("列追加");
		m_BtnRow.SetName("行追加");
		m_BtnClm.SetBtnCallBack(ClickAddMember);
		m_BtnRow.SetBtnCallBack(ClickAddId);
	}
	//---------------------------------------------------
	// 更新処理
	//---------------------------------------------------
	void Update ()
	{
		switch (m_eState)
		{
			case EZ_STATE_ID.INIT:
				break;
			case EZ_STATE_ID.RUN:
				break;
			case EZ_STATE_ID.TERM:
				break;
		}
	}
	//---------------------------------------------------
	// カラムヘッダーを生成
	//---------------------------------------------------
	private CZColumnHeader CreateClmHeader()
	{
		CZColumnHeader	pRet = null;

		if (CZAdministrator.Admin.PrefClmHeader != null)
		{
			GameObject pObj = Instantiate(CZAdministrator.Admin.PrefClmHeader) as GameObject;
			pObj.name = "Col_" + m_ClmList.Count;
			pObj.transform.SetParent(transform);
			float fPosX = (SCZDefine.CELL_SIZE.x + 12) * m_ClmList.Count - 480;
			pObj.transform.localPosition	= new Vector3(fPosX + 560, SCZDefine.COL_HEADER_Y, 0);
			pObj.transform.localScale		= Vector3.one;

			pRet = pObj.GetComponent<CZColumnHeader>();
			m_ClmList.Add(pRet);

			for (int ii = 0; ii < m_iRowNum; ++ii)
			{
				if (pRet.CellList.Count < m_iRowNum)
				{
					pRet.CreateCell();
				}
			}
		}

		return pRet;
	}
	//---------------------------------------------------
	// ボタンコールバック
	//---------------------------------------------------
	public void ClickAddId()
	{
		// リストの要素を 1 増やす
		++m_iRowNum;
		foreach (CZColumnHeader pClm in m_ClmList)
		{
			pClm.CreateCell();
		}
		Vector3 vPos = m_BtnRow.transform.localPosition;
		vPos.y -= SCZDefine.CELL_SIZE.y + SCZDefine.CELL_POS_OFS.y;
		m_BtnRow.transform.localPosition = vPos;

		Vector2 vSize = m_RectTr.sizeDelta;
		vSize.y += SCZDefine.CELL_SIZE.y + SCZDefine.CELL_POS_OFS.y;
		m_RectTr.sizeDelta = vSize;
	}
	//---------------------------------------------------
	public void ClickAddMember()
	{
		// ClmHeader を追加する
		CreateClmHeader();
		Vector3 vPos = m_BtnClm.transform.localPosition;
		vPos.x += SCZDefine.CELL_SIZE.x + SCZDefine.CELL_POS_OFS.x;
		m_BtnClm.transform.localPosition = vPos;

		Vector2 vSize = m_RectTr.sizeDelta;
		vSize.x += SCZDefine.CELL_SIZE.x + SCZDefine.CELL_POS_OFS.x;
		m_RectTr.sizeDelta = vSize;
	}
	//---------------------------------------------------
//===========================================================
}
