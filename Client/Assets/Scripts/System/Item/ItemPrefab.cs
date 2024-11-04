using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Client
{
    [RequireComponent(typeof(Collider2D))]
    /// <summary>
    /// 씬 상에서 출현할 아이템 오브젝트 프리팹. 드랍 또는 버릴 시 Instantiate됨
    /// </summary>
    public class ItemPrefab : MonoBehaviour
    {
        private CharItemData _CharItemData;
        private Collider2D _itemCollider;

        private void Awake()
        {
            if(TryGetComponent(out _itemCollider))
                _itemCollider.isTrigger = true;           
        }

        public void SetItemWData(CharItemData item)
        {
            _CharItemData = item;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //collision 플레이어인지 확인
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            //collision 플레이어인지 확인
        }

    }
}