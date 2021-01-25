using System.Collections.Generic;
using System.Linq;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace ETModel 
{
    public class GamerSystem : AwakeSystem<Gamer, long>
    {
        public override void Awake(Gamer self, long a)
        {
            self.Awake(a);
        }
    }

    public sealed class Gamer : Entity
    {
        /// <summary>
        /// 每个玩家绑定一个实体 机器人的UserID为0
        /// </summary>
        public long UserID { get; private set; }

        public void Awake(long userid) 
        {
            this.UserID = userid;
        }

        public Vector3 Position 
        {
            get
            {
                return GameObject.transform.position;
            }
        }

        public Quaternion Rotation
        {
            get
            {
                return GameObject.transform.rotation;
            }
            set
            {
                GameObject.transform.rotation = value;
            }
        }

        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }
            base.Dispose();
        }
    }
}