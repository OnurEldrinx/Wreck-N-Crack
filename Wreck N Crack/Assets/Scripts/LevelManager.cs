using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{

    public GameObject cubes;
    public int numberOfCubes;
    public int fallenCubes;
    public int levelNo;

    public bool isLevelFinished;

    // Start is called before the first frame update
    void Start()
    {

        levelNo = PlayerPrefs.GetInt("LevelNo");
        numberOfCubes = cubes.transform.childCount;

    }

    // Update is called once per frame
    void Update()
    {

        if(fallenCubes == numberOfCubes)
        {

            isLevelFinished = true;

            UIManager.Instance.winUI.SetActive(true);

            UIManager.Instance.timeScoreText.text = UIManager.Instance.timerText.text;

            if(GameManager.Instance.chronometer <= 20)
            {

                UIManager.Instance.thorImg.SetActive(true);

            }else if (GameManager.Instance.chronometer <= 40)
            {

                UIManager.Instance.hulkImg.SetActive(true);

            }
            else if (GameManager.Instance.chronometer <= 60)
            {

                UIManager.Instance.terminatorImg.SetActive(true);

            }
            else
            {

                UIManager.Instance.kongImg.SetActive(true);

            }

        }
        
    }
}
