using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainSystem : MonoBehaviour {

    [Header("フリック時の星の移動速度")]
    public float slowFlickMove;

    [Header("融合と貫通のしきい値")]
    public float flickSpeedfusion;

    [Header("0normal、1温度、2空気、3重力、4質量")]
    public int mainParameterNum;

    [Header("0水、1電気、2毒、3金属")]
    public int subParameterNum;

    [Header("パラメーターの上限")]
    public int limitParameter;

    [Header("衝突時の光の強さ")]
    public int collisionPowerLight;

    [Header("パラメータ：低のしきい値")]
    public int lowParameter;

    [Header("パラメータ：高のしきい値")]
    public int highParameter;

    void Awake () {
        
    }
	
	void Update () {
		
	}
}
