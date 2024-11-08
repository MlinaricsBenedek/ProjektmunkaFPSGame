using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public BulletController bullet;
    public Animator animator;
    public Transform GunPosisition;
    public Camera playerCamera;
    PhotonView PV;
    public GameObject aimTarget;
    public int playerHeal;
    private bool playerCanShoot = true;
    public float fov = 60f;
    public bool cameraCanMove = true;
    public float mouseSensitivity = 2f;
    public float maxLookAngle = 50f;
    public bool canShootBullet;
    public bool lockCursor = true;
    // Internal Variables
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public bool enableZoom = true;
    public bool holdToZoom = false;
    public KeyCode zoomKey = KeyCode.Mouse1;
    public float zoomFOV = 30f;
    public float zoomStepTime = 5f;

    public bool playerCanMove = true;
    public float walkSpeed = 5f;
    public float maxVelocityChange = 5.0f;
    float zDinstance = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();
        // Set internal variables
        playerCamera.fieldOfView = fov;
    }
    void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (!PV.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
        }
        playerHeal = 100;
    }

    float camRotation;

    private void Update()
    {
        if (!PV.IsMine) return;
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


            pitch -= mouseSensitivity * Input.GetAxis("Mouse Y");


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
        if (!PV.IsMine) return;
        else
        {
            if (playerCanMove)
            {
                Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                if (targetVelocity.x != 0 || targetVelocity.z != 0)
                {
                    animator.SetBool("IsMoving", true);
                }
                else
                {
                    animator.SetBool("IsMoving",false);
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
    public void setHeal(int Damage)
    {
        if (!PV.IsMine) { return; }
        if (playerHeal > Damage)
        {
            playerHeal -= Damage;
        }
        else
        {
            playerHeal = 0;
            //ide kell megimplementálni az animációt. 
            Destroy(gameObject);
        }
    }
    IEnumerator WaitForShoot()
    {
        yield return new WaitForSeconds(1f);
        bullet.shootBullet(canShootBullet);
        canShootBullet = false;
        animator.SetBool("IsShooting", false);
        //Handle the weapon reloading time
        yield return new WaitForSeconds(3f);
        playerCanShoot = true;
    }
}
