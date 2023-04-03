using UnityEngine;
using UnityEngine.UI;

public namespace ppyLEK.Debug
public class DebugInfo : MonoBehaviour
{
    private GameObject gameManager;
    private GameObject playerRoot;
    private bool debugEnabled;

    [SerializeField] private Text fpsText;
    [SerializeField] private float hudRefreshRate = 1f;

    [SerializeField] private Text posText;
    [SerializeField] private Text networkStatus;
    
    private float timer;
    private bool networkBool;

    
    

    void Start()
    {
        gameManager = GameObject.FindGameObjectsWithTag("GameManager");
        playerRoot = GameObject.FindGameObjectsWithTag("PlayerRoot");

        debugEnabled = gameManager.GetComponent<GameManagerMaster>().debugBool;
        if (!debugEnabled)
            gameObject.SetActive(false); 
    }

    void FixedUpdate()
    {
        if (Time.unscaledTime > timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            fpsText.text = "FPS: " + fps;
            timer = Time.unscaledTime + hudRefreshRate;
        }

        posText.text = "Player pos: X:"
            + playerRoot.transform.position.x.toString() + " Y:"
            + playerRoot.transform.position.y.toString() + " Z:"
            + playerRoot.transform.position.z.toString();

        if (Application.internetReachability == NetworkReachability.NotReachable) networkBool = false;
        else networkBool = true;

        if (networkBool) networkStatus.text = "Network unreachable! Check connection.";
        else networkStatus.text = "Network reachable!";
    }
}