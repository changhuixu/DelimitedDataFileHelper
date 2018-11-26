# Delimited Data File Helper

Reader and Writer for Delimited Data File (csv, tab/pipe delimited files)

![AppVeyor](https://img.shields.io/appveyor/ci/changhuixu/DelimitedDataFileHelper.svg?logo=appveyor&style=flat-square)
![NuGet](https://img.shields.io/nuget/v/uiowa.DelimitedDataHelper.svg?logo=nuget&style=flat-square)

---

1. Why need to have this little library?

   There are many csv libraries out there, but I still prefer to write my own. First reason is that it is not so difficult to write a reader and writer. Second, most of my files don't need cumbersome settings for reader and writer. I just want things become easy and simple.

2. Usage

- By default, csv file reader and writer will read and write "" quoted entries.
- By default, all delimited file reader will trim starting/ending white spaces of each entry.
- By default, all delimited file writer will write a header row in the output file.

```c#
var data = new CsvFile("filename.csv").GetData<Contact>();
data.WriteToCsvFile("output.csv");
```

If you want to skip first n rows,

```c#
var data = new PipeDelimitedFile("input.csv")
        .SkipNRows(1)
        .GetData<Contact>()
        .ToList();
```

If you don't want to trim starting/ending white spaces of each entry,

```c#
var data = new TabDelimitedFile("input.txt")
        .SkipNRows(1)
        .GetData<Contact>(new DelimitedFileReaderConfig(false))
        .ToList();
```

If you don't want to write header in the output file,

```c#
var config = new CsvWriterConfig {WriteHeader = false};
data.WriteToCsvFile("output.csv", config);
```
