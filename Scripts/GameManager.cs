using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public Player player_prefab;
    public Player player;



    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    public void StartGame()
    {
        player = Instantiate(player_prefab);
        Camera.main.GetComponent<CameraMovement>().player = player.GetComponent<Rigidbody2D>();
    }





    private void OnLevelWasLoaded(int level)
    {
        StartGame();
    }





}
