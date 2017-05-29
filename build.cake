var target = Argument("target", "Default");

Task("Default")
    .Does(() =>
    {
        DotNetCoreRestore("./src/**");
        DotNetCoreBuild("./src/**");
    });

RunTarget(target);