using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SaveManagerScript : MonoBehaviour {
	public static string SCENE_NAME = "SceneName";
	public static int tempe;											//温度
	public static int air;												//空気
	public static int grav;												//重力
	public static int mass;												//質量
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
		
	}

	// Update is called once per frame
	void Update () {

	}

	public void PushSaveButton(int saveNo){								//押されたセーブボタンのスクリプト＆ボタンの番号読み込み
		Debug.Log (saveNo);												//選択したロードボタンをログで表示
		PlayerPrefs.SetInt ("data" + saveNo + "MainPara", player.GetComponent<PlayerScript>().GetParam((int)MAIN_PARA_ID.air));		//「温度」をセーブ内容として保管
		//PlayerPrefs.SetInt ("data" + saveNo + "air", gra);				//「空気」をセーブ内容として保管
//		PlayerPrefs.SetInt ("data" + saveNo + "gravity", PlayerScript.MAIN_PARA_ID.grav);			//「重力」をセーブ内容として保管
		/*PlayerPrefs.SetInt ("data" + saveNo + "mass", gra);				//「質量」をセーブ内容として保管
		PlayerPrefs.SetInt ("data" + saveNo + "poison", gra);			//「毒」をセーブ内容として保管
		PlayerPrefs.SetInt ("data" + saveNo + "metal", gra);			//「金属」をセーブ内容として保管
		*/
		PlayerPrefs.Save ();											//セーブ
	}

	public void PushBackButton(){										//戻るボタンを押したときのスクリプト
		sceneName = PlayerPrefs.GetString(SCENE_NAME);
		SceneManager.LoadScene (sceneName);
	}
}
