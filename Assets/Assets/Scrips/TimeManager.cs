using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeManager : MonoBehaviour
{
    Image timeBar;
    public float maxTime = 5f;
    float timeLeft;
    public GameObject timeUpText;

    private string input;
    public Text question;

    private int num1;
    private int num2;
    private int aux;

    public Slider dragonHealthBar;
    public Slider playerHealthBar;

    private int dragonHealth = 100;
    private int playerHealth = 100;


    public Image dragonHeart;
    public Image dragon;

    // Start is called before the first frame update
    void Start()
    {
        timeUpText.SetActive(false);
        timeBar = GetComponent<Image>();
        timeLeft = maxTime;

        num1 = Random.Range(1, 16);
        num2 = Random.Range(1, 16);
        question.text = num1.ToString() + "   +   " + num2.ToString();

        dragonHealthBar.value = dragonHealth;
        playerHealthBar.value = playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        int.TryParse(input, out int aux);

        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeBar.fillAmount = timeLeft / maxTime;
            if(aux == (num1 + num2))
            {
                if(dragonHealth > 0)
                {
                    dragonHealth -= 10;
                    dragonHealthBar.value = dragonHealth;
                    num1 = Random.Range(1, 16);
                    num2 = Random.Range(1, 16);
                    question.text = num1.ToString() + "   +   " + num2.ToString();
                    timeLeft = maxTime;
                    timeBar.fillAmount = 1;
                    if(dragonHealth == 0)
                    {
                        timeUpText.SetActive(true);
                        Time.timeScale = 0;
                        Destroy(dragon);
                        dragonHealthBar.transform.position = new Vector2(-500, 0);
                        Destroy(dragonHeart);
                    }
                }
            }
        }
        else
        {
            playerHealth -= 10;
            playerHealthBar.value = playerHealth;
            num1 = Random.Range(1, 16);
            num2 = Random.Range(1, 16);
            question.text = num1.ToString() + "   +   " + num2.ToString();
            timeLeft = maxTime;
            timeBar.fillAmount = 1;
        }
    }

    public void ReadStringInput(string str)
    {
        input = str;
        Debug.Log(input);
    }
}
