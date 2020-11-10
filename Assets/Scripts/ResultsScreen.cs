using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultsScreen : MonoBehaviour
{
    [SerializeField]
    GameObject text;

    public CameraMovement cameraMovement;

    // Start is called before the first frame update
    void Update()
    {
        text.GetComponent<TextMeshProUGUI>().text = "SCORE: " + cameraMovement.score;
    }
}
