using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private GameObject myHead;
    [Tooltip("Health in this case is minutes of allowed survival (it will be multiplied by 60 on start, no need to type that in)")]
    [SerializeField] float myHealth;
    [Tooltip("Insert an object with animator component attached")]
    [SerializeField] Animator anim;
    [Tooltip("The speed of the animation played by the Animator")]
    [SerializeField] float animSpeed;
    [Tooltip("toggle wether you want to use an on screen animated damage UI or not")]
    [SerializeField] bool useAnimator = false;

    private void Start()
    {
        myHealth = myHealth * 60;
        myHead = Camera.main.gameObject;
    }

    void Update()
    {
        if (myHead.transform.localPosition.y < 1f)
        {
            if(useAnimator == true)
                anim.SetFloat("speed", -animSpeed);

            myHealth = myHealth - 0.7f * Time.deltaTime;
        }
        else if (myHead.transform.localPosition.y >= 1f)
        {
            if (useAnimator == true)
                anim.SetFloat("speed", animSpeed);

            myHealth = myHealth - 1 * Time.deltaTime;
        }

        if (myHealth <= 0)
        {
            PlayerPrefs.SetInt("Death", 1);
            SceneManager.LoadScene("EndScene");
        }
    }
}
