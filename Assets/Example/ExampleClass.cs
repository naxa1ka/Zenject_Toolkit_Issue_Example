using UnityEngine;
using Zenject;

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