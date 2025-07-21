using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public InputField userName, userAge;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        userName.text = PlayerPrefs.GetString("userName");
        userAge.text = PlayerPrefs.GetString("userAge");

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SaveUserDataBtnClick()
    {
        PlayerPrefs.SetString("userName", userName.text);
        PlayerPrefs.SetString("userAge", userAge.text);
    }
}
