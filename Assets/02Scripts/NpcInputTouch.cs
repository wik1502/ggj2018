using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInputTouch : MonoBehaviour {
    
    public bool deadTrigger;                //NPCが死んでいるか(オブジェクトが消えるまでの猶予期間。演出用)
    GameObject player;          //プレイヤーオブジェクト
    Vector3 starPositionBefore; //1フレーム前の座標
    Vector3 starPositionAfter;  //1フレーム後の座標
    Vector3 moveVector;         //フリック時に動くベクトル
    public static Vector3 moveVectorStatic; //moveVectorの外部参照用
    GameMainSystem gameSystem;

    void Start () {
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameMainSystem>();
        deadTrigger = false;                //NPCは死んでるか初期化
        moveVector = new Vector3(0, 0, 0);
        player = GameObject.Find("Player"); //プレイヤーオブジェクトの取得
    }
	
	void Update () {
        //フリック時、算出ベクトルで移動
        if (!PlayerCollision.triggerEnter)
            this.gameObject.transform.Translate(moveVector * gameSystem.slowFlickMove * Time.deltaTime);

        //離れたNPCを消す
        DeleteNpc();
    }
    
    void OnMouseDrag()  //マウスドラッグ中の処理
    {
        if (!deadTrigger)   //死ぬまでの猶予期間でないなら実行
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
    }

    //離れたNPCを消す
    void DeleteNpc()
    {
        if (Mathf.Abs((this.transform.position - player.transform.position).magnitude) > 15.0f)  //距離が離れたら(カメラから出るくらい)
            Destroy(this.gameObject);    //NPCを消す
    }

    private void OnDestroy()
    {
        GameObject.Find("NpcPop").SendMessage("Repop");
    }
}
