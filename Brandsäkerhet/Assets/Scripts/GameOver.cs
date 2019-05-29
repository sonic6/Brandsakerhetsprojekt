using UnityEngine.UI;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] string insertLineOne;
    [SerializeField] string fireAlive;
    [SerializeField] string fireDead;
    [SerializeField] string insertLineThree;

    [SerializeField] Text lineOne;
    [SerializeField] Text lineTwo;
    [SerializeField] Text lineThree;

    private void Awake()
    {
        int myFireCondition = PlayerPrefs.GetInt("fireCondition");

        if (PlayerPrefs.GetInt("Death") == 0)
        {
            lineTwo.gameObject.SetActive(true);
            if (myFireCondition == 1)
                lineTwo.text = fireAlive;

            else if (myFireCondition == 0)
                lineTwo.text = fireDead;

            if (PlayerPrefs.GetInt("fireIncreased") == 1)
            {
                lineThree.gameObject.SetActive(true);
                lineThree.text = insertLineThree;
            }
        }
        else if (PlayerPrefs.GetInt("Death") == 1)
        {
            lineOne.gameObject.SetActive(true);
            lineOne.text = insertLineOne;
        }
    }
}
