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

	public CZSheetMng	SheetMng	{ get { return m_SheetMng; } }
	public GameObject	PrefSheet	{ get { return m_PrefSheet; } }

	//---------------------------------------------------
	// private
	//---------------------------------------------------
	private static CZAdministrator	m_Instance = null;

	private EZ_STATE_ID		m_eState;
	private CZSheetMng		m_SheetMng;

	// リソースは全部 Admin が持つことにする？
	private GameObject		m_PrefSheet;

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

		m_PrefSheet	= Resources.Load<GameObject>("Prefabs/Pref_Sheet");
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
//===========================================================
}
