using UnityEngine;
using UnityEngine.UI;  // For UI Button functionality

public class CarMovement : MonoBehaviour
{
    public float speed = 10f; // Speed at which the car moves forward
    public float horizontalSpeed = 5f; // Speed at which the car moves left/right
    public float[] lanePositions; // Array to store X positions for each lane
    private int currentLane = 1; // Starts in the middle lane (index 1)
    public Button leftButton;  // Reference to the Left Button
    public Button rightButton; // Reference to the Right Button

    void Start()
    {
        // Assign Button listeners for lane changes
        leftButton.onClick.AddListener(SnapLeft);
        rightButton.onClick.AddListener(SnapRight);
    }

    void Update()
    {
        // Move the car forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Snap the car to the selected lane position
        float targetX = lanePositions[currentLane];
        float currentX = transform.position.x;
        transform.position = new Vector3(Mathf.Lerp(currentX, targetX, Time.deltaTime * horizontalSpeed), transform.position.y, transform.position.z);
    }

    // Function to snap the car to the left lane
    void SnapLeft()
    {
        if (currentLane > 0)
        {
            currentLane--; // Move to the left lane
        }
    }

    // Function to snap the car to the right lane
    void SnapRight()
    {
        if (currentLane < lanePositions.Length - 1)
        {
            currentLane++; // Move to the right lane
        }
    }
}