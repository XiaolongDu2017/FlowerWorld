using strange.extensions.context.impl;
public class GameContextView : ContextView 
{
    void Awake()
    {
        this.context = new GameMVCSContext(this);
    }
}
