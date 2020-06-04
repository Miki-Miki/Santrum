using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Dash))]

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 4.0f;
    private float moveInput;

    [Header("Jump")]
    public float jumpHeight = 5.0f;
    public float jumpTime;
    private bool isJumping;
    private float jumpTimeCounter;

    [HideInInspector]
    public bool hasDash;

    private bool isDashing;

    [HideInInspector]
    public bool isGrounded;

    [Header("Ground check")]
    public Transform feetPosition;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Rigidbody2D rb2d;
    string facingDirection = "";

    private Animator anim;

    [HideInInspector]
    public bool dashFull;

    [Header("Timer")]
    [Range(0.01f, 1.0f)] public float startingOffset;
    private TimeMaster timeMaster;

    private CheckpointMaster checkpointMaster;
    private KillPlayer deadlyObjects;
    //private bool hasPlayerRespawned = false;

    private Shake cameraShaker;

    private ResetLevel resetLevel;
    
    private GameObject gameOverScreen;

    private Dash dash;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        rb2d.isKinematic = false;
        
        anim = gameObject.GetComponent<Animator>();

        if(GameObject.FindGameObjectWithTag("cpMaster") != null) {
            checkpointMaster = GameObject.FindGameObjectWithTag("cpMaster").GetComponent<CheckpointMaster>();
        }

        if(GameObject.FindGameObjectWithTag("DeathBed") != null) {
            deadlyObjects = GameObject.FindGameObjectWithTag("DeathBed").GetComponent<KillPlayer>();
        }

        if(GameObject.FindGameObjectWithTag("CameraShaker") != null) {
            cameraShaker = GameObject.FindGameObjectWithTag("CameraShaker").GetComponent<Shake>();
        }

        if(GameObject.FindGameObjectWithTag("TimeMaster") != null) {
            timeMaster = GameObject.FindGameObjectWithTag("TimeMaster").GetComponent<TimeMaster>();
        }

        if(GameObject.FindGameObjectWithTag("LevelReset") != null) {
            resetLevel = GameObject.FindGameObjectWithTag("LevelReset").GetComponent<ResetLevel>();
        }

        if(GameObject.FindGameObjectWithTag("GameOverScreen") != null) {
            gameOverScreen = GameObject.FindGameObjectWithTag("GameOverScreen");
            gameOverScreen.SetActive(false);
        }

        dash = gameObject.GetComponent<Dash>();
        
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * movementSpeed * Time.deltaTime;
    }

    void Update()
    {

        //    Jump
        // -----------
        // Checking if player grounded by OverlapCircle positioned at player's feet
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, whatIsGround);

        // Transforming player eulerAngles as for the sprite to face the direction of movement
        if (facingDirection == "RIGHT")
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (facingDirection == "LEFT")
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        // Jumping
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb2d.velocity = Vector2.up * jumpHeight;
        }

        // If the space bar is held down the jump is longer by how long we hold down < jumpTimeCounter
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb2d.velocity = Vector2.up * jumpHeight;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        // -----------
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            GetFacingDirection();
        }


        isDashing = dash.isDashing;
        //   Animation
        // -------------
        // Player
        anim.SetFloat("Speed", Mathf.Abs(moveInput));
        anim.SetBool("IsJumping", !isGrounded);
        anim.SetBool("IsDashing", isDashing);

        // Check if player dead
        if(deadlyObjects != null && deadlyObjects.isPlayerDead) {
            RespawnPlayer();
            cameraShaker.camShake();
            timeMaster.CutTimeInHalf();
            timeMaster.IncrementNumOfResets();
            Debug.Log("Player dead?");
        }

        //  Timer
        // --------
        if((Input.GetAxis("Horizontal") > Mathf.Abs(startingOffset) 
            || Input.GetAxis("Vertical") > Mathf.Abs(startingOffset))
            && timeMaster != null) {
                timeMaster.isStarted = true;
        }

        if(timeMaster != null && timeMaster.isTimeOver()) {
            StartCoroutine(GameOver());
        }
    }

    // Loads first scene 
    IEnumerator GameOver() {
        this.enabled = false;
        gameOverScreen.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

    private string GetFacingDirection()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            facingDirection = "LEFT";
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            facingDirection = "RIGHT";
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            facingDirection = "DOWN";
        }

        return facingDirection;
    }

    public void RespawnPlayer() {
        transform.position = checkpointMaster.lastCheckpointPos;
        //hasPlayerRespawned = true;
    }

}
