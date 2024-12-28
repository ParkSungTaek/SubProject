using Unity.VisualScripting;
using UnityEngine;

namespace Client
{
    public class CharNonTarget : CharProjectal
    {
        [SerializeField]
        private Vector3 Target;         // ��ǥ ����

        [SerializeField]
        private float FixedMaxHeight;   // �ְ��� ����
        
        private float elaspedTime = 0f; // ��� �ð�
        private float estimatedTime;    // ���� ���� �ð�

        private float InitialSpeed;     // �ʱ� �ӷ�
        private Vector3 directionXZ;    // ���� ����
        private float LaunchAngle;      // �߻簢
        private float cosAngle;
        private float sinAngle;

        protected override void CharInit()
        {
            base.CharInit();
            GetSpeedAndAngle();
        }
       
        private void FixedUpdate()
        {
            if (elaspedTime > estimatedTime)
                return;
            transform.position = CalculatePosition(Origin, Target);            
        }

        /// <summary>
        /// �Է°�(����ü �ִ� ����, �߷�, Ÿ�� ��ġ)�� ���� �˵��� 
        /// </summary>
        private void GetSpeedAndAngle()
        {
            // Ÿ���� ���� ���� �˻�
            if (Target.y >= FixedMaxHeight)
                FixedMaxHeight = Target.y + 1f;

            // xz��� ��ҿ� y�� ��� ����
            Vector3 horizontalVec = new Vector3(Target.x - Origin.x, 0, Target.z - Origin.z);
            float horizontalDistance = Vector3.Magnitude(horizontalVec);
            directionXZ = horizontalVec.normalized;

            Vector3 verticalVec = (Target.y -  Origin.y) * Vector3.up;
            float verticalDistance = Vector3.Magnitude(verticalVec);

            // �������� ���� ���� ���� ����
            float tangent = 
                2f * (FixedMaxHeight + Mathf.Sqrt(FixedMaxHeight *(FixedMaxHeight - verticalDistance))) / horizontalDistance;
            LaunchAngle = Mathf.Atan(tangent);

            // ������ cos, sin ���� ���ϱ�
            cosAngle = Mathf.Cos(LaunchAngle);
            sinAngle = Mathf.Sin(LaunchAngle);

            // �߻� �ӵ� ���ϱ�
            InitialSpeed = Mathf.Sqrt(2f * gravity * FixedMaxHeight) / sinAngle;
        }

        private Vector3 CalculatePosition(Vector3 Origin, Vector3 Target)
        {            
            float nowXZ = InitialSpeed * cosAngle * elaspedTime;
            float nowY = InitialSpeed * sinAngle * elaspedTime - 0.5f * gravity * elaspedTime * elaspedTime;
            
            Vector3 updatedPosition = nowXZ * directionXZ + nowY * Vector3.up;
            elaspedTime += Time.fixedDeltaTime;
            return updatedPosition;
        }
    }
}