using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotPlacing : MonoBehaviour
{
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

        if (isMoving)
        {
            if(transform.position.x <= carrotPoint1.x || transform.position.x >= carrotPoint2.x)
            {
                carrotSpeed = -carrotSpeed;
            }
            transform.position += new Vector3(carrotSpeed*Time.deltaTime, 0f, 0f);
        }
    }

    void ScoreCalculator()
    {
        float scoreRemoval = Vector3.Distance(transform.position, carrotTargetPos) * scoreModifier;
        scoreCounter -= (int)scoreRemoval;
    }
}
