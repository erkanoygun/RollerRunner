using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerController : MonoBehaviour
{
    private float speed;
    Vector3 rot;
    private Touch _touch;
    private Quaternion _rotationY;
    [SerializeField] private float _rotateSpeed = 0.2f;

    void Update()
    {

        if (Input.touchCount > 0)
        {

            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Moved)
            {
                _rotationY = Quaternion.Euler(0f, 0f, -_touch.deltaPosition.x * _rotateSpeed);
                transform.rotation = _rotationY * transform.rotation;

            }
        }

    }
}
