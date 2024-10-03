using UnityEngine;

namespace Client
{
    /// <summary>
    /// ���� (�ǰ� �ݶ��̴� ����)
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