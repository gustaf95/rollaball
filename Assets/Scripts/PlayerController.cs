using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

    public Rigidbody rb;
    public float speed;
    public Text CountText;

    private int count;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        DisplayCountText();
        count = 0;
    }
	
	// Update is called once per frame
	void Update () {
        DisplayCountText();
    }

    private void FixedUpdate()
    {

        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.acceleration.x;        float moveVertical = Input.acceleration.y;
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        
        rb.AddForce(movement * speed);
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
            collision.gameObject.SetActive(false);
    }
    */

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count+1;
            DisplayCountText();
        }                
    }    void DisplayCountText()
    {
        CountText.text = "Count: " + count.ToString() + " x:"+ Input.acceleration.x.ToString() + " y:" + Input.acceleration.y.ToString()+ " z:" + Input.acceleration.z.ToString();
    }
}
