FAST SEARCH
===========

Efficient and very fast text search implementation, using Aho-Corasick as text-search engine.

The current implementation is case sensitive.

*Note: be aware the project includes large samples, so it might take a while to download*

Aho-Corasick
------------
blka bla bla

https://github.com/mganss/AhoCorasick

Installations
-------------

In order to be able to run the code, need a previous installation of **dotNet** framework or **dotNet sdk**

Find the installation in the following link: https://dotnet.microsoft.com/download

Build the project
-------------
Once **dotNet sdk** is install, the system is ready to compile the code, using the following instructions:

```
dotnet build --configuration Release
```

For more information: https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build

How to use? Let's try the amazing fast-search! 
----------------------------------------------

In this repo, there are 4 sample files that can be use for testing:

1) big.txt (6.5MB)
2) enwik-part-am (52.4MB)
3) small_text.txt (201b)
4) text.txt (26KB)

In the following link can find very large dataset samples: http://mattmahoney.net/dc/textdata.html

So, searching is very simple (after building the project in "release" mode), see the sintax below

### Sintax
```
dotnet bin/Release/net5.0/search-text.dll TEXT_FILE_PATH MULTIPLE_TEXT_TO_SEARCH
```

### Parameters
TEXT_FILE_PATH: relative or absolute path.

MULTIPLE_TEXT_TO_SEARCH: any string or string separated by space. Double quote can be use

### Sample

```
dotnet bin/Release/net5.0/search-text.dll "./assets/big.txt" James John Robert Michael William David Richard Charles Joseph Thomas Christopher
```

Performance
-----------

Few tests were done (see computer configuration below), see table below:

Chunk Size: 1000

| File Size | Words Count | Time      |
| --------- | ----------- | --------- |
| 26 kb     |     1       | 15 ms     |
| 6.5 mb    |     1       | 114 ms    |
| 52.4 mb   |     1       | 827 ms    |
| 1 tb      |     1       | 16090 ms  |
| 26 kb     |     10      | 15 ms     |
| 6.5 mb    |     10      | 143 ms    |
| 52.4 mb   |     10      | 938 ms    |
| 1 tb      |     10      | 17985 ms  |
| 26 kb     |     50      | 16 ms     |
| 6.5 mb    |     50      | 143 ms    |
| 52.4 mb   |     50      | 1008 ms   |
| 1 tb      |     50      | 18772 ms  |
 
### Computer Configuration
* MacBoo Pro (2019)
* Memory: 32GB
* Processor: 2.3GHZ 8-Core Intel I9


TODO
----
1) Unit tests
2) Handle Errors (ex: file doesn't exist)
3) Add Case-Sensitive Option
4) Dependency Injection in order to change search implementation according to file type (and better unit tests)
5) Search Engine improvement, allowing to search full phrases (avoiding nested)
6) Process chunks in parallel (thread/multiple process)