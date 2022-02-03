using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewinderController : MonoBehaviour
{
    GameObject currentGameObject;
    TapeController currentTape;
    public float currentTapeProgress;
    public float rewindSpeed;
    STATE currentState;

    SpriteRenderer spriteRenderer;
    Color originalColor;

    
    public Sprite runningSprite;
    public Sprite finishedSprite;
    public Sprite readySprite;

    enum STATE {
        READY,
        RUNNING,
        FINISHED
    }

    private void Start()
    {
        currentState = STATE.READY;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = readySprite;
    }

    void Update()
    {
        if (currentState == STATE.RUNNING)
        {
            if (currentTapeProgress < 1)
            {
                spriteRenderer.sprite = runningSprite;
                currentTapeProgress += rewindSpeed;
            }
            else if (currentTapeProgress >= 1)
            {
                currentState = STATE.FINISHED;
                spriteRenderer.sprite = finishedSprite;
            }
        }
    }

    private void OnMouseDown()
    {
        Debug.Log(currentState);
        if (currentState == STATE.FINISHED)
        {
            Debug.Log("FINISHED - Process unloading");
            FindObjectOfType<GameManager>().currentScore++;
            ResetState();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (currentState == STATE.READY && collision.gameObject.tag == "tape")
        {
            currentTapeProgress = collision.gameObject.GetComponent<TapeController>().percentComplete;
            currentState = STATE.RUNNING;
            Destroy(collision.gameObject);
        }
    }

    internal void ResetState()
    {
        Debug.Log("Reset State For " + name);
        spriteRenderer.sprite = readySprite;
        currentState = STATE.READY;
    }

}
