using UnityEngine;
using Zenject;

public class GameSetupInstaller : MonoInstaller
{
	public GameObject m_gPlayerSnake, m_gTile;
	
    public override void InstallBindings()
    {
		Container.BindInterfacesAndSelfTo<SteeringWheel>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<TilesGenerator>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<WallGenerator>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<CollectibleHandler>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<ScoreHandler>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<PlayerManagement>().FromComponentInHierarchy().AsSingle();

		Container.BindFactory<Vector3, Player, Player.PlayerFactory>().FromComponentInNewPrefab(m_gPlayerSnake);
		Container.BindFactory<int,Vector3, TileData, TileData.TileFactory>().FromComponentInNewPrefab(m_gTile).UnderTransformGroup("TileParent"); ;
	}
}