using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CameraMovement : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject snowManEmpty;
    public GameObject[] initializeObjects = new GameObject[10];
    public Transform[] cameraPositions = new Transform[10];
    public Transform[] snowManPositions = new Transform[10];
    int positionCount = 0;

    public int score;

    public void NextGame()
    {
        initializeObjects[positionCount].SetActive(false);
        positionCount += 1;
        mainCamera.transform.position = cameraPositions[positionCount].position;
        snowManEmpty.transform.position = snowManPositions[positionCount].position;
        initializeObjects[positionCount].SetActive(true);
    }

    private void Start() {
        mainCamera.transform.position = cameraPositions[positionCount].position;
        snowManEmpty.transform.position = snowManPositions[positionCount].position;
    }
}
