/************************************************************
 * @title	SCZDefine.cs
 * @desc	定数定義クラス
 * @author	Noirand 2016
 ************************************************************/
using UnityEngine;
using System.Collections;

public static class SCZDefine {
//===========================================================
// 定数宣言
//===========================================================
	//---------------------------------------------------
	// 列の型
	//---------------------------------------------------
	public enum COL_TYPE
	{
		 NONE	= 0
		,INT
		,FLOAT
		,STRING
		,BOOL
	};
	//---------------------------------------------------
	// コンポーネントのサイズ
	//---------------------------------------------------
	public const float	COL_HEADER_Y	= 300 - 360;
	public static readonly Vector2	CELL_SIZE	 = new Vector2(160, 36);
	public static readonly Vector2	CELL_POS_OFS = new Vector2(12, 12);
	public static readonly Vector3	COL_BTN_POS	= new Vector3(-280+560, 300-360, 0);
	public static readonly Vector3	ROW_BTN_POS	= new Vector3(-480+560, 208-360, 0);

	//---------------------------------------------------
	// 色定義
	//---------------------------------------------------
	public static readonly Color	COL_BTN_COLOR		= Color.green;
	public static readonly Color	ROW_BTN_COLOR		= Color.green;

	public static readonly Color	FOCUS_LABEL_COLOR	= Color.blue;
	public static readonly Color	FOCUS_TEXT_COLOR	= Color.white;
	public static readonly Color	NORMAL_LABEL_COLOR	= Color.white;
	public static readonly Color	NORMAL_TEXT_COLOR	= Color.black;

	//---------------------------------------------------
	// string 文字数上限
	//---------------------------------------------------
	public const int	STRING_MAX	= 8;
	//---------------------------------------------------
//===========================================================
}
