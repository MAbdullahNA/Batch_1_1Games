using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardInput, turnInput, jumpInput;
    public float forwardSpeed = 10f, turnSpeed = 5f, jumpForce = 5f;

    /*public int intNum = -1;
    public long longNum = 213;

    public float floatN = 45.34f;
    public double doubleN = 45.3333d;

    public char charNum = '"';
    public string stringN = "\"";

    public bool boolNum = true;

    public Vector2 vector2Num;
    public Vector3 Vector3Num;*/

    private void Start()
    {
        //rb = GetComponent<Rigidbody>();
       /* intNum = 4 / 3;
        floatN = 4 / 3;
        Debug.Log("int = " + intNum);
        Debug.Log("float = " + floatN);

        charNum = '\'';
        Debug.Log("Char = " + charNum);
        Debug.Log("String = " + stringN);

        vector2Num = new Vector2(0,2);
        Debug.Log("Vector2: " + vector2Num);*/
    }
    
    private void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime *forwardSpeed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * turnInput);


    }
    //
    private void LateUpdate() // Late update will run after Update
    {
        jumpInput = Input.GetAxis("Jump");
        if(jumpInput == 1 && rb.linearVelocity.y == 0)
        {
            rb.AddForce(new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z), ForceMode.Impulse);
        }
    }
}
