using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;
public class Demo1ContextView : ContextView {
    void Awake()
    {
        this.context = new Demo1MVCSContext(this);

        // context.Start();

    }
}