﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ETModel
{
    public class FrameTestComponet : Component
    {
        public int count = 1;
        public int waitTime = 1000;
        public bool interval = false;

        public void Update()
        {
            if (interval)
            {
                //间隔时不调用UpdateSync
                return;
            }
            this.UpdateAsync().Coroutine();
        }

        private async ETVoid UpdateAsync()
        {
            Log.Info($"===>frame{count}");

            //调用UpdateAsync时修改interval状态，计数+1
            interval = true;
            count++;

            //可每秒执行一次
            TimerComponent timerComponent = Game.Scene.GetComponent<TimerComponent>();
            await timerComponent.WaitAsync(waitTime);
            //间隔后修改interval状态
            interval = false;
        }
    }

    [ObjectSystem]
    public class FrameTestComponetUpdateSystem : UpdateSystem<FrameTestComponet>
    {
        public override void Update(FrameTestComponet self)
        {
            self.Update();
        }
    }
}