using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Ofline : MonoBehaviour
{
    public float RacketSpeed;

    private Rigidbody2D rb;
    private Vector2 racketDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("VerticalOfline2");
        racketDirection = new Vector2(0, directionY).normalized;
    }
    private void FixedUpdate()
    {
        rb.velocity = racketDirection * RacketSpeed;
    }
}
