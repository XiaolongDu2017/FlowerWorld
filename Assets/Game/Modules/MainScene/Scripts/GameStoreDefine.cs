using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameDesignFlowerConfig
    {
        public int id;
        public string smallIcon;
        public string bigIcon;
        public int[] unlockID;
    }
    public enum StoreType
    {
        Flowerpot,
        Seed
    }
    public enum SeedType {
        Type1 = 1,
        Type2 = 2,
        Type3 = 3,
    }
    public class SeedData {
        public SeedType seedType;
        public string iconPath;
        public string itemPath;
        public int cost;
    }
    public class FlowerpotData {
        public int m_id;
        public string iconPath;
        public string itemPath;
        public int cost;
    }
    public class StoreItemData
    {
        public StoreType storeType;
        public int m_id;
        public string iconPath;
        public string itemPath;
        public int cost;
    }
}
