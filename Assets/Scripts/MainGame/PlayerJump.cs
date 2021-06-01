using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource au;
    public int jumpForce = 10;
    private GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");

    }

    // Update is called once per frame
    void Update()
    {
        // Only jumps when NOT paused
        // accesses Canvas Manager Script's paused flag
        if (Input.GetKeyDown(KeyCode.Space) && !canvas.GetComponent<CanvasManager>().paused){
            MakePlayerJump(jumpForce);
        }
    }

    //Method that makes the player Jump
    public void MakePlayerJump(int force)
    {
        au = GetComponent<AudioSource>();
        au.Play();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        
    }
}
