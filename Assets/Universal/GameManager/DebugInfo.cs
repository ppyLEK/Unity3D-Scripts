using UnityEngine;
using UnityEngine.UI;

public namespace ppyLEK.Debug
public class DebugInfo : MonoBehaviour
{
    public GameObject gameManager = GameObject.FindGameObjcetsWithTag("GameManager");
    private bool debug;
    //FPS
    [SerializeField] private Text fpsText;
    [SerializeField] private float hudRefreshRate = 1f;
    private float timer;

    //WorldPos
    [SerializeField] private Text posText;
    public GameObject playerRoot = GameObject.FindGameObjectsWithTag("PlayerRoot");

    void Start()
    {
        debug = gameManager.GetComponent<GameManagerMaster>().debug;
    }

    void Update()
    {
        if (debug)
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
        }
    }
}