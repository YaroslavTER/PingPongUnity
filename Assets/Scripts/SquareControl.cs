using UnityEngine;
using System.Collections;

public class SquareControl : MonoBehaviour {
    Rigidbody2D rb2d;
    public float speed = 500;
    float beg_x_position = 0, beg_y_position = 0;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        beg_x_position = rb2d.position.x;
        beg_y_position = rb2d.position.y;
        rb2d.velocity = new Vector2(speed, speed);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "RightWall" || col.gameObject.name == "LeftWall")
            rb2d.velocity = new Vector2(-rb2d.velocity.x, rb2d.velocity.y);
        else if (col.gameObject.name == "UpWall" || col.gameObject.name == "Plate")
            rb2d.velocity = new Vector2(rb2d.velocity.x, -rb2d.velocity.y);
        else if (col.gameObject.tag == "Floor") Spavn();
        else if (col.gameObject.tag == "Enemy") {
            rb2d.velocity = new Vector2(rb2d.velocity.x, -rb2d.velocity.y);
            Destroy(col.gameObject); 
        }
    }

    void Spavn()
    {
        rb2d.position = new Vector3(beg_x_position, beg_y_position, rb2d.transform.position.z);
        rb2d.velocity = new Vector2(speed, speed);
    }
}
