using System;

namespace DependencyInjProject.Models;

public class GuidGeneratorTransient : IGuidGeneratorTransient
{
    public Guid guid { get; set; }

    public GuidGeneratorTransient()
    {
        guid = System.Guid.NewGuid();
    }

}
public interface IGuidGeneratorTransient
{
    public Guid guid { get; set; }
}

