# gtest2html

[![LICENSE](https://img.shields.io/badge/License-MIT-brightfreen.svg)](https://spdx.org/licenses/MIT)
![APP_VER](https://img.shields.io/badge/gtest2html-v1.1.0-%230067C5)
![LIB_VER](]https://img.shields.io/badge/libgtest2html-v0.1.0-%230067C5)
![DOT_NET_FRAMEWORK](https://img.shields.io/badge/Framework-4.7-a?style=flat&logo=.NET)

**gtest2html** is an application to convert .xml format data a test application using googletest framework and run it with "_--xml:_" option.

## Features

This application converts the xml files output by a test applciation using googletest into html files.

## How to use

To run the application, type the following on the command line.

``
gtest2html path/to/output path/to/input
``

The `path/to/input` should be folder contains xml files.  
To see the pages the application generated, open `index.html` under `path/to/output` directory.

### Attention

The outputs the application generate do not contain CSS file. So, the HTML pages are plain text.  
To change it, add a CSS file named `report.css` in the same directory as index.html. 

