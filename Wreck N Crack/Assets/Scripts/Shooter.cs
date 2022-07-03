using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public static Shooter instance;

    [SerializeField] private float throwForce = 1f;             
    [SerializeField] private float throwForceZ = 50f;           

    private Vector2 startPos, endPos, direction;                
    private float tapStartTime, tapEndTime, totalTime;          
    public GameObject ballObj;                                 

    public GameObject BallObj { get => ballObj; set => ballObj = value; }

    private bool canCheckSwipe = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

   
    void Update()
    {

        if (GameManager.Instance.isGameStarted && !LevelManager.Instance.isLevelFinished)
        {

            if (Input.GetMouseButtonDown(0))
            {
                tapStartTime = Time.time;
                startPos = Input.mousePosition;
                canCheckSwipe = true;

            }

            if (Input.GetMouseButtonUp(0) && canCheckSwipe)
            {
                tapEndTime = Time.time;
                totalTime = tapEndTime - tapStartTime;
                endPos = Input.mousePosition;
                direction = startPos - endPos;

                BallObj = ObjectPool.SharedInstance.GetPooledObject();
                if (BallObj != null)
                {
                    BallObj.transform.position = transform.position;
                    BallObj.transform.rotation = transform.rotation;
                    BallObj.SetActive(true);
                }

                
                BallObj.GetComponent<Rigidbody>().isKinematic = false;

                BallObj.GetComponent<Rigidbody>().AddForce(-direction.x * throwForce, -direction.y * throwForce, throwForceZ / totalTime);

                canCheckSwipe = false;


            }
        }

    }

   
}
