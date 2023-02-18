using UnityEngine;

namespace DIA.nsHeroController
{
    public class HeroInput : MonoBehaviour
    {
        #region Variables       

        [Header("Controller Input")]
        public string horizontalInput = "Horizontal";
        public string verticallInput = "Vertical";
        public KeyCode jumpInput = KeyCode.Space;
        public KeyCode attackInput = KeyCode.E; 
        public KeyCode strafeInput = KeyCode.Tab;
        public KeyCode sprintInput = KeyCode.LeftShift;

        [Header("Camera Input")]
        public string rotateCameraXInput = "Mouse X";
        public string rotateCameraYInput = "Mouse Y";

        [HideInInspector] public HeroController cc;


        #endregion

        protected virtual void Start()
        {
            InitilizeController();
        }

        protected virtual void FixedUpdate()
        {
            cc.UpdateMotor();               
            cc.ControlLocomotionType();    
            cc.ControlRotationType();       
        }

        protected virtual void Update()
        {
            InputHandle();                 
            cc.UpdateAnimator();            
        }

        public virtual void OnAnimatorMove()
        {
            cc.ControlAnimatorRootMotion(); 
        }

        #region Basic Locomotion Inputs

        protected virtual void InitilizeController()
        {
            cc = GetComponent<HeroController>();

            if (cc != null)
                cc.Init();
        }

       

        protected virtual void InputHandle()
        {
            MoveInput();
            SprintInput();
            StrafeInput();
            JumpInput();
            AttackInput();
        }

        public virtual void MoveInput()
        {
            cc.input.x = Input.GetAxis(horizontalInput);
            cc.input.z = Input.GetAxis(verticallInput);
        }


        protected virtual void StrafeInput()
        {
            if (Input.GetKeyDown(strafeInput))
                cc.Strafe();
        }

        protected virtual void SprintInput()
        {
            if (Input.GetKeyDown(sprintInput))
                cc.Sprint(true);
            else if (Input.GetKeyUp(sprintInput))
                cc.Sprint(false);
        }


        protected virtual bool JumpConditions()
        {
            return cc.isGrounded && cc.GroundAngle() < cc.slopeLimit && !cc.isJumping && !cc.stopMove;
        }


        protected virtual void JumpInput()
        {
            if (Input.GetKeyDown(jumpInput) && JumpConditions())
                cc.Jump();
        }

        protected virtual void AttackInput()  
        {
            if (Input.GetKeyDown(attackInput) )
                cc.Attack();
        }

        #endregion       
    }
}