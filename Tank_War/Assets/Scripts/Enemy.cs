using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    //属性值
    private float moveSpeed = 3.0f;
    private Vector3 bulletEulerAngles;
    private float v;
    private float h;
    //引用
    private SpriteRenderer sr;
    public Sprite[] tankSprite;  //上 右 下 左 0 8 16 24
    public GameObject explosionPrefab;
    public GameObject bulletPrefab;
    //计时器
    private float timeVal;
    private float timeValChangeDir;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //攻击的时间间隔
        if (timeVal >= 3)
        {
            Attack();
        }
        else
        {
            timeVal += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Tank_Move();
        //Attack();
    }

    /// <summary>
    /// 坦克移动方法
    /// </summary>
    private void Tank_Move()
    {
        if (timeValChangeDir >= 4)
        {
            int num = Random.Range(0, 8);
            if (num >= 5)
            {
                v = -1;
                h = 0;
            }
            else if (num == 0)
            {
                v = 1;
                h = 0;
            }
            else if (num > 0 && num <= 2)
            {
                v = 0;
                h = -1;
            }
            else if (num > 2 && num <= 4)
            {
                v = 0;
                h = 1;
            }
            //旋转后计时器清零
            timeValChangeDir = 0;
        }
        else
        {
            timeValChangeDir += Time.fixedDeltaTime;
        }
        //垂直轴输入
        //v = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (v < 0)
        {
            sr.sprite = tankSprite[2];
            bulletEulerAngles = new Vector3(0, 0, 180);
        }
        else if (v > 0)
        {
            sr.sprite = tankSprite[0];
            bulletEulerAngles = new Vector3(0, 0, 0);
        }

        if (v != 0)
        {
            return;
        }


        //水平轴输入
        //h = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (h < 0)
        {
            sr.sprite = tankSprite[3];
            bulletEulerAngles = new Vector3(0, 0, 90);
        }
        else if (h > 0)
        {
            sr.sprite = tankSprite[1];
            bulletEulerAngles = new Vector3(0, 0, -90);
        }
    }

    /// <summary>
    /// 坦克攻击方法
    /// </summary>
    private void Attack()
    {
            //子弹产生的角度：当前坦克的角度+子弹应该旋转的角度
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bulletEulerAngles));
            timeVal = 0;
    }

    /// <summary>
    /// 死亡方法
    /// </summary>
    private void Die()
    {
        //产生爆炸特效
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        //死亡
        Destroy(gameObject);
    }

}
