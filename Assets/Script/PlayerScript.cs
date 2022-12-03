using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    PlayerController controller;
    public AudioSource src;
    public AudioSource onHurt;
    public int movementSpeed;
    public Animator Anim;
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    float turnSpeed = 1;
    [SerializeField] bool isWalking = false;
    public GameObject dieMenu;
    [SerializeField] Rigidbody rb;
    BoxCollider m_collider;
    public Transform cam;

    public HealthBar healthBar;

    //health
    public float healthPlayer = 1000f;
    private float persenHp;

    public static PlayerScript playerScript;
    public ObjectPickUp objectPickUp;
    public ObjectableZombie objectableZombie;
    private float lastClick = 0;
    float time;
    float remainingTime;
    bool ak = false;
    bool ab = false;
    bool runPressed;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        healthBar.MaxHealth(healthPlayer);
        time = Time.time;
        ab = false;
        // Debug.Log("start " + healthPlayer);
    }

    void Awake()
    {
        controller = new PlayerController();
        controller.Enable();
        playerScript = this;
        controller.Land.run.performed += ctx => runPressed = ctx.ReadValueAsButton();
    }
    void FixedUpdate()
    {
        Vector2 move = controller.Land.Newaction.ReadValue<Vector2>();
        isWalking = true;
        playerMove();
        

        m_collider = GetComponent<BoxCollider>();
        // if (objectPickUp.isPickMagicItem == true)
        // {

        //     if (Input.GetKeyDown(KeyCode.Space))
        //     {
        //         m_collider.size = new Vector3(0.3f, 0.3f, 0.3f);
        //     }
        // }



        if (ak)
        {
            adDunyaUpdate();
        }
        else if (!ab && Input.GetButton("Jump") && objectPickUp.isPickMagicItem == true && objectableZombie.isScene4 == true)
        {
            adDunyaStart();
        }
        Debug.Log(remainingTime + " " + ak);
    }

    void playerMove()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(h, 0f, v).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float tragetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, tragetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            if (Input.GetKey(KeyCode.LeftShift) || runPressed) isWalking = false;
            turnSpeed = isWalking ? 0.1f : 1f;
            
            Vector3 moveDirection = Quaternion.Euler(0f, tragetAngle, 0f) * Vector3.forward * turnSpeed;
            Anim.SetFloat("speed", turnSpeed);


            Vector3 data = rb.velocity = moveDirection.normalized * movementSpeed * Time.deltaTime;
            rb.AddForce(data, ForceMode.VelocityChange);
        }
        else
        {
            Anim.SetFloat("speed", direction.magnitude);
            src.Play();
        }
    }

    //take Damage

    public void playerTakeDamage(float damage)
    {
        healthPlayer -= damage;

        healthBar.setHealth(healthPlayer);
        onHurt.Play();
        if (healthPlayer == 0)
        {
            Die();
            //Open Die Menus
            dieMenu.SetActive(true);
        }
        // Debug.Log("setelah" + healthPlayer);
    }

    public void Die()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        Destroy(gameObject, 3);
    }

    void adDunyaUpdate()
    {
        remainingTime = time + 10f - Time.time;
        objectPickUp.textJutsu.text = "AD Dunyaaaa";

        if (remainingTime <= 0)
        {
            ab = true;
            m_collider.size = new Vector3(0.1130839f, 0.2526225f, 0.08323526f);
            ak = false;
        }
        else
        {
            m_collider.size = new Vector3(0.3f, 0.3f, 0.3f);
        }
    }
    void adDunyaStart()
    {
        time = Time.time;
        ak = true;
        objectPickUp.textJutsu.text = "";
    }

}