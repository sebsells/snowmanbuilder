using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using System.Collections;
using UnityEngine;


public class SizeChanger : MonoBehaviour {

    [SerializeField]
    GameObject sphere;

    Vector3 moveDist = new Vector3(0.01f, 0.01f, 0.01f);

    void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            sphere.transform.localScale += moveDist;

        }
    }
}