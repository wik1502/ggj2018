using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInputTouch : MonoBehaviour {
    
    public bool deadTrigger;                //NPCが死んでいるか
    public static Vector3 moveVectorStatic; //moveVectorの外部参照用

    Vector3 starPositionBefore; //1フレーム前の座標
    Vector3 starPositionAfter;  //1フレーム後の座標
    Vector3 moveVector;         //フリック時に動くベクトル
    
    void Start () {
        deadTrigger = false;    //NPCは死んでるか初期化
	}
	
	void Update () {
        this.gameObject.transform.Translate(moveVector * GameMainSystem.slowFlickMoveStatic * Time.deltaTime);    //フリック時、算出ベクトルで移動
	}


    void OnMouseDrag()  //マウスドラッグ中の処理
    {
        starPositionBefore = this.transform.position;           //算出前(1フレーム前)の座標

        Vector3 objectPointInScreen = Camera.main.WorldToScreenPoint(this.transform.position);                          //カメラ位置の取得
        Vector3 mousePointInScreen = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objectPointInScreen.z);  //カメラ上でのマウス位置の取得
        Vector3 mousePointInWorld = Camera.main.ScreenToWorldPoint(mousePointInScreen);                                 //カメラ上のマウス位置をWorld座標に変換
        mousePointInWorld.z = this.transform.position.z;        //Z座標はオブジェクトに合わせる
        this.transform.position = mousePointInWorld;            //オブジェクト位置をマウス位置に合わせる

        starPositionAfter = this.transform.position;            //算出後(1フレーム後)の座標

        moveVector = starPositionAfter - starPositionBefore;    //フリック時のベクトルの算出
        moveVectorStatic = moveVector;                          //参照用のStatic変数に値を代入
    }

    void OnMouseUp()    //マウスを放した時の処理(フリック時)
    {
        
    }
}
