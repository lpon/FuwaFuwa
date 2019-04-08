using UnityEngine;

public class MainCameraController : MonoBehaviour
{

    GameObject mainCharacter;

    public float offset;

    void Start()
    {
        mainCharacter = GameObject.Find("Girl");
    }


    void Update()
    {
        float characterYPosition = mainCharacter.transform.position.y;

        // Prevent the camera following the character below the starting point 
        // and above the ending point
        if (characterYPosition > -59f && characterYPosition < 60.5f)
        {
            // Main Camera will follow the mainCharacter only along the y axis
            transform.position = new Vector3(
                                                x: transform.position.x,
                                                y: characterYPosition - offset,
                                                z: transform.position.z
                                            );
        }
    }
}
