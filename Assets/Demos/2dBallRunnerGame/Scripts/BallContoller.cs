using UnityEngine;

public class BallContoller : MonoBehaviour
{
    Rigidbody2D ball;
    public float moveSpeed = 5f;

    public bool moveLeft = false;
    public bool moveRight = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight)
        {
            ball.AddForceX(moveSpeed);
        }
        else if (moveLeft)
        {
            ball.AddForceX(-moveSpeed);
        }
    }
    public void MoveLeft()
    {
        moveLeft = true;
    }
    public void MoveRight()
    {
        moveRight = true;
    }
    public void StopMove()
    {
        moveLeft = false;
        moveRight = false;
    }
    public void MoveUp()
    {

    }
}
