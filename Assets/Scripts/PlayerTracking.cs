using UnityEngine;

public class PlayerTracking : MonoBehaviour
{
    public GameObject Player;
    public GameManager myGameManager;
    public SpriteRenderer Renderer;
    public GameObject bottom;
    private bool canTrack = false;
    private void Start()
    {
        Invoke("MyDelayedMethod", 1.5f);
    }

    void MyDelayedMethod()
    {
        Player = myGameManager.player;
        canTrack = true;
    }

    void Update()
    {
        if(canTrack)
            CalculateLayeringOnPlayerPosition();
    }

    public void CalculateLayeringOnPlayerPosition()
    {
        if (Player.transform.position.y > bottom.transform.position.y + 2)
        {
            Renderer.sortingOrder = 15;
        } else
            Renderer.sortingOrder = 10;


    }
}
