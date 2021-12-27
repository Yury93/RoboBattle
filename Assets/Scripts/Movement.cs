using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private float speed;
    private float gravity = -9.8f;
    [SerializeField] private Camera camera;
    [SerializeField] private GameObject particleExplosion;
    [SerializeField] private ParticleSystem particleFire;
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioSource audioExplosive;
    [SerializeField] private Joystick joystickMove;
    [SerializeField]private float timer, startTimer;
    private float deltaX, deltaZ;
    void Start()
    {
       startTimer = timer;
        characterController = GetComponentInParent<CharacterController>();
    }
    void Update()
    {
         deltaX = Input.GetAxis("Horizontal") * speed;
         deltaZ = Input.GetAxis("Vertical") * speed;
        AndroidMove();

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        characterController.Move(movement);
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Fire();
            timer = startTimer;
        }
    }
    private void AndroidMove()
    {
        if (joystickMove.Direction.x > 0)
        {
            deltaX = 1 * speed;
        }
        else if (joystickMove.Direction.x < 0)
        {
            deltaX = -1 * speed;
        }
        else
        {
            deltaX = 0;
        }

        if (joystickMove.Direction.y > 0)
        {
            deltaZ = 1 * speed;
        }
        else if (joystickMove.Direction.y < 0)
        {
            deltaZ = -1 * speed;
        }
        else
        {
            deltaZ = 0;
        }
    }
   private void Fire()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
       
            particleFire.Play();
            audio.Play();
            Vector3 point = new Vector3(
            camera.pixelWidth / 2, camera.pixelHeight / 2, 0);
            Ray ray = camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

                if(hit.collider.tag == "Enemy")
                {
                    StartCoroutine(Bullet(hit.point));
                    audioExplosive.Play();
                    GuiPlayer.instance.ScoreUpdate();
                    Destroy(hit.collider.gameObject);
                }
            
        }
    }
    IEnumerator Bullet(Vector3 pos)
    {
        GameObject sphere = Instantiate(particleExplosion, pos,Quaternion.identity);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(5);
        Destroy(sphere);
    }
}
