using UnityEngine;

public class FPS : MonoBehaviour
{
    public Animator BotAnimator;

    private void Start()
    {
        BotAnimator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            BotAnimator.SetTrigger("Idle");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            BotAnimator.SetTrigger("Kick");
        }
        if(Input.GetKey(KeyCode.S))
        {

            BotAnimator.SetTrigger("Kick");
        }
    }
}
