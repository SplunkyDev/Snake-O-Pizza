using UnityEngine;
using Zenject;

public class GameSetupInstaller : MonoInstaller
{
	public GameObject m_gPlayerSnake, m_gTile;
	
    public override void InstallBindings()
    {
		//binding them to their interfaces and Registering all these scripts to the container
		Container.BindInterfacesAndSelfTo<SteeringWheel>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<TilesGenerator>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<WallGenerator>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<CollectibleHandler>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<ScoreHandler>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<PlayerManagement>().FromComponentInHierarchy().AsSingle();

		//binding the scripts to their intrfaces and registering these factory to container
		Container.BindFactory<Vector3, Player, Player.PlayerFactory>().FromComponentInNewPrefab(m_gPlayerSnake);
		Container.BindFactory<int,Vector3, TileData, TileData.TileFactory>().FromComponentInNewPrefab(m_gTile).UnderTransformGroup("TileParent"); ;
	}
}