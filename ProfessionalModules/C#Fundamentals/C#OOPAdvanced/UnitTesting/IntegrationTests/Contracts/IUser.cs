using System;
using System.Collections.Generic;
using System.Text;

public interface IUser
{
    string Name { get; }

    IReadOnlyCollection<ICategory> Categories { get; }

    void AddCategory(ICategory category);

    void RemoveCategory(ICategory category);
}
