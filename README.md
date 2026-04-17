# gtest2html

[![LICENSE](https://img.shields.io/badge/License-MIT-brightfreen.svg)](https://spdx.org/licenses/MIT)  
![DOT_NET_FRAMEWORK](https://img.shields.io/badge/Framework-4.7.1-a?style=flat&logo=.NET&color=blueviolet)
![APP_VER](https://img.shields.io/badge/gtest2html-v1.1.2-%230067C5&color=brightgreen)
![LIB_VER](https://img.shields.io/badge/libgtest2html-v0.1.2-%230067C5&color=brightgreen)  
![DOT_NET_CORE](https://img.shields.io/badge/.NET_Core-8.0-a?style=flat-square&logo=.NET&color=purple)
![DOT_NET_CORE](https://img.shields.io/badge/.NET_Core-9.0-a?style=flat-square&logo=.NET&color=purple)
![APP_VER](https://img.shields.io/badge/gtest2html-v0.3.0-%230067C5?style=flat-square&color=yellow)
![LIB_VER](https://img.shields.io/badge/libgtest2html-v0.3.0-%230067C5?style=flat-square&color=yellow)  

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

The application output includes a CSS file.
If you need to change the styles, modify `report.css` located in the root of the generated output.
