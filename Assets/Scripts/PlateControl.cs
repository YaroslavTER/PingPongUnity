using UnityEngine;
using System.Collections;

public class PlateControl : MonoBehaviour {
    Rigidbody2D rb2d;
    public int speed = 100;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
        else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
    }
}
