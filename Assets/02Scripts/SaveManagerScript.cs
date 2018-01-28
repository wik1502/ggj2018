using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SaveManagerScript : MonoBehaviour {
	public static string SCENE_NAME = "SceneName";
	string sceneName;

	[SerializeField] private GameObject player;

	private enum MAIN_PARA_ID {
		normal = 0,
		tempe,
		air,
		grav,
		mass,
		MAXID
	};

	private enum SUB_PARA_ID {
		water = 0,						//イメージとしては　const int water = 0(読み取り専用)
		elec,
		pois,
		metal,
		MAXID
	};

	string[] mainParamName = {"defalt","tempe", "air","grav","mass"};
	string[] subParamName = {"water", "elec","pois","metal"};
	int cha;
	int i;
	int[] mainPara = new int[(int)(MAIN_PARA_ID.MAXID)];
	int[] subPara = new int[(int)(SUB_PARA_ID.MAXID)];
	// Use this for initialization
	void Start () {
		for (i = 0; i < (int)MAIN_PARA_ID.MAXID; i++) {
			cha = PlayerPrefs.GetInt ("Data0MainPara" + mainParamName [i]);
			mainPara [i] = cha;
			Debug.Log (mainParamName[i]+":"+mainPara [i]);
		}
		for (i = 0; i < (int)SUB_PARA_ID.MAXID; i++) {
			cha = PlayerPrefs.GetInt ("Data0SubPara" + subParamName [i]);
			subPara [i] = cha;
			Debug.Log (subParamName[i]+":"+subPara [i]);
		}

	}

	// Update is called once per frame
	void Update () {

	}

	public void PushSaveButton(int saveNo){								//押されたセーブボタンのスクリプト＆ボタンの番号読み込み
		Debug.Log (saveNo);												//選択したロードボタンをログで表示
		for(int i = 0; i < (int)MAIN_PARA_ID.MAXID; i++){
			PlayerPrefs.SetInt ("Data" + saveNo + "MainPara" + mainParamName[i], mainPara[i]);		//メインパラメータを保管
			PlayerPrefs.Save();
			Debug.Log(PlayerPrefs.GetInt ("Data" + saveNo + "MainPara" + mainParamName[i]));
		}
		for(i = 0; i < (int)SUB_PARA_ID.MAXID; i++){
			PlayerPrefs.SetInt ("Data" + saveNo + "SubPara" + subParamName[i], subPara[i]);		//サブパラメータを保管
			PlayerPrefs.Save();
			Debug.Log(PlayerPrefs.GetInt ("Data" + saveNo + "SubPara" + subParamName[i]));
		}
	}

	public void PushBackButton(){										//戻るボタンを押したときのスクリプト
		sceneName = PlayerPrefs.GetString(SCENE_NAME);
		SceneManager.LoadScene (sceneName);
	}
}
