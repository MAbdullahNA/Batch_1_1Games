using UnityEngine;
using UnityEngine.UI;

public class CubeMovement : MonoBehaviour
{
    public GameManager _gameManager;

    int num = 5;
    [SerializeField] Renderer r1, r2, r3, r4, r5;

    public Material greenMat;
    Rigidbody rb;

    [SerializeField] float inputX;
    [SerializeField] float inputY;

    public float speed = 5;
    public float turnSpeed = 5;
    public float jumpForce = 100;

    public bool isGrounded = false;
    public bool isGameStart = false;

    public GameObject homePanel, gamePanel;

    public Text PreScoreText;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        PreScoreText.text = PlayerPrefs.GetInt("score",10).ToString();

    }

    private void Update()
    {
        if (isGameStart)
        {
            inputX = Input.GetAxis("Horizontal");
            inputY = Input.GetAxis("Vertical");

            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed * inputY);
            transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * inputX);

            float jumpInput = Input.GetAxis("Jump");
            if (jumpInput == 1 && isGrounded) // isGrounded == true// ground check with collider
            {
                rb.AddForce(rb.linearVelocity.x,  jumpForce, rb.linearVelocity.z);
            }
        }
    }
    //
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            isGameStart = false;
            int level = _gameManager.levelNo;
            level++;
            if(level<_gameManager.levelGOs.Length)
            {
                //playerPref
            }
            else
            {
                level = 0;
                //playerPres
            }
            //Scene reload
        }
    }
    //
    public void GameStart()
    {
        isGameStart = true;
        homePanel.SetActive(false);
        gamePanel.SetActive(true);
    }
}
