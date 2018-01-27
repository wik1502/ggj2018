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
		water = 0,
		elec,
		pois,
		metal,
		MAXID
	};

	string[] mainParamName = {"defalt","tempe", "air","grav","mass"};
	string[] sabParamName = {"water", "elec","pois","metal"};
	// Use this for initialization
	void Start () {
		for (int j = 1; j < 5; j++) {
			
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public void PushSaveButton(int saveNo){								//押されたセーブボタンのスクリプト＆ボタンの番号読み込み
		Debug.Log (saveNo);												//選択したロードボタンをログで表示
		for(int i = 1; i < 5; i++){
			PlayerPrefs.SetInt ("data" + saveNo + "MainPara" + mainParamName[i], PlayerPrefs.GetInt("data0MainPara"+mainParamName[i]));		//
		}
		for(int i = 0; i < 4; i++){
			PlayerPrefs.SetInt ("data" + saveNo + "SabPara" + mainParamName[i], PlayerPrefs.GetInt("data0MainPara"+mainParamName[i]));		//
		}

		PlayerPrefs.Save ();											//セーブ
	}

	public void PushBackButton(){										//戻るボタンを押したときのスクリプト
		sceneName = PlayerPrefs.GetString(SCENE_NAME);
		SceneManager.LoadScene (sceneName);
	}
}
