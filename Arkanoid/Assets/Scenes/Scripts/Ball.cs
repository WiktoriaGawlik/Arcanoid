using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Paddle paddle1;        //jest skrypt o takiej nazwie więc odrazu powstaje taka klasa ; paddle1 bo w przyszłości będziemy chcieli ich więcej)
    [SerializeField] bool hasStarted = false;
    [SerializeField] float xPush;
    [SerializeField] float yPush;
    [SerializeField] Rigidbody2D rb;
    Vector2 paddleToBallVector;
    public GameManager gm;

	// Use this for initialization
	private void Start () {
        paddleToBallVector = transform.position - paddle1.transform.position;     // blokowanie się piłki (oblicza pozycje platformy, odejmuje od niej 

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;
	}

    // Update is called once per frame
    private void Update()
    {
        if (!hasStarted) 
        {
            LockBallToPaddle(); //metoda
            LunchOnMouseClick();
        }
    }

    private void LunchOnMouseClick() //metoda wyrzucania
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity= new Vector2 (xPush, yPush);
            rb.simulated = true;
        }
                                              // throw new NotImplementedException();        pojawia się przy tworzeniu metody, krzyczy nam że czegoś tu brakuje                               
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if(collision.CompareTag("lose"))
        {
            gm.UpdateLives(-1);
            hasStarted = false;
        }
    }
}
