using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalMagicAttack : MonoBehaviour
{
    private List<Buff> buffs;
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
    private void Start()
    {
        buffs = new List<Buff>();
    }
    public void AddBuff(Buff buff)
    {
        buffs.Add(buff);
        StartCoroutine("DeleteBuff", buff);
    }

    private IEnumerator DeleteBuff(Buff buff)
    {
        yield return new WaitForSeconds(buff.Time);
        buffs.Remove(buff);
    }

    public float CountMagicAttack()
    {
        float MagicAttack = 0;

        if(buffs.Count!=0)
        foreach(Buff buff in buffs)
        {
            MagicAttack += buff.Value;
        }
        return MagicAttack < -10 ? -10 : MagicAttack ;
    }
}
