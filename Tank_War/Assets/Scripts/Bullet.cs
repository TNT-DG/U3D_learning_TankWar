using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float moveSpeed = 10.0f;

    public bool isPlayerBullet;

	// Use this for initialization
	void Start () {
	
        
        	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(transform.up * moveSpeed * Time.deltaTime, Space.World); 
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            //子弹碰到玩家
            case "Tank":
                if (!isPlayerBullet)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;
            //子弹碰到基地
            case "Heart":
                collision.SendMessage("Die");
                Destroy(gameObject);
                break;
            //子弹碰到敌人
            case "Enemy":
                if (isPlayerBullet)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;
            //子弹碰到墙
            case "Wall":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            //子弹碰到障碍
            case "Barrier":
                Destroy(gameObject);
                break;

            default:
                break;
        }
    }
}
