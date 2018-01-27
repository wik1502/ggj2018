using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour {

    float[] mainParameter;          //プレイヤーのメインパラメータ
    float[] subParameter;           //プレイヤーのサブパラメータ

    public GameObject hitEffect;    //エフェクトの取得
    NpcParameter npcParameter;      //接触NPCのパラメータ
    bool npcDead;                   //接触NPCが死んでいるか
    
	void Start () {
        mainParameter = new float[GameMainSystem.mainParameterNumStatic];   //プレイヤーのメインパラメータの配列確保
        subParameter = new float[GameMainSystem.subParameterNumStatic];     //プレイヤーのメインパラメータの配列確保
    }
	
	void Update () {
		
	}

    void OnTriggerEnter(Collider t)
    {
        npcParameter = t.GetComponent<NpcParameter>();      //ぶつかったNPCのパラメータの取得
        npcDead = t.GetComponent<NpcInputTouch>().deadTrigger; //NPCが死んでるか

        Instantiate(hitEffect, this.transform.position, this.transform.rotation);   //エフェクトのインスタンス化(再生)
    }

    void OnTriggerStay(Collider t)
    {
        if (!npcDead)
        {
            if (NpcInputTouch.moveVectorStatic.magnitude / Time.deltaTime <= GameMainSystem.flickSpeedfusionStatic)  //ぶつかった時の速度がしきい値以下だったら
            {
                addParameter(npcParameter.mainParameter, npcParameter.subParameter);    //融合(加算)処理の呼び出し
                Debug.Log("add");
            }
            else
            {
                cutParameter(npcParameter.mainParameter, npcParameter.subParameter);    //貫通(減算)処理の呼び出し
                Debug.Log("cut");
            }
            npcDead = true;                 //NPC死す
            Destroy(t.gameObject, 0.2f);    //0.5秒後にオブジェクトを消す（後で融合の演出に変える）

            //Debug.Log(InputTouch.moveVectorStatic.magnitude / Time.deltaTime);
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

            //Debug.Log("Sum - mainParameter" + i + "：" + mainParameter[i]);
        }
        Debug.Log("Sum - mainParameter0：" + mainParameter[0]);

        //サブパラメータの加算
        for (int i = 0; i < subParameter.Length; i++)
        {
            if ((subParameter[i] + npcSubPara[i]) <= GameMainSystem.limitParameterStatic) //上限以下だったらそのまま加算、超えたら上限値を代入
                subParameter[i] += npcSubPara[i];
            else
                subParameter[i] = GameMainSystem.limitParameterStatic;

            //Debug.Log("Sum - subParameter" + i + "：" + subParameter[i]);
        }
        Debug.Log("Sum - subParameter0：" + subParameter[0]);
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

            //Debug.Log("Sum - mainParameter" + i + "：" + mainParameter[i]);
        }
        Debug.Log("Sum mainParameter0：" + mainParameter[0]);

        //サブパラメータの減算
        for (int i = 0; i < subParameter.Length; i++)
        {
            if ((subParameter[i] - npcSubPara[i]) >= 0) //上限以下だったらそのまま加算、超えたら上限値を代入
                subParameter[i] -= npcSubPara[i];
            else
                subParameter[i] = 0;

            //Debug.Log("Sum - subParameter" + i + "：" + subParameter[i]);
        }
        Debug.Log("Sum subParameter0：" + subParameter[0]);
    }
}
