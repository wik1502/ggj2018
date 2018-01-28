using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverSystem : MonoBehaviour {
    
    public GameObject sunEffectsPre;
    public GameObject gameoverPanel;
    GameObject mainCamera;
    GameObject sunEffects;
    bool gameoverFlg;
    Vector3 moveAnim = new Vector3(10.0f, 0.0f, 0.0f);

	// Use this for initialization
	void Start () {
        mainCamera = GameObject.Find("Main Camera");
        gameoverFlg = false;
	}
	
	// Update is called once per frame
	void Update () {
        gameoverAnim();
	}

    public void gameoverButton()
    {
        gameoverPre();
    }

    void gameoverPre()
    {
        sunEffects = Instantiate(sunEffectsPre, new Vector3(mainCamera.transform.position.x - 70.0f, mainCamera.transform.position.y, -4.2f), Quaternion.identity);
        sunEffects.transform.Rotate(-80.0f, transform.rotation.y, transform.rotation.z);
        gameoverFlg = true;
        SoundManager.Instance.PlaySE(0);

    }

    void gameoverAnim()
    {
        if (gameoverFlg == true)
        {
            if (sunEffects.transform.position.x <= 0.0f)
            {
                sunEffects.transform.Translate(moveAnim * Time.deltaTime);
            }
            else
            {
                gameoverFlg = false;
                gameoverPanel.SetActive(true);
                SoundManager.Instance.PlayBGM(2);   //BGM再生：ゲームオーバー
            }
        }
    }
}
