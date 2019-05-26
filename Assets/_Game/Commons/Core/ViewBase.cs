using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Game
{
    public class ViewBase : MonoBehaviour
    {
        protected virtual void Awake()
        {
            AddListeners();
        }

        protected virtual void Start()
        {
            
        }

        protected virtual void AddListeners()
        {
        }

        protected virtual void RemoveListeners()
        {
        }

        protected virtual void OnDestroy()
        {
            RemoveListeners();
        }
    }
}