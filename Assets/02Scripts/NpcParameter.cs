using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcParameter : MonoBehaviour {
    
    public float[] mainParameter;   //NPCのメインパラメータ
    public float[] subParameter;    //NPCのサブパラメータ
    
    void Start () {
        mainParameter = new float[GameMainSystem.mainParameterNumStatic];   //NPCのメインパラメータの配列確保
        subParameter = new float[GameMainSystem.subParameterNumStatic];     //NPCのメインパラメータの配列確保

        //NPCのメインパラメータのランダム生成
        for (int i = 0; i < mainParameter.Length; i++)
        {
            mainParameter[i] = Random.Range(0, GameMainSystem.limitParameterStatic);
            //Debug.Log("mainParameter" + i + "：" + mainParameter[i]);
        }
        Debug.Log("NPC mainParameter0：" + mainParameter[0]);

        //NPCのサブパラメータのランダム生成
        for (int i = 0; i < subParameter.Length; i++)
        {
            subParameter[i] = Random.Range(0, GameMainSystem.limitParameterStatic);
            //Debug.Log("subParameter" + i + "：" + subParameter[i]);
        }
        Debug.Log("NPC subParameter0：" + subParameter[0]);
    }
	
	void Update () {
		
	}

    
}
