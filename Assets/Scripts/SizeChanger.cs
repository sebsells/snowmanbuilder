using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    public CameraMovement cameraMovement;

    [SerializeField]
    GameObject targetSphere; // Visual target for the player
    [SerializeField]
    GameObject snowmanSphere; // Sphere that he user is changing
    public float targetSize = 100f;
    public float startingSize = 50f;

    public int scoreCounter = 100;
    int scoreModifier = 4;

    const float scaleIncrease = 0.3f;
    Vector3 moveDist = new Vector3(scaleIncrease, scaleIncrease, scaleIncrease);
    float moveAccel = 0.7f;

    bool isIncreasing = false;

    void Start() {
        targetSphere.transform.localScale = new Vector3(1f, 1f, 1f) * targetSize;
        snowmanSphere.transform.localScale = new Vector3(1f, 1f, 1f) * startingSize;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            isIncreasing = true;
        } else if (Input.GetKeyUp(KeyCode.Space)) {
            isIncreasing = false;
            ScoreCalculator();
            cameraMovement.NextGame();
        }

        if (isIncreasing) {
            moveAccel += 0.03f;
            snowmanSphere.transform.localScale += moveDist * moveAccel;
        }
    }

    void ScoreCalculator() {
        float scoreRemoval = Mathf.Abs(snowmanSphere.transform.localScale.x - targetSize) * scoreModifier;
        scoreCounter -= (int)scoreRemoval;
        cameraMovement.score += scoreCounter;
    }
}