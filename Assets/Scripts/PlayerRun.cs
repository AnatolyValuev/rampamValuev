using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Quest.Enemies
{
    public class PlayerRun : MonoBehaviour
    {
        [SerializeField] private float speed = 3f;
        [SerializeField] private float runSpeed = 5f;
        // [SerializeField] private float speedJump = 1f;
        [SerializeField] private float angularSpeed = 100f;

        [SerializeField] private GameObject _mine;
        [SerializeField] private Transform _mineSpawnPlace;
        [SerializeField] private int _damageMine;



        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private const string Running = "Running";
        private const string Jump = "Jump";
        private const string MouseX = "Mouse X";



        [SerializeField] private GameObject fonarik;
        [SerializeField] private int healthFonarik = 10;



        private Vector3 direction;
        private bool isRunning;
        private Vector3 rotationDir;




        
        void Update()
        {
            direction.x = Input.GetAxis(Horizontal);
            direction.z = Input.GetAxis(Vertical);
            direction.y = Input.GetAxis(Jump);




            isRunning = Input.GetButton(Running);

            transform.Translate(direction * ((isRunning ? runSpeed : speed) * Time.deltaTime));
            transform. Rotate(rotationDir);

            rotationDir.y = Input.GetAxis(MouseX) * angularSpeed * Time.deltaTime;



            if (Input.GetKey(KeyCode.Mouse0))
            {
                fonarik.SetActive(true);
                healthFonarik -= 1;





            }
            else
            {
                fonarik.SetActive(false);

            }

            if (Input.GetKey(KeyCode.Mouse1))
            {
                Instantiate(_mine, _mineSpawnPlace.position, _mineSpawnPlace.rotation);
                
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
        }




    }

    
}