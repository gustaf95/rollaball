using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    public Rigidbody rb;
    public float speed;
    public UnityEngine.UI.Text CountText;

    private int count;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        CountText.text = "Count: " + count.ToString();
        count = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
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
            CountText.text = "Count: " + count.ToString();
        }                
    }
}
