namespace ETModel 
{
    [ObjectSystem]
    public class UserAwakeSystem : AwakeSystem<User, long> 
    {
        public override void Awake(User self, long a)
        {
            self.Awake(a);
        }
    }

    public sealed class User : Entity 
    {
        /// <summary>
        /// 玩家对象
        /// </summary>
        public long UserID { get; private set; }

        public void Awake(long id) 
        {
            this.UserID = id;
        }

        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }
            base.Dispose();
            this.UserID = 0;
        }
    }
}