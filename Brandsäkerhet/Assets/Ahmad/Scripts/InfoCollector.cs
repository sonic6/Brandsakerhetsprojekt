using UnityEngine;

public class InfoCollector : MonoBehaviour
{
    public static bool fireCondition;
    public static bool fireIncreased;
    public static bool doorsCondition;
    public static bool windowCondition;

    private void Awake()
    {
        fireCondition = true;
        fireIncreased = false;
        doorsCondition = false;
        windowCondition = false;
    }
    
}
