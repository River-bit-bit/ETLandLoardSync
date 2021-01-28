using System.Collections.Generic;
using System.Linq;

namespace ETModel 
{
    [ObjectSystem]
    public class GamerComponentAwakeSystem : AwakeSystem<GamerComponent>
    {
        public override void Awake(GamerComponent self)
        {
            self.Awake();
        }
    }

    public class GamerComponent : Component
    {
        public static GamerComponent Instance { get; private set; }

        //public User MyUser;

        /// <summary>
        /// UserID Gamer
        /// </summary>
        private readonly Dictionary<long, Gamer> idGamers = new Dictionary<long, Gamer>();

        public void Awake()
        {
            Instance = this;
        }

        public override void Dispose()
        {
            if (this.IsDisposed) 
            {
                return;
            }
            base.Dispose();

            foreach (Gamer gamer in this.idGamers.Values)
            {
                gamer.Dispose();
            }
        }

        public void Add(Gamer gamer)
        {
            this.idGamers.Add(gamer.UserID, gamer);
        }

    }
}