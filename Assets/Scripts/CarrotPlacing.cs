using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotPlacing : MonoBehaviour
{
    public int scoreCounter = 100;
    int scoreModifier = 1;
    Vector3 carrotTargetPos = new Vector3(0f, 0f, 0f);
    Vector3 carrotPoint1 = new Vector3(0f, 0f, 0f);
    Vector3 carrotPoint2 = new Vector3(0f, 0f, 0f);

    float carrotSpeed = 1;
    bool isMoving = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
            if(transform.position == carrotPoint1 || transform.position == carrotPoint2)
            {
                Vector3 tempVector = carrotPoint1;
                carrotPoint1 = carrotPoint2;
                carrotPoint2 = tempVector;
            }
            transform.position = Vector3.MoveTowards(carrotPoint1, carrotPoint2, carrotSpeed);
        }
    }

    void ScoreCalculator()
    {
        int scoreRemoval = (int)Vector3.Distance(transform.position, carrotTargetPos) * scoreModifier;
        scoreCounter -= scoreRemoval;
    }
}
