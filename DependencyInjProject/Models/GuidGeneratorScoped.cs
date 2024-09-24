using System;

namespace DependencyInjProject.Models;

public class GuidGeneratorScoped : IGuidGeneratorScoped
{
    public Guid guid { get; set; }

    public GuidGeneratorScoped()
    {
        guid = System.Guid.NewGuid();
    }
}
public interface IGuidGeneratorScoped
{
    public Guid guid { get; set; }
}
