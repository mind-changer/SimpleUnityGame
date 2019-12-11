using UnityEngine;


public class CharacterMotor : MonoBehaviour
{
    /*// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */


    [SerializeField]
    private float m_Speed = 0.2f;

    [SerializeField]
    private float m_RunMultiplier = 1.0f;

    [SerializeField]
    private float m_Gravity = 10.0f;

    [SerializeField]
    private float m_JumpForce = 5.0f;

    [SerializeField]
    private AudioClip m_FootstepSound;

    [SerializeField]
    private AudioClip m_JumpSound;

    [SerializeField]
    private AudioClip m_LandSound;

    [SerializeField]
    private AudioClip m_RunSound;

     


    ////////////////////////////////////////////////////

    private CollisionFlags m_MoveFlag;
    private Vector3 m_MoveDir;    
    private bool m_PreviouslyGrounded;
    private bool m_Jumping;
    
    

  
    ///////////////////////////////////////////////////

    //Creater Controller Object
    private CharacterController m_Controller;

    private InputManager m_Input;

    private AudioSource m_AudioSource;

   



    ////////////////////////////////////////////////////

    private void Awake()
    {
        m_Input = GetComponent<InputManager>();

        //Get CharacterController object from Unity
        m_Controller = GetComponent<CharacterController>();

        m_AudioSource = GetComponent<AudioSource>();

       

       

    }
       
    //////////////////////////////////////////////////
   
    private void Update()
    {
        
        if (!m_PreviouslyGrounded && m_Controller.isGrounded)
        {
            PlayLandSound();
            m_MoveDir.y = 0f;
            m_Jumping = false;
        }

        if (!m_Controller.isGrounded && !m_Jumping && m_PreviouslyGrounded)
        {
            m_MoveDir.y = 0f;
        }


        m_PreviouslyGrounded = m_Controller.isGrounded;
    }

    private void FixedUpdate()
    {
        //Debug.Log(m_Controller.velocity.magnitude);
        

        //Check if on terrain
        if (m_MoveFlag == CollisionFlags.Below)
        {
           
            var rightVector = (m_Input.Horizontal * transform.right);
            var forwardVector = (m_Input.Vertical * transform.forward);

            //Create Vector3 of Player Movement on Terrain
            m_MoveDir = rightVector + forwardVector;
            m_MoveDir *= GetSpeed();
            
            if(!m_Input.IsRunning && m_Controller.isGrounded == true && m_Controller.velocity.sqrMagnitude > 0 && m_AudioSource.isPlaying == false && m_PreviouslyGrounded)
            {
                PlayFootstepSound();
            }
            
            

            

            if (m_Input.IsJumping)
            {
                PlayJumpSound();
                m_MoveDir.y = m_JumpForce;
                m_Jumping = true;
            }

            

            if (Input.GetKey(KeyCode.LeftShift) && m_AudioSource.isPlaying == false)
            {
                PlayRunSound(); 
            }



        }


        
       
        //Gravity when controller not on terrain
        m_MoveDir.y -= m_Gravity * Time.fixedDeltaTime;

        //Render Movement of Controller
        m_MoveFlag = m_Controller.Move(m_MoveDir * Time.fixedDeltaTime);

        
    }
    ///////////////////////////////////////////////////////////////////////
    private float GetSpeed()
    {
        //Run on press and hold Left Shift key
        
        var speed = m_Speed;
        speed *= m_Input.IsRunning ? m_RunMultiplier : 1.0f;

        return speed;
    }

    private void PlayJumpSound()
    {
        m_AudioSource.clip = m_JumpSound;
        m_AudioSource.Play();
    }

    private void PlayLandSound()
    {
        m_AudioSource.clip = m_LandSound;
        m_AudioSource.Play();
    }

    private void PlayFootstepSound()
    {
        m_AudioSource.clip = m_FootstepSound;
        m_AudioSource.volume = Random.Range(0.8f, 1f);
        m_AudioSource.pitch = Random.Range(0.8f, 1.1f);  
        m_AudioSource.Play();
    }
    
    private void PlayRunSound()
    {
        m_AudioSource.clip = m_RunSound;
          
        m_AudioSource.PlayOneShot(m_RunSound, 1.0f);
        
    }
}
