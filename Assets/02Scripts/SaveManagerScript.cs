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

	private enum SAB_PARA_ID {
		water = 0,						//イメージとしては　const int water = 0(読み取り専用)
		elec,
		pois,
		metal,
		MAXID
	};

	string[] mainParamName = {"defalt","tempe", "air","grav","mass"};
	string[] sabParamName = {"water", "elec","pois","metal"};
	int cha;
	int j, l;
	int[] mainPara = new int[(int)(MAIN_PARA_ID.MAXID) - 1];
	int[] sabPara = new int[(int)(SAB_PARA_ID.MAXID)];
	// Use this for initialization
	void Start () {
		for (j = 1; j < (int)MAIN_PARA_ID.MAXID; j++) {
			cha = PlayerPrefs.GetInt ("Data0" + mainParamName [j]);
			mainPara [j - 1] = cha;
			Debug.Log (mainPara [j - 1]);
		}
		for (l = 0; l < (int)SAB_PARA_ID.MAXID; l++) {
			cha = PlayerPrefs.GetInt ("Data0" + sabParamName [l]);
			sabPara [l] = cha;
			Debug.Log (sabPara [l]);
		}

	}

	// Update is called once per frame
	void Update () {

	}

	public void PushSaveButton(int saveNo){								//押されたセーブボタンのスクリプト＆ボタンの番号読み込み
		Debug.Log (saveNo);												//選択したロードボタンをログで表示
		for(int i = 1; i < (int)MAIN_PARA_ID.MAXID; i++){
			PlayerPrefs.SetInt ("data" + saveNo + "MainPara" + mainParamName[i], mainPara[i - 1]);		//メインパラメータを保管
			Debug.Log(PlayerPrefs.GetInt ("data" + saveNo + "MainPara" + mainParamName[i]));
		}
		for(int k = 0; k < (int)SAB_PARA_ID.MAXID; k++){
			PlayerPrefs.SetInt ("data" + saveNo + "SabPara" + mainParamName[k], sabPara[k]);		//サブパラメータを保管
			Debug.Log(PlayerPrefs.GetInt ("data" + saveNo + "SabPara" + sabParamName[k]));
		}

		PlayerPrefs.Save ();											//セーブ
	}

	public void PushBackButton(){										//戻るボタンを押したときのスクリプト
		sceneName = PlayerPrefs.GetString(SCENE_NAME);
		SceneManager.LoadScene (sceneName);
	}
}
