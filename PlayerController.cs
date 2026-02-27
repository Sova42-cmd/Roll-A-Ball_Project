// MonoBehaviour/Vector3/GameObject basically for all classes
using UnityEngine;
// for onMove function
using UnityEngine.InputSystem;
// for text
using TMPro;

// defines code, allows idk koroche nado
public class PlayerController : MonoBehaviour
{
    
    // visible in Inspector
    public float speed = 1;
    public TextMeshProUGUI countText;
    public Transform pickUpObjectParent;
    public GameManagerScript gameManager;
    public GameObject enemyObject;
    
    // NOT visible in Inspector
    private Rigidbody _rb;
    
    private int _count;
    private int _maxCoin;
    
    private float _movementX;
    private float _movementY;
    
    
    // runs once when game's loaded
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _maxCoin = pickUpObjectParent.childCount; //looks at that parent object and counts how many items are inside.
        _count = _maxCoin; //Sets starting score to the total number of items found.
       
        SetCountText(_count);
    }
    
    
    // Runs every frame
    private void Update()
    {
        var movement = new Vector3(_movementX, 0, _movementY);
        _rb.AddForce(movement * speed); // pushes the ball in the direction of input multiplied by speed.
    }
    
    //triggered by the Input System whenever move (press WASD)
    private void OnMove(InputValue movementValue)
    {
        var movementVector = movementValue.Get<Vector2>(); 
        
        _movementX = movementVector.x;
        _movementY = movementVector.y;
    }
    
    
    //This happens when hit something solid.
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Enemy")) //Checks if the thing you hit has the "Enemy" label.
        {
            return;
        }
        
        gameObject.SetActive(false); // Instead of destroying just set's inactive
        gameManager.GameOver(); // shows game over UI
    }

    
    //also checks when hit something, but doesn't stop you
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("pickUpCube")) //checks if the item is collectible
        {
            return;
        }
        _count--; //minus from how many there were in parents object
        SetCountText(_count);
        Destroy(other.gameObject); //then removes from the world
    }
    
    

    private void SetCountText(int score) //updates what player sees on screen
    {
        if (_count > 0) //check ete collectibles mnacel a shows how many
        {
            countText.text = "Dice Remaining: " + score.ToString();
        }
        else //ete chka this text
        {
           gameManager.GameWin();
           enemyObject.SetActive(false);
        }
    }
}