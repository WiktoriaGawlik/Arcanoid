using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    public Rigidbody2D ball;
    public Sprite Block1;
    public Sprite BlockBroken2;
    public Sprite BlockBroken3;
    private SpriteRenderer cc;
    public Transform explosion;

    public int hitsNeeded = 3;
    public int hitsTaken;

     void Start()
    {
        hitsTaken = 0;
        cc = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (hitsTaken == 1)
        {      
            cc.sprite = BlockBroken2;
        }
        if (hitsTaken==2)
        {
            cc.sprite = BlockBroken3;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)

    {
        hitsTaken += 1;
        if (hitsTaken>=hitsNeeded)
        {
            Instantiate(explosion, collision.transform.position, collision.transform.rotation);
            Destroy(gameObject);
        }
    }

}
