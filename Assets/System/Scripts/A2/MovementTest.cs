using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    [SerializeField] List<MovementTrigger> movementTriggers;
    public bool PlayerMoved => movementTriggers.Where(x=> x.HasEntered).Count() > 0;
}
