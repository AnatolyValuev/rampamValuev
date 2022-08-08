using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest.Enemies
{

    public class ControlDoor : ControlObjects
    {
        [SerializeField] private Vector3 openedDoor = new Vector3(0f, 90f, 0f);
        [SerializeField] private Vector3 closedDoor = new Vector3(0f, 0f, 0f);
        [SerializeField] private Transform door;
        [SerializeField] private float speed = 1f;

        private const float Delta = 5f;
        private Quaternion openedDoorQ;
        private Quaternion closedDoorQ;
        public override void Activate()
        {
            StopAllCoroutines();
            StartCoroutine(OpenDoor());
            // animator.SetBool(" имя буливой переменной которая создана в аниматоре ", true) - включить через анимацию и буливой переменной 
        }

        private void Awake()
        {
            openedDoorQ = Quaternion.Euler(openedDoor);
            closedDoorQ = Quaternion.Euler(closedDoor);
        }

        private IEnumerator OpenDoor()
        {
            while (Quaternion.Angle(door.rotation, openedDoorQ) > Delta)
            {
                door.rotation = Quaternion.Slerp(door.rotation, openedDoorQ, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            yield return null;
        }
        public override void Deactivate()
        {
            StopAllCoroutines();
            StartCoroutine(CloseDoor());
         }
        private IEnumerator CloseDoor()
        {
            while (Quaternion.Angle(door.rotation, closedDoorQ) > Delta)
            {
                door.rotation = Quaternion.Slerp(door.rotation, closedDoorQ, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            yield return null;
        }

    }
}