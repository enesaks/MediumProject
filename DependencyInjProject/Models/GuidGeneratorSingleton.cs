using System;

namespace DependencyInjProject.Models;

public class GuidGeneratorSingleton : IGuidGeneratorSingleton
{
    public Guid guid { get; set; }
    public GuidGeneratorSingleton()
    {
        guid = System.Guid.NewGuid();
    }

}
public interface IGuidGeneratorSingleton
{
    public Guid guid { get; set; }
}
