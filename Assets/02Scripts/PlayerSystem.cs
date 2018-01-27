using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour {

    private enum MAIN_PARA_ID
    {
        normal = 0,
        tempe,
        air,
        grav,
        mass,
        MAXID
    };

    private enum SAB_PARA_ID
    {
        water = 0,
        elec,
        pois,
        metal,
        MAXID
    };

    public Material[] changeMaterial;
    public GameObject cloudEffect;
    public GameObject gravityModelGata;
    public GameObject gravityModelNormal;
    public GameObject gravityModelSphere;

    public static int[] mainParameter;  //プレイヤーのメインパラメータ
    int[] subParameter;                 //プレイヤーのサブパラメータ

    public GameObject hitEffectPre;     //エフェクトの取得
    GameObject[] hitEffect;             //衝突時のエフェクト
    NpcParameter npcParameter;          //接触NPCのパラメータ
    GameMainSystem gameSystem;
    
	void Start () {
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameMainSystem>();
        mainParameter = new int[(int)MAIN_PARA_ID.MAXID];           //プレイヤーのメインパラメータの配列確保
        subParameter = new int[(int)SAB_PARA_ID.MAXID];             //プレイヤーのサブパラメータの配列確保
        hitEffect = new GameObject[gameSystem.collisionPowerLight]; //衝突時のエフェクトの配列準備
        SetParameterInit();                                         //初期パラメータの代入
    }
	
	void Update () {
        NpcAttack();
        
    }

    //衝突時の処理
    void NpcAttack()
    {
        if (PlayerCollision.triggerEnter)
        {
            npcParameter = PlayerCollision.collider.GetComponent<NpcParameter>();           //ぶつかったNPCのパラメータの取得

            //エフェクトの処理
            for (int i = 0; i < hitEffect.Length; i++)
            {
                hitEffect[i] = Instantiate(hitEffectPre, this.transform.position + new Vector3(0.0f, 1.0f, -5.0f), this.transform.rotation);   //エフェクトのインスタンス化(再生)
                Destroy(hitEffect[i], 1.0f);    //1秒後にエフェクトを消す
            }

            //加算減算の処理
            if (NpcInputTouch.moveVectorStatic.magnitude / Time.deltaTime <= gameSystem.flickSpeedfusion)  //ぶつかった時の速度がしきい値以下だったら
            {
                //addParameter(npcParameter.mainParameter, npcParameter.subParameter);    //融合(加算)処理の呼び出し
                Destroy(PlayerCollision.collider.gameObject, 0.1f);    //0.1秒後にNPCを消す
            }
            else
            {
                //cutParameter(npcParameter.mainParameter, npcParameter.subParameter);    //貫通(減算)処理の呼び出し
            }
            PlayerCollision.triggerEnter = false;   //NPC死す
            ChangePlayerState();
        }
    }
    

    /*  融合(加算)処理  */
    void addParameter(int[] npcMainPara, int[] npcSubPara)
    {
        //メインパラメータの加算
        for (int i = 0; i < mainParameter.Length; i++)
        {
            if ((mainParameter[i] + npcMainPara[i]) <= gameSystem.limitParameter) //上限以下だったらそのまま加算、超えたら上限値を代入
                mainParameter[i] += npcMainPara[i];
            else
                mainParameter[i] = gameSystem.limitParameter;
        }
        Debug.Log("Sum mainParameter0：" + mainParameter[0]);

        //サブパラメータの加算
        for (int i = 0; i < subParameter.Length; i++)
        {
            if ((subParameter[i] + npcSubPara[i]) <= gameSystem.limitParameter) //上限以下だったらそのまま加算、超えたら上限値を代入
                subParameter[i] += npcSubPara[i];
            else
                subParameter[i] = gameSystem.limitParameter;
        }
        //Debug.Log("Sum subParameter0：" + subParameter[0]);
    }

    /*  貫通(減算)処理  */
    void cutParameter(int[] npcMainPara, int[] npcSubPara)
    {
        //メインパラメータの減算
        for (int i = 0; i < mainParameter.Length; i++)
        {
            if ((mainParameter[i] - npcMainPara[i]) >= 0) //上限以下だったらそのまま加算、超えたら上限値を代入
                mainParameter[i] -= npcMainPara[i];
            else
                mainParameter[i] = 0;
        }
        Debug.Log("Sum mainParameter0：" + mainParameter[0]);

        //サブパラメータの減算
        for (int i = 0; i < subParameter.Length; i++)
        {
            if ((subParameter[i] - npcSubPara[i]) >= 0) //上限以下だったらそのまま加算、超えたら上限値を代入
                subParameter[i] -= npcSubPara[i];
            else
                subParameter[i] = 0;
        }
        //Debug.Log("Sum subParameter0：" + subParameter[0]);
    }

	public void AutoSaveMainPara(int num){
		PlayerPrefs.SetInt ("Data0MainPara", mainParameter [num]);
	}

	public void AutoSaveSubPara(int num){
		PlayerPrefs.SetInt ("Data0SabPara", mainParameter [num]);
	}

    void SetParameterInit()
    {
        string[] paramStr = { "norm", "temp", "air", "grav", "mess" };
        
        for (int i = (int)MAIN_PARA_ID.tempe; i < (int)MAIN_PARA_ID.MAXID; i++)
        {
            mainParameter[i] = PlayerPrefs.GetInt("prottype" + paramStr[i]);

            Debug.Log(mainParameter[i]);
        }
    }

    void ChangePlayerState()
    {
        //温度低　＋　水高　＝　テクスチャ　氷
        //ChangeIceTexture();

        //温度中　＋　水高　＝　テクスチャ　水
        //ChangeWaterTexture();

        //温度高　＋　水高　＝　テクスチャ　水＋雲
        //ChangeWaterCloudTexture();

        ChangeModel();      //重力：モデル変更

        ChangeScaleSmall(); //質量：スケール変更
    }

    void ChangeIceTexture()
    {
        if (mainParameter[(int)MAIN_PARA_ID.tempe] <= gameSystem.lowParameter)
        {
            
        }
    }

    void ChangeWaterTexture()
    {

    }

    void ChangeWaterCloudTexture()
    {
        //Instantiate(cloudEffect, this.transform.position, this.transform.rotation);
    }
    
    //重力：モデル変更
    void ChangeModel()
    {
        if (PlayerSystem.mainParameter[(int)MAIN_PARA_ID.grav] <= gameSystem.lowParameter)
        {
            //重力：低＝ガタガタ
            gravityModelGata.SetActive(true);
            gravityModelNormal.SetActive(false);
            gravityModelSphere.SetActive(false);
        }
        else if (PlayerSystem.mainParameter[(int)MAIN_PARA_ID.grav] >= gameSystem.highParameter)
        {
            //重力：高＝球
            gravityModelGata.SetActive(false);
            gravityModelNormal.SetActive(false);
            gravityModelSphere.SetActive(true);
        }
        else
        {
            //重力：中＝通常
            gravityModelGata.SetActive(false);
            gravityModelNormal.SetActive(true);
            gravityModelSphere.SetActive(false);
        }
    }

    //質量：スケール変更
    void ChangeScaleSmall()
    {
        if (PlayerSystem.mainParameter[(int)MAIN_PARA_ID.mass] <= gameSystem.lowParameter)       //質量：低＝小さい
            this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        else if (PlayerSystem.mainParameter[(int)MAIN_PARA_ID.mass] >= gameSystem.highParameter) //質量：高＝大きい
            this.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        else
            this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);      //質量：中＝真ん中

    }
}
