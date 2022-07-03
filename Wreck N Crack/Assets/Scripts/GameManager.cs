using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    public bool isGameStarted;
    public float chronometer;

    // Start is called before the first frame update
    void Start()
    {

        UIManager.Instance.levelNoText.text = "LEVEL " + (PlayerPrefs.GetInt("LevelNo") + 1);

        Application.targetFrameRate = 60;

    }

    // Update is called once per frame
    void Update()
    {

        if (isGameStarted && !LevelManager.Instance.isLevelFinished)
        {

            chronometer += Time.deltaTime;

        }

        if (Input.GetMouseButtonDown(0) && !isGameStarted)
        {

            isGameStarted = true;
            UIManager.Instance.waitUI.SetActive(false);

        }


    }

    public void NextLevel()
    {

        LevelManager.Instance.levelNo++;
        PlayerPrefs.SetInt("LevelNo", LevelManager.Instance.levelNo);
        PlayerPrefs.Save();


        if ((SceneManager.GetActiveScene().buildIndex + 1) % 5 == 0)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);

        }
        else
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }


    }

    public void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
