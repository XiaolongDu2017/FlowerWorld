using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class GameView : View
{
    bool _isRegisterFired = false;

    protected string _tag = "";

    protected string Tag
    {
        get { return _tag; }
        set { _tag = value; }
    }

    protected override void Awake()
    {
        base.Awake();

        if (registeredWithContext && !_isRegisterFired)
        {
            _isRegisterFired = true;
            OnRegister();
        }
    }


    protected override void Start()
    {
        base.Start();

        if (registeredWithContext && !_isRegisterFired)
        {
            _isRegisterFired = true;
            OnRegister();
        }

    }

    protected override void OnDestroy()
    {
        if (registeredWithContext)
            OnUnRegister();

        base.OnDestroy();
    }

    virtual protected void OnRegister()
    {
        AddListeners();
        SetTag();
    }

    virtual protected void SetTag()
    {
        Tag = GetType().Name;
    }

    virtual protected void OnUnRegister()
    {
        RemoveListeners();
    }

    virtual protected void AddListeners()
    {
    }

    virtual protected void RemoveListeners()
    {
    }
}
