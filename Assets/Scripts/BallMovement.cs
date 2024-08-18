using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float StartSpeed;
    public float AddSpeed;
    public float MaxSpeed;

    public bool player1start = true;

    private int Hitcounter;
    private Rigidbody2D rb;
    public ScoreManager scoreManager;

    public AudioClip ballCollideClip, WallClip;
    public AudioSource ballSound;

    // Start is called before the first frame update
    void Start()
    {
        ballSound.clip = WallClip;
        ballSound.Play();
        scoreManager = FindObjectOfType<ScoreManager>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }
    public void restartBall()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 1);
    }
    public IEnumerator Launch()
    {
        restartBall();
        Hitcounter = 0;
        yield return new WaitForSeconds(1);
        if (player1start == true)
        {
            MoveBall(new Vector2(-1, 0));

        }
        else
        {
            MoveBall(new Vector2(1, 0));
        }
    }

    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;
        float ballSpeed = StartSpeed + Hitcounter * AddSpeed;
        rb.velocity = direction * ballSpeed;
    }
    public void IncresHitCounter () 
    {
        if(Hitcounter *AddSpeed < MaxSpeed )
        {
            Hitcounter++;
        }    
    }

    #region ballbounce 
    
    private void Bounce (Collision2D collision) 
    {
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = collision.transform.position;
        float racketHight = collision.collider.bounds.size.y;
        float positionX ;

        if(collision.gameObject.tag == "Player")
        {

            positionX = 1;
        }
        else
        {
            positionX = -1;
        }
        float positionY = (ballPosition.y-racketPosition.y)/racketHight;
        IncresHitCounter();
        MoveBall(new Vector2(positionX,positionY));

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ballSound.clip = ballCollideClip;
            ballSound.Play();
            Bounce(other);
        }
        else if (other.gameObject.tag == "EWall") 
        {
            scoreManager.Player1Goal();
            player1start = false;
            StartCoroutine(Launch());
        }
        else if (other.gameObject.tag == "PWall")
        {
            scoreManager.Player2Goal();
            player1start = true;
            StartCoroutine(Launch());
        }

    } 

    #endregion
}
