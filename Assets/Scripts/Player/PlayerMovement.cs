using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [FormerlySerializedAs("movesSpped")] [Header("Movement info")] [SerializeField]
    private float movesSpeed;

    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayerMask;
    private Rigidbody rigidbody;
    private Vector2 curMoveValue;
    private PlayerController controller;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        controller = GetComponent<PlayerController>();
    }

    private void Start()
    {
        controller.OnMoveEvent += SetMoveDirection;
        controller.OnJumpEvent += Jump;
    }


    private void FixedUpdate()
    {
        //Move 로직의 경우에는 물리연산을 기반으로하는 로직이기 때문에 정확한 타이밍에 처리가 돼야 더 안정적인 결과를 얻을 수 있다.
        // Update의 경우에는 사용자의 환경에 따라 프레임차이가 심하므로 결과가 불안정할 확률이 높음.
        // 반면 FixedUpdate의 경우에는  고정된 시간 간격  (50hz(0.02초))으로 호출 되므로,
        // 사양이 매우 낮은 컴퓨터가 아니라면 안정된 물리 연산 수행이 가능.
        Move();
    }

    private void SetMoveDirection(Vector2 newDir)
    {
        curMoveValue = newDir;
    }

    private void Move()
    {
        // Vector3.foward Vector3(0,0,1) | Vector3.right Vector3(1,0,0) 를 회전 값에 따라 setting 해준 값이 transform.forward or transform.right
        Vector3 dir = transform.forward * curMoveValue.y + transform.right * curMoveValue.x;
        dir *= movesSpeed;

        // dir.y값을 재설정 해주는 이유
        // 1. 경사면 같은 경우에는 값이 달라질 수도 있음(플레이어가 회전이 돼있다면)    
        // 2. 점프 자체가 적용이 안됨.(velocity값이 바뀌면 jump에서 수행해준 값이 사라지므로 )
        dir.y = rigidbody.velocity.y;
        rigidbody.velocity = dir;
    }

    private void Jump()
    {
        if(!IsGround())
                return;
        rigidbody.AddForce(Vector2.up *jumpPower,ForceMode.Impulse);
    }

    
    
    private bool IsGround()
    {
        Ray[] rays = new Ray[]
        {
            new Ray(transform.position+ (transform.forward * 0.2f) + (transform.up * 0.01f) , Vector3.down),
            new Ray(transform.position+ (-transform.forward * 0.2f) + (transform.up * 0.01f) , Vector3.down),
            new Ray(transform.position+ (transform.right * 0.2f) + (transform.up * 0.01f) , Vector3.down),
            new Ray(transform.position+ (-transform.right * 0.2f) + (transform.up * 0.01f) , Vector3.down)
        };

        
        
        for (int i = 0; i < rays.Length; i++)
        {
            if(Physics.Raycast(rays[i],0.1f,groundLayerMask))
                  return true;
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Ray[] rays = new Ray[]
        {
            new Ray(transform.position+ (transform.forward * 0.2f) + (transform.up * 0.01f) , Vector3.down),
            new Ray(transform.position+ (-transform.forward * 0.2f) + (transform.up * 0.01f) , Vector3.down),
            new Ray(transform.position+ (transform.right * 0.2f) + (transform.up * 0.01f) , Vector3.down),
            new Ray(transform.position+ (-transform.right * 0.2f) + (transform.up * 0.01f) , Vector3.down)
        };



        Gizmos.color = Color.red;

        for (int i = 0; i < rays.Length; i++)
        {
            Gizmos.DrawRay(rays[i].origin,rays[i].direction * 0.1f);
        }
      
    }
}