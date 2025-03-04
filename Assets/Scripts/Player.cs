using UnityEngine;

public class Player : MonoBehaviour
{
    private const int MOVEMENT_SPEED = 35;

    [SerializeField] private Transform _body;
    private Transform _transform;
    private Camera _cameraMain;
    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _cameraMain = Camera.main;
    }
    private void Update()
    {
        Move(GetPosition());
    }
    private Vector2 GetPosition()
    {
        return _cameraMain.ScreenToWorldPoint(Input.mousePosition);
    }
    private void Move(Vector3 direction)
    {
        var delta = direction - _transform.position;
        if (delta.sqrMagnitude > 1 && Mathf.Sign(delta.x) != Mathf.Sign(_body.localScale.x)) Flip();
        _transform.position += delta * MOVEMENT_SPEED * Time.deltaTime;
    }
    private void Flip()
    {
        _body.localScale = new Vector3(_body.localScale.x * -1,_body.localScale.y);
    }
    
}
