using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainSystem : MonoBehaviour {

    [Header("フリック時の星の移動速度")]
    public float slowFlickMove;
    public static float slowFlickMoveStatic;

    [Header("融合と貫通のしきい値")]
    public float flickSpeedfusion;
    public static float flickSpeedfusionStatic;

    [Header("0温度、1空気、2重力、3質量")]
    public int mainParameterNum;
    public static int mainParameterNumStatic;

    [Header("0水、1電気、2毒、3金属")]
    public int subParameterNum;
    public static int subParameterNumStatic;

    [Header("パラメーターの上限")]
    public float limitParameter;
    public static float limitParameterStatic;
    
    void Awake () {
        //参照用のstatic変数に代入
        slowFlickMoveStatic = slowFlickMove;
        flickSpeedfusionStatic = flickSpeedfusion;
        limitParameterStatic = limitParameter;
        mainParameterNumStatic = mainParameterNum;
        subParameterNumStatic = subParameterNum;
    }
	
	void Update () {
		
	}
}
