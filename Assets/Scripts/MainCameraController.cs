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
        // Main Camera will follow the mainCharacter only along the y axis
        transform.position = new Vector3(
                                            x: transform.position.x,
                                            y: mainCharacter.transform.position.y - offset,
                                            z: transform.position.z
                                        );
    }
}
