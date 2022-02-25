# Lighting Internals Package
Provides APIs to access internal APIs related to lighting.

# `LightingData`
Provides access to the information contained in the `LightingDataAsset` class. To use it, create a new instance and call `Initialize`:
```cs
var data = ScriptableObject.CreateInstance<LightingData>();
data.Initialize(Lightmapping.lightingDataAsset);
```
In order to save your changes back to the `LightingDataAsset`, use the `Save` method:
```cs
data.Save(Lightmapping.lightingDataAsset);
```
