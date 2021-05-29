using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;
    public int jumpForce = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            rb = GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * jumpForce , ForceMode2D.Impulse);
        }
    }
}
