using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotPlacing : MonoBehaviour
{
    [SerializeField]
    GameObject carrot;

    public CameraMovement cameraMovement;
    public int scoreCounter = 100;
    int scoreModifier = 100;
    Vector3 carrotTargetPos = new Vector3(0f, 3f, -32f);
    public Vector3 carrotPoint1 = new Vector3(-1f, 3f, -32f);
    public Vector3 carrotPoint2 = new Vector3(1f, 3f, -32f);

    float carrotSpeed = 1f;
    bool isMoving = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = false;
            ScoreCalculator();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            cameraMovement.NextGame();
        }

        if (isMoving)
        {
            if(carrot.transform.position.x <= carrotPoint1.x || carrot.transform.position.x >= carrotPoint2.x)
            {
                carrotSpeed = -carrotSpeed;
            }
            carrot.transform.position += new Vector3(carrotSpeed*Time.deltaTime, 0f, 0f);
        }
    }

    void ScoreCalculator()
    {
        float scoreRemoval = Vector3.Distance(carrot.transform.position, carrotTargetPos) * scoreModifier;
        scoreCounter -= (int)scoreRemoval;
        cameraMovement.score += scoreCounter;
    }
}
