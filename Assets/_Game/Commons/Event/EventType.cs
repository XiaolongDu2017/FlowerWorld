﻿namespace Game
{
    public enum EventType
    {
        None = 0,

        /// <summary>
        /// 按钮点击
        /// </summary>
        CommonBtnClick = 1,

        /// <summary>
        /// 面板关闭
        /// </summary>
        CommonPopupClose = 2,


        FlowerStateChange = 3,

        ArrangeButtonClick = 4,
        
        /// <summary>
        /// 花盆道具选择
        /// </summary>
        FlowerpotStateChange = 5,
    }
}