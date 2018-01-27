using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NPCのパラメータのランダム生成だけです。仮で作ったものなので書き換えてもらって大丈夫です。
//ただし衝突時の加減算で全パラメータ配列を計算しているので、パラメータ数を減らしたりするとそこでエラーが出ます。
//そこも書き換えちゃうか山本に言ってください。
public class NpcParameter : MonoBehaviour {
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

    [SerializeField] GameObject[] iconPrefab;
    private MAIN_PARA_ID mainParam;
    private SAB_PARA_ID subParam;

    //public int[] mainParameter;   //NPCのメインパラメータ
    //public int[] subParameter;    //NPCのサブパラメータ
    GameMainSystem gameSystem;
    
    public int GetMainParam()
    {
        return (int)mainParam;
    }

    public int GetSubParam()
    {
        return (int)subParam;
    }

    void Start () {
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameMainSystem>();
/*
        mainParameter = new int[(int)MAIN_PARA_ID.MAXID];   //NPCのメインパラメータの配列確保
        subParameter = new int[SAB_PARA_ID.MAXID];     //NPCのメインパラメータの配列確保

        //NPCのメインパラメータのランダム生成
        for (int i = 0; i < mainParameter.Length; i++)
        {
            mainParameter[i] = Random.Range(0, gameSystem.limitParameter);
        }
        //Debug.Log("NPC mainParameter0：" + mainParameter[0]);

        //NPCのサブパラメータのランダム生成
        for (int i = 0; i < subParameter.Length; i++)
        {
            subParameter[i] = Random.Range(0, gameSystem.limitParameter);
        }
        //Debug.Log("NPC subParameter0：" + subParameter[0]);
 */
    }

    void Update() {

    }

    public void SetParam(int mParam, int sParam) {
        mainParam = (MAIN_PARA_ID)mParam;
        subParam = (SAB_PARA_ID)sParam;

        string[] mpStr = { "normal", "tempe", "air", "grav", "mass" };
        string[] spStr = { "water", "elec", "pois", "metal", "subnormal???" };

        Debug.Log((int)mainParam + ":" + (int)subParam);
        Debug.Log(mpStr[(int)mainParam] + ":" + spStr[(int)subParam]);


        GameObject a = Instantiate(iconPrefab[(int)subParam], gameObject.transform);
        a.transform.parent = gameObject.transform;
        a.transform.position += new Vector3(0.5f, 0.5f, -0.5f);
    }

}
