using UnityEngine;

namespace Client
{
    /// <summary>
    /// 무적 (피격 콜라이더 제거)
    /// </summary>
    public class Avoidance : ExecutionBase
    {
        public Avoidance(BuffParameter buffParam) : base(buffParam)
        {
        }


        public override void RunExecution(bool StartExecution)
        {
            base.RunExecution(StartExecution);
            if (StartExecution)
            {
                if (_TargetChar.FightCollider != null)
                {
                    _TargetChar.FightCollider.gameObject.SetActive(false);
                }
            }
            else
            {
                if (_TargetChar.FightCollider != null)
                {
                    _TargetChar.FightCollider.gameObject.SetActive(true);
                }
            }
        }
    }
}