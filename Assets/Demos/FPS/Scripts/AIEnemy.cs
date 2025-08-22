using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    public NavMeshAgent bot;
    public GameObject player;
    public float chaseDistace = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bot = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float radius = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if (radius <= chaseDistace) { bot.SetDestination(player.transform.position);
            bot.isStopped = false;
        }
        else { bot.isStopped=true; }
    }
}
