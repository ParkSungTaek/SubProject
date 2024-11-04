using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Client
{
    [RequireComponent(typeof(Collider2D))]
    /// <summary>
    /// �� �󿡼� ������ ������ ������Ʈ ������. ��� �Ǵ� ���� �� Instantiate��
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
            //collision �÷��̾����� Ȯ��
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            //collision �÷��̾����� Ȯ��
        }

    }
}