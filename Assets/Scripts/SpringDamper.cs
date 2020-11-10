using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpringDamper : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Vector2 targetPos;
    public Vector2 currentPos;
    public Vector2 direction;
    public Vector3 screenCenter;
    public Rigidbody2D rigBod;
    private float spring = 1f;
    private float drag = 0.05f;
    public bool dragging = false;
    


    // Start is called before the first frame update
    void Start()
    {
        rigBod = this.GetComponent<Rigidbody2D>();
        screenCenter = new Vector3 (Screen.width/2, Screen.height/2,0);
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = new Vector2(this.transform.localPosition.x, this.transform.localPosition.y);
        direction = (targetPos - currentPos);

        rigBod.velocity += direction * spring;
        rigBod.velocity -= rigBod.velocity * drag;


        if (dragging)
        {
            this.transform.localPosition = Input.mousePosition - screenCenter;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
    }
}
