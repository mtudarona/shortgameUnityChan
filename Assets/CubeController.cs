using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {

    //キューブの移動速度
    private float speed = -0.2f;

    //消滅位置
    private float deadLine = -10;

    //音声再生用
    private AudioSource sound;

	// Use this for initialization
	void Start () {
        //AudioSourceコンポーネントを取得し、変数に格納
        sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        //画面外に出たら破棄する
        if(transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
	}

    //ブロックが衝突した場合に呼ばれる関数
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag != "unitychan")
        {
            sound.PlayOneShot(sound.clip);
        }
    }
}
