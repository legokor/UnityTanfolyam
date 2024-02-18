using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetManager : MonoBehaviour {
    [SerializeField] List<Target> targets = new List<Target>();
    public int ShotTargets => targets.Where(x => x.Hit).Count();
}