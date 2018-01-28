using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetUpToMainGame : MonoBehaviour {

    private bool countDown;
    private float count = 2;

    [SerializeField] private Image siroImage;
    private float alfa;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(countDown == true)
        {
            count -= Time.deltaTime;
            siroImage.color = new Color(siroImage.color.r, siroImage.color.g, siroImage.color.b,alfa);
            alfa++;
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
