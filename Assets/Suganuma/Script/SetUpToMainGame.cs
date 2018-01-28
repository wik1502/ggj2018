using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetUpToMainGame : MonoBehaviour {

    private bool countDown;
    private float count = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(countDown == true)
        {
            count -= Time.deltaTime;
        }
        if(count <= 0)
        {
            SoundManager.Instance.PlaySE(5);    //効果音：作成
            SceneManager.LoadScene("02GameMain");
            Debug.Log("idou");
        }
	}

    void SceneChange()
    {
        countDown = true;
    }
}
