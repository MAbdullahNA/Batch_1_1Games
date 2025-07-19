using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CubeCollider : MonoBehaviour
{
    public int score = 0;
    public int health = 100;

    public Text scoreText;
    public Slider healthSlider;
    //
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger" + other.gameObject.name);
        if (other.gameObject.tag == "Coin")
        {
            score++; // score = score+1
            scoreText.text = score.ToString();
            other.gameObject.SetActive(false);
            Debug.Log("Coin Collected");
            PlayerPrefs.SetInt("score",score);
        }
        else if(other.gameObject.tag == "Enemy")
        {
            health = health-20;
            healthSlider.value = health;
            if(health <= 0)
            {
                gameObject.SetActive(false);
            }
            Debug.Log("Collided with enemy");
        }
    }
}
