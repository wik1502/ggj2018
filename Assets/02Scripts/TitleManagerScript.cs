using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManagerScript : MonoBehaviour {
	string SCENE_NAME = SaveManagerScript.SCENE_NAME;
	public GameObject loadButton;
	// Use this for initialization
	void Start () {
        SoundManager.Instance.PlayBGM(0);
        PlayerPrefs.DeleteKey (SCENE_NAME);
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.HasKey ("data1gravity") == false && PlayerPrefs.HasKey ("data2gravity") == false && 
			PlayerPrefs.HasKey ("data3gravity") == false && PlayerPrefs.HasKey ("data4gravity") == false && 
			PlayerPrefs.HasKey ("data5gravity") == false) {			//セーブデータがあるかどうかの確認
			//セーブデータが１つもない場合
			loadButton.SetActive(false);
		} else {
			//セーブデータがあった場合
			loadButton.SetActive(true);
		}
	}

	public void StartButton(){                                  //初めから
        SoundManager.Instance.PlaySE(2);                        //2=はじめてゲーム開始時の音
        PlayerPrefs.SetString (SCENE_NAME, "SceneTitle");		//SCENE_NAMEに"SceneTitle"を代入
		PlayerPrefs.Save ();									//記録
		SceneManager.LoadScene("SetUpScene");
	}

	public void LoadButton(){                                   //続きから
        SoundManager.Instance.PlaySE(1);                        //1=決定音
        PlayerPrefs.SetString (SCENE_NAME, "SceneTitle");		//SCENE_NAMEに"SceneTitle"を代入
		PlayerPrefs.Save ();									//記録
		SceneManager.LoadScene ("SceneLoad");					//ロードシーンに移る
	}

	public void DeleteButton(){									//データ全削除
        SoundManager.Instance.PlaySE(1);                        //1=決定音
        PlayerPrefs.DeleteAll ();
	}

}
