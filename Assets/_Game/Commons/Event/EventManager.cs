using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public class EventManager
    {
        private readonly Dictionary<EventType, List<EventEntity>> m_Dictionary =
            new Dictionary<EventType, List<EventEntity>>();

        private static EventManager m_Instance = null;

        public static EventManager Instance
        {
            get { return m_Instance ?? (m_Instance = new EventManager()); }
        }

        public void addEventListener(EventType pType, Action<object> pAction)
        {
            List<EventEntity> list;
            if (m_Dictionary.ContainsKey(pType))
                list = m_Dictionary[pType];
            else
            {
                list = new List<EventEntity>();
                m_Dictionary.Add(pType, list);
            }

            foreach (var entity in list)
            {
                if (entity.ObjAction == pAction)
                {
                    return;
                }
            }

            var eventEntity = new EventEntity
            {
                ObjAction = pAction,
            };
            list.Add(eventEntity);
        }

        public void addEventListener(EventType pType, Action pAction)
        {
            List<EventEntity> list;
            if (m_Dictionary.ContainsKey(pType))
                list = m_Dictionary[pType];
            else
            {
                list = new List<EventEntity>();
                m_Dictionary.Add(pType, list);
            }

            if (list.Any(pEntity => pEntity.Action == pAction))
            {
                return;
            }

            var eventEntity = new EventEntity {Action = pAction};
            list.Add(eventEntity);
        }

        public void DispatchEvent(EventType pType)
        {
            if (!m_Dictionary.ContainsKey(pType)) return;
            List<EventEntity> list = m_Dictionary[pType];
            foreach (var entity in list)
            {
                entity.Action();
            }
        }

        public void DispatchEvent(EventType pType, object pParam)
        {
            if (!m_Dictionary.ContainsKey(pType)) return;
            List<EventEntity> list = m_Dictionary[pType];
            foreach (var entity in list)
            {
                entity.ObjAction(pParam);
            }
        }

        public void removeEventListener(EventType pType, Action<object> pAction)
        {
            if (!m_Dictionary.ContainsKey(pType)) return;
            List<EventEntity> list = m_Dictionary[pType];
            foreach (var entity in list.ToArray())
            {
                if (entity.ObjAction == pAction)
                {
                    list.Remove(entity);
                }
            }
        }


        public void removeEventListener(EventType pType, Action pAction)
        {
            if (!m_Dictionary.ContainsKey(pType)) return;
            List<EventEntity> list = m_Dictionary[pType];
            foreach (var entity in list.ToArray())
            {
                if (entity.Action == pAction)
                {
                    list.Remove(entity);
                }
            }
        }
    }


    internal class EventEntity
    {
        public Action Action;
        public Action<object> ObjAction;
    }
}