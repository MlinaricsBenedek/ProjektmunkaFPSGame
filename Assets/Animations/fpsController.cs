using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fpsController : MonoBehaviour
{
    private Rigidbody rb;

    public Camera playerCamera;
  //  public Bullet bullet;
    public Animator animator;
    public Transform GunPosisition;
    private bool playerCanShoot = true;
    public float fov = 60f;
    public bool invertCamera = false;
    public bool cameraCanMove = true;
    public float mouseSensitivity = 2f;
    public float maxLookAngle = 50f;
    public bool canShootBullet;
    // Crosshair
    public bool lockCursor = true;
    // Internal Variables
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private Image crosshairObject;

    public GameObject aimTarget;

    public bool enableZoom = true;
    public bool holdToZoom = false;
    public KeyCode zoomKey = KeyCode.Mouse1;
    public float zoomFOV = 30f;
    public float zoomStepTime = 5f;

    // Internal Variables
    private bool isZoomed = false;
    public bool playerCanMove = true;
    public float walkSpeed = 5f;
    public float maxVelocityChange = 5.0f;

    // Internal Variables
   // private bool isWalking = false;
    // Internal Variables
    private Vector3 originalScale;
    float zDinstance = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        // Set internal variables
        playerCamera.fieldOfView = fov;
        originalScale = transform.localScale;
    }

    void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    float camRotation;

    private void Update()
    {
        HandleCamera();
        Shoot();
    }

    void FixedUpdate()
    {
        Move();
    }
    private void HandleCamera()
    {
        // Control camera movement
        if (cameraCanMove)
        {
            yaw = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity;

            if (!invertCamera)
            {
                pitch -= mouseSensitivity * Input.GetAxis("Mouse Y");
            }
            else
            {
                // Inverted Y
                pitch += mouseSensitivity * Input.GetAxis("Mouse Y");
            }
            pitch = Mathf.Clamp(pitch, -maxLookAngle, maxLookAngle);

            transform.localEulerAngles = new Vector3(0, yaw, 0);
            playerCamera.transform.localEulerAngles = new Vector3(pitch, 0, 0);
            Vector3 mouseScreenPosition = Input.mousePosition;
            mouseScreenPosition.z = zDinstance; 
            Vector3 mouseWorldPosition = playerCamera.ScreenToWorldPoint(mouseScreenPosition);


            aimTarget.transform.position = new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, mouseWorldPosition.z);
            aimTarget.transform.localEulerAngles = playerCamera.transform.localEulerAngles;
        }
    }
    private void Move()
    {
        if (playerCanMove)
        {

            // Calculate how fast we should be moving
            Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            // Checks if player is walking and isGrounded
            // Will allow head bob
            if (targetVelocity.x != 0 || targetVelocity.z != 0)
            {           
                animator.SetBool("IsMoving", false);
            }
            else
            {
                animator.SetBool("IsMoving", true);
            }
            targetVelocity = transform.TransformDirection(targetVelocity) * walkSpeed;
            Vector3 velocity = rb.velocity;
            Vector3 velocityChange = (targetVelocity - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;

            rb.AddForce(velocityChange, ForceMode.VelocityChange);
        }
    }
    private void Shoot()
    {
        if (Input.GetMouseButton(0) && playerCanShoot)
        {
            playerCanShoot = false;

            animator.SetBool("IsShooting", true);
            canShootBullet = true;
            StartCoroutine(WaitForShoot());
        }
    }
    IEnumerator WaitForShoot()
    {
        yield return new WaitForSeconds(1f);
        //bullet.shootBullet(GunPosisition, canShootBullet);
        canShootBullet = false;
        animator.SetBool("IsShooting", false);
        //Handle the weapon reloading time
        yield return new WaitForSeconds(3f);
        playerCanShoot = true;
    }
}
