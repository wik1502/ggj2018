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
	int[] storaSub = new int[5];
	string[] mainParamName = {"defalt","tempe", "air","grav","mass"};
	string[] subParamName = {"water", "elec","pois","metal"};

	private enum MAIN_PARA_ID {
		normal = 0,
		tempe,
		air,
		grav,
		mass,
		MAXID
	};

	private enum SUB_PARA_ID {
		water = 0,
		elec,
		pois,
		metal,
		MAXID
	};
	private int i;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

	}

	public void PushLoadButton(int loadNo){					//押されたセーブボタンのスクリプト＆ボタンの番号読み込み
		Debug.Log (loadNo);									//選択したロードボタンをログで表示
		for(i = 0; i < (int)MAIN_PARA_ID.MAXID; i++){
			storaMain[i] = PlayerPrefs.GetInt ("Data" + loadNo + "MainPara" + mainParamName [i]);	//選択したロードデータの読み込み
			Debug.Log ("storaMain"+i+":"+storaMain [i]);
		}
		for(i = 0; i < (int)SUB_PARA_ID.MAXID; i++){
			storaSub[i] = PlayerPrefs.GetInt ("Data" + loadNo + "SubPara" + subParamName [i]);
			Debug.Log ("storaSub"+i+":"+storaSub [i]);
		}
		PlayerPrefs.DeleteKey(SCENE_NAME);					//SCENE_NAMEの削除
		PlayerPrefs.SetString (SCENE_NAME, "SceneLoad");	//SCENE_NAMEにSceneLoadを代入
		SceneManager.LoadScene ("02GameMain");
	}

	public void PushBackButton(){							//戻るボタンを押したときのスクリプト
		sceneName = PlayerPrefs.GetString(SCENE_NAME);		//戻るシーンの入っているSCENE_NAMEを代入
		SceneManager.LoadScene (sceneName);					//SCENE_NAMEに戻る
	}

}
