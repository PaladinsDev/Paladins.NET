# Paladins.Net


## Test Config
By default `Paladins.Net.Tests/config/auth.json` is not tracked through the following command:
```
git update-index --assume-unchanged Paladins.Net.Tests/config/auth.json
```

If it needs tracked again for variable updates or whatever then remove all private variables and retrack the changes through the follow command:
```
git update-index --no-assume-unchanged Paladins.Net.Tests/config/auth.json
```

## Tools
C# .Net Core 3.1
Visual Studio 2019
SonarLint - https://www.sonarlint.org/visualstudio
coverlet.collector
StyleCop.Analyzers