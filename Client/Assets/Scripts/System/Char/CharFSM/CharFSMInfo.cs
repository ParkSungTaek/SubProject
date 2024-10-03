using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Client
{
    /// <summary>
    /// 캐릭터별 상태 관리 툴
    /// </summary>
    public class CharFSMInfo
    {
        private Dictionary<PlayerState, CharState> _fsmDictionary = new Dictionary<PlayerState, CharState>();
        private CharBase _charBase;
        private CharState _charNowState;
        public CharState CharNowState => _charNowState;
        public PlayerState PlayerState => _charNowState.NowPlayerState();
        public Dictionary<PlayerState, CharState> FSMDictionary => _fsmDictionary;

        public CharFSMInfo(CharBase charBase)
        {
            _charBase = charBase;

            for (PlayerState i = 0; i < PlayerState.OTHER; i++)
            {
                CreateFSMParameter parameter = new CreateFSMParameter();
                parameter.PlayerState = i;
                parameter.CharBase = charBase;
                parameter.CharFSMInfo = this;
                _fsmDictionary[i] = FSMFactory.CreateFSM(parameter);
            }
            _charNowState = _fsmDictionary[PlayerState.IDLE];
        }

        public void CharAction(FSMParameter parameter)
        {
            if (_charNowState == null)
                return;

            PlayerState playerState = _charNowState.NowPlayerState();
            _charNowState = _charNowState.CharAction(parameter);

            // 이미 플레이중이면 무시
            _charNowState.AnimPlay(playerState != _charNowState.NowPlayerState());
        }
    }
}