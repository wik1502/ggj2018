using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SaveManagerScript : MonoBehaviour {
	public static string SCENE_NAME = "SceneName";
	public static int gra;
	string sceneName;

	// Use this for initialization
	void Start () {
		//gra = GameManagerScript.gra;						//SceneGameからgraの値を持ってくる
	}

	// Update is called once per frame
	void Update () {

	}

	public void PushSaveButton(int saveNo){					//押されたセーブボタンのスクリプト＆ボタンの番号読み込み
		Debug.Log (saveNo);											//選択したロードボタンをログで表示
		PlayerPrefs.SetInt ("data" + saveNo + "gravity", gra);		//セーブ内容
		PlayerPrefs.Save ();										//セーブ
	}

	public void PushBackButton(){							//戻るボタンを押したときのスクリプト
		sceneName = PlayerPrefs.GetString(SCENE_NAME);
		SceneManager.LoadScene (sceneName);
	}
}
