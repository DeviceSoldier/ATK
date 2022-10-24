using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseCController : MonoBehaviour
{
    private enum DragonState
    {
        MoveLeft,
        MoveRight,
        Come,
        Attack,
        Leave,
    }

    [SerializeField] private float maxRadius = 200f;
    [SerializeField] private float minRadius = 10f;
    [SerializeField] private float speed = 100f;
    [SerializeField] private float maxTheta = Mathf.PI / 2f; // rad
    [SerializeField] private Vector2 idleTimeRange;
    [SerializeField] private float heightOffset = 2f;
    private float _angleSpeed;
    private float _radius;
    private StateMachine<DragonState> _stateMachine = new StateMachine<DragonState>();
    private Vector3 _origin;
    private Transform _playerTransform;
    private float _theta = 0f;
    private Animator _animator;
    private bool _goRight;
    private float _idleTime;
    private float _timer = 0f;
    private bool _isAnimationOver = false;
    private float _heightOffset;

    public void AnimationOver()
    {
        _isAnimationOver = true;
    }

    private void UpdatePosition(float radius, float theta)
    {
        float x = Mathf.Sin(theta);
        float y = Mathf.Cos(theta);
        Vector3 offset = new Vector3(x, 0f, y) * radius;
        offset.y = _heightOffset;
        var newPos = _origin + _playerTransform.TransformVector(offset);
        transform.position = newPos;
    }

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _playerTransform = FindObjectOfType<PlayerGage>().transform;
        _origin = _playerTransform.position;
        _angleSpeed = speed / maxRadius; // rad
        _radius = maxRadius;
        _idleTime = Random.Range(idleTimeRange.x, idleTimeRange.y);
        _heightOffset = heightOffset;
        
        _stateMachine.AddNode(DragonState.MoveLeft, () =>
        {
            _theta -= _angleSpeed * Time.deltaTime;
            UpdatePosition(_radius,_theta);
        }, () =>
        {
            Debug.Log("Enter MoveLeft");
            _goRight = false;
        }, () =>
        {
            
        });
        
        _stateMachine.AddNode(DragonState.MoveRight, () =>
        {
            _theta += _angleSpeed * Time.deltaTime;
            UpdatePosition(_radius,_theta);
        }, () =>
        {
            Debug.Log("Enter MoveRight");
            _goRight = true;
        }, () =>
        {
            
        });
        
        _stateMachine.AddNode(DragonState.Come, () =>
        {
            _radius -= speed * Time.deltaTime;
            _heightOffset = Mathf.Lerp(heightOffset, 0f, _timer / (maxRadius - minRadius) * speed);
            UpdatePosition(_radius,_theta);
        }, () =>
        {
            Debug.Log("Enter Come");
            _timer = 0f;
        }, () =>
        {
            if (_radius < minRadius)
                _radius = minRadius;
            UpdatePosition(_radius,_theta);
        });
        
        _stateMachine.AddNode(DragonState.Attack, () =>
        {
            
        }, () =>
        {
            Debug.Log("Enter Attack");
            
            _animator.SetTrigger(Random.Range(0f,1f)<0.5f?"Attack1":"Attack2");
        }, () =>
        {
            
        });
        
        _stateMachine.AddNode(DragonState.Leave, () =>
        {
            _radius += speed * Time.deltaTime;
            _heightOffset = Mathf.Lerp(0f,heightOffset,  _timer / (maxRadius - minRadius) * speed);
            UpdatePosition(_radius,_theta);
        }, () =>
        {
            Debug.Log("Enter Leave");
            _isAnimationOver = false;
            _timer = 0f;
        }, () =>
        {
            _timer = 0f;
            _idleTime = Random.Range(idleTimeRange.x, idleTimeRange.y);
            
            if (_radius >maxRadius)
                _radius = maxRadius;
        });
        
        _stateMachine.AddEdge(DragonState.MoveLeft,DragonState.MoveRight,()=>_theta<=-maxTheta);
        _stateMachine.AddEdge(DragonState.MoveRight,DragonState.MoveLeft,()=>_theta>=maxTheta);
        
        _stateMachine.AddEdge(DragonState.MoveRight,DragonState.Come,()=>_timer>=_idleTime);
        _stateMachine.AddEdge(DragonState.MoveLeft,DragonState.Come,()=>_timer>=_idleTime);
        _stateMachine.AddEdge(DragonState.Come,DragonState.Attack,()=>_radius<=minRadius);
        
        _stateMachine.AddEdge(DragonState.Attack,DragonState.Leave,()=>_isAnimationOver);
        _stateMachine.AddEdge(DragonState.Leave,DragonState.MoveRight,()=>_radius>=maxRadius&&_goRight);
        _stateMachine.AddEdge(DragonState.Leave,DragonState.MoveLeft,()=>_radius>=maxRadius&&!_goRight);
        
        _stateMachine.SetEntry(DragonState.MoveLeft);
    }

    void Update()
    {
        _timer += Time.deltaTime;
        _stateMachine.Update();
        transform.LookAt(_origin);
        transform.Rotate(Vector3.up,-90f);
        var euler = transform.rotation.eulerAngles;
        euler.z = 0f;
        transform.rotation=Quaternion.Euler(euler);
    }
}
