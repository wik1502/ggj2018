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
    public GameObject[] gravityModel;

    int[] mainParameter;  //プレイヤーのメインパラメータ
    int[] subParameter;                 //プレイヤーのサブパラメータ
    float changeWaitCount;
    bool countStart;

    public GameObject hitEffectPre;     //エフェクトの取得
    GameObject[] hitEffect;             //衝突時のエフェクト
    NpcParameter npcParameter;          //接触NPCのパラメータ
    GameMainSystem gameSystem;
    GameObject cloud;
    
	void Start () {
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameMainSystem>();
        mainParameter = new int[(int)MAIN_PARA_ID.MAXID];           //プレイヤーのメインパラメータの配列確保
        subParameter = new int[(int)SAB_PARA_ID.MAXID];             //プレイヤーのサブパラメータの配列確保
        hitEffect = new GameObject[gameSystem.collisionPowerLight]; //衝突時のエフェクトの配列準備
        SetParameterInit();                                         //初期パラメータの代入
        changeWaitCount = 0;                                        //演出用の待ち時間カウント
        ChangePlayerState();                                        //初期状態の表現
    }
	
	void Update () {
        NpcAttack();
        ChangeStateCount();
    }

    //衝突時の処理
    void NpcAttack()
    {
        if (PlayerCollision.triggerEnter)   //ぶつかった瞬間だけの処理
        {
            npcParameter = PlayerCollision.collider.GetComponent<NpcParameter>();           //ぶつかったNPCのパラメータの取得
            countStart = true;
            changeWaitCount = 0;

            //エフェクトの処理
            for (int i = 0; i < hitEffect.Length; i++)
            {
                hitEffect[i] = Instantiate(hitEffectPre, this.transform.position + new Vector3(0.0f, 1.0f, -5.0f), this.transform.rotation);   //エフェクトのインスタンス化(再生)
                Destroy(hitEffect[i], 1.0f);    //1秒後にエフェクトを消す
            }

            //加算減算の処理
            if (NpcInputTouch.moveVectorStatic.magnitude / Time.deltaTime <= gameSystem.flickSpeedfusion)  //ぶつかった時の速度がしきい値以下だったら
            {
                addParameter(npcParameter.GetMainParam(), npcParameter.GetSubParam());    //融合(加算)処理の呼び出し
                Destroy(PlayerCollision.collider.gameObject, 0.1f);    //0.1秒後にNPCを消す
            }
            else
            {
                cutParameter(npcParameter.GetMainParam(), npcParameter.GetSubParam());    //貫通(減算)処理の呼び出し
            }
            PlayerCollision.triggerEnter = false;   //NPC死す
        }
    }
    

    /*  融合(加算)処理  */
    void addParameter(int npcMainPara, int npcSubPara)
    {
        //メインパラメータの加算
        mainParameter[npcMainPara] = Mathf.Min(mainParameter[npcMainPara] + 1, gameSystem.limitParameter);
        Debug.Log("Add mainParameter"+ npcMainPara + "：" + mainParameter[npcMainPara]);
        
        //サブパラメータの加算
        subParameter[npcSubPara] = Mathf.Min(subParameter[npcSubPara] + 1, gameSystem.limitParameter);

        //デバッグ用
        //subParameter[3] = 6;    //金属に変更
    }

    /*  貫通(減算)処理  */
    void cutParameter(int npcMainPara, int npcSubPara)
    {
        //メインパラメータの減算
        mainParameter[npcMainPara] = Mathf.Max(mainParameter[npcMainPara] - 1, 0);
        Debug.Log("Cut mainParameter" + npcMainPara + "：" + mainParameter[npcMainPara]);
        
        //サブパラメータの減算
        subParameter[npcSubPara] = Mathf.Max(subParameter[npcSubPara] - 1, 0);
    }

    void ChangeStateCount()
    {
        if (countStart)
        {
            changeWaitCount += Time.deltaTime;
            if (changeWaitCount > 0.5f)
            {
                ChangePlayerState();
                changeWaitCount = 0;
                countStart = false;
            }
        }
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
        ChangeWaterMaterial();  //温度・水：マテリアル・エフェクト変更

        ChangeModel();          //重力：モデル変更

        ChangeScaleSmall();     //質量：スケール変更

        ChangeMetalMaterial();  //金属：マテリアル変更
    }

    void ChangeWaterMaterial()
    {
        if (subParameter[(int)SAB_PARA_ID.water] >= gameSystem.highParameter)       //水が多いとき
        {
            if (mainParameter[(int)MAIN_PARA_ID.tempe] <= gameSystem.lowParameter)  //温度が低いとき
            {
                for (int i = 0; i < gravityModel.Length; i++)
                    gravityModel[i].GetComponent<Renderer>().material = changeMaterial[0];     //すべてのモデルのマテリアルを氷に変更
            }
            else
            {
                for (int i = 0; i < gravityModel.Length; i++)
                    gravityModel[i].GetComponent<Renderer>().material = changeMaterial[1];     //すべてのモデルのマテリアルを水に変更
                if (mainParameter[(int)MAIN_PARA_ID.tempe] >= gameSystem.highParameter)
                {
                    cloud = Instantiate(cloudEffect, this.transform.position, this.transform.rotation); //雲のエフェクトを再生
                }
            }
        }
        else
        {
            for (int i = 0; i < gravityModel.Length; i++)
                gravityModel[i].GetComponent<Renderer>().material = changeMaterial[2];     //すべてのモデルのマテリアルを岩に変更
        }

        //水が少なくなるか、温度が低くなって、雲があったら、雲を消す
        if ((subParameter[(int)SAB_PARA_ID.water] <= gameSystem.lowParameter || mainParameter[(int)MAIN_PARA_ID.tempe] < gameSystem.highParameter) && cloud != null)
        {
            Destroy(cloud, 0.5f);
        }
    }
    
    //重力：モデル変更
    void ChangeModel()
    {
        if (mainParameter[(int)MAIN_PARA_ID.grav] <= gameSystem.lowParameter)
        {
            //重力：低＝ガタガタ
            gravityModel[0].SetActive(true);
            gravityModel[1].SetActive(false);
            gravityModel[2].SetActive(false);
        }
        else if (mainParameter[(int)MAIN_PARA_ID.grav] >= gameSystem.highParameter)
        {
            //重力：高＝球
            gravityModel[0].SetActive(false);
            gravityModel[1].SetActive(false);
            gravityModel[2].SetActive(true);
        }
        else
        {
            //重力：中＝通常
            gravityModel[0].SetActive(false);
            gravityModel[1].SetActive(true);
            gravityModel[2].SetActive(false);
        }
    }

    //質量：スケール変更
    void ChangeScaleSmall()
    {
        if (mainParameter[(int)MAIN_PARA_ID.mass] <= gameSystem.lowParameter)       //質量：低＝小さい
            this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        else if (mainParameter[(int)MAIN_PARA_ID.mass] >= gameSystem.highParameter) //質量：高＝大きい
            this.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        else
            this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);              //質量：中＝真ん中
    }

    //金属：マテリアル変更
    void ChangeMetalMaterial()
    {
        if (subParameter[(int)SAB_PARA_ID.metal] >= gameSystem.highParameter)           //金属が多いとき
        {
            for (int i = 0; i < gravityModel.Length; i++)
                gravityModel[i].GetComponent<Renderer>().material = changeMaterial[3];  //すべてのモデルのマテリアルを金属に変更
        }
    }
}
