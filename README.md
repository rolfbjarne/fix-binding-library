Workaround for breaking change in Xamarin.iOS 11.10
---------------------------------------------------

More information about the breaking change can be found [here](https://developer.xamarin.com/releases/ios/xamarin.ios_11/xamarin.ios_11.10/#More_information_about_3832).

The fix is to rebuild any binding library with a recent-ish version of
Xamarin.iOS (any version from the last couple of years should be enough).

If the source code isn't available for the library (like for example the
[CorePlot component][1]), this tool can be used to fix it, by passing the library
as a command-line argument to the tool.

1. Build the tool:

```shell
$ make
```

2. Pass the library to the tool (the library will be saved in the same location):

```shell
$ mono bin/Debug/fix-binding-library.exe /Users/rolf/Downloads/coreplot-1.5.1.2/lib/ios-unified/CorePlotiOS.dll
Processing /Users/rolf/Downloads/coreplot-1.5.1.2/lib/ios-unified/CorePlotiOS.dll
Fixing CorePlot.CPTAnimationDelegate
Fixing CorePlot.CPTAxisDelegate
Fixing CorePlot.CPTBarPlotDataSource
Fixing CorePlot.CPTBarPlotDelegate
Fixing CorePlot.CPTLegendDelegate
Fixing CorePlot.CPTPieChartDataSource
Fixing CorePlot.CPTPieChartDelegate
Fixing CorePlot.CPTPlotDataSource
Fixing CorePlot.CPTPlotDelegate
Fixing CorePlot.CPTPlotAreaDelegate
Fixing CorePlot.CPTPlotSpaceDelegate
Fixing CorePlot.CPTRangePlotDataSource
Fixing CorePlot.CPTRangePlotDelegate
Fixing CorePlot.CPTResponder
Fixing CorePlot.CPTScatterPlotDataSource
Fixing CorePlot.CPTScatterPlotDelegate
Fixing CorePlot.CPTTradingRangePlotDataSource
Fixing CorePlot.CPTTradingRangePlotDelegate
Processed /Users/rolf/Downloads/coreplot-1.5.1.2/lib/ios-unified/CorePlotiOS.dll successfully
```

[1]: https://components.xamarin.com/gettingstarted/coreplot
