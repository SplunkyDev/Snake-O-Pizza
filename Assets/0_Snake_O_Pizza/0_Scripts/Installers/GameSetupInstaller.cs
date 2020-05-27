using UnityEngine;
using Zenject;

public class GameSetupInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
		Container.BindInterfacesAndSelfTo<SteeringWheel>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<TilesGenerator>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<WallGenerator>().FromComponentInHierarchy().AsSingle();
    }
}