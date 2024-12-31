using Zenject;

namespace ChristmasLearningProject.Runtime.View
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<MoveFleet>().AsSingle();
        }
    }
}