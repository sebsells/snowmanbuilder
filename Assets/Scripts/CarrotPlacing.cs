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
    Vector3 carrotTargetPos = new Vector3(75f, 18.8f, 0f);
    public Vector3 carrotPoint1 = new Vector3(75f, 18.8f, -1f);
    public Vector3 carrotPoint2 = new Vector3(75f, 18.8f, 1f);

    float carrotSpeed = 1f;
    bool isMoving = true;

    private void Start() {
        carrot.transform.localScale = new Vector3(3f, 3f, 3f);
    }

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
            if(carrot.transform.position.z <= carrotPoint1.z || carrot.transform.position.z >= carrotPoint2.z)
            {
                carrotSpeed = -carrotSpeed;
            }
            carrot.transform.position += new Vector3(0f, 0f, carrotSpeed * Time.deltaTime);
        }
    }

    void ScoreCalculator()
    {
        float scoreRemoval = Vector3.Distance(carrot.transform.position, carrotTargetPos) * scoreModifier;
        scoreCounter -= (int)scoreRemoval;
        cameraMovement.score += scoreCounter;
    }
}
