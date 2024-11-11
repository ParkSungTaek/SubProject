using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Client.AnimationDefine;
using static Client.SystemEnum;
using static Client.InputManager;
using Client;
using UnityEngine.AI;

namespace Client
{
    /// <summary>
    /// 캐릭터 베이스 class
    /// </summary>
    public abstract class CharBase : MonoBehaviour
    {

        [SerializeField] private long _index;  // CharData 테이블의 인덱스 
        [SerializeField] private Collider2D _FightCollider; // 전투 콜라이더
        [SerializeField] private Collider2D _MoveCollider;  // 이동 콜라이더
        [SerializeField] private GameObject _SkillRoot;
        [SerializeField] protected NavMeshAgent _NavMeshAgent;


        private ExecutionInfo _executionInfo = null;  // 기능 정보
        private CharFSMInfo _charFSM; // 캐릭터 현재 유한상태 머신
        private CharSKillInfo _charSKillInfo; // 캐릭터 스킬
        private CharAnimInfo _charAnimInfo; // 캐릭터 스킬
        private CharItemInfo _charItemInfo; // 캐릭터 보유/장비 아이템

        private CharStat _charStat = null;  // Stat 정보
        private CharData _charData = null;  // 캐릭터 데이터
        private SPUM_Prefabs _sPUM_Prefabs = null; // SPUM 프리팹

        private GameObject _LWeapon = null;  // 왼손 무기
        private GameObject _RWeapon = null;  // 오른손 무기
        private Transform _CharTransform = null; // 캐릭터 트렌스폼
        private Transform _CharUnitRoot = null; // 캐릭터 유닛 루트 트렌스폼

        private PlayerState _currentState;  // 현재 상태
        private bool _isAction = false;  // 행동중인가? 판별
        private Dictionary<PlayerState, int> _indexPair = new(); // 
        
        protected long _id;

        private Vector3 _rightRotation = new Vector3(0, 180,0);
        private Vector2 _lefRotationtion = Vector3.zero;

        private Vector3 _rightPos = new Vector3(1, 0, 0);
        private Vector2 _leftPos = new Vector3(-1, 0, 0);

        public Vector3 LookAtPos { get; private set; } = Vector3.right;

        protected virtual SystemEnum.eCharType CharType => SystemEnum.eCharType.None;

        public Dictionary<eExecutionGroupType, List<ExecutionBase>> ExecutionBaseDic => _executionInfo.ExecutionBaseDic;
        public Collider2D FightCollider => _FightCollider;
        public Collider2D MoveCollider  => _MoveCollider;
        public ExecutionInfo ExecutionInfo => _executionInfo;  // 기능 정보
        public CharFSMInfo CharFSM => _charFSM; // 캐릭터 현재 유한상태 머신
        public CharSKillInfo CharSKillInfo => _charSKillInfo; // 캐릭터 스킬
        public CharAnimInfo CharAnimInfo => _charAnimInfo; // 캐릭터 스킬
        public Transform CharTransform => _CharTransform;
        private Transform CharUnitRoot => _CharUnitRoot; // 캐릭터 유닛 루트 트렌스폼
        public CharItemInfo CharItemInfo => _charItemInfo;
        protected CharBase() { }

        private void Awake()
        {
            _CharTransform = transform;
            _CharUnitRoot = Util.FindChild<Transform>(gameObject,"UnitRoot");
            _id = CharManager.Instance.GetNextID();
            _executionInfo = new ExecutionInfo();
            _executionInfo.Init();
            _charFSM = new CharFSMInfo(this);
            _charData = DataManager.Instance.GetData<CharData>(_index);
            _NavMeshAgent = GetComponent<NavMeshAgent>();

            if (_charData != null)
            {
                CharStatData charStat = DataManager.Instance.GetData<CharStatData>(_charData.charStatId);
                if (charStat == null)
                {
                    Debug.LogError($"캐릭터 ID : {_index} 데이터 Get 성공 charStat {_charData.charStatId} 데이터 Get 실패");
                }
                _charStat = new CharStat(charStat);
            }
            else
            {
                Debug.LogError($"캐릭터 ID : {_index} Data 데이터 Get 실패");
            }
        }
        private void Start()
        {
            SPUM_Prefabs sPUM_Prefabs = Util.GetOrAddComponent<SPUM_Prefabs>(gameObject);
            if (sPUM_Prefabs != null)
            {
                _sPUM_Prefabs = sPUM_Prefabs;
            }
            if (!_sPUM_Prefabs.allListsHaveItemsExist())
            {
                _sPUM_Prefabs.PopulateAnimationLists();
            }
            _sPUM_Prefabs.OverrideControllerInit();
            foreach (PlayerState state in Enum.GetValues(typeof(PlayerState)))
            {
                _indexPair[state] = 0;
            }
            // 애니메이션
            _charAnimInfo = new CharAnimInfo(_sPUM_Prefabs._anim);
            CharInit();
        }

        void Update()
        {
            foreach (var executionBaseList in ExecutionBaseDic)
            {
                foreach (var execution in executionBaseList.Value)
                {
                    execution.CheckTimeOver();
                    execution.Update(Time.deltaTime);
                }
            }
            
        }

        // Char의 Start시점에 불림
        protected virtual void CharInit()
        {
            CharManager.Instance.SetChar<CharBase>(this);
            
            // 스킬
            _charSKillInfo = new CharSKillInfo(this);
            if (_charSKillInfo != null)
            {
                _charSKillInfo.Init(_charData.charSkillList);
            }


        }

        public virtual void CharDistroy()
        {
            Type myType = this.GetType();
            CharManager.Instance.Clear(myType, _id);
            Destroy(gameObject);
        }

        public long GetID() => _id;

        public SystemEnum.eCharType GetCharType()
        {
            return CharType;
        }

        public void CharMove(Vector2 vector)
        {
            if (vector == Vector2.zero)
                return;
            if (_charStat == null)
            {
                Debug.LogWarning($"{transform.name} 의 Stat가 없음");
                return;
            }
            if (vector.x > 0)
            {
                transform.eulerAngles = _rightRotation;
                LookAtPos = _rightPos;
            }
            else 
            {
                transform.eulerAngles = _lefRotationtion;
                LookAtPos = _leftPos;

            }
            Vector3 deltaMove = LookAtPos * _charStat.GetStat(eState.NSpeed);
            deltaMove = deltaMove * Time.deltaTime;

            transform.position += deltaMove;
        }

        public void FSMCharMove(Vector2 vector)
        {
            FSMParameter fSMParameter = new FSMParameter();
            if (vector == Vector2.zero)
            {
                fSMParameter.charAction = CharAction.Idle;
                fSMParameter.action = null;
                fSMParameter.isPlayAnim = true;
                fSMParameter.AnimName = AnimDefine.IDLE.AnimationEnumToString();
                _charFSM.CharAction(fSMParameter);
                return;
            }

            fSMParameter.charAction = CharAction.Move;
            fSMParameter.action = () => CharMove(vector);
            fSMParameter.isPlayAnim = true;
            fSMParameter.AnimName = AnimDefine.MOVE.AnimationEnumToString();
            _charFSM.CharAction(fSMParameter);
        }
        public void FSMCharSkill(long skillID)
        {
            FSMParameter fSMParameter = new FSMParameter();
            fSMParameter.charAction = CharAction.Attack;
            _charFSM.CharAction(fSMParameter);
        }

        public void SetStateAnimationIndex(PlayerState state, int index = 0)
        {
            _indexPair[state] = index;
        }
        public void PlayStateAnimation(PlayerState state)
        {
            _sPUM_Prefabs.PlayAnimation(state, _indexPair[state]);
        }
    }
}