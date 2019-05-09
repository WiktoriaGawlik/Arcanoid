using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenWithInUnits = 16f; //pozwala prywatnym zmiennym pojawiać się w Inspektorze
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    void Update()  {                                                 //bo potrzebujemy na bieżąco ustawienie myszki
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWithInUnits;
        Vector2 paddlePos = new Vector2(mousePosInUnits, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);  //public static float Clamp(float value, float min, float max); 
        transform.position = paddlePos;
    }
}

