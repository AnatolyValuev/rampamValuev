using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadPlayer : MonoBehaviour
{

    private const string MouseY = "Mouse Y";
    private Vector3 rotationDir;
    [SerializeField] private float angularSpeed = 100f;

    void Update()
    {
        transform.Rotate(rotationDir);
        rotationDir.x = Input.GetAxis(MouseY) * angularSpeed * -Time.deltaTime;
    }
}
