using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float m_TurnSpeed;
    public float m_MoveSpeed;
    public float horizontal;
    public float vertical;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    public Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    public Scanner scanner;
    

    public float m_PlayerHP;
    public float m_PlayerMP;
    public float m_PlayerDamage;

    public FloatingJoystick m_ugo_Controller;


    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        if (GameManager.gameManager.curGUIState != (int)GameManager.m_GameState.GamePlaye)
            return;
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Z 키");
            GameManager.gameManager.UseItem();
        }
    }

    void FixedUpdate()
    {
        //리지드바디 얼음 풀어주기
        m_Rigidbody.freezeRotation = false;
        //죽음 감지
        if (m_PlayerHP <= 0)
        {
            //움직임을 멈추고 입력을 방지하는 한줄
            m_Rigidbody.velocity = Vector3.zero;
            PlayerDown();            
            return;
        }
        // 정지 옵션
        if (GameManager.gameManager.curGUIState != 1)
            return;

        // 점프를 그만두게 인게임 모션으로 돌아가게 만들기
        m_Animator.SetBool("GameStrat", true);

        // 게임이 끝나도 리턴
        if (GameManager.gameManager.curGUIState == 2)
            return;


        DoPlayerMove();


    }


        


        /*
           Transform firePosition = GetComponentInParent<Transform>();
        if (scanner.m_NearTarget != null)
        {
            Vector3 direction = scanner.m_NearTarget.position - rig.position;
            direction.y = 0f;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            rig.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 newPosition = rig.position + direction * m_SkillVelocity * Time.deltaTime;
            rig.MovePosition(newPosition);
        }
        else
        {
            Vector3 forwardMovement = transform.forward * m_SkillVelocity * Time.deltaTime;
            rig.MovePosition(rig.position + forwardMovement);
        }
        */


    void DoPlayerMove()
    {
        //horizontal = Input.GetAxis("Horizontal");
        //vertical = Input.GetAxis("Vertical");

        horizontal = m_ugo_Controller.Horizontal;
        vertical = m_ugo_Controller.Vertical;

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool Walk = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("Walk", Walk);

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, m_TurnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);

        // 현재 Rigidbody의 속도를 부드럽게 줄임
        //m_Rigidbody.velocity = Vector3.Lerp(m_Rigidbody.velocity, Vector3.zero, 1f - Mathf.Exp(-m_TurnSpeed * Time.fixedDeltaTime));

        // Rigidbody를 직접 조작
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_MoveSpeed * Time.fixedDeltaTime);
        m_Rigidbody.MoveRotation(m_Rotation);


        m_Rigidbody.velocity = Vector3.zero; //충돌시 회전이나 맵 끝까지가는 현상을 방지
        
    }


    void DamagedPlayer(float sourceAtk)
    {
        m_PlayerHP -= sourceAtk;
    }

    void PlayerDown()
    {

        //GameManager.gameManager.curGUIState = 2;
        m_Animator.SetBool("IsLive", false);

        
        // 3초뒤에 게임멈추는 메서드를 호출
        Invoke("PauseGame", 2.6f);        
    }
    void PauseGame()
    {
        GameManager.gameManager.SetGUIScene(GameManager.m_GameState.Fails);
        Debug.Log(GameManager.gameManager.curGUIState);
        // 게임을 일시 정지
        Time.timeScale = 0f;
        //Vector3.forward
        // Vector3.right   
    }
    
    void OnCollisionEnter(Collision collision)
    {
        m_Rigidbody.freezeRotation = true;              
    }




}

    /*
    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
   */
