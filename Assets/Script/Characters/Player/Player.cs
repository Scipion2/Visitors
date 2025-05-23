using UnityEngine;

public class Player : Character
{

    [SerializeField] private float TankCapacityFilled=0;

    //SETTERS

    //GETTERS

    //ESSENTIALS
    

    public void OnEnable()
    {

        EventManager.instance.DarkMaterialEvent.AddListener(AddDarkMaterial);

    }

    public void OnDisable()
    {
        
        EventManager.instance.DarkMaterialEvent.RemoveListener(AddDarkMaterial);

    }

    public override void TakeDamage(DamageType TypeOfDamageTaken)
    {

        switch(TypeOfDamageTaken)
        {

            case DamageType.Base :

                if(LowerState())
                    TakeDamage(DamageType.Lethal);

                break;

            case DamageType.Lethal :

                if(LoseLive(1))
                {

                    Death();
                    GameManager.instance.Defeat();

                }
                else
                    UpdateData();

                break;

            case DamageType.Final :

                Death();
                GameManager.instance.Defeat();

                break;

            default :

                break;

        }

    }

    private bool LowerState()
    {

        //LoseLive(1);
        return true;

    }

    private void UpdateData()
    {

        this.transform.position=LevelManager.instance.GetCurrentSpawn().position;
        UIManager.instance.UpdateLives(CurrentLives);      

    }

    public void AddDarkMaterial(float AmountToAdd)
    {

        TankCapacityFilled+=AmountToAdd;
        if(TankCapacityFilled>=1)
        {

            TankCapacityFilled=1;
            GameManager.instance.WinLevel();

        }

    }

    public void End()
    {

        Destroy(this.gameObject);

    }


}
