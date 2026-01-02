using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 12f;
    public float mouseSensitivity = 2f;
    
    private Rigidbody rb;
    private Camera playerCamera;
    private float cameraRotationX = 0f;
    private bool firstPerson = true;
    
    private int coinsCollected = 0;
    private int totalCoins = 0;
    private int fallsCount = 0;
    private bool gameOver = false;
    


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        
        CreateCamera();
        
        Cursor.lockState = CursorLockMode.Locked;
        
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        Debug.Log("Всего монет на уровне: " + totalCoins);
    }
    
    void CreateCamera()
    {
        GameObject cameraObj = new GameObject("PlayerCamera");
        cameraObj.transform.parent = transform;
        
        playerCamera = cameraObj.AddComponent<Camera>();
        playerCamera.fieldOfView = 60f;
        
        if (GameObject.Find("Main Camera")) 
            Destroy(GameObject.Find("Main Camera"));
        
        SetCameraPosition();
    }
    
    void Update()
    {
        if (gameOver) return;
        
        CheckFall();
        
        if (Input.GetKeyDown(KeyCode.V))
        {
            SwitchCamera();
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCursor();
        }
        
        CameraControl();
    }
    
    void FixedUpdate()
    {
        if (gameOver) return;
        
        Movement();
    }
    
    void SwitchCamera()
    {
        firstPerson = !firstPerson;
        SetCameraPosition();
    }
    
    void SetCameraPosition()
    {
        if (firstPerson)
        {
            playerCamera.transform.localPosition = new Vector3(0, 1.7f, 0);
        }
        else
        {
            playerCamera.transform.localPosition = new Vector3(0, 2f, -5f);
        }
    }
    
    void CameraControl()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, mouseX, 0);
        
        if (firstPerson)
        {
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
            cameraRotationX -= mouseY;
            cameraRotationX = Mathf.Clamp(cameraRotationX, -90f, 90f);
            playerCamera.transform.localRotation = Quaternion.Euler(cameraRotationX, 0, 0);
        }
        else
        {
            playerCamera.transform.LookAt(transform.position + Vector3.up * 1f);
        }
    }
    
    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 direction = transform.forward * vertical + transform.right * horizontal;
        direction = direction.normalized * speed;
        
        Vector3 velocity = new Vector3(direction.x, rb.velocity.y, direction.z);
        rb.velocity = velocity;
    }
    
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
    }
    
    void CheckFall()
    {
        if (transform.position.y < -10f)
        {
            fallsCount++;
            Debug.Log("Упал! Падение №" + fallsCount);
            
            if (fallsCount >= 3)
            {
                GameOver();
                return;
            }
            
            Respawn();
        }
    }
    
    void Respawn()
    {
        transform.position = new Vector3(0, 2, 0);
        rb.velocity = Vector3.zero;
    }
    
    void GameOver()
    {
        gameOver = true;
        Debug.Log("ПРОИГРЫШ! Упал 3 раза!");
    }
    

    void WinGame()
    {
        gameOver = false;
        Debug.Log("ПОБЕДА! Все " + totalCoins + " монет собраны!");
    }
    
    public void AddCoin()
    {
        if (gameOver) return;
        
        coinsCollected++;
        Debug.Log("Монетка собрана! Всего: " + "/" + totalCoins);
        
        if (coinsCollected == totalCoins)
        {
            WinGame();
           
        }
    }
    
    void ToggleCursor()
    {
        Cursor.visible = !Cursor.visible;
        Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;
    }
}