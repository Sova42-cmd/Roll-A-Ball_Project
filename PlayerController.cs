using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    
    private Rigidbody _rb;
    private int _count;
    private float _movementX;
    private float _movementY;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _count = 0;
        
        SetCountText();
        winTextObject.SetActive(false);
    }

    private void OnMove(InputValue movementValue)
    {
        var movementVector = movementValue.Get<Vector2>(); 
        
        _movementX = movementVector.x;
        _movementY = movementVector.y;
    }

    private void SetCountText()
    {
        countText.text = "Count: " + _count.ToString();
        if (_count >= 24)
        {
            winTextObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        var movement = new Vector3(_movementX, 0.0f, _movementY); 
        
        _rb.AddForce(movement * speed); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Enemy")) 
        {
            return;
        }
        ShowGameOverUI();
        Destroy(gameObject);
    }

    private void ShowGameOverUI()
    {
        winTextObject.gameObject.SetActive(true);
        winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("pickUpCube"))
            return;

        other.gameObject.SetActive(false);
        _count = _count + 1;
        
        SetCountText();
    }
}