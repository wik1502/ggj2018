using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LoadManagerScript : MonoBehaviour {
	public static string SCENE_NAME = "SceneName";
	public static int lGra;
	string sceneName;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

	}

	public void PushLoadButton(int loadNo){					//押されたセーブボタンのスクリプト＆ボタンの番号読み込み
		Debug.Log (loadNo);									//選択したロードボタンをログで表示
		lGra = PlayerPrefs.GetInt("data"+ loadNo +"gravity");			//読み込み試作
		lGra++;												//ロード画面からゲームに飛んだらSceneGameのTextGraの値が増える
		PlayerPrefs.DeleteKey(SCENE_NAME);					//SCENE_NAMEの削除
		PlayerPrefs.SetString (SCENE_NAME, "SceneLoad");	//SCENE_NAMEにSceneLoadを代入
		SceneManager.LoadScene ("SceneGame");				//セーブ
	}

	public void PushBackButton(){							//戻るボタンを押したときのスクリプト
		sceneName = PlayerPrefs.GetString(SCENE_NAME);		//戻るシーンの入っているSCENE_NAMEを代入
		SceneManager.LoadScene (sceneName);					//SCENE_NAMEに戻る
	}
}
