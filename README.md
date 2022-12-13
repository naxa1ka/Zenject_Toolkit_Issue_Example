# Zenject Toolkit Issue Example
Example to issue https://github.com/Mathijs-Bakker/Extenject/issues/67 \
**Description issue**: *Throwing a null reference exception during an "Install" method call with a UI Document on scene*
# Environment
 - Zenject version: 9.3.1
 - Unity version: 2021.3.11f1
 - Build: WebGL
# WebGL Console
![image](https://user-images.githubusercontent.com/68388374/207296931-c93cc497-8e83-49e9-9cf6-934897601d28.png)

# Scene Environment
- Gameobject with **Example Installer**
- Scene context with reference to **Example Installer** as **Mono Installer**
- Gameobject with UI Document with reference to **Example UI Document**
- Default scene components: **Camera, Directional Light** without changes

### Example UI Document 
```
<ui:UXML xmlns:ui="UnityEngine.UIElements" xmlns:uie="UnityEditor.UIElements" xsi="http://www.w3.org/2001/XMLSchema-instance" engine="UnityEngine.UIElements" editor="UnityEditor.UIElements" noNamespaceSchemaLocation="../../UIElementsSchema/UIElements.xsd" editor-extension-mode="False">
    <ui:Label text="Extenject :(" display-tooltip-when-elided="true" name="Label" style="-unity-text-align: upper-center; -unity-font-style: bold; font-size: 100px;" />
</ui:UXML>
```

# Code 
```
public class ExampleClass : IInitializable
{
    private readonly ExampleDependency _exampleDependency;

    public ExampleClass(ExampleDependency exampleDependency)
    {
        _exampleDependency = exampleDependency;
    }

    public void Initialize()
    {
        Debug.Log(_exampleDependency.Message);
    }
}
```
```
public class ExampleDependency
{
    public readonly string Message = "Hello world";
}
```
```
public class ExampleInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ExampleDependency>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<ExampleClass>().AsSingle().NonLazy();
    }
}
```
