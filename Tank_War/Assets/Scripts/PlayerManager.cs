using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {
    //属性值
    public int lifeValue = 3;
    public int playerScole = 0;
    public bool isDead;
    public bool isDefeat;

    //引用
    public GameObject born;
    public Text playScoreText;
    public Text playerLifeValueText;
    public GameObject isDefeatUI;

    //单例
    private static PlayerManager instance;
    private PlayerManager() { }

    public static PlayerManager Instance
    {
        get
        {
            return instance;
        }

        set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
        if(isDefeat)
        {
            isDefeatUI.SetActive(true);
            Invoke("ReturnToMain", 3);
            return;
        }
        if (isDead)
        {
            Recover(); 
        }
        playScoreText.text = playerScole.ToString();
        playerLifeValueText.text = lifeValue.ToString();
	}

    private void Recover()
    {
        if (lifeValue < 0)
        {
            //游戏失败，返回主界面
            isDefeat = true;
            Invoke("ReturnToMain", 3);
        }
        else
        {
            lifeValue--;
            GameObject go = Instantiate(born, new Vector3(-2, -8, 0), Quaternion.identity);
            go.GetComponent<Born>().createPlayer = true;
            isDead = false;
        }
    }

    private void ReturnToMain()
    {
        SceneManager.LoadScene(0);
    }
}
