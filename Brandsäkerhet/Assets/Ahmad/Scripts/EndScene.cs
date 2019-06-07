using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    [SerializeField] Canvas myCanvas;

    [Tooltip("The distance between this gameobject and the player for which the canvas will be activated/deactivated")]
    [SerializeField] float ValidDistance;

    GameObject target;
    bool mybool;
    Vector2 myPos;

    [Tooltip("Insert here the name of the scene you want to be loaded after this level is over")]
    [SerializeField] string nextScene;
    

    public void EndGame()
    {
        if(InfoCollector.fireCondition == false)
            PlayerPrefs.SetInt("fireCondition", 0);
        else if(InfoCollector.fireCondition == true)
            PlayerPrefs.SetInt("fireCondition", 1);
        if (InfoCollector.fireIncreased == true)
            PlayerPrefs.SetInt("fireIncreased", 1);
        else if (InfoCollector.fireIncreased == false)
            PlayerPrefs.SetInt("fireIncreased", 0);

        PlayerPrefs.SetInt("Death", 0);
        SceneManager.LoadScene(nextScene);
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void CloseGame()
    {
        Application.Quit();
    }


    private void Start()
    {
        myCanvas.gameObject.SetActive(false);
        target = GameObject.FindGameObjectWithTag("MainCamera");
        myPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.z);
    }

    private void OnCloseEnough()
    {
        Vector2 playerPos = new Vector2(target.transform.position.x, target.transform.position.z);
        if (System.Math.Abs(myPos.x - playerPos.x) <= ValidDistance && System.Math.Abs(myPos.y - playerPos.y) <= ValidDistance)
        {
            mybool = true;
        }
        else mybool = false;
    }

    private void Update()
    {
        OnCloseEnough();
        if (mybool == true)
            myCanvas.gameObject.SetActive(true);
        else
            myCanvas.gameObject.SetActive(false);
    }
}
