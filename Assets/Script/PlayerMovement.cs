using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5;
    [SerializeField] private float rotationSpeed = 500;
    [SerializeField] private List<Transform> boxes = new List<Transform>();
    [SerializeField] private Transform boxHandPlace;

    Animator anim;

    private Touch _touch;

    private Vector3 _touchDown;
    private Vector3 _touchUp;

    private bool _dragStarted;
    private bool _isMoving;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        boxes.Add(boxHandPlace);
    }

    void Update()
    {
        if (anim)
        {
            anim.SetBool("isMoving", _isMoving);
        }
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Began)
            {
                _dragStarted = true;
                _isMoving = true;
                _touchUp = _touch.position;
                _touchDown = _touch.position;
            }
        }
        if (_dragStarted)
        {
            if (_touch.phase == TouchPhase.Moved)
            {
                _touchDown = _touch.position;
            }

            if (_touch.phase == TouchPhase.Ended)
            {
                _touchDown = _touch.position;
                _isMoving = false;
                _dragStarted = false;
            }
            gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, CalculateRotation(), rotationSpeed * Time.deltaTime);
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        }
        if (Physics.Raycast(transform.position, transform.forward, out var hit, 1f))
        {
            if (hit.collider.CompareTag("boxCollectPoint") && boxes.Count < 4){
                if(hit.collider.transform.childCount > 2) {
                    var box = hit.collider.transform.GetChild(1);
                    boxes.Add(box);
                    box.parent = null;
                }
                
            }
        }
    }

    public bool IsMoving()
    {
        return _isMoving;
    }

    Quaternion CalculateRotation()
    {
        Quaternion temp = Quaternion.LookRotation(CalculateDirection(), Vector3.up);
        return temp;
    }
    Vector3 CalculateDirection()
    {
        Vector3 temp = (_touchDown - _touchUp).normalized;
        temp.z = temp.y;
        temp.y = 0;
        return temp;
    }
}