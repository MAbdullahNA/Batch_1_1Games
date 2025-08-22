using UnityEngine;

public class FPSController : MonoBehaviour
{
    public Animator _playerAnimator;
    public PlayerLocomotion _playerLocomotion;

    public string inputX = "InputX";
    public string inputY = "InputY";
    public float lcomotionBlend = 2f;
    private Vector2 moveInput = Vector2.zero;
    private Vector2 currenMove = Vector2.zero;

    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        _playerLocomotion = GetComponent<PlayerLocomotion>();
    }
    // Update is called once per frame
    void Update()
    {
        PlayerAnimation();
    }
    public void PlayerAnimation()
    {
        moveInput = _playerLocomotion.moveInput;
        currenMove = Vector2.Lerp(currenMove, moveInput, lcomotionBlend*Time.deltaTime);

        _playerAnimator.SetFloat(inputX, currenMove.x);
        _playerAnimator.SetFloat(inputY, currenMove.y);
    }
}
