using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;

    public void UpdateHealth(int healthValue)
    {
        health += healthValue;
        Debug.Log("health: "+health);
        if (health <=0){ Destroy(this.gameObject); }
    }
}
