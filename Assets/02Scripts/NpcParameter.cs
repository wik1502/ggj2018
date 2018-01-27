using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NPCのパラメータのランダム生成だけです。仮で作ったものなので書き換えてもらって大丈夫です。
//ただし衝突時の加減算で全パラメータ配列を計算しているので、パラメータ数を減らしたりするとそこでエラーが出ます。
//そこも書き換えちゃうか山本に言ってください。
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
        }
        Debug.Log("NPC mainParameter0：" + mainParameter[0]);

        //NPCのサブパラメータのランダム生成
        for (int i = 0; i < subParameter.Length; i++)
        {
            subParameter[i] = Random.Range(0, GameMainSystem.limitParameterStatic);
        }
        Debug.Log("NPC subParameter0：" + subParameter[0]);
    }
	
	void Update () {
		
	}

    
}
