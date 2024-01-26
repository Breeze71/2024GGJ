using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V
{
    public interface ITriggerCheckable
    {
        public bool IsInChaseRange {get; set;}
        public bool IsInAttackRange {get; set;}

        public void SetChasingStatus(bool _IsInChaseRange);

        public void SetAttackStatus(bool _IsInAttackRange);

    }
}
