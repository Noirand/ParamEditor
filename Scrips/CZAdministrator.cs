/************************************************************
 * @title	CZAdministrator
 * @desc	全体管理
 * @author	Noirand
 ************************************************************/
using UnityEngine;
using System.Collections;

public class CZAdministrator : MonoBehaviour {
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

	public static CZAdministrator	Admin	{ get { return m_Instance; } }

	public CZSheetMng	SheetMng		{ get { return m_SheetMng; } }
	public GameObject	PrefSheet		{ get { return m_PrefSheet; } }
	public GameObject	PrefClmHeader	{ get { return m_PrefClmHeader; } }
	public GameObject	PrefCell		{ get { return m_PrefCell; } }
	public GameObject	PrefBtn			{ get { return m_PrefBtn; } }

	//---------------------------------------------------
	// private
	//---------------------------------------------------
	private static CZAdministrator	m_Instance = null;

	private EZ_STATE_ID		m_eState;
	private CZSheetMng		m_SheetMng;

	// リソースは全部 Admin が持つことにする？
	private GameObject		m_PrefSheet;
	private GameObject		m_PrefClmHeader;
	private GameObject		m_PrefCell;
	private GameObject		m_PrefBtn;

//===========================================================
// 関数定義
//===========================================================
	//---------------------------------------------------
	// コンストラクタ
	//---------------------------------------------------
	void Awake ()
	{
		if (m_Instance == null)
		{
			m_Instance = this;
		}

		m_eState	= EZ_STATE_ID.INIT;
		m_SheetMng	= transform.FindChild("SheetRoot").GetComponent<CZSheetMng>();

		InitPrefab();
	}
	//---------------------------------------------------
	// 最初の更新
	//---------------------------------------------------
	void Start ()
	{
	
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
	// プレハブの初期設定
	//---------------------------------------------------
	private void InitPrefab()
	{
		m_PrefSheet		= Resources.Load<GameObject>("Prefabs/Pref_Sheet");
		m_PrefClmHeader	= Resources.Load<GameObject>("Prefabs/Pref_ClmHeader");
		m_PrefCell		= Resources.Load<GameObject>("Prefabs/Pref_Cell");
		m_PrefBtn		= Resources.Load<GameObject>("Prefabs/Pref_Btn");
	}
	//---------------------------------------------------
	// ボタン生成
	//---------------------------------------------------
	public CZButton CreateButton(Transform trParent, Vector3 vPos, string sName="")
	{
		CZButton pRet = null;

		if (PrefBtn != null)
		{
			GameObject pObj = Instantiate(PrefBtn);
			pObj.name = sName;
			pObj.transform.SetParent(trParent);
			pObj.transform.localPosition	= vPos;
			pObj.transform.localScale		= Vector3.one;
			pRet = pObj.GetComponent<CZButton>();
		}

		return pRet;
	}
	//---------------------------------------------------
//===========================================================
}
