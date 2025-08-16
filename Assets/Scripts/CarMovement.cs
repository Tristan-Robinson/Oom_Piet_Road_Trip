using UnityEngine;
using UnityEngine.UI; // For UI Button functionality

public class CarMovement : MonoBehaviour
{
    public float speed = 10f; // Speed at which the car moves forward
    public float horizontalSpeed = 5f; // Speed at which the car moves left/right
    public float xBound = 5f; // Boundary for how far left/right the car can move
    private float movementX; // Horizontal movement input

    public Button leftButton;  // Reference to the Left Button
    public Button rightButton; // Reference to the Right Button

    private void Start()
    {
        // Assign Button listeners for mobile controls
        if (leftButton != null)
            leftButton.onClick.AddListener(MoveLeft);
        if (rightButton != null)
            rightButton.onClick.AddListener(MoveRight);
    }

    void Update()
    {
        // Move the car forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Get player input for left/right movement (A/D keys or buttons)
        movementX = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow keys

        // Move the car left and right, constrained by xBound
        float newXPosition = Mathf.Clamp(transform.position.x + movementX * horizontalSpeed * Time.deltaTime, -xBound, xBound);
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
    }

    // Function to move the car left using button press
    public void MoveLeft()
    {
        // Only allow movement within bounds
        float newXPosition = Mathf.Clamp(transform.position.x - horizontalSpeed * Time.deltaTime, -xBound, xBound);
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
    }

    // Function to move the car right using button press
    public void MoveRight()
    {
        // Only allow movement within bounds
        float newXPosition = Mathf.Clamp(transform.position.x + horizontalSpeed * Time.deltaTime, -xBound, xBound);
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
    }
}
