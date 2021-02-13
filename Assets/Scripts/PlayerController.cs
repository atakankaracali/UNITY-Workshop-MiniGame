using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public SpriteRenderer sp;
    public int yurumeHizi = 5;
    public int ziplamaKuvveti = 900;
    public float yatay;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        yatay = Input.GetAxis("Horizontal");

        if(yatay >0)
        {
            sp.flipX = false;
        }
        if(yatay < 0)
        {
            sp.flipX = true;
        }

        rb.velocity = new Vector2(yatay * yurumeHizi, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * ziplamaKuvveti);
            
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("deniz"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

}
