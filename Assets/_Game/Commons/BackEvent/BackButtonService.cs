using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Game
{
    public interface IBackButtonListener
    {
        void SubscribeToBackButtonEvent();
        void UnSubscribeFromBackButtonEvent();
        bool HandleBackButtonPress();
    }

    public interface IBackButtonService
    {
        void AddListener(IBackButtonListener listener);
        void RemoveListener(IBackButtonListener listener);
        void DefaultBackButtonAction();
    }

    public class BackButtonService : ViewBase, IBackButtonService
    {
        public static BackButtonService Instace;
        
        private void Awake()
        {
            Instace = this;
        }

        List<IBackButtonListener> _listeners = new List<IBackButtonListener>();

        public void AddListener(IBackButtonListener listener)
        {
            _listeners.Add(listener);
        }

        public void RemoveListener(IBackButtonListener listener)
        {
            _listeners.Remove(listener);
        }

        void Update()
        {
#if UNITY_ANDROID || UNITY_EDITOR
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                NotifyListeners();
            }
#endif
        }

        public void DefaultBackButtonAction()
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

        void NotifyListeners()
        {
            for (int i = _listeners.Count - 1; i >= 0; i--)
            {
                if (_listeners[i] == null)
                {
                    _listeners.RemoveAt(i);
                    continue;
                }

                if (_listeners[i].HandleBackButtonPress())
                {
                    return;
                }
            }
        }
    }
}