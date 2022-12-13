using Zenject;

public class ExampleInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ExampleDependency>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<ExampleClass>().AsSingle().NonLazy();
    }
}