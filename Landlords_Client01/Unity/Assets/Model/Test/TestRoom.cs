using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

namespace ETModel
{
    public sealed class TestRoom : Entity
    {
        public CancellationTokenSource waitCts;
    }
}