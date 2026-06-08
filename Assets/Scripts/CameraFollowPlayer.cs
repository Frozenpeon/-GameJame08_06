using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            transform.position = Player.transform.position - new Vector3(0, 0 , 10);
        }
    }
}
