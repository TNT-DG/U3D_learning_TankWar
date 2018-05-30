using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour
{
    //用于装饰初始化地图所需物体的数组
    //0.基地 1.墙 2.障碍 3.出生效果 4.河流 5.草 6.空气墙
    public GameObject[] items;
    //用于存储已经存在物体的地点坐标
    private List<Vector3> itemPositionList = new List<Vector3>();

    private void Awake()
    {
        InitMap();
    }

    /// <summary>
    /// 初始化地图
    /// </summary>
    private void InitMap()
    {
        //初始化基地
        CreateItems(items[0], new Vector3(0, -8, 0), Quaternion.identity);
        //用墙把基地围起来
        CreateItems(items[1], new Vector3(-1, -8, 0), Quaternion.identity);
        CreateItems(items[1], new Vector3(1, -8, 0), Quaternion.identity);
        for (int i = 0; i < 3; i++)
        {
            CreateItems(items[1], new Vector3(i - 1, -7, 0), Quaternion.identity);
        }
        //初始化外围空气墙
        for (int i = -11; i < 12; i++)
        {
            CreateItems(items[6], new Vector3(i, 9, 0), Quaternion.identity);
            CreateItems(items[6], new Vector3(i, -9, 0), Quaternion.identity);
        }
        for (int i = -8; i < 9; i++)
        {
            CreateItems(items[6], new Vector3(-11, i, 0), Quaternion.identity);
            CreateItems(items[6], new Vector3(11, i, 0), Quaternion.identity);
        }
        //初始化地图
        for (int i = 0; i < 60; i++)
        {
            CreateItems(items[1], CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreateItems(items[2], CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreateItems(items[4], CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreateItems(items[5], CreateRandomPosition(), Quaternion.identity);
        }
        //初始化玩家
        GameObject go = Instantiate(items[3], new Vector3(-2, -8, 0), Quaternion.identity);
        go.GetComponent<Born>().createPlayer = true;
        //产生敌人
        CreateItems(items[3], new Vector3(-10, 8, 0), Quaternion.identity);
        CreateItems(items[3], new Vector3(0, 8, 0), Quaternion.identity);
        CreateItems(items[3], new Vector3(10, 8, 0), Quaternion.identity);

        InvokeRepeating("CreateEnemy", 4, 5);
    }

    /// <summary>
    /// 生成物体
    /// </summary>
    /// <param name="物体类别"></param>
    /// <param name="物体位置"></param>
    /// <param name="物体旋转"></param>
    private void CreateItems(GameObject createGameObject, Vector3 position, Quaternion rotation)
    {
        GameObject itemGo = Instantiate(createGameObject, position, rotation);
        itemGo.transform.SetParent(gameObject.transform);
        itemPositionList.Add(position);
    }

    /// <summary>
    /// 产生随机位置
    /// </summary>
    /// <returns></returns>
    private Vector3 CreateRandomPosition()
    {
        //不生成X=-10，10的两列，y=-8,8两行
        while (true)
        {
            Vector3 createPositon = new Vector3(Random.Range(-9, 10), Random.Range(-7, 8), 0);

            if(!HasThePosition(createPositon))
            {
                return createPositon;
            }
        }
    }

    /// <summary>
    /// 判断该坐标是否已经存在于列表中
    /// </summary>
    /// <param name="createPos"></param>
    /// <returns></returns>
    private bool HasThePosition(Vector3 createPos)
    {
        foreach(Vector3 x in itemPositionList)
        {
            if (createPos == x)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 产生敌人的方法
    /// </summary>
    private void CreateEnemy()
    {
        int num = Random.Range(0, 3);
        Vector3 enemyPos = new Vector3();
        switch (num)
        {
            case 0:
                enemyPos = new Vector3(-10, 8, 0);
                break;
            case 1:
                enemyPos = new Vector3(0, 8, 0);
                break;
            case 2:
                enemyPos = new Vector3(10, 8, 0);
                break;
            default:
                break;
        }
        CreateItems(items[3], enemyPos, Quaternion.identity);
    }

}
