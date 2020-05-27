using UnityEngine;
using Zenject;

public class GameSetupInstaller : MonoInstaller
{
	public GameObject m_gPlayerSnake;

    public override void InstallBindings()
    {
		Container.BindInterfacesAndSelfTo<SteeringWheel>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<TilesGenerator>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<WallGenerator>().FromComponentInHierarchy().AsSingle();

		Container.BindFactory<Vector3, Player, Player.PlayerFactory>().FromComponentInNewPrefab(m_gPlayerSnake);
	}
}