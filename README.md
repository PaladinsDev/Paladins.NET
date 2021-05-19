# Paladins.Net


## Launch Settings
By default `src/Properties/launchSettings.json` is not tracked through the following command:
```
git update-index --assume-unchanged src/Properties/launchSettings.json
```

If it needs tracked again for variable updates or whatever then remove all private variables and retrack the changes through the follow command:
```
git update-index --no-assume-unchanged src/Properties/launchSettings.json
```