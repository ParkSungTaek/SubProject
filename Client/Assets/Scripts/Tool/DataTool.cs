using UnityEngine;
using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
namespace Client
{
    public class DataTool
    {
        [MenuItem("Data/데이터검증")]
        public static void DataVerification()
        {
            DataManager.Instance.DataLoad();
        }
    }
}
#endif
