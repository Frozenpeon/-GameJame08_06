using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private bool canMove = true;

    // Update is called once per frame
    void Update()
    {
        GetKeyboardInput();
    }
    
    public void SetCanMove(bool value)
    {
        canMove = value;
    }

    private void GetKeyboardInput()
    {
        if (!canMove) return;
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        print(horizontalInput);
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}
