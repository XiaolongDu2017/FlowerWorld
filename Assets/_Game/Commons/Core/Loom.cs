using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Loom : MonoBehaviour
    {
        private static Loom m_Current;

        public static Loom Current
        {
            get
            {
                Initialize();
                return m_Current;
            }
        }

        private void Awake()
        {
            m_Current = this;
            m_Initialized = true;
            DontDestroyOnLoad(this.gameObject);
        }

        private static bool m_Initialized;

        private static void Initialize()
        {
            if (!m_Initialized)
            {
                if (!Application.isPlaying)
                    return;
                m_Initialized = true;
                var g = new GameObject("Loom");
                m_Current = g.AddComponent<Loom>();
            }
        }


        public struct QueueItem
        {
            public Action<object> ParamAction;
            public Action Action;
            public object ParamObj;
        }


        private readonly List<QueueItem> m_CurrentQuene = new List<QueueItem>();

        public static void QueueOnMainThread(Action pAction)
        {
            lock (Current.m_CurrentQuene)
            {
                Current.m_CurrentQuene.Add(new QueueItem {Action = pAction, ParamObj = null});
            }
        }

        public static void QueueOnMainThread(Action<object> pAction, object pObj)
        {
            lock (Current.m_CurrentQuene)
            {
                Current.m_CurrentQuene.Add(new QueueItem {ParamAction = pAction, ParamObj = pObj});
            }
        }

        private readonly List<QueueItem> m_DoQuene = new List<QueueItem>();

        private void Update()
        {
            lock (m_CurrentQuene)
            {
                m_DoQuene.Clear();
                m_DoQuene.AddRange(m_CurrentQuene);
                m_CurrentQuene.Clear();
            }
            foreach (var item in m_DoQuene)
            {
                if (item.ParamObj == null)
                    item.Action();
                else
                    item.ParamAction(item.ParamObj);
            }
        }
    }
}