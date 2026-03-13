using System.Collections;
using System.Collections.Generic;

public interface IWeapon 
{
    Weapon Weapon { get; }
    
    void Attack();

    //пока оставлю но не использую его 
}
