namespace Game
{
    public enum SceneId
    {
        Init = 0,
        Home = 1,
        ArrangeFlower = 2
    }
    
    public enum FlowerState
    {
        None = -1,
        Empty = 0,
        Seed =1, // 种子
        Seedling =2 , //幼苗
        Grown1 = 3,//小叶
        Grown2 = 4,//大叶
        Ripe = 5// 成熟
        
    }
   
    public class GameDefine
    {
    }
    
    
}