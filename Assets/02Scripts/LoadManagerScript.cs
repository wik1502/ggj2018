using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LoadManagerScript : MonoBehaviour {
	public static string SCENE_NAME = "SceneName";
	string sceneName;
	int[] storaMain = new int[5];
	int[] storaSab = new int[5];
	string[] mainParamName = {"defalt","tempe", "air","grav","mass"};
	string[] sabParamName = {"water", "elec","pois","metal"};

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

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

	}

	public void PushLoadButton(int loadNo){					//押されたセーブボタンのスクリプト＆ボタンの番号読み込み
		Debug.Log (loadNo);									//選択したロードボタンをログで表示
		for(int i = 1; i < (int)MAIN_PARA_ID.MAXID; i++){
			storaMain[i - 1] = PlayerPrefs.GetInt ("Data" + loadNo + mainParamName [i]);	//選択したロードデータの読み込み
			Debug.Log (storaMain [i - 1]);
		}
		for(int j = 0; j < (int)SAB_PARA_ID.MAXID; j++){
			storaMain[j] = PlayerPrefs.GetInt ("Data" + loadNo + sabParamName [j]);
			Debug.Log (storaSab [j]);
		}
		PlayerPrefs.DeleteKey(SCENE_NAME);					//SCENE_NAMEの削除
		PlayerPrefs.SetString (SCENE_NAME, "SceneLoad");	//SCENE_NAMEにSceneLoadを代入
		SceneManager.LoadScene ("SceneGame");
	}

	public void PushBackButton(){							//戻るボタンを押したときのスクリプト
		sceneName = PlayerPrefs.GetString(SCENE_NAME);		//戻るシーンの入っているSCENE_NAMEを代入
		SceneManager.LoadScene (sceneName);					//SCENE_NAMEに戻る
	}

}
