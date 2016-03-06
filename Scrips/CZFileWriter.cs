/************************************************************
 * @title	CZFileWriter.cs
 * @desc	パラメータファイル書き出しクラス
 * @author	Noirand 2016
 ************************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class CZFileWriter {
//===========================================================
// 変数宣言
//===========================================================
	//---------------------------------------------------
	// public
	//---------------------------------------------------
	public static CZFileWriter		Instance	{ get {return m_Instance;} }

	//---------------------------------------------------
	// private
	//---------------------------------------------------
	private static CZFileWriter		m_Instance = null;

//===========================================================
// 関数定義
//===========================================================
	//---------------------------------------------------
	// コンストラクタ
	//---------------------------------------------------
	public CZFileWriter()
	{
		if (m_Instance == null)
		{
			m_Instance = this;
		}
	}
	//---------------------------------------------------
	// ファイル書き出し処理
	//---------------------------------------------------
	public void WriteFile(List<CZColumnHeader> pClmList, string sFileName="")
	{
		// ファイル名とファイルパスの調整
		if (sFileName == "")
		{
			sFileName = "outFile.txt";
		}
		else
		{
			sFileName += ".txt";
		}
#if UNITY_STANDALONE_OSX && !UNITY_EDITOR
		string sFilePath = Application.dataPath + "/../../output/";
#else
		string sFilePath = Application.dataPath + "/../output/";
#endif
		if (!Directory.Exists(sFilePath))
		{
			Directory.CreateDirectory(sFilePath);
		}

		// ファイル書き込みここから
		StreamWriter sw;
		FileInfo fi = new FileInfo(sFilePath + sFileName);
		sw = fi.AppendText();

		// 書き込み
		if (pClmList == null)
		{
			sw.WriteLine("TEST");
		}
		else
		{
			// 変数名
			for (int ii=0; ii<pClmList.Count; ++ii)
			{
				if (ii != 0)
				{
					sw.Write(",");
				}

				sw.Write(pClmList[ii].ColName);

				if (ii == pClmList.Count - 1)
				{
					sw.WriteLine("");
				}
			}
			// 値
			int iIdNum = pClmList[0].CellList.Count;
			for (int jj = 0; jj < iIdNum; ++jj)
			{
				for (int ii=0; ii<pClmList.Count; ++ii)
				{
					if (ii != 0)
					{
						sw.Write(",");
					}

					sw.Write(pClmList[ii].CellList[jj].Param);

					if (ii == pClmList.Count - 1)
					{
						sw.WriteLine("");
					}
				}
			}
		}

		// あとしまつ
		sw.Flush();
		sw.Close();
	}
	//---------------------------------------------------
//===========================================================
}
