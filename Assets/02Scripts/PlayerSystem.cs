using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour {

    float[] mainParameter;          //プレイヤーのメインパラメータ
    float[] subParameter;           //プレイヤーのサブパラメータ

    public GameObject hitEffectPre;    //エフェクトの取得
    GameObject[] hitEffect;
    NpcParameter npcParameter;      //接触NPCのパラメータ
    
	void Start () {
        mainParameter = new float[GameMainSystem.mainParameterNumStatic];   //プレイヤーのメインパラメータの配列確保
        subParameter = new float[GameMainSystem.subParameterNumStatic];     //プレイヤーのサブパラメータの配列確保
        
        hitEffect = new GameObject[GameMainSystem.collisionPowerLightStatic];   //衝突時のエフェクトの配列準備
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
            if (NpcInputTouch.moveVectorStatic.magnitude / Time.deltaTime <= GameMainSystem.flickSpeedfusionStatic)  //ぶつかった時の速度がしきい値以下だったら
            {
                addParameter(npcParameter.mainParameter, npcParameter.subParameter);    //融合(加算)処理の呼び出し
                Destroy(PlayerCollision.collider.gameObject, 0.1f);    //0.1秒後にNPCを消す
            }
            else
            {
                cutParameter(npcParameter.mainParameter, npcParameter.subParameter);    //貫通(減算)処理の呼び出し
            }
            PlayerCollision.triggerEnter = false;   //NPC死す
        }
    }
    

    /*  融合(加算)処理  */
    void addParameter(float[] npcMainPara, float[] npcSubPara)
    {
        //メインパラメータの加算
        for (int i = 0; i < mainParameter.Length; i++)
        {
            if ((mainParameter[i] + npcMainPara[i]) <= GameMainSystem.limitParameterStatic) //上限以下だったらそのまま加算、超えたら上限値を代入
                mainParameter[i] += npcMainPara[i];
            else
                mainParameter[i] = GameMainSystem.limitParameterStatic;
        }
        Debug.Log("Sum mainParameter0：" + mainParameter[0]);

        //サブパラメータの加算
        for (int i = 0; i < subParameter.Length; i++)
        {
            if ((subParameter[i] + npcSubPara[i]) <= GameMainSystem.limitParameterStatic) //上限以下だったらそのまま加算、超えたら上限値を代入
                subParameter[i] += npcSubPara[i];
            else
                subParameter[i] = GameMainSystem.limitParameterStatic;
        }
        Debug.Log("Sum subParameter0：" + subParameter[0]);
    }

    /*  貫通(減算)処理  */
    void cutParameter(float[] npcMainPara, float[] npcSubPara)
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
        Debug.Log("Sum subParameter0：" + subParameter[0]);
    }

	public void AutoSaveMainPara(int num){
		PlayerPrefs.SetInt ("Data0MainPara", mainParameter [num]);
	}

	public void AutoSaveSubPara(int num){
		PlayerPrefs.SetInt ("Data0SabPara", mainParameter [num]);
	}
}
