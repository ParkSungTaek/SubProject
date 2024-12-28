using Unity.VisualScripting;
using UnityEngine;

namespace Client
{
    public class CharNonTarget : CharProjectal
    {
        [SerializeField]
        private Vector3 Target;         // 목표 지점

        [SerializeField]
        private float FixedMaxHeight;   // 최고점 높이
        
        private float elaspedTime = 0f; // 경과 시간
        private float estimatedTime;    // 예상 도달 시간

        private float InitialSpeed;     // 초기 속력
        private Vector3 directionXZ;    // 수평 성분
        private float LaunchAngle;      // 발사각
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
        /// 입력값(투사체 최대 높이, 중력, 타겟 위치)을 통한 궤도의 
        /// </summary>
        private void GetSpeedAndAngle()
        {
            // 타겟의 높이 조건 검사
            if (Target.y >= FixedMaxHeight)
                FixedMaxHeight = Target.y + 1f;

            // xz평면 요소와 y축 요소 구함
            Vector3 horizontalVec = new Vector3(Target.x - Origin.x, 0, Target.z - Origin.z);
            float horizontalDistance = Vector3.Magnitude(horizontalVec);
            directionXZ = horizontalVec.normalized;

            Vector3 verticalVec = (Target.y -  Origin.y) * Vector3.up;
            float verticalDistance = Vector3.Magnitude(verticalVec);

            // 포물선의 식을 통해 각도 유도
            float tangent = 
                2f * (FixedMaxHeight + Mathf.Sqrt(FixedMaxHeight *(FixedMaxHeight - verticalDistance))) / horizontalDistance;
            LaunchAngle = Mathf.Atan(tangent);

            // 각도의 cos, sin 성분 구하기
            cosAngle = Mathf.Cos(LaunchAngle);
            sinAngle = Mathf.Sin(LaunchAngle);

            // 발사 속도 구하기
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