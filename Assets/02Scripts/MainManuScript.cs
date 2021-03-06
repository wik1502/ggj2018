﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManuScript : MonoBehaviour {
	GameObject mainManu;					//メニューボタン
	GameObject saveManu;					//セーブボタン
	GameObject loadManu;					//ロードボタン
	GameObject resManu;						//リセットボタン
	private bool opn;						//メニューを開いているかの判定

	public static string SCENE_NAME = "SceneName";
	string sceneName;

	// Use this for initialization
	void Start () {
		mainManu = GameObject.Find ("ButtonManu");			//メニューボタンを探す
		saveManu = GameObject.Find ("ButtonSave");
		loadManu = GameObject.Find ("ButtonLoad");
		resManu = GameObject.Find ("ButtonReset");

		saveManu.SetActive (false);
		loadManu.SetActive (false);
		resManu.SetActive (false);
		opn = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PushManuButton(){
		if (opn == false) {
			//閉まっている場合
			saveManu.SetActive (true);
			loadManu.SetActive (true);
			resManu.SetActive (true);
			opn = true;
		} else {
			//開いている場合
			saveManu.SetActive (false);
			loadManu.SetActive (false);
			resManu.SetActive (false);
			opn = false;
		}
	}

	public void SaveButton(){
		PlayerPrefs.SetString (SCENE_NAME, "02GameMain");		//SCENE_NAMEに"02GameMain"を代入
		PlayerPrefs.Save ();									//記録
		SceneManager.LoadScene ("SceneSave");					//セーブシーンに移る
	}

	public void LoadButton(){
		PlayerPrefs.SetString (SCENE_NAME, "02GameMain");		//SCENE_NAMEに"02GameMain"を代入
		PlayerPrefs.Save ();									//記録
		SceneManager.LoadScene ("SceneLoad");					//ロードシーンに移る
	}

    public void TitleButton()
    {
        SceneManager.LoadScene("SceneTitle");                    //ロードシーンに移る
    }
}
