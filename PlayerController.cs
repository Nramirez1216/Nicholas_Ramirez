﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController: MonoBehaviour
{
    public float speed;
    public Text CountText;
    public Text winText;
    private Rigidbody rb;
    private int count;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        CountText.text = "Count:" + count.ToString ();
        winText.text = ""; 
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1
            CountText.text = "Count:" + count.ToString();
        }
    }
    void SetCountText()
    {
        CountText.text = "Count:" + count.ToString();
        if (count>=12)
        {
            winText.text = "You Win!";
        }
    }
}
