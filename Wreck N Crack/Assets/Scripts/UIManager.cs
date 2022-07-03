using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : Singleton<UIManager>
{

    public GameObject waitUI;
    public GameObject inGameUI;
    public GameObject winUI;

    public TextMeshProUGUI levelNoText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI timeScoreText;
    public GameObject thorImg;
    public GameObject terminatorImg;
    public GameObject kongImg;
    public GameObject hulkImg;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timerText.text =((int)GameManager.Instance.chronometer).ToString(); 

    }
}
