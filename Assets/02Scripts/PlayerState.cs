using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {
    
    /*
    public enum StateCTRL
    {
        ICE,
        WATER,
        CLOUD,

    }
    */

    public GameObject cloudEffect;
    public GameObject gravityModelGata;
    public GameObject gravityModelNormal;
    public GameObject gravityModelSphere;
    GameObject initModel;

    // Use this for initialization
    void Start () {
        initModel = GameObject.Find("meteorite");
        ChangePlayerState();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ChangePlayerState()
    {
        //switch

        //温度低　＋　水高　＝　テクスチャ　氷
        ChangeIceTexture();

        //温度中　＋　水高　＝　テクスチャ　水
        ChangeWaterTexture();

        //温度高　＋　水高　＝　テクスチャ　水＋雲
        ChangeWaterCloudTexture();

        //質量低　＝　スケール小
        ChangeScaleSmall();

        //質量中　＝　スケール中
        ChangeScaleNormal();

        //質量大　＝　スケール大
        ChangeScaleLarge();

        //重力低　＝　モデル　ガタガタ
        ChangeModelGata();

        //重力中　＝　モデル　ふつう
        ChangeModelNormal();

        //重力高　＝　モデル　球
        ChangeModelSphere();
    }

    void ChangeIceTexture()
    {

    }

    void ChangeWaterTexture()
    {

    }

    void ChangeWaterCloudTexture()
    {
        //Instantiate(cloudEffect, this.transform.position, this.transform.rotation);
    }

    //質量低　＝　スケール小
    void ChangeScaleSmall()
    {
        this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    //質量中　＝　スケール中
    void ChangeScaleNormal()
    {
        this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    //質量大　＝　スケール大
    void ChangeScaleLarge()
    {
        this.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
    }

    //重力低　＝　モデル　ガタガタ
    void ChangeModelGata()
    {
        gravityModelGata.SetActive(true);
        gravityModelNormal.SetActive(false);
        gravityModelSphere.SetActive(false);
    }

    //重力中　＝　モデル　ふつう
    void ChangeModelNormal()
    {
        gravityModelGata.SetActive(false);
        gravityModelNormal.SetActive(true);
        gravityModelSphere.SetActive(false);
    }

    //重力高　＝　モデル　球
    void ChangeModelSphere()
    {
        gravityModelGata.SetActive(false);
        gravityModelNormal.SetActive(false);
        gravityModelSphere.SetActive(true);
    }
}
