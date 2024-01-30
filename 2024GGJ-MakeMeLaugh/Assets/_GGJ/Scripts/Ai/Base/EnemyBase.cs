using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using V.Tool.JuicyFeeling;

namespace V
{
    public class EnemyBase : MonoBehaviour, IEnemyMoveable, ITriggerCheckable
    {
        public Rigidbody2D Rb {get; set;}
        [field : SerializeField] public Animator anim{get; set;}
        public bool IsFacingRight {get; set;} = false;

        public bool IsInLaughRange {get; set;}
        public bool IsInAttackRange {get; set;}

        #region ScriptableObject FSM
        [SerializeField] private EnemyIdleSOBase enemyIdleSOBase;
        [SerializeField] private EnemyChaseSOBase enemyChaseSOBase;
        [SerializeField] private EnemyAttackSOBase enemyAttackSOBase;

        public EnemyIdleSOBase EnemyIdleBaseInstance {get; set;}
        public EnemyChaseSOBase EnemyChaseBaseInstance {get; set;}
        public EnemyAttackSOBase EnemyAttackBaseInstance {get; set;}        
        #endregion
        
        #region FSM
        public EnemyStateMachine StateMachine{get; set;}

        public EnemyIdleState IdleState {get; set;}
        public EnemyAttackState AttackState {get; set;}
        public EnemyChaseState ChaseState {get; set;}
        #endregion

        public Transform PlayerTransform;
        [HideInInspector] public SquashAndStretch DashSquashStretch;


        #region Unity
        protected virtual void Awake() 
        {
            PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            DashSquashStretch = GetComponent<SquashAndStretch>();

            EnemyIdleBaseInstance = Instantiate(enemyIdleSOBase);
            EnemyChaseBaseInstance = Instantiate(enemyChaseSOBase);
            EnemyAttackBaseInstance = Instantiate(enemyAttackSOBase);

            StateMachine = new EnemyStateMachine();

            IdleState = new EnemyIdleState(this, StateMachine);    
            AttackState = new EnemyAttackState(this, StateMachine);   
            ChaseState = new EnemyChaseState(this, StateMachine);   
        }
        protected virtual void Start() 
        {
            Rb = GetComponent<Rigidbody2D>();    

            EnemyIdleBaseInstance.Initialize(gameObject, this);
            EnemyChaseBaseInstance.Initialize(gameObject, this);
            EnemyAttackBaseInstance.Initialize(gameObject, this);

            StateMachine.Initalize(IdleState);
        }
        
        protected virtual void Update() 
        {
            StateMachine.CurrentEnemyState.FrameUpdate();    
        }
        private void FixedUpdate() 
        {
            StateMachine.CurrentEnemyState.PhysicsUpdate();
        }
        #endregion

        #region Movement
        public void SetVelocity(Vector2 _velocity)
        {
            Rb.velocity = _velocity;
            CheckFacing(_velocity);
        }

        public void CheckFacing(Vector2 _velocity)
        {
            if(IsFacingRight && _velocity.x < 0f)
            {
                Flip();
                Debug.Log("flip");
            }
            else if(!IsFacingRight && _velocity.x > 0)
            {
                Flip();
                Debug.Log("flip back");
            }
        }

        [Button]
        private void Flip()
        {
            if(transform.rotation.y == 0)
            {
                Vector3 _rotate = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
                transform.rotation = Quaternion.Euler(_rotate);

            }
            else
            {
                Vector3 _rotate = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
                transform.rotation = Quaternion.Euler(_rotate);                
            }

            IsFacingRight = !IsFacingRight;                  
        }
        #endregion
        
        public void SetLaughStatus(bool _IsInChaseRange)
        {
            IsInLaughRange = _IsInChaseRange;
        }

        public void SetAttackStatus(bool _IsInAttackRange)
        {
            IsInAttackRange = _IsInAttackRange;
        }

        public virtual void TransferToYello()
        {

        }


        #region Anim Trigger
        private void AnimTriggerEvent(AnimTriggerTypes _triggerTypes)
        {
            StateMachine.CurrentEnemyState.AnimTriggerEvent(_triggerTypes);
        }

        public enum AnimTriggerTypes
        {
            EnemyDamaged,
            PlayFootStepSound,
        }
        #endregion
    }
}
