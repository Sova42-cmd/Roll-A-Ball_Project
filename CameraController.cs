using UnityEngine;

// gemini's explanation ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

// This script is designed to give you the movement of a parent-child relationship, but without the rotation.

// By using _offset, the camera says: "I will follow your position, but I don't care which way you are facing or if you are spinning."

// If you just write transform.position = player.transform.position;, the camera will be inside the player.
// You won't see the character; you'll see the inside of their head!

//The _offset is just a fancy way of saying "Stay 10 feet back so I can actually see what I'm playing."

// gemini's explanation ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

public class CameraController : MonoBehaviour
{

    public GameObject player;
    private Vector3 _offset; //offset is smth like (0, 5, -10) keep this lenght from player ig?
    
    private void Start()
    {
        _offset = transform.position - player.transform.position; //
    }

    private void LateUpdate() // LATEupdate runs after all other updates, but didn't notice any difference in game
    {
        transform.position = player.transform.position + _offset;
    }
}
// this rude messages must be gone!
