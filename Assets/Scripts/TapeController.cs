using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeController : MonoBehaviour
{
    private bool isDragging;
    public float percentComplete;
    public bool isRewinding;

    GameObject currentRewinder;

    private void Start()
    {
        percentComplete = Random.value;
        GetComponent<BoundaryManager>().MainCamera = Camera.main;
        isRewinding = false;
    }


    public void OnMouseUpAsButton()
    {
        if (percentComplete >= 1.0f)
        {
            // Tape is finished and player clicks it

            //gameObject.GetComponentInParent<GameManager>().currentScore++;

            // Reset the winder for the next tape
            //currentRewinder.GetComponent<RewinderController>().ResetState();

            //Destroy(this);
        }
    }

    public void OnMouseDown()
    {
        isDragging = true;


    }

    public void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "rewinder")
        {
            currentRewinder = collision.gameObject;
        }
    }

}
