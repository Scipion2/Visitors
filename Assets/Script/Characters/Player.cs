using UnityEngine;

public class Player : Character
{


    //SETTERS

    //GETTERS

    //ESSENTIALS

    public override void TakeDamage(DamageType TypeOfDamageTaken)
    {

        switch(TypeOfDamageTaken)
        {

            case DamageType.Base :

                if(LowerState())
                    UpdateData();

                break;

            case DamageType.Lethal :

                if(LoseLive(1))
                    Death();
                else
                    UpdateData();

                break;

            case DamageType.Final :

                Death();

                break;

            default :

                break;

        }

    }

    private bool LowerState()
    {

        return true;

    }

    private void UpdateData()
    {

        this.transform.position=LevelManager.instance.GetCurrentSpawn().position;
        UIManager.instance.UpdateLives(CurrentLives);      

    }


}
