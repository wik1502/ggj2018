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
            //SceneManager.LoadScene("MainGame");
            Debug.Log("idou");
        }
	}

    void SceneChange()
    {
        countDown = true;
    }
}
