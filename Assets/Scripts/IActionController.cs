using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActionController {
    float speed { get; set; }
    Action act { get;set; }
    void Move();
    void Attack();
    
}
