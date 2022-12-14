using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Quest.Enemies
{
    public class PlayerRun : MonoBehaviour
    {
        [SerializeField] private float speed = 3f;
        [SerializeField] private float runSpeed = 5f;
         [SerializeField] private float speedJump = 1f;
        [SerializeField] private float angularSpeed = 100f;

        [SerializeField] private GameObject _mine;
        [SerializeField] private Transform _mineSpawnPlace;
        [SerializeField] private int _damageMine;
       // [SerializeField] private float timer;
        //[SerializeField] private ParticleSystem boom;

        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private const string Running = "Running";
        //private const string Jump = "Jump";
        private const string MouseX = "Mouse X";
        //private const string MouseY = "Mouse Y";
        private const string Ground = "Ground";

       
         


        [SerializeField] private GameObject fonarik;
        [SerializeField] private int healthFonarik = 10000;
        [SerializeField] private TextMeshProUGUI textFonarik;

    



        private Vector3 direction;
        private bool isRunning;
        private Vector3 rotationDir;
       // [SerializeField] private float time;

        private bool isGround; // ??????
        private Rigidbody rb; // ??????




        private void Awake()
        {
            rb = GetComponent<Rigidbody>(); // ??????
        }


        void Update()
        {

           // timer += Time.deltaTime;
            direction.x = Input.GetAxis(Horizontal);
            direction.z = Input.GetAxis(Vertical);
            // direction.y = Input.GetAxis(Jump);

            textFonarik.text = "????? ????????: " + healthFonarik.ToString(); // ????? ?????? ?????? ????????.



            isRunning = Input.GetButton(Running);

            transform.Translate(direction * ((isRunning ? runSpeed : speed) * Time.deltaTime));
            transform. Rotate(rotationDir);

            rotationDir.y = Input.GetAxis(MouseX) * angularSpeed * Time.deltaTime;
            //rotationDir.x = Input.GetAxis(MouseY) * angularSpeed * -Time.deltaTime;

            

            if (Input.GetKey(KeyCode.Mouse0) && healthFonarik > 0)
            {
                fonarik.SetActive(true);
                healthFonarik -= 1;





            }
            else
            {
                fonarik.SetActive(false);

            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                
                Instantiate(_mine, _mineSpawnPlace.position, _mineSpawnPlace.rotation);
               
             //   if (timer >= 1)
             //   {
             //       _mine.SetActive(false);
            //        boom.Play();
            //        timer = 0;

               // }
                
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGround)
            {
                rb.AddForce(speedJump * transform.up, ForceMode.Impulse); // ??????
            }
           
           



        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                var enemy = other.GetComponent<HealthMan>();
                enemy.Hit(_damageMine);
                Destroy(gameObject);

            }

              if (other.CompareTag("Batary"))
                {
                healthFonarik += 5000;
                }

        }



        private void OnCollisionEnter(Collision collision)
        {
            isGround = collision.gameObject.CompareTag(Ground);  // ??????
        }
        private void OnCollisionExit(Collision other)
        {
            isGround = !other.gameObject.CompareTag(Ground);   // ??????
        }

    }

    
}