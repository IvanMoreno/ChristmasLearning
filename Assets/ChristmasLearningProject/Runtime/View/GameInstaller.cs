using ChristmasLearningProject.Runtime.Application;
using ChristmasLearningProject.Runtime.Domain;
using Zenject;

namespace ChristmasLearningProject.Runtime.View
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Game>().AsSingle();
            Container.Bind<Fleet>().AsSingle();
            Container.Bind<MoveFleet>().AsSingle();
            Container.Bind<TogglePause>().AsSingle();
            Container.BindInterfacesTo<UnitySea>().AsSingle();
        }
    }
}